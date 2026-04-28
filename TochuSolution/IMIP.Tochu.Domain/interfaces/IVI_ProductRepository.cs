using IMIP.Tochu.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.interfaces
{
    public interface IVI_ProductRepository
    {
        Task<List<VI_Product>> GetAllAsync();
        Task<List<VI_Product>> GetByProductAsync(string NOUSCD);
    }
}
