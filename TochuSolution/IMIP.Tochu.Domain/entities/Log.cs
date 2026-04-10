using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Entities
{
    public class Log : BaseEntity
    {
        public string Level { get; set; }      // INFO, WARN, ERROR
        public string Message { get; set; }
        public string Source { get; set; } 
        public string StackTrace { get; set; }
        public string UserName { get; set; } 
    }
}
