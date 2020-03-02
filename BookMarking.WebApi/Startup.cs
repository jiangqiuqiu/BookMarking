using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMarking.Common.ApiModels;
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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseMiddleware<GlobalExceptionMiddleWare>();//��׽ȫ���쳣���Զ����м��

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CustomCorsPolicy");//һ��Ҫ����UseRouting��UseEndpoints֮��

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
