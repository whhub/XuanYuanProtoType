using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Logging;
using System.ComponentModel.Composition;
using XAppFramework.Shared;

namespace XAppFramework.Common
{
    [Export(typeof(ILogger))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    class Logger : ILogger, ILoggerFacade
    {
        public void Log(LogType logType, LogLevel logLevel, string logContent)
        {
            System.Console.WriteLine("LOG_{0}_{1} [{3}]\t{2}", logType, logLevel, logContent, DateTime.Now.ToLongTimeString());
        }

        public void LogException(Exception e)
        {
            System.Console.WriteLine("LOG_EXCEPTION [{1}]\t{0}", e.Message, DateTime.Now.ToLongTimeString());
            System.Console.WriteLine("\t{0}", e.StackTrace.Replace("\n", "\t\n"));
        }

        public void Log(string message, Category category, Priority priority)
        {
            System.Console.WriteLine("LOG_{0}_{1} [{3}]\t{2}", category, priority, message, DateTime.Now.ToLongTimeString());
        }
    }
}
