using IMIP.Tochu.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.interfaces
{
    public interface IVI_SeinouMstSEService
    {
        Task<VI_SeinouMstSE_Model?> GetByProductAndNouscdAsync(string product, string nouscd);
    }
}
