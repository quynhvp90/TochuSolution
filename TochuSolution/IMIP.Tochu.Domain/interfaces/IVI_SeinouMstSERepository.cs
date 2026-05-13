using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.interfaces
{
    public interface IVI_SeinouMstSERepository : IRepository<VI_SeinouMstSE>
    {
        Task<List<VI_SeinouMstSE>> GetAllAsync();
        Task<List<VI_SeinouMstSE>> GetByProductAsync(string product);
        Task<VI_SeinouMstSE?> GetByProductNameAndNouSCDAsync(string productName, string nouSCD);
    }
}
