using IMIP.Tochu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models
{
    public class ProductMeshModel : BaseModel
    {
        private Guid _id;
        public Guid Id { get => _id; set => SetProperty(ref _id, value); }

        private string _productName;
        public string ProductName { get => _productName; set => SetProperty(ref _productName, value); }
        private string _customerName;
        public string CustomerName { get => _productName; set => SetProperty(ref _productName, value); }

        private decimal _resinContextMin;
        public decimal ResinContextMin { get => _resinContextMin; set => SetProperty(ref _resinContextMin, value); }

        private decimal _resinContextMax;
        public decimal ResinContextMax { get => _resinContextMax; set => SetProperty(ref _resinContextMax, value); }

        private decimal _strengthXMin;
        public decimal StrengthXMin { get => _strengthXMin; set => SetProperty(ref _strengthXMin, value); }

        private decimal _strengthXMax;
        public decimal StrengthXMax { get => _strengthXMax; set => SetProperty(ref _strengthXMax, value); }

        private decimal _strengthRMin;
        public decimal StrengthRMin { get => _strengthRMin; set => SetProperty(ref _strengthRMin, value); }

        private decimal _strengthRMax;
        public decimal StrengthRMax { get => _strengthRMax; set => SetProperty(ref _strengthRMax, value); }

        private decimal _stickyPointMin;
        public decimal StickyPointMin { get => _stickyPointMin; set => SetProperty(ref _stickyPointMin, value); }

        private decimal _stickyPointMax;
        public decimal StickyPointMax { get => _stickyPointMax; set => SetProperty(ref _stickyPointMax, value); }

        private bool _m14Active;
        public bool M14Active { get => _m14Active; set => SetProperty(ref _m14Active, value); }

        private decimal _m14Min;
        public decimal M14Min { get => _m14Min; set => SetProperty(ref _m14Min, value); }

        private decimal _m14Max;
        public decimal M14Max { get => _m14Max; set => SetProperty(ref _m14Max, value); }

        private bool _m18_5Active;
        public bool M18_5Active { get => _m18_5Active; set => SetProperty(ref _m18_5Active, value); }

        private decimal _m18_5Min;
        public decimal M18_5Min { get => _m18_5Min; set => SetProperty(ref _m18_5Min, value); }

        private decimal _m18_5Max;
        public decimal M18_5Max { get => _m18_5Max; set => SetProperty(ref _m18_5Max, value); }

        private bool _m26Active;
        public bool M26Active { get => _m26Active; set => SetProperty(ref _m26Active, value); }

        private decimal _m26Min;
        public decimal M26Min { get => _m26Min; set => SetProperty(ref _m26Min, value); }

        private decimal _m26Max;
        public decimal M26Max { get => _m26Max; set => SetProperty(ref _m26Max, value); }

        private bool _m36Active;
        public bool M36Active { get => _m36Active; set => SetProperty(ref _m36Active, value); }

        private decimal _m36Min;
        public decimal M36Min { get => _m36Min; set => SetProperty(ref _m36Min, value); }

        private decimal _m36Max;
        public decimal M36Max { get => _m36Max; set => SetProperty(ref _m36Max, value); }

        private bool _m50Active;
        public bool M50Active { get => _m50Active; set => SetProperty(ref _m50Active, value); }

        private decimal _m50Min;
        public decimal M50Min { get => _m50Min; set => SetProperty(ref _m50Min, value); }

        private decimal _m50Max;
        public decimal M50Max { get => _m50Max; set => SetProperty(ref _m50Max, value); }

        private bool _m70Active;
        public bool M70Active { get => _m70Active; set => SetProperty(ref _m70Active, value); }

        private decimal _m70Min;
        public decimal M70Min { get => _m70Min; set => SetProperty(ref _m70Min, value); }

        private decimal _m70Max;
        public decimal M70Max { get => _m70Max; set => SetProperty(ref _m70Max, value); }

        private bool _m100Active;
        public bool M100Active { get => _m100Active; set => SetProperty(ref _m100Active, value); }

        private decimal _m100Min;
        public decimal M100Min { get => _m100Min; set => SetProperty(ref _m100Min, value); }

        private decimal _m100Max;
        public decimal M100Max { get => _m100Max; set => SetProperty(ref _m100Max, value); }

        private bool _m140Active;
        public bool M140Active { get => _m140Active; set => SetProperty(ref _m140Active, value); }

        private decimal _m140Min;
        public decimal M140Min { get => _m140Min; set => SetProperty(ref _m140Min, value); }

        private decimal _m140Max;
        public decimal M140Max { get => _m140Max; set => SetProperty(ref _m140Max, value); }

        private bool _m200Active;
        public bool M200Active { get => _m200Active; set => SetProperty(ref _m200Active, value); }

        private decimal _m200Min;
        public decimal M200Min { get => _m200Min; set => SetProperty(ref _m200Min, value); }

        private decimal _m200Max;
        public decimal M200Max { get => _m200Max; set => SetProperty(ref _m200Max, value); }

        private bool _m280Active;
        public bool M280Active { get => _m280Active; set => SetProperty(ref _m280Active, value); }

        private decimal _m280Min;
        public decimal M280Min { get => _m280Min; set => SetProperty(ref _m280Min, value); }

        private decimal _m280Max;
        public decimal M280Max { get => _m280Max; set => SetProperty(ref _m280Max, value); }

        private bool _mPanActive;
        public bool MPanActive { get => _mPanActive; set => SetProperty(ref _mPanActive, value); }

        private decimal _mPanMin;
        public decimal MPanMin { get => _mPanMin; set => SetProperty(ref _mPanMin, value); }

        private decimal _mPanMax;
        public decimal MPanMax { get => _mPanMax; set => SetProperty(ref _mPanMax, value); }

        private DateTime _createdAt = DateTime.Now;
        public DateTime CreatedAt { get => _createdAt; set => SetProperty(ref _createdAt, value); }

        private DateTime? _updatedAt;
        public DateTime? UpdatedAt { get => _updatedAt; set => SetProperty(ref _updatedAt, value); }
    }
}
