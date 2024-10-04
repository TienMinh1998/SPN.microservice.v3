using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;

namespace Vocap.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                string errorMessage = $"Error occurred!";
                if (ex is BusinessLogicException)
                {
                    errorMessage = ex.Message;
                }
                await HandleExceptionAsync(
                    httpContext,
                    HttpStatusCode.InternalServerError,
                    errorMessage
                );
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, HttpStatusCode internalServerError, string message)
        {
            httpContext.Response.ContentType = "application/json";
            var response = httpContext.Response;

            ExceptionJsonResponse jsonResponseException = new ExceptionJsonResponse
            {
                Data = null,
                IsSuccessful = false,
                Message = message,
            };

            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(jsonResponseException, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }

        // response 
        private class ExceptionJsonResponse
        {
            public object Data { get; set; }
            public bool IsSuccessful { get; set; }
            public string Message { get; set; }
        }
    }
}
