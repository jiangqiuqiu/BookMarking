using Autofac;
using BookMarking.Common.ApiModels;
using BookMarking.Common.AutoFac;
using BookMarking.Common.Extensions;
using BookMarking.Common.Filters;
using BookMarking.Common.Log;
using BookMarking.Common.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;

namespace BookMarking.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log4NetConfig.Init(Configuration);//����log4net
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options=> {
                options.Filters.Add<ApiResultFilterAttribute>();
            }).AddJsonOptions(options => { //���.net core ��̨���ؽ����ǰ̨��Сд������
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            }); 

            //������֤
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var validateError = context.ModelState.GetValidationSummary();
                    
                    return new BadRequestObjectResult(new ValidationResultModel(400, "������֤��ͨ��", validateError));// new JsonResult(Result.FromError($"������֤��ͨ����{error.ToString()}", ResultCode.InvalidParams));
                };

            });

            //����һ��������Դ���Կ���
            services.AddCors(options =>
            {
                options.AddPolicy("CustomCorsPolicy", policy =>
                {
                    // �趨����������Դ���ж��������','����
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            //ע��Swagger������������һ���Ͷ��Swagger �ĵ�
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "VisionIGIVU",
                    Version = "v1.0",
                    Description = "BookMaking �ղ���ַ������Ч��",
                });
                // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
                var xmlPath = Path.Combine(basePath, "BMSwagger.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseMiddleware<GlobalExceptionMiddleWare>();//��׽ȫ���쳣���Զ����м��

            app.UseSwagger();//�����м����������Swagger��ΪJSON�ս��

            //�����м�������swagger-ui��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookMaking");
                //c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CustomCorsPolicy");//һ��Ҫ����UseRouting��UseEndpoints֮��

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //ʹ��AutoFac��DI����
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<BMAutoFacModule>();
        }

    }
}
