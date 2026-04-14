using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models
{
    public class ProductChildModel : BaseModel
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

        private int _number;
        public int Number { get => _number; set => SetProperty(ref _number, value); }

        private int _lotNumber;
        public int LotNumber { get => _lotNumber; set => SetProperty(ref _lotNumber, value); }

        private DateTime _manufacturingDate;
        public DateTime ManufacturingDate { get => _manufacturingDate; set => SetProperty(ref _manufacturingDate, value); }

        private decimal _weight;
        public decimal Weight { get => _weight; set => SetProperty(ref _weight, value); }

        private string _unit;
        public string Unit { get => _unit; set => SetProperty(ref _unit, value); }

        private string _packingCD;
        public string PackingCD { get => _packingCD; set => SetProperty(ref _packingCD, value); }

        private string _packingName;
        public string PackingName { get => _packingName; set => SetProperty(ref _packingName, value); }

        private string _productName = string.Empty;
        public string ProductName { get => _productName; set => SetProperty(ref _productName, value); }
    }
}
