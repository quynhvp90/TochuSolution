using IMIP.Tochu.Common;
using IMIP.Tochu.Application.Interfaces;
using IMIP.Tochu.Application.Mappers;
using IMIP.Tochu.Application.Models;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.LogServices
{
    public class LoggerService : IDbLogger
    {
        private readonly ILogQueue _queue;
        public LoggerService(ILogQueue queue)
        {
            _queue = queue;
        }
        public void Error(Exception exception, string message = null)
        {
            Log("ERROR", message + ": " + exception.Message, exception.Source, exception.StackTrace);
        }

        public void Error(string message)
        {
            Log("ERROR", message);
        }

        public void Error(string message, string source, string stackTrace = null)
        {
            Log("ERROR", message, source, stackTrace);
        }

        public void Info(string message)
        {
            Log("INFO", message);
        }


        public void Warning(string message)
        {
            Log("WARN", message);
        }


        private void Log(string level, string message, string source = null, string stackTrace = null)
        {
            try {
                var logModel = new LoggerModel
                {
                    Level = level,
                    Message = message,
                    Source = source,
                    StackTrace = stackTrace,
                    CreatedAt = DateTime.Now,
                    UserName = AppLogger.CurrentUser
                };
                _queue.EnqueueAsync(logModel);
            }
            catch (Exception ex)
            {
                AppLogger.Error($"Failed to log db message: {ex.Message}");
            }
            
        }
    }
}
