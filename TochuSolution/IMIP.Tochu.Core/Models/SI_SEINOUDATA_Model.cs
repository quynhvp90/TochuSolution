using IMIP.Tochu.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models
{
    public class SI_SEINOUDATA_Model : NotifyBase
    {
        private int _juchuuno;
        public int JUCHUUNO
        {
            get => _juchuuno;
            set => SetProperty(ref _juchuuno, value);
        }

        private int _num;
        public int NUM
        {
            get => _num;
            set => SetProperty(ref _num, value);
        }

        private string? _lotno;
        public string? LOTNO
        {
            get => _lotno;
            set => SetProperty(ref _lotno, value);
        }

        private string? _userHinban;
        public string? USERHINBAN
        {
            get => _userHinban;
            set => SetProperty(ref _userHinban, value);
        }

        private string _nouscd = null!;
        public string NOUSCD
        {
            get => _nouscd;
            set => SetProperty(ref _nouscd, value);
        }

        private decimal? _t10;
        public decimal? T10
        {
            get => _t10;
            set => SetProperty(ref _t10, value);
        }

        private decimal? _t20;
        public decimal? T20
        {
            get => _t20;
            set
            {
                if (SetProperty(ref _t20, value))
                {
                    if (value.HasValue)
                    {
                        MA20 = Math.Round(value.Value * 9.80665m, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        MA20 = null;
                    }
                }
            }
        }

        private decimal? _t30;
        public decimal? T30
        {
            get => _t30;
            set
            {
                if (SetProperty(ref _t30, value))
                {
                    if (value.HasValue)
                    {
                        MA30 = Math.Round(value.Value * 9.80665m, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        MA30 = null;
                    }
                }
            }
        }

        private decimal? _t40;
        public decimal? T40
        {
            get => _t40;
            set => SetProperty(ref _t40, value);
        }

        private decimal? _t50;
        public decimal? T50
        {
            get => _t50;
            set => SetProperty(ref _t50, value);
        }
        private decimal? _t60;
        public decimal? T60
        {
            get => _t60;
            set => SetProperty(ref _t60, value);
        }
        private decimal? _t70;
        public decimal? T70
        {
            get => _t70;
            set => SetProperty(ref _t70, value);
        }
        private decimal? _t80;
        public decimal? T80
        {
            get => _t80;
            set => SetProperty(ref _t80, value);
        }
        private decimal? _t90;
        public decimal? T90
        {
            get => _t90;
            set => SetProperty(ref _t90, value);
        }
        private decimal? _t100;
        public decimal? T100
        {
            get => _t100;
            set => SetProperty(ref _t100, value);
        }
        private decimal? _t110;
        public decimal? T110
        {
            get => _t110;
            set => SetProperty(ref _t110, value);
        }
        private decimal? _t120;
        public decimal? T120
        {
            get => _t120;
            set => SetProperty(ref _t120, value);
        }
        private decimal? _t130;
        public decimal? T130
        {
            get => _t130;
            set => SetProperty(ref _t130, value);
        }
        private decimal? _t140;
        public decimal? T140
        {
            get => _t140;
            set => SetProperty(ref _t140, value);
        }
        private decimal? _t150;
        public decimal? T150
        {
            get => _t150;
            set => SetProperty(ref _t150, value);
        }
        private decimal? _t160;
        public decimal? T160
        {
            get => _t160;
            set => SetProperty(ref _t160, value);
        }

        private DateTime? _uptime;
        public DateTime? UPTIME
        {
            get => _uptime;
            set => SetProperty(ref _uptime, value);
        }

        private DateTime? _nouki;
        public DateTime? NOUKI
        {
            get => _nouki;
            set => SetProperty(ref _nouki, value);
        }

        private string? _noussnm;
        public string? NOUSSNM
        {
            get => _noussnm;
            set => SetProperty(ref _noussnm, value);
        }

        private string? _nisugatacd;
        public string? NISUGATACD
        {
            get => _nisugatacd;
            set => SetProperty(ref _nisugatacd, value);
        }

        private int? _juchusuu;
        public int? JUCHUSUU
        {
            get => _juchusuu;
            set => SetProperty(ref _juchusuu, value);
        }

        private string? _suujp;
        public string? SUUJP
        {
            get => _suujp;
            set => SetProperty(ref _suujp, value);
        }

        private string? _tantou1;
        public string? TANTOU1
        {
            get => _tantou1;
            set => SetProperty(ref _tantou1, value);
        }

        private string? _tantou2;
        public string? TANTOU2
        {
            get => _tantou2;
            set => SetProperty(ref _tantou2, value);
        }

        private string? _tantou3;
        public string? TANTOU3
        {
            get => _tantou3;
            set => SetProperty(ref _tantou3, value);
        }

        private string? _comm;
        public string? COMM
        {
            get => _comm;
            set => SetProperty(ref _comm, value);
        }

        private DateTime? _printdt;
        public DateTime? PRINTDT
        {
            get => _printdt;
            set => SetProperty(ref _printdt, value);
        }

        private decimal? _ma150;
        public decimal? MA150
        {
            get => _ma150;
            set => SetProperty(ref _ma150, value);
        }

        private decimal? _ma20;
        public decimal? MA20
        {
            get => _ma20;
            set => SetProperty(ref _ma20, value);
        }

        private decimal? _ma30;
        public decimal? MA30
        {
            get => _ma30;
            set => SetProperty(ref _ma30, value);
        }
    }
}
