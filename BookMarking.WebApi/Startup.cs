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
            Log4NetConfig.Init(Configuration);//加载log4net
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options=> {
                options.Filters.Add<ApiResultFilterAttribute>();
            }).AddJsonOptions(options => { //解决.net core 后台返回结果到前台变小写的问题
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            }); 

            //参数验证
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var validateError = context.ModelState.GetValidationSummary();
                    
                    return new BadRequestObjectResult(new ValidationResultModel(400, "参数验证不通过", validateError));// new JsonResult(Result.FromError($"参数验证不通过：{error.ToString()}", ResultCode.InvalidParams));
                };

            });

            //允许一个或多个来源可以跨域
            services.AddCors(options =>
            {
                options.AddPolicy("CustomCorsPolicy", policy =>
                {
                    // 设定允许跨域的来源，有多个可以用','隔开
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "VisionIGIVU",
                    Version = "v1.0",
                    Description = "BookMaking 收藏网址，提升效率",
                });
                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
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
            

            app.UseMiddleware<GlobalExceptionMiddleWare>();//捕捉全局异常的自定义中间件

            app.UseSwagger();//启用中间件服务生成Swagger作为JSON终结点

            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookMaking");
                //c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CustomCorsPolicy");//一定要放在UseRouting和UseEndpoints之间

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //使用AutoFac做DI容器
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<BMAutoFacModule>();
        }

    }
}
