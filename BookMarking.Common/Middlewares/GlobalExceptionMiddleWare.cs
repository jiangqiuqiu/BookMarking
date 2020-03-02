using BookMarking.Common.ApiModels;
using BookMarking.Common.Log;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookMarking.Common.Middlewares
{
    public class GlobalExceptionMiddleWare
    {
        public readonly RequestDelegate Next;

        public GlobalExceptionMiddleWare(RequestDelegate next)
        {
            Next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;
            await WriteExceptionAsync(context, exception).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception exception)
        {
            //记录日志
            Log4NetUtil.LogError(exception.GetBaseException().ToString(),exception);

            //返回友好的提示
            var response = context.Response;

            //状态码
            if (exception is Exception)
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            
            response.ContentType = "application/json";
            await response.WriteAsync(JsonConvert.SerializeObject(new CustomExceptionResultModel(response.StatusCode,exception.GetBaseException()))).ConfigureAwait(false);
        }
    }
}
