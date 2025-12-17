using System.ComponentModel.DataAnnotations;
using System.Net;
using FluentValidation;


namespace TaskManager.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // continúa al siguiente middleware
            }
            catch (FluentValidation.ValidationException ex) 
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    status = 400,
                    errors = ex.Errors.Select(e => new 
                    {
                        field = e.PropertyName,
                        message = e.ErrorMessage
                    })
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    status = 500,
                    message = "Error interno del servidor"
                });
            }
        }
    }
}
