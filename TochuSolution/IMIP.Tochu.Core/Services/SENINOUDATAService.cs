using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Mappers;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Core.Models.Paging;
using IMIP.Tochu.Domain.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Services
{
    public class SENINOUDATAService : ISENINOUDATAService
    {
        private readonly ISI_SEINOUDATARepository _si_SEINOUDATARepository;
        private readonly IDbLogger _dbLogger;
        public SENINOUDATAService(ISI_SEINOUDATARepository si_SEINOUDATARepository, IDbLogger dbLogger)
        {
            _si_SEINOUDATARepository = si_SEINOUDATARepository;
            _dbLogger = dbLogger;
        }
        public async Task<PagedResult<SI_SEINOUDATA_Model>> GetSENINOUDATAAsync(SeninouDataPagingRequest paging)
        {
            var result = new PagedResult<SI_SEINOUDATA_Model>
            {
                PageSize = paging.PageSize,
                PageIndex = paging.PageIndex,
            };
            try
            {
                var query = _si_SEINOUDATARepository.Query();
                if (paging.JuchuuRCS?.JuchuuDenpyouNO != null)
                {
                    query = query.Where(j => j.JUCHUUNO == paging.JuchuuRCS.JuchuuNO);
                }
                query = query.OrderBy(x => x.NUM);

                // Get total count before applying pagination
                result.TotalCount = await query.CountAsync();
                var items = await query
                    .Skip((paging.PageIndex - 1) * paging.PageSize)
                    .Take(paging.PageSize)
                    .Select(j => new SI_SEINOUDATA_Model
                    {
                        JUCHUUNO = j.JUCHUUNO,
                        NOUSCD = j.NOUSCD,
                        NUM = j.NUM,
                        LOTNO = j.LOTNO,
                        PRINTDT = j.PRINTDT == new DateTime(9999, 12, 31) ? null : j.PRINTDT
                    })
                    .ToListAsync();

                result.Items = items;
            }
            catch (Exception ex)
            {
                _dbLogger.Error(ex, "SENINOUDATAService.GetSENINOUDATAAsync");
                throw new InvalidOperationException("An error occurred while fetching SENINOUDATA data.");
            }
            return result;
        }
    }
}
