using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Mappers;
using IMIP.Tochu.Core.Models;
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

namespace IMIP.Tochu.Core.Services
{
    public class SENINOUDATAService : ISENINOUDATAService
    {
        private readonly ISI_SEINOUDATARepository _si_SEINOUDATARepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbLogger _dbLogger;
        public SENINOUDATAService(ISI_SEINOUDATARepository si_SEINOUDATARepository, IDbLogger dbLogger, IUnitOfWork unitOfWork)
        {
            _si_SEINOUDATARepository = si_SEINOUDATARepository;
            _dbLogger = dbLogger;
            _unitOfWork = unitOfWork;
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
                if (paging.JuchuuRCS?.JuchuuNO != null)
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

        public async Task<SI_SEINOUDATA_Model?> GetSENINOUDATAByIdAsync(int juchuuNo, int num)
        {
            var item = await _si_SEINOUDATARepository.GetByIDAsync(juchuuNo, num);
            return item?.ToModel();
        }

        public async Task<SI_SEINOUDATA_Model> Save(SI_SEINOUDATA_Model model)
        {
            var modelUpdate = await _si_SEINOUDATARepository.GetByIDAsync(model.JUCHUUNO, model.NUM);
            if (modelUpdate != null)
            {
                modelUpdate.NOUSCD = model.NOUSCD;
                modelUpdate.LOTNO = model.LOTNO;
                modelUpdate.PRINTDT = model.PRINTDT ?? new DateTime(9999, 12, 31);
                _si_SEINOUDATARepository.Update(modelUpdate);
            }
            else
            {
                modelUpdate = new SI_SEINOUDATA
                {
                    JUCHUUNO = model.JUCHUUNO,
                    NUM = model.NUM,
                    NOUSCD = model.NOUSCD,
                    LOTNO = model.LOTNO,
                    PRINTDT = model.PRINTDT ?? new DateTime(9999, 12, 31)
                };
                _si_SEINOUDATARepository.Add(modelUpdate);
            }
            await _unitOfWork.CommitAsync();
            return modelUpdate.ToModel();
        }
    }
}
