using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StatelessAPIs.HandleException;
using Newtonsoft.Json;
using AutoWrapper.Wrappers;

namespace StatelessAPIs.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            if (ex is NotFoundExeception)
            {
                code = HttpStatusCode.NotFound;
            }
            else if (ex is BadRequestException || ex is IllegalArgumentException)
            {
                code = HttpStatusCode.BadRequest;
            }

            string responseBody = JsonConvert.SerializeObject(new ApiResponse((int)code, ex.Message));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(responseBody);
        }
    }
}