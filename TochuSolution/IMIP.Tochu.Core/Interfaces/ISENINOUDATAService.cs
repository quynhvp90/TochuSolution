using IMIP.Tochu.Core.models;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Core.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Interfaces
{
    public interface ISENINOUDATAService
    {
        Task<PagedResult<SI_SEINOUDATA_Model>> GetSENINOUDATAAsync(SeninouDataPagingRequest paging);
        Task<SI_SEINOUDATA_Model?> GetSENINOUDATAByIdAsync(int juchuuNo, int num);
        SI_SEINOUDATA_Model MeshAutomatically(SI_SEINOUDATA_Model seinouData, VI_SeinouMst_Model seinouMst);
        Task<SI_SEINOUDATA_Model> Save(SI_SEINOUDATA_Model model);

    }
}
