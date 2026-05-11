using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.interfaces
{
    public interface IVI_SeinouMstService
    {
        Task<List<models.VI_SeinouMst_Model>> GetByProductAndNouscdAsync(string product, string nouscd);
    }
}
