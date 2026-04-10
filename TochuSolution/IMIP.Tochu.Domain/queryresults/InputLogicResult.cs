using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.QueryResults
{
    public class InputLogicResult
    {
        public int Num { get; set; }
        public string Product { get; set; }
        public decimal? Min { get; set; }
        public decimal? Max { get; set; }
        public string Nm { get; set; }
        public int? Enum { get; set; }
        public string Kbn { get; set; }
    }
}
