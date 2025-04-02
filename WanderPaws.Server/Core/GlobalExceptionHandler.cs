using WanderPaws.Application.Interfaces;
using FluentValidation;
using Newtonsoft.Json;

namespace WanderPaws.Server.Core
{
    public class GlobalExceptionHandler(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogError(e, e.Message);

                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {   //// MODIFITCATION FOR THE FUTURE: UNHANDLED EXCEPTION WILL BE LOGGED AND NOT SHOWN TO A USER
            //LogErrorToDatabase(exception);

            var (StatusCode, Message) = GetExceptionDetails(exception);
            
            var response = new
            {
                message = Message
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = StatusCode;

            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        public static (int StatusCode, string Message) GetExceptionDetails(Exception ex)
        {
            if (ex is ICustomException customException)
            {
                return (customException.StatusCode, customException.Message);
            }

            if (ex is ValidationException validationEx)
            {
                var errors = validationEx.Errors.Select(e => e.ErrorMessage);

                string message = errors != null ? string.Join(Environment.NewLine, errors) : "Validation error occurred.";

                return (StatusCodes.Status422UnprocessableEntity, message);
            }

            return (StatusCodes.Status500InternalServerError, "An unexpected error has occurred.");
        }
    }
}
