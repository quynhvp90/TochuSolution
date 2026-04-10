using IMIP.Tochu.Application.Interfaces;
using IMIP.Tochu.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.LogServices
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
