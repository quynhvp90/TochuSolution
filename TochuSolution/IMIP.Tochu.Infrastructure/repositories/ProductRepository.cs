using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Domain.QueryResults;
using IMIP.Tochu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Domain.Entities.Product>, IProductRepository
    {
        public ProductRepository(TochuDBContext context) : base(context)
        {
        }

        public async Task<List<InputLogicResult>> GetInputLogic(string productName)
        {
            var result = await (from a in _context.SI_Seinoumsts
                         join b in _context.SI_Codemsts
                             on new { Num = a.Num, Kbn = "A" }
                             equals new { Num = b.Num, Kbn = b.Kbn }
                             into gj
                         from b in gj.DefaultIfEmpty()
                         where a.Product == productName
                         orderby a.Num
                        select new InputLogicResult
                        {
                            Num = a.Num,
                            Product = a.Product,
                            Min = a.Min,
                            Max = a.Max,
                            Nm = b != null ? b.Nm : null,
                            Enum = b != null ? b.Enum : (int?)null,
                            Kbn = b != null ? b.Kbn : null
                        }).ToListAsync();
            return result;
        }
    }
}
