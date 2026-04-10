using IMIP.Tochu.Application.Interfaces;
using IMIP.Tochu.Application.Models;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.LogServices
{
    public class LogBackgroundService : BackgroundService
    {
        private readonly ILogQueue _queue;
        private readonly IServiceScopeFactory _scopeFactory;

        public LogBackgroundService(ILogQueue queue, IServiceScopeFactory scopeFactory)
        {
            _queue = queue;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var batch = new List<LoggerModel>();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var log = await _queue.DequeueAsync(stoppingToken);
                    batch.Add(log);

                    // gom batch
                    if (batch.Count >= 50)
                    {
                        await SaveBatch(batch, stoppingToken);
                        batch.Clear();
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
        }

        private async Task SaveBatch(List<LoggerModel> batch, CancellationToken token)
        {
            int retry = 0;

            while (retry < 3)
            {
                try
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var repo = (ILogRepository)scope.ServiceProvider.GetService(typeof(ILogRepository));

                        var entities = batch.Select(x => new Log
                        {
                            Level = x.Level,
                            Message = x.Message,
                            Source = x.Source,
                            StackTrace = x.StackTrace,
                            CreatedAt = x.CreatedAt,
                            UserName = x.UserName
                        }).ToList();

                        await repo.AddLogs(entities);
                    }

                    return;
                }
                catch (Exception)
                {
                    retry++;
                    await Task.Delay(500, token);
                }
            }

            Console.WriteLine("Log DB failed!");
        }
    }
}
