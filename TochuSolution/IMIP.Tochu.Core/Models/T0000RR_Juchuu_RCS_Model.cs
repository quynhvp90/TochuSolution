using IMIP.Tochu.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Models
{
    public class T0000RR_Juchuu_RCS_Model : NotifyBase
    {
        private int _juchuuNO;
        public int JuchuuNO
        {
            get => _juchuuNO;
            set => SetProperty(ref _juchuuNO, value);
        }

        private int _juchuuDenpyouNO;
        public int JuchuuDenpyouNO
        {
            get => _juchuuDenpyouNO;
            set => SetProperty(ref _juchuuDenpyouNO, value);
        }

        private string? _juchuuKyotenCD;
        public string? JuchuuKyotenCD
        {
            get => _juchuuKyotenCD;
            set => SetProperty(ref _juchuuKyotenCD, value);
        }

        private string? _juchuuKyotenNM;
        public string? JuchuuKyotenNM
        {
            get => _juchuuKyotenNM;
            set => SetProperty(ref _juchuuKyotenNM, value);
        }

        private DateTime? _juchuuYMD;
        public DateTime? JuchuuYMD
        {
            get => _juchuuYMD;
            set => SetProperty(ref _juchuuYMD, value);
        }

        private DateTime? _nouki;
        public DateTime? Nouki
        {
            get => _nouki;
            set => SetProperty(ref _nouki, value);
        }

        private string? _shukkaKyotenCD;
        public string? ShukkaKyotenCD
        {
            get => _shukkaKyotenCD;
            set => SetProperty(ref _shukkaKyotenCD, value);
        }

        private string? _shukkaBashoCD;
        public string? ShukkaBashoCD
        {
            get => _shukkaBashoCD;
            set => SetProperty(ref _shukkaBashoCD, value);
        }

        private string? _juchuuKBN;
        public string? JuchuuKBN
        {
            get => _juchuuKBN;
            set => SetProperty(ref _juchuuKBN, value);
        }

        private string? _haisouCD;
        public string? HaisouCD
        {
            get => _haisouCD;
            set => SetProperty(ref _haisouCD, value);
        }

        private string? _chikuCD;
        public string? ChikuCD
        {
            get => _chikuCD;
            set => SetProperty(ref _chikuCD, value);
        }

        private string? _nouSCD;
        public string? NouSCD
        {
            get => _nouSCD;
            set => SetProperty(ref _nouSCD, value);
        }

        private string? _nouSSNM;
        public string? NouSSNM
        {
            get => _nouSSNM;
            set => SetProperty(ref _nouSSNM, value);
        }

        private string? _userHinban;
        public string? UserHinban
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

        private string? _itemCD;
        public string? ItemCD
        {
            get => _itemCD;
            set => SetProperty(ref _itemCD, value);
        }

        private string? _itemNM;
        public string? ItemNM
        {
            get => _itemNM;
            set => SetProperty(ref _itemNM, value);
        }

        private int? _juchuuSuu;
        public int? JuchuuSuu
        {
            get => _juchuuSuu;
            set => SetProperty(ref _juchuuSuu, value);
        }

        private string? _nisugataCD;
        public string? NisugataCD
        {
            get => _nisugataCD;
            set => SetProperty(ref _nisugataCD, value);
        }

        private string? _uriKeitaiKBN;
        public string? UriKeitaiKBN
        {
            get => _uriKeitaiKBN;
            set => SetProperty(ref _uriKeitaiKBN, value);
        }

        private string? _tekiyou1;
        public string? Tekiyou1
        {
            get => _tekiyou1;
            set => SetProperty(ref _tekiyou1, value);
        }

        private string? _tankaUnitCD;
        public string? TankaUnitCD
        {
            get => _tankaUnitCD;
            set => SetProperty(ref _tankaUnitCD, value);
        }
    }

}
