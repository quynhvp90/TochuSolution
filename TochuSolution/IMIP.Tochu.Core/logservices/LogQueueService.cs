using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Models;
using System.Threading.Channels;

namespace IMIP.Tochu.Core.LogServices
{
    public class LogQueueService : ILogQueue
    {
        private readonly Channel<LoggerModel> _channel;
        public LogQueueService()
        {
            _channel = Channel.CreateUnbounded<LoggerModel>(new UnboundedChannelOptions
            {
                SingleReader = true,
                SingleWriter = false
            });
        }

        public async ValueTask EnqueueAsync(LoggerModel log)
        {
            await _channel.Writer.WriteAsync(log);
        }

        public async Task<LoggerModel> DequeueAsync(CancellationToken cancellationToken)
        {
            return await _channel.Reader.ReadAsync(cancellationToken);
        }
    }
}
