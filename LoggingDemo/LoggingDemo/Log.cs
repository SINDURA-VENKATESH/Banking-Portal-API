using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
namespace LoggingDemo
{
    public class Log : ILog
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        public Log() { }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Information(string message)
        {
            logger. Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }
    }
}
