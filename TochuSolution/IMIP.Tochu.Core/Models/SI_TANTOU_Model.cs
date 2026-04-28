using IMIP.Tochu.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models
{
    public class SI_TANTOU_Model : NotifyBase
    {
        private string _jigyousho = null!;
        public string JIGYOUSHO
        {
            get => _jigyousho;
            set => SetProperty(ref _jigyousho, value);
        }

        private int _num;
        public int NUM
        {
            get => _num;
            set => SetProperty(ref _num, value);
        }

        private string? _text1;
        public string? TEXT1
        {
            get => _text1;
            set => SetProperty(ref _text1, value);
        }
    }
}
