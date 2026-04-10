using IMIP.Tochu.Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.Interfaces
{
    public interface ILogQueue
    {
        ValueTask EnqueueAsync(LoggerModel log);
        Task<LoggerModel> DequeueAsync(CancellationToken cancellationToken);
    }
}
