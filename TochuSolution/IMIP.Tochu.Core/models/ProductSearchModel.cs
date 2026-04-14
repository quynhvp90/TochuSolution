using IMIP.Tochu.Core.Models.Paging;
using IMIP.Tochu.Shared.Enums;

namespace IMIP.Tochu.Core.Models
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
        public PerformanceTable? PerformanceTable { get; set; } = Shared.Enums.PerformanceTable.All;
    }
}
