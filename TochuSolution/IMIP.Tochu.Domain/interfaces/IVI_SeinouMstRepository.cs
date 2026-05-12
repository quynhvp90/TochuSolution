using IMIP.Tochu.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.interfaces
{
    public interface IVI_SeinouMstRepository
    {
        Task<List<VI_SeinouMst>> GetAllAsync();
        Task<List<VI_SeinouMst>> GetByProductAsync(string product);
        Task<VI_SeinouMst?> GetByProductNameAndNouSCDAsync(string productName, string nouSCD);
    }
}
