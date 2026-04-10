using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly TochuDBContext _context;

        public LogRepository(TochuDBContext context)
        {
            _context = context;
        }

        public async Task AddLog(Log log)
        {
            try
            {
                await _context.Logs.AddAsync(log);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // fallback log (file / console)
                Console.WriteLine($"[LOG ERROR] {ex.Message}");
            }
        }

        public async Task AddLogs(IEnumerable<Log> logs)
        {
            try
            {
                await _context.Logs.AddRangeAsync(logs);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LOG ERROR] {ex.Message}");
            }
        }
    }
}