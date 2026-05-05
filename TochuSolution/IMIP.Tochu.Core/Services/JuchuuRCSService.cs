using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Mappers;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Core.Models.Paging;
using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Services
{
    public class JuchuuRCSService : IJuchuuRCSService
    {
        private readonly IT0000RR_Juchuu_RCSRepository _juchuuRCSRepository;
        private readonly IUnitOfWork _unitOfWork;
        public JuchuuRCSService(IT0000RR_Juchuu_RCSRepository juchuuRCSRepository, IUnitOfWork unitOfWork)
        {
            _juchuuRCSRepository = juchuuRCSRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<T0000RR_Juchuu_RCS_Model>> GetJuchuuRCSAsync(JuchuuPaging paging)
        {
            var result = new PagedResult<T0000RR_Juchuu_RCS_Model>
            {
                PageSize = paging.PageSize,
                PageIndex = paging.PageIndex,
            };
            var query = _juchuuRCSRepository.Query();
            if (paging.JuchuuKyotenCD != null)
            {
                query = query.Where(j => j.JuchuuKyotenCD == paging.JuchuuKyotenCD);
            }
            if (paging.StartNouki.HasValue)
            {
                var start = paging.StartNouki.Value.Date;
                query = query.Where(j => j.Nouki >= start);
            }

            if (paging.EndNouki.HasValue)
            {
                var end = paging.EndNouki.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(j => j.Nouki < end);
            }
            query = query.OrderBy(j => j.JuchuuNO);
            result.TotalCount = await query.CountAsync();
            var items = await query
                .Skip((paging.PageIndex - 1) * paging.PageSize)
                .Take(paging.PageSize)
                .ToListAsync();

            result.Items = items.Select(j => j.ToModel()).ToList();
            return result;
        }
    }
}
