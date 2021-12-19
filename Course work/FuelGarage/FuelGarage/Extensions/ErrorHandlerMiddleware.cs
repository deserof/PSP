using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FuelGarage.Extensions
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(
            ILogger<ErrorHandlerMiddleware> logger,
            RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                _logger.LogErrorMiddleware(error);
                var result = JsonSerializer.Serialize(new { message = error.Message } );
                await response.WriteAsync(result);
            }
        }
    }
}
