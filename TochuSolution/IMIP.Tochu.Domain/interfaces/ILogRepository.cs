using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task AddLog(Entities.Log log);
        Task AddLogs(IEnumerable<Entities.Log> logs);
    }
}
