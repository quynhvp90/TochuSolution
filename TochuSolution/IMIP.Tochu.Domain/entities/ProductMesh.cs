using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Entities
{
    public class ProductMesh : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ResinContextMin { get; set; }
        public decimal ResinContextMax { get; set; }
        public decimal StrengthXMin { get; set; }
        public decimal StrengthXMax { get; set; }
        public decimal StrengthRMin { get; set; }
        public decimal StrengthRMax { get; set; }
        public decimal StickyPointMin { get; set; }
        public decimal StickyPointMax { get; set;}
        public bool M14Active { get; set; }
        public decimal M14Min { get; set; }
        public decimal M14Max { get; set; }
        public bool M18_5Active { get; set; }
        public decimal M18_5Min { get; set; }
        public decimal M18_5Max { get; set; }
        public bool M26Active { get; set; }
        public decimal M26Min { get; set; }
        public decimal M26Max { get; set; }
        public bool M36Active { get; set; }
        public decimal M36Min { get; set; }
        public decimal M36Max { get; set; }
        public bool M50Active { get; set; }
        public decimal M50Min { get; set; }
        public decimal M50Max { get; set; }
        public bool M70Active { get; set; }
        public decimal M70Min { get; set; }
        public decimal M70Max { get; set; }
        public bool M100Active { get; set; }
        public decimal M100Min { get; set; }
        public decimal M100Max { get; set; }
        public bool M140Active { get; set; }
        public decimal M140Min { get; set; }
        public decimal M140Max { get; set; }
        public bool M200Active { get; set; }
        public decimal M200Min { get; set; }
        public decimal M200Max { get; set; }
        public bool M280Active { get; set; }
        public decimal M280Min { get; set; }
        public decimal M280Max { get; set; }
        public bool MPanActive { get; set; }
        public decimal MPanMin { get; set; }
        public decimal MPanMax { get; set; }
        public virtual Product Product { get; set; }

    }
}
