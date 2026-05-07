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
        private readonly IDbLogger _dbLogger;
        public JuchuuRCSService(IT0000RR_Juchuu_RCSRepository juchuuRCSRepository, IUnitOfWork unitOfWork, IDbLogger dbLogger)
        {
            _juchuuRCSRepository = juchuuRCSRepository;
            _unitOfWork = unitOfWork;
            _dbLogger = dbLogger;
        }

        public async Task<PagedResult<T0000RR_Juchuu_RCS_Model>> GetJuchuuRCSAsync(JuchuuPagingRequest paging)
        {
            var result = new PagedResult<T0000RR_Juchuu_RCS_Model>
            {
                PageSize = paging.PageSize,
                PageIndex = paging.PageIndex,
            };
            try { 
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
                // Apply sorting
                // --- Server-side sort ---
                query = (paging.SortField, paging.SortAscending) switch
                {
                    ("JuchuuNO", true) => query.OrderBy(j => j.JuchuuNO),
                    ("JuchuuNO", false) => query.OrderByDescending(j => j.JuchuuNO),

                    ("JuchuuDenpyouNO", true) => query.OrderBy(j => j.JuchuuDenpyouNO),
                    ("JuchuuDenpyouNO", false) => query.OrderByDescending(j => j.JuchuuDenpyouNO),

                    ("JuchuuKyotenCD", true) => query.OrderBy(j => j.JuchuuKyotenCD),
                    ("JuchuuKyotenCD", false) => query.OrderByDescending(j => j.JuchuuKyotenCD),

                    ("JuchuuKyotenNM", true) => query.OrderBy(j => j.JuchuuKyotenNM),
                    ("JuchuuKyotenNM", false) => query.OrderByDescending(j => j.JuchuuKyotenNM),

                    ("JuchuuYMD", true) => query.OrderBy(j => j.JuchuuYMD),
                    ("JuchuuYMD", false) => query.OrderByDescending(j => j.JuchuuYMD),

                    ("Nouki", true) => query.OrderBy(j => j.Nouki),
                    ("Nouki", false) => query.OrderByDescending(j => j.Nouki),

                    ("ShukkaKyotenCD", true) => query.OrderBy(j => j.ShukkaKyotenCD),
                    ("ShukkaKyotenCD", false) => query.OrderByDescending(j => j.ShukkaKyotenCD),

                    ("ShukkaBashoCD", true) => query.OrderBy(j => j.ShukkaBashoCD),
                    ("ShukkaBashoCD", false) => query.OrderByDescending(j => j.ShukkaBashoCD),

                    ("JuchuuKBN", true) => query.OrderBy(j => j.JuchuuKBN),
                    ("JuchuuKBN", false) => query.OrderByDescending(j => j.JuchuuKBN),

                    ("HaisouCD", true) => query.OrderBy(j => j.HaisouCD),
                    ("HaisouCD", false) => query.OrderByDescending(j => j.HaisouCD),

                    ("ChikuCD", true) => query.OrderBy(j => j.ChikuCD),
                    ("ChikuCD", false) => query.OrderByDescending(j => j.ChikuCD),

                    ("NouSCD", true) => query.OrderBy(j => j.NouSCD),
                    ("NouSCD", false) => query.OrderByDescending(j => j.NouSCD),

                    ("NouSSNM", true) => query.OrderBy(j => j.NouSSNM),
                    ("NouSSNM", false) => query.OrderByDescending(j => j.NouSSNM),

                    ("UserHinban", true) => query.OrderBy(j => j.UserHinban),
                    ("UserHinban", false) => query.OrderByDescending(j => j.UserHinban),

                    ("UserHinmei", true) => query.OrderBy(j => j.UserHinmei),
                    ("UserHinmei", false) => query.OrderByDescending(j => j.UserHinmei),

                    ("ItemCD", true) => query.OrderBy(j => j.ItemCD),
                    ("ItemCD", false) => query.OrderByDescending(j => j.ItemCD),

                    ("ItemNM", true) => query.OrderBy(j => j.ItemNM),
                    ("ItemNM", false) => query.OrderByDescending(j => j.ItemNM),

                    ("JuchuuSuu", true) => query.OrderBy(j => j.JuchuuSuu),
                    ("JuchuuSuu", false) => query.OrderByDescending(j => j.JuchuuSuu),

                    ("NisugataCD", true) => query.OrderBy(j => j.NisugataCD),
                    ("NisugataCD", false) => query.OrderByDescending(j => j.NisugataCD),

                    ("UriKeitaiKBN", true) => query.OrderBy(j => j.UriKeitaiKBN),
                    ("UriKeitaiKBN", false) => query.OrderByDescending(j => j.UriKeitaiKBN),

                    ("Tekiyou1", true) => query.OrderBy(j => j.Tekiyou1),
                    ("Tekiyou1", false) => query.OrderByDescending(j => j.Tekiyou1),

                    ("TankaUnitCD", true) => query.OrderBy(j => j.TankaUnitCD),
                    ("TankaUnitCD", false) => query.OrderByDescending(j => j.TankaUnitCD),

                    _ => query.OrderBy(j => j.JuchuuNO),
                };

                // Get total count before applying pagination
                result.TotalCount = await query.CountAsync();
                var items = await query
                    .Skip((paging.PageIndex - 1) * paging.PageSize)
                    .Take(paging.PageSize)
                    .ToListAsync();

                result.Items = items.Select(j => j.ToModel()).ToList();
            }
            catch (Exception ex)
            {
                _dbLogger.Error(ex, "JuchuuRCSService.GetJuchuuRCSAsync");
                throw new InvalidOperationException("An error occurred while fetching JuchuuRCS data.");
            }
            return result;
        }
    }
}
