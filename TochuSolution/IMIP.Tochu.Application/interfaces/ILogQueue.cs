using IMIP.Tochu.Application.Models;

namespace IMIP.Tochu.Application.Interfaces
{
    public interface ILogQueue
    {
        ValueTask EnqueueAsync(LoggerModel log);
        Task<LoggerModel> DequeueAsync(CancellationToken cancellationToken);
    }
}
