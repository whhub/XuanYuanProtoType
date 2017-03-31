using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAppFramework.Shared
{
    public interface ILogger
    {
        void Log(LogType logType, LogLevel logLevel, string logContent);
        void LogException(Exception e);
    }

    public enum LogLevel
    {
        INFO, WARNING, ERROR 
    }

    public enum LogType
    {
        SVC, DEV, TRACE
    }
}
