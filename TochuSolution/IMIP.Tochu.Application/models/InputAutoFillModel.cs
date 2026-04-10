using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.Models
{
    public class InputAutoFillModel
    {
        public string NM { get; set; }
        public int ENUM { get; set; }
        public int NUM { get; set; }
        public string PRODUCT { get; set; }
        public decimal Min { get; set; } = 0;
        public decimal Max { get; set; } = 0;
    }
}
