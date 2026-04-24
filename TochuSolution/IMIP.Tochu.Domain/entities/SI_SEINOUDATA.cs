using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.entities
{
    public class SI_SEINOUDATA
    {
        public int JUCHUUNO { get; set; }
        public int NUM { get; set; }

        public string? LOTNO { get; set; }
        public string? USERHINBAN { get; set; }
        public string NOUSCD { get; set; } = null!;

        public decimal? T10 { get; set; }
        public decimal? T20 { get; set; }
        public decimal? T30 { get; set; }
        public decimal? T40 { get; set; }
        public decimal? T50 { get; set; }
        public decimal? T60 { get; set; }
        public decimal? T70 { get; set; }
        public decimal? T80 { get; set; }
        public decimal? T90 { get; set; }
        public decimal? T100 { get; set; }
        public decimal? T110 { get; set; }
        public decimal? T120 { get; set; }
        public decimal? T130 { get; set; }
        public decimal? T140 { get; set; }
        public decimal? T150 { get; set; }
        public decimal? T160 { get; set; }

        public DateTime? UPTIME { get; set; }
        public DateTime? NOUKI { get; set; }

        public string? NOUSSNM { get; set; }
        public string? NISUGATACD { get; set; }

        public int? JUCHUSUU { get; set; }
        public string? SUUJP { get; set; }

        public string? TANTOU1 { get; set; }
        public string? TANTOU2 { get; set; }
        public string? TANTOU3 { get; set; }

        public string? COMM { get; set; }

        public DateTime PRINTDT { get; set; }

        public decimal? MA150 { get; set; }
        public decimal? MA20 { get; set; }
        public decimal? MA30 { get; set; }
    }
}
