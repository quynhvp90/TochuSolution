using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models.Paging
{
    public class JuchuuPaging : PagedRequest
    {
        public DateTime? StartNouki { get; set; }
        public DateTime? EndNouki { get; set; }
        public string JuchuuKyotenCD { get; set; } = string.Empty;
    }
}
