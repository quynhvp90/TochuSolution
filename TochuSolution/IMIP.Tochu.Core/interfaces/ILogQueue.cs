using IMIP.Tochu.Core.Models;

namespace IMIP.Tochu.Core.Interfaces
{
    public interface ILogQueue
    {
        ValueTask EnqueueAsync(LoggerModel log);
        Task<LoggerModel> DequeueAsync(CancellationToken cancellationToken);
    }
}
