using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Entities
{
    public class SI_Seinoumst : BaseEntity
    {
        public int Num { get; set; }
        public string Product { get; set; }
        public string CustomerName { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
    }
}
