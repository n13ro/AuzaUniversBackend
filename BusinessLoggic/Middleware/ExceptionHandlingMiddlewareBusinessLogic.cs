using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Middleware
{
    public class ExceptionHandlingMiddlewareBusinessLogic
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddlewareBusinessLogic> _logger;

        public ExceptionHandlingMiddlewareBusinessLogic(RequestDelegate next, ILogger<ExceptionHandlingMiddlewareBusinessLogic> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                await _next(ctx);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error, this description {Message}", ex.Message);
                ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await ctx.Response.WriteAsync(ex.Message);
            }
        }
    }
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddlewareBusinessLogic>();
        }
    }
}
