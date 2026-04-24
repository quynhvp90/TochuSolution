using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Entities
{
    public class SI_SEINOUMST
    {
        public string PRODUCT { get; set; } = null!;
        public string NOUSCD { get; set; } = null!;
        public int NUM { get; set; }

        public decimal? MIN { get; set; }
        public decimal? MAX { get; set; }
    }
}
