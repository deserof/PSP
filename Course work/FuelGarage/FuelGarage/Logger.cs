using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace FuelGarage
{
    public static class Logger
    {
        public static void LogErrorMiddleware<T>(
            this ILogger<T> logger,
            Exception exception)
        {
            var trace = new StackTrace(exception, true);
            var stackFrame = trace.GetFrame(0);
            var classFullName = stackFrame.GetFileName();
            var methodFullName = stackFrame.GetMethod().Name;
            var lineNo = stackFrame.GetFileLineNumber();
            logger.LogError($"[{DateTime.Now.ToString("G")}][class: {classFullName} | method: {methodFullName} | {lineNo} line] ex.Message: {exception.Message}", exception);
        }
    }
}
