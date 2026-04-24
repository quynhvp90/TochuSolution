using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.entities
{
    public class SI_MEMO
    {
        public string JIGYOUSHO { get; set; } = null!;
        public int NUM { get; set; }

        public string? MEMO { get; set; }
    }
}
