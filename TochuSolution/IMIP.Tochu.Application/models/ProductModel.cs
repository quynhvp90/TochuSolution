using IMIP.Tochu.Shared.Enums;

namespace IMIP.Tochu.Application.Models
{
    public class ProductModel : BaseModel
    {
        private Guid _id;
        public Guid Id { get => _id; set => SetProperty(ref _id, value); }

        private DateTime _createdAt;
        public DateTime CreatedAt { get => _createdAt; set => SetProperty(ref _createdAt, value); }

        private DateTime? _updatedAt;
        public DateTime? UpdatedAt { get => _updatedAt; set => SetProperty(ref _updatedAt, value); }

        private int _productId;
        public int ProductId { get => _productId; set => SetProperty(ref _productId, value); }

        private int _orderNumber;
        public int OrderNumber { get => _orderNumber; set => SetProperty(ref _orderNumber, value); }

        private DateTime _orderDate;
        public DateTime OrderDate { get => _orderDate; set => SetProperty(ref _orderDate, value); }

        private DateTime _deliveryDate;
        public DateTime DeliveryDate { get => _deliveryDate; set => SetProperty(ref _deliveryDate, value); }

        private string _customerName;
        public string CustomerName { get => _customerName; set => SetProperty(ref _customerName, value); }

        private int _partNumber;
        public int PartNumber { get => _partNumber; set => SetProperty(ref _partNumber, value); }

        private string _productName;
        public string ProductName { get => _productName; set => SetProperty(ref _productName, value); }

        private int _orderQuantity;
        public int OrderQuantity { get => _orderQuantity; set => SetProperty(ref _orderQuantity, value); }

        private string _unit;
        public string Unit { get => _unit; set => SetProperty(ref _unit, value); }

        private string _packagingCD;
        public string PackagingCD { get => _packagingCD; set => SetProperty(ref _packagingCD, value); }

        private string _packagingName;
        public string PackagingName { get => _packagingName; set => SetProperty(ref _packagingName, value); }

        private int _lotNumber;
        public int LotNumber { get => _lotNumber; set => SetProperty(ref _lotNumber, value); }

        private string _performanceM;
        public string PerformanceM { get => _performanceM; set => SetProperty(ref _performanceM, value); }

        private string _forCustomers;
        public string ForCustomers { get => _forCustomers; set => SetProperty(ref _forCustomers, value); }

        private PerformanceTable _performanceTable;
        public PerformanceTable PerformanceTable { get => _performanceTable; set => SetProperty(ref _performanceTable, value); }

        private bool _insured;
        public bool Insured { get => _insured; set => SetProperty(ref _insured, value); }
        private bool _active;
        public bool Active { get => _active; set => SetProperty(ref _active, value); }

        private DateTime _printingDate;
        public DateTime PrintingDate { get => _printingDate; set => SetProperty(ref _printingDate, value); }

        private bool _printing;
        public bool Printing { get => _printing; set => SetProperty(ref _printing, value); }

        private decimal _resinContent;
        public decimal ResinContent { get => _resinContent; set => SetProperty(ref _resinContent, value); }

        private decimal _transverseRuptureStrengthX;
        public decimal TransverseRuptureStrengthX { get => _transverseRuptureStrengthX; set => SetProperty(ref _transverseRuptureStrengthX, value); }

        private decimal _transverseRuptureStrengthR;
        public decimal TransverseRuptureStrengthR { get => _transverseRuptureStrengthR; set => SetProperty(ref _transverseRuptureStrengthR, value); }

        private decimal _stickyPoint;
        public decimal StickyPoint { get => _stickyPoint; set => SetProperty(ref _stickyPoint, value); }

        private decimal _afs_fn;
        public decimal AFS_FN { get => _afs_fn; set => SetProperty(ref _afs_fn, value); }

        private decimal _m14;
        public decimal m14 { get => _m14; set => SetProperty(ref _m14, value); }

        private decimal _m18_5;
        public decimal m18_5 { get => _m18_5; set => SetProperty(ref _m18_5, value); }

        private decimal _m26;
        public decimal m26 { get => _m26; set => SetProperty(ref _m26, value); }

        private decimal _m36;
        public decimal m36 { get => _m36; set => SetProperty(ref _m36, value); }

        private decimal _m50;
        public decimal m50 { get => _m50; set => SetProperty(ref _m50, value); }

        private decimal _m70;
        public decimal m70 { get => _m70; set => SetProperty(ref _m70, value); }

        private decimal _m100;
        public decimal m100 { get => _m100; set => SetProperty(ref _m100, value); }

        private decimal _m140;
        public decimal m140 { get => _m140; set => SetProperty(ref _m140, value); }

        private decimal _m200;
        public decimal m200 { get => _m200; set => SetProperty(ref _m200, value); }

        private decimal _m280;
        public decimal m280 { get => _m280; set => SetProperty(ref _m280, value); }

        private decimal _mPAN;
        public decimal mPAN { get => _mPAN; set => SetProperty(ref _mPAN, value); }

        private decimal _af_fn = 100;
        public decimal AF_FN { get => _af_fn; set => SetProperty(ref _af_fn, value); }

        private string _comment;
        public string Comment { get => _comment; set => SetProperty(ref _comment, value); }

        private ProductMeshModel _productMesh = new ProductMeshModel();
        public ProductMeshModel ProductMesh { get => _productMesh; set => SetProperty(ref _productMesh, value); }

        private List<ProductChildModel> _childrens = new List<ProductChildModel>();
        public List<ProductChildModel> Childrens { get => _childrens; set => SetProperty(ref _childrens, value); }
    }
}
