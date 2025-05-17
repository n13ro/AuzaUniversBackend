using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace WebApi.Middleware
{
    public class ExceptionHandlingMiddlewareController
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddlewareController> _logger;

        public ExceptionHandlingMiddlewareController(RequestDelegate next, ILogger<ExceptionHandlingMiddlewareController> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext ctx)
        {
            try
            {
                await _next(ctx);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred: {Message}", ex.Message);
                ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await ctx.Response.WriteAsync(ex.Message);
            }
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingController(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddlewareController>();
        }
    }
}
