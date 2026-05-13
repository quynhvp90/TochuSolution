using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models.Paging
{
    public class VI_SeinouMstSEPagingRequest : PagedRequest
    {
        public string? ProductName { get; set; }
        public string? NouSCD { get; set; }
    }
}
