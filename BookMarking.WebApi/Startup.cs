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
            Log4NetConfig.Init(Configuration);//加载log4net
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options=> {
                options.Filters.Add<ApiResultFilterAttribute>();
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseMiddleware<GlobalExceptionMiddleWare>();//捕捉全局异常的自定义中间件

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CustomCorsPolicy");//一定要放在UseRouting和UseEndpoints之间

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
