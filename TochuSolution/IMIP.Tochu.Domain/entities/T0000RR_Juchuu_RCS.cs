using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.entities
{
    public class T0000RR_Juchuu_RCS
    {
        public int JuchuuNO { get; set; }
        public int JuchuuDenpyouNO { get; set; }

        public string? JuchuuKyotenCD { get; set; }
        public string? JuchuuKyotenNM { get; set; }

        public DateTime? JuchuuYMD { get; set; }
        public DateTime? Nouki { get; set; }

        public string? ShukkaKyotenCD { get; set; }
        public string? ShukkaBashoCD { get; set; }

        public string? JuchuuKBN { get; set; }
        public string? HaisouCD { get; set; }
        public string? ChikuCD { get; set; }

        public string? NouSCD { get; set; }
        public string? NouSSNM { get; set; }

        public string? UserHinban { get; set; }
        public string? UserHinmei { get; set; }

        public string? ItemCD { get; set; }
        public string? ItemNM { get; set; }

        public int? JuchuuSuu { get; set; }

        public string? NisugataCD { get; set; }
        public string? UriKeitaiKBN { get; set; }
        public string? Tekiyou1 { get; set; }
        public string? TankaUnitCD { get; set; }
    }
}
