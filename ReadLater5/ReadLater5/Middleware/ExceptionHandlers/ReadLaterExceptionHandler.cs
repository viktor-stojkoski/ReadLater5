namespace ReadLater5.Middleware.ExceptionHandlers
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    using Newtonsoft.Json;

    using Shared.Exceptions;

    public class ReadLaterExceptionHandler
    {
        private readonly RequestDelegate _request;

        public ReadLaterExceptionHandler(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            string result =
                JsonConvert.SerializeObject(
                    ex is null
                        ? "Exception is null"
                        : ex.Message
                        ?? "Message is null");

            int statusCode = ex switch
            {
                ReadLaterNotFoundException => (int)HttpStatusCode.NotFound,
                ReadLaterAlreadyExistsException => (int)HttpStatusCode.Conflict,
                ReadLaterValidationException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
