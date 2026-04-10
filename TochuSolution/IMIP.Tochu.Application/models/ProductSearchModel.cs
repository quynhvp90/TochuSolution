using IMIP.Tochu.Common.Enums;
using IMIP.Tochu.Application.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.Models
{
    public class ProductSearchModel : PagedRequest
    {
        public string SortField { get; set; } = "CreatedAt";
        public bool SortDesc { get; set; } = false;
        public DateTime? OrderDateFrom { get; set; }
        public DateTime? OrderDateTo { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string CustomerName { get; set; }
        public int? PartNumber { get; set; }
        public string ProductName { get; set; }
        public PerformanceTable? PerformanceTable { get; set; } = Common.Enums.PerformanceTable.All;
    }
}
