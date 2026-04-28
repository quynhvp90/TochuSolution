using IMIP.Tochu.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models
{
    public class SI_SEINOUMST_Model : NotifyBase
    {
        private string _product = null!;
        public string PRODUCT
        {
            get => _product;
            set => SetProperty(ref _product, value);
        }

        private string _nouscd = null!;
        public string NOUSCD
        {
            get => _nouscd;
            set => SetProperty(ref _nouscd, value);
        }

        private int _num;
        public int NUM
        {
            get => _num;
            set => SetProperty(ref _num, value);
        }

        private decimal? _min;
        public decimal? MIN
        {
            get => _min;
            set => SetProperty(ref _min, value);
        }

        private decimal? _max;
        public decimal? MAX
        {
            get => _max;
            set => SetProperty(ref _max, value);
        }

    }
}
