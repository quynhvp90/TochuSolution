using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Core.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Interfaces
{
    public interface IJuchuuRCSService
    {
        Task<PagedResult<T0000RR_Juchuu_RCS_Model>> GetJuchuuRCSAsync(JuchuuPaging paging);
    }
}
