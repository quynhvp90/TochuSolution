using IMIP.Tochu.Core.interfaces;
using IMIP.Tochu.Core.mappers;
using IMIP.Tochu.Core.models;
using IMIP.Tochu.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.services
{
    public class VI_SeinouMstService : IVI_SeinouMstService
    {
        private readonly IVI_SeinouMstRepository _repository;
        public VI_SeinouMstService(IVI_SeinouMstRepository repository)
        {
            _repository = repository;
        }
        public async Task<VI_SeinouMst_Model> GetByProductAndNouscdAsync(string product, string nouscd)
        {
            var item = await _repository.GetByProductNameAndNouSCDAsync(product, nouscd);
            if (item == null) { 
                item = await _repository.GetByProductNameAndNouSCDAsync(product, "999-9999");
            }
            return item.ToModel();
        }
    }
}
