using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Entities
{
    public class SI_Codemst : BaseEntity
    {
        public int Num { get; set; }
        public string Nm { get; set; }
        public int Enum { get; set; }
        public string Kbn { get; set; }
        public string Eyobi { get; set; }
    }
}
