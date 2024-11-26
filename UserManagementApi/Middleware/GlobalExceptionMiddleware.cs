using System.Net;
using Newtonsoft.Json;
using UserManagementApi.Errors;
using UserManagementApi.Exceptions;
using UserManagementApi.Models.Errors;

namespace UserManagementApi.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;

                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        result = JsonConvert.SerializeObject(new CodeErrorGlobalResponse(statusCode, notFoundException.Message));
                        break;

                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        result = JsonConvert.SerializeObject(new CodeErrorGlobalResponse(statusCode, badRequestException.Message));
                        break;
                    case FluentValidation.ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var errors = validationException.Errors.Select(e => new CodeErrorValidation(
                            type: e.ErrorCode,
                            message: e.ErrorMessage,
                            path: e.PropertyName,
                            location: "body"
                        )).ToArray();
                        result = JsonConvert.SerializeObject(new CodeErrorValidationResponse(statusCode, errors));
                        break;
                }

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(result);
            }
        }
    }
}