using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Mappers;
using IMIP.Tochu.Core.models;
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
                if (paging.JuchuuRCS?.JuchuuDenpyouNO != null)
                {
                    query = query.Where(j => j.JUCHUUNO == paging.JuchuuRCS.JuchuuDenpyouNO);
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

        public SI_SEINOUDATA_Model MeshAutomatically(SI_SEINOUDATA_Model seinouData, VI_SeinouMst_Model seinouMst)
        {
            var rng = new Random();
            const decimal target = 100m;

            var meshFields = new (Action<SI_SEINOUDATA_Model, decimal> setVal, decimal min, decimal max)[]
            {
                ((m, v) => m.T50  = v, seinouMst.T50A ?? 0m, seinouMst.T50B  ?? target),
                ((m, v) => m.T60  = v, seinouMst.T60A ?? 0m, seinouMst.T60B  ?? target),
                ((m, v) => m.T70  = v, seinouMst.T70A ?? 0m, seinouMst.T70B  ?? target),
                ((m, v) => m.T80  = v, seinouMst.T80A ?? 0m, seinouMst.T80B  ?? target),
                ((m, v) => m.T90  = v, seinouMst.T90A ?? 0m, seinouMst.T90B  ?? target),
                ((m, v) => m.T100 = v, seinouMst.T100A ?? 0m, seinouMst.T100B  ?? target),
                ((m, v) => m.T110 = v, seinouMst.T110A ?? 0m, seinouMst.T110B ?? target),
                ((m, v) => m.T120 = v, seinouMst.T120A ?? 0m, seinouMst.T120B ?? target),
                ((m, v) => m.T130 = v, seinouMst.T130A ?? 0m, seinouMst.T130B ?? target),
                ((m, v) => m.T140 = v, seinouMst.T140A ?? 0m, seinouMst.T140B ?? target),
                ((m, v) => m.T150 = v, seinouMst.T150A ?? 0m, seinouMst.T150B ?? target),
            };
            var simpleFields = new (Action<SI_SEINOUDATA_Model, decimal> setVal, decimal min, decimal max)[]
            {
                ((m, v) => m.T10  = v, seinouMst.T10A ?? 0m, seinouMst.T10B  ?? target),
                ((m, v) => m.T20  = v, seinouMst.T30A ?? 0m, seinouMst.T30B  ?? target),
                ((m, v) => m.T30  = v, seinouMst.T40A ?? 0m, seinouMst.T40B  ?? target),
                ((m, v) => m.T40  = v, seinouMst.T20A ?? 0m, seinouMst.T20B  ?? target),
            };
            foreach (var field in simpleFields)
            {
                decimal lo = Math.Min(field.min, field.max);
                decimal hi = Math.Max(field.min, field.max);
                decimal value = lo + (decimal)rng.NextDouble() * (hi - lo);
                field.setVal(seinouData, Math.Round(value, 2));
            }
            // --- Validate feasibility ---
            decimal totalMin = meshFields.Sum(f => f.min);
            decimal totalMax = meshFields.Sum(f => f.max);

            if (totalMin > target || totalMax < target)
                throw new InvalidOperationException(
                    $"Setting master not match: sum min={totalMin:F1} > 100 or sum max={totalMax:F1} < 100.");

            // --- Sequential Constrained Random ---
            decimal[] values = new decimal[meshFields.Length];
            decimal remaining = target;

            for (int i = 0; i < meshFields.Length; i++)
            {
                bool isLast = (i == meshFields.Length - 1);

                if (isLast)
                {
                    values[i] = Math.Max(meshFields[i].min, Math.Min(meshFields[i].max, remaining));
                }
                else
                {
                    decimal sumMinAfter = meshFields.Skip(i + 1).Sum(f => f.min);
                    decimal sumMaxAfter = meshFields.Skip(i + 1).Sum(f => f.max);

                    decimal lo = Math.Max(meshFields[i].min, remaining - sumMaxAfter);
                    decimal hi = Math.Min(meshFields[i].max, remaining - sumMinAfter);

                    lo = Math.Max(0m, lo);
                    hi = Math.Max(lo, hi);

                    // Random decimal: rng.NextDouble() return double, cast to decimal
                    decimal randomFraction = (decimal)rng.NextDouble();
                    values[i] = lo + randomFraction * (hi - lo);
                }

                values[i] = Math.Round(values[i], 2);
                remaining -= values[i];
            }
            

            for (int i = 0; i < meshFields.Length; i++)
                meshFields[i].setVal(seinouData, values[i]);
            // Field 34: m合計
            seinouData.MA150 = values.Sum();
            // Field 39: AFS.FN
            seinouData.T160 = (seinouData.T50 * 7
                    + seinouData.T60 * 10
                    + seinouData.T70 * 20
                    + seinouData.T80 * 30
                    + seinouData.T90 * 40
                    + seinouData.T100 * 50
                    + seinouData.T110 * 70
                    + seinouData.T120 * 100
                    + seinouData.T130 * 140
                    + seinouData.T140 * 200
                    + seinouData.T150 * 300) / 100;

            return seinouData;
        }

        public async Task<SI_SEINOUDATA_Model> Save(SI_SEINOUDATA_Model model)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                // DELETE existing record if exists
                var modelExisting = await _si_SEINOUDATARepository.GetByIDAsync(model.JUCHUUNO, model.NUM);
                if (modelExisting != null)
                    _si_SEINOUDATARepository.Delete(modelExisting);

                // INSERT new record
                var modelInsert = new SI_SEINOUDATA
                {
                    USERHINBAN = model.USERHINBAN,
                    // ── Header ────────────────────────────────────────────
                    JUCHUUNO = model.JUCHUUNO,
                    NUM = model.NUM,
                    NOUSCD = model.NOUSCD,
                    LOTNO = model.LOTNO,
                    PRINTDT = model.PRINTDT ?? new DateTime(9999, 12, 31),

                    // ── Analysis ──────────────────────────────────────────
                    T10 = model.T10,   // 樹脂分   Resin Content
                    T40 = model.T40,   // 粘着点   Adhesion Point

                    // ── Transverse Rupture Strength ───────────────────────
                    T20 = model.T20,   // 抗折力X (kgf/cm²)
                    MA20 = model.MA20,  // 抗折力X (N/cm²) 自動計算
                    T30 = model.T30,   // 抗折力R (kgf/cm²)
                    MA30 = model.MA30,  // 抗折力R (N/cm²) 自動計算

                    // ── Mesh ──────────────────────────────────────────────
                    T50 = model.T50,   // m14
                    T60 = model.T60,   // m18.5
                    T70 = model.T70,   // m26
                    T80 = model.T80,   // m36
                    T90 = model.T90,   // m50
                    T100 = model.T100,  // m70
                    T110 = model.T110,  // m100
                    T120 = model.T120,  // m140
                    T130 = model.T130,  // m200
                    T140 = model.T140,  // m280
                    T150 = model.T150,  // mPAN

                    // ── Auto-calculated ───────────────────────────────────
                    MA150 = model.MA150, // m合計 自動計算⑥
                    T160 = model.T160,  // AFS.FN 自動計算⑦

                    // ── Footer ────────────────────────────────────────────
                    COMM = model.COMM,   // 備考
                };

                _si_SEINOUDATARepository.Add(modelInsert);

                await _unitOfWork.CommitAsync();
                return modelInsert.ToModel();
            } finally
            {
                _unitOfWork.EndTransactionAsync();
            }
        }
    }
}
