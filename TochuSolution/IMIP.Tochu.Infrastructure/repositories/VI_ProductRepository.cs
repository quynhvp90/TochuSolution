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
    public class VI_ProductRepository : GenericRepository<VI_Product>, IVI_ProductRepository
    {
        public VI_ProductRepository(TochuDBContext dBContext) : base(dBContext) { }
        public async Task<List<VI_Product>> GetByProductAsync(string NOUSCD)
        {
            return await _context.VI_Products.Where(p => p.NOUSCD == NOUSCD).ToListAsync();
        }

        public async Task<List<VI_Product>> GetAllAsync()
        {
            return await _context.VI_Products.ToListAsync();
        }
    }
}
