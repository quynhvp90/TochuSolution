using IMIP.Tochu.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models
{
    public class SI_CODEMST_Model : NotifyBase
    {
        private string _kbn = null!;
        public string KBN
        {
            get => _kbn;
            set => SetProperty(ref _kbn, value);
        }

        private int _id;
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _nm = null!;
        public string NM
        {
            get => _nm;
            set => SetProperty(ref _nm, value);
        }

        private int _enum;
        public int ENUM
        {
            get => _enum;
            set => SetProperty(ref _enum, value);
        }

        private string? _eyobi;
        public string? EYOBI
        {
            get => _eyobi;
            set => SetProperty(ref _eyobi, value);
        }
    }
}
