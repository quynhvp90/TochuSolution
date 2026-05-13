using IMIP.Tochu.Core.interfaces;
using IMIP.Tochu.Core.mappers;
using IMIP.Tochu.Core.models;
using IMIP.Tochu.Core.Models.Paging;
using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PagedResult<VI_SeinouMstSE_Model>> GetByProductAndNouscdAsync(VI_SeinouMstSEPagingRequest request)
        {
            var result = new PagedResult<VI_SeinouMstSE_Model>()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };

            var query = _seinouMstSERepository.Query();

            if (!string.IsNullOrWhiteSpace(request.ProductName))
            {
                var keyword = request.ProductName.ToLower();

                query = query.Where(x =>
                    x.PRODUCT != null &&
                    x.PRODUCT.ToLower().Contains(keyword));
            }

            query = query.OrderBy(x => x.NOUSCD);

            var total = await query.CountAsync();

            var items = await query
                .Skip(request.PageSize * (request.PageIndex - 1))
                .Take(request.PageSize)
                .Select(s => s.ToModel())
                .ToListAsync();

            result.TotalCount = total;
            result.Items = items;

            return result;
        }
    }
}
