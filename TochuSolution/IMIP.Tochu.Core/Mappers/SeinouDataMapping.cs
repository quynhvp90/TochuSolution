using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Mappers
{
    public static class SeinouDataMapping
    {
        public static SI_SEINOUDATA_Model ToModel(this SI_SEINOUDATA entity)
        {
            return new SI_SEINOUDATA_Model()
            {
                NUM = entity.NUM,
                JUCHUUNO = entity.JUCHUUNO,
                COMM = entity.COMM,
                JUCHUSUU = entity.JUCHUSUU,
                LOTNO = entity.LOTNO,
                MA150 = entity.MA150,
                MA20 = entity.MA20,
                MA30 = entity.MA30,
                NOUKI = entity.NOUKI,
                NOUSCD = entity.NOUSCD,
                NOUSSNM = entity.NOUSSNM,
                NISUGATACD = entity.NISUGATACD,
                PRINTDT = entity.PRINTDT,
                SUUJP = entity.SUUJP,
                T10 = entity.T10,
                T110 = entity.T110,
                T120 = entity.T120,
                T130 = entity.T130,
                T140 = entity.T140,
                T150 = entity.T150,
                T160 = entity.T160,
                T20 = entity.T20,
                T30 = entity.T30,
                T40 = entity.T40,
                T50 = entity.T50,
                T60 = entity.T60,
                T70 = entity.T70,
                T80 = entity.T80,
                T90 = entity.T90,
                UPTIME = entity.UPTIME,
                USERHINBAN = entity.USERHINBAN,
                TANTOU1 = entity.TANTOU1,
                TANTOU2 = entity.TANTOU2,
                TANTOU3 = entity.TANTOU3,
                T100 = entity.T100                
            };
        }
    }
}
