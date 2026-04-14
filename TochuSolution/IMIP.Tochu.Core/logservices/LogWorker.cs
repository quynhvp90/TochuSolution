using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using Unity;

namespace IMIP.Tochu.Core.LogServices
{
    public class LogWorker
    {
        private readonly ILogQueue _queue;
        private readonly IUnityContainer _container;

        public LogWorker(ILogQueue queue, IUnityContainer container)
        {
            _queue = queue;
            _container = container;
        }

        public void Start()
        {
            Task.Run(async () =>
            {
                var batch = new List<LoggerModel>();

                while (true)
                {
                    var log = await _queue.DequeueAsync(CancellationToken.None);
                    batch.Add(log);

                    if (batch.Count >= 50)
                    {
                        await SaveBatch(batch);
                        batch.Clear();
                    }
                }
            });
        }

        private async Task SaveBatch(List<LoggerModel> batch)
        {
            try
            {
                using (var scope = _container.CreateChildContainer())
                {
                    var repo = scope.Resolve<ILogRepository>();

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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log failed: " + ex.Message);
            }
        }
    }
}
