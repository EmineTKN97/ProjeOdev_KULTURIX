using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Core.Exception
{
    public class ExceptionMiddleware
    {
        RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (System.Exception e)
            {
                await HandleExcepitonAsync(httpContext,e);
            }
        
        }

        private  Task HandleExcepitonAsync(HttpContext httpContext, System.Exception e)
        {
           httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "InternalServerError";
            if (e.GetType() == typeof(ValidationException))
            {
                message = "Bad Request";
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                IEnumerable<ValidationFailure> validationErrors = ((ValidationException)e).Errors;
                return httpContext.Response.WriteAsync(new ValidationErrorDetails()
                {
                    StatusCode=400,
                    Message= message,
                    ValidationErrors = validationErrors
                }.ToString());
            }
            if (e.GetType() == typeof(UnauthorizedAccessException))
            {
                message = "Yetkiniz Yok";
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return httpContext.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = message,

                }.ToString());
            }
            return httpContext.Response.WriteAsync(new ErrorDetails()
            { 
            StatusCode = httpContext.Response.StatusCode,
                    Message = message,

            }.ToString());
        }
    }
}
