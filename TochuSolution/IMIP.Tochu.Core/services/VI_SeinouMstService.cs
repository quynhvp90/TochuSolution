using IMIP.Tochu.Core.interfaces;
using IMIP.Tochu.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.services
{
    public class VI_SeinouMstService : IVI_SeinouMstService
    {
        public Task<List<VI_SeinouMst_Model>> GetByProductAndNouscdAsync(string product, string nouscd)
        {
            throw new NotImplementedException();
        }
    }
}
