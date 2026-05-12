using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Infrastructure.Data;
using IMIP.Tochu.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Infrastructure.repositories
{
    public class VI_SeinouMstRepository : GenericRepository<VI_SeinouMst>, IVI_SeinouMstRepository
    {
        public VI_SeinouMstRepository(TochuDBContext context) : base(context)
        {
        }

        public async Task<List<VI_SeinouMst>> GetByProductAsync(string product)
        {
            return await _context.VI_SeinouMsts.Where(x => x.PRODUCT == product).ToListAsync();
        }

        public async Task<List<VI_SeinouMst>> GetAllAsync()
        {
            return await _context.VI_SeinouMsts.ToListAsync();
        }

        public async Task<VI_SeinouMst?> GetByProductNameAndNouSCDAsync(string productName, string nouSCD)
        {
            var item = await _context.VI_SeinouMsts.FirstOrDefaultAsync(x => x.PRODUCT == productName && x.NOUSCD == nouSCD);
            return item;
        }
    }
}
