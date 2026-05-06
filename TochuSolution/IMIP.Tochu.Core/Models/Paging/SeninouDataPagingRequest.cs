using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models.Paging
{
    public class SeninouDataPagingRequest : PagedRequest
    {
        public SeninouDataPagingRequest() { }
        public T0000RR_Juchuu_RCS_Model? JuchuuRCS { get; set; }
    }
}
