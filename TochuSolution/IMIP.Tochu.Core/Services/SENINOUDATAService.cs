using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Core.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Services
{
    public class SENINOUDATAService : ISENINOUDATAService
    {
        public Task<PagedResult<SI_SEINOUDATA_Model>> GetSENINOUDATAAsync(SeninouDataPagingRequest paging)
        {
            throw new NotImplementedException();
        }
    }
}
