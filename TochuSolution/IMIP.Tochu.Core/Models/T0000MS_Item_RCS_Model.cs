using IMIP.Tochu.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models
{
    public class T0000MS_Item_RCS_Model : NotifyBase
    {
        private string _userHinban = null!;
        public string UserHinban
        {
            get => _userHinban;
            set => SetProperty(ref _userHinban, value);
        }

        private string? _userHinmei;
        public string? UserHinmei
        {
            get => _userHinmei;
            set => SetProperty(ref _userHinmei, value);
        }
    }
}
