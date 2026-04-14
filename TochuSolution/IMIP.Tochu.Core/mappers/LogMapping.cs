using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Mappers
{
    public static class LogMapping
    {
        public static LoggerModel Mapping(this Log log)
        {
            return new LoggerModel
            {
                Id = log.Id,
                CreatedAt = log.CreatedAt,
                Level = log.Level,
                Message = log.Message,
                Source = log.Source,
                StackTrace = log.StackTrace,
                UserName = log.UserName
            };
        }
        public static void UpdateMapping(this Log logEntity, LoggerModel logModel)
        {
            logEntity.Level = logModel.Level;
            logEntity.Message = logModel.Message;
            logEntity.Source = logModel.Source;
            logEntity.StackTrace = logModel.StackTrace;
            logEntity.UserName = logModel.UserName;
        }
    }
}
