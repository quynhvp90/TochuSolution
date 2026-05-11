using IMIP.Tochu.Core.interfaces;
using IMIP.Tochu.Core.mappers;
using IMIP.Tochu.Core.models;
using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.services
{
    public class VI_SeinouMstSEService : IVI_SeinouMstSEService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVI_SeinouMstSERepository _seinouMstSERepository;
        public VI_SeinouMstSEService(IUnitOfWork unitOfWork, IVI_SeinouMstSERepository seinouMstSERepository)
        {
            _unitOfWork = unitOfWork;
            _seinouMstSERepository = seinouMstSERepository;
        }
        public async Task<VI_SeinouMstSE_Model?> GetByProductAndNouscdAsync(string product, string nouscd)
        {
            var items = await _seinouMstSERepository.GetByProductNameAndNouSCDAsync(product, nouscd);
            if (items == null)
            {
                items = await _seinouMstSERepository.GetByProductNameAndNouSCDAsync(product, "999-9999");
            }
            return items?.ToModel();
        }
    }
}
