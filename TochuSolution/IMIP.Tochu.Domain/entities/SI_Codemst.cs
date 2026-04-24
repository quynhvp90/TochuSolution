using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Entities
{
    public class SI_CODEMST
    {
        public string KBN { get; set; } = null!;
        public int ID { get; set; }

        public string NM { get; set; } = null!;
        public int ENUM { get; set; }

        public string? EYOBI { get; set; }
    }
}
