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
    public class VI_SeinouMstSERepository : GenericRepository<VI_SeinouMstSE>, IVI_SeinouMstSERepository
    {
        public VI_SeinouMstSERepository(TochuDBContext context) : base(context)
        {
        }
        public async Task<List<VI_SeinouMstSE>> GetAllAsync()
        {
            return await _context.VI_SeinouMstSEs.ToListAsync();
        }

        public async Task<List<VI_SeinouMstSE>> GetByProductAsync(string product)
        {
            return await _context.VI_SeinouMstSEs.Where(x => x.PRODUCT == product).ToListAsync();
        }
    }
}
