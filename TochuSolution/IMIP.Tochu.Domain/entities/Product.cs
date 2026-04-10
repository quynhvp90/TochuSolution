using IMIP.Tochu.Shared.Enums;

namespace IMIP.Tochu.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }
        public int OrderNumber { get; set; }
        public int OrderQuantity { get; set; }
        public string Unit { get; set; }
        public string PackagingCD { get; set; }
        public string PackagingName { get; set; }
        public int LotNumber { get; set; }
        public string PerformanceM { get; set; }
        public string ForCustomers { get; set; }    
        public bool Insured { get; set; }
        public bool Printing { get; set; }
        public bool Active { set; get; } = true;
        public decimal ResinContent { get; set; }
        public decimal TransverseRuptureStrengthX { get; set; }
        public decimal TransverseRuptureStrengthR { get; set; }
        public decimal StickyPoint { get; set; }
        public decimal AFS_FN { get; set; }
        public decimal m14 { get; set; }
        
        public decimal m18_5 { get; set; }
        public decimal m26 { get; set; }
        public decimal m36 { get; set; }
        public decimal m50 { get; set; }
        public decimal m70 { get; set; }
        public decimal m100 { get; set; }
        public decimal m140 { get; set; }
        public decimal m200 { get; set; }
        public decimal m280 { get; set; }
        public decimal mPAN { get; set; }
        public decimal AF_FN { get; set; }
        public string Comment { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int PartNumber { get; set; }
        public PerformanceTable PerformanceTable { get; set; } = PerformanceTable.All;
        public DateTime PrintingDate { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public virtual ProductMesh ProductMesh { get; set; }
    }
}


