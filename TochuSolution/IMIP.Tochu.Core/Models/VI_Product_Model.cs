using IMIP.Tochu.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models
{
    public class VI_Product_Model : NotifyBase
    {
        public string? UserHinban { get; set; }
        public string? UserHinmei { get; set; }
        public string? NOUSCD { get; set; }
    }
}
