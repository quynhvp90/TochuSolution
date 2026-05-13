using IMIP.Tochu.Core.models;
using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Interfaces
{
    public interface IPrintCSVService
    {
        Task PrintAsync(string filePath, SI_SEINOUDATA_Model seinouData, T0000RR_Juchuu_RCS_Model juchuuRCS, VI_SeinouMstSE_Model seinouMst, string tantou1, string tantou2, string tantou3);
    }
}
