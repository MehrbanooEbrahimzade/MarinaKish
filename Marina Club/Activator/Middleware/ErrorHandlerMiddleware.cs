using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Net;
using static Marina_Club.Controllers.ApiController;
using Infrastructure.Repository;
using Application.Exceptions;

namespace Marina_Club.Activator.MiddleWare
{
    public class ErrorHandlerMiddleWare
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            //catch(Exception error)
            //{
            //    await ConfigureResponse(context, HttpStatusCode.InternalServerError, error.Message);
            //}
            catch(NotFoundExeption error)
            {
                await ConfigureResponse(context, HttpStatusCode.NotFound, error.Message);
            }
        }
        private static async Task ConfigureResponse(HttpContext context , HttpStatusCode statusCode , string message)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(new ResponseMessage(message,statusCode).ToString());
        }
    }
}
