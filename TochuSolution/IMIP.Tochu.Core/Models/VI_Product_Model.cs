using IMIP.Tochu.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models
{
    public class VI_Product_Model : NotifyBase
    {
        private string? _userHinban;
        private string? _userHinmei;
        private string? _nouscd;
        public string? UserHinban
        {
            get => _userHinban;
            set => SetProperty(ref _userHinban, value);
        }
        public string? UserHinmei
        {
            get => _userHinmei;
            set => SetProperty(ref _userHinmei, value);
        }
        public string? NOUSCD
        {
            get => _nouscd;
            set => SetProperty(ref _nouscd, value);
        }
    }
}
