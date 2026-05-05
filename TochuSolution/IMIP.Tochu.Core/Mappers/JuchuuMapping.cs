using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Mappers
{
    public static class JuchuuMapping
    {
        public static T0000RR_Juchuu_RCS_Model ToModel(this T0000RR_Juchuu_RCS juchuuRCS)
        {
            return new T0000RR_Juchuu_RCS_Model
            {
                JuchuuDenpyouNO = juchuuRCS.JuchuuDenpyouNO,
                JuchuuKyotenCD = juchuuRCS.JuchuuKyotenCD,
                JuchuuKyotenNM = juchuuRCS.JuchuuKyotenNM,
                JuchuuNO = juchuuRCS.JuchuuNO,
                JuchuuYMD = juchuuRCS.JuchuuYMD,
                Nouki = juchuuRCS.Nouki,
                ShukkaBashoCD = juchuuRCS.ShukkaBashoCD,
                ShukkaKyotenCD = juchuuRCS.ShukkaKyotenCD,
                JuchuuKBN = juchuuRCS.JuchuuKBN,
                HaisouCD = juchuuRCS.HaisouCD,
                ChikuCD = juchuuRCS.ChikuCD,
                NouSCD = juchuuRCS.NouSCD,
                NouSSNM = juchuuRCS.NouSSNM,
                UserHinban = juchuuRCS.UserHinban,
                UserHinmei = juchuuRCS.UserHinmei,
                ItemCD = juchuuRCS.ItemCD,
                ItemNM = juchuuRCS.ItemNM,
                JuchuuSuu = juchuuRCS.JuchuuSuu,
                NisugataCD = juchuuRCS.NisugataCD,
                UriKeitaiKBN = juchuuRCS.UriKeitaiKBN,
                Tekiyou1 = juchuuRCS.Tekiyou1,
                TankaUnitCD = juchuuRCS.TankaUnitCD
            };
        }   
    }
}
