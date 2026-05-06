using IMIP.Tochu.Shared;
using System;

namespace IMIP.Tochu.Core.Models
{
    public class T0000RR_Juchuu_RCS_Model : NotifyBase
    {
        #region Private Fields

        private int _juchuuNO;
        private int _juchuuDenpyouNO;

        private string? _juchuuKyotenCD;
        private string? _juchuuKyotenNM;

        private DateTime? _juchuuYMD;
        private DateTime? _nouki;

        private string? _shukkaKyotenCD;
        private string? _shukkaBashoCD;

        private string? _juchuuKBN;
        private string? _haisouCD;
        private string? _chikuCD;

        private string? _nouSCD;
        private string? _nouSSNM;

        private string? _userHinban;
        private string? _userHinmei;

        private string? _itemCD;
        private string? _itemNM;

        private int? _juchuuSuu;

        private string? _nisugataCD;
        private string? _uriKeitaiKBN;

        private string? _tekiyou1;
        private string? _tankaUnitCD;

        #endregion

        #region Public Properties

        public int JuchuuNO
        {
            get => _juchuuNO;
            set => SetProperty(ref _juchuuNO, value);
        }

        public int JuchuuDenpyouNO
        {
            get => _juchuuDenpyouNO;
            set => SetProperty(ref _juchuuDenpyouNO, value);
        }

        public string? JuchuuKyotenCD
        {
            get => _juchuuKyotenCD;
            set => SetProperty(ref _juchuuKyotenCD, value);
        }

        public string? JuchuuKyotenNM
        {
            get => _juchuuKyotenNM;
            set => SetProperty(ref _juchuuKyotenNM, value);
        }

        public DateTime? JuchuuYMD
        {
            get => _juchuuYMD;
            set => SetProperty(ref _juchuuYMD, value);
        }

        public DateTime? Nouki
        {
            get => _nouki;
            set => SetProperty(ref _nouki, value);
        }

        public string? ShukkaKyotenCD
        {
            get => _shukkaKyotenCD;
            set => SetProperty(ref _shukkaKyotenCD, value);
        }

        public string? ShukkaBashoCD
        {
            get => _shukkaBashoCD;
            set => SetProperty(ref _shukkaBashoCD, value);
        }

        public string? JuchuuKBN
        {
            get => _juchuuKBN;
            set => SetProperty(ref _juchuuKBN, value);
        }

        public string? HaisouCD
        {
            get => _haisouCD;
            set => SetProperty(ref _haisouCD, value);
        }

        public string? ChikuCD
        {
            get => _chikuCD;
            set => SetProperty(ref _chikuCD, value);
        }

        public string? NouSCD
        {
            get => _nouSCD;
            set => SetProperty(ref _nouSCD, value);
        }

        public string? NouSSNM
        {
            get => _nouSSNM;
            set => SetProperty(ref _nouSSNM, value);
        }

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

        public string? ItemCD
        {
            get => _itemCD;
            set => SetProperty(ref _itemCD, value);
        }

        public string? ItemNM
        {
            get => _itemNM;
            set => SetProperty(ref _itemNM, value);
        }

        public int? JuchuuSuu
        {
            get => _juchuuSuu;
            set => SetProperty(ref _juchuuSuu, value);
        }

        public string? NisugataCD
        {
            get => _nisugataCD;
            set => SetProperty(ref _nisugataCD, value);
        }

        public string? UriKeitaiKBN
        {
            get => _uriKeitaiKBN;
            set => SetProperty(ref _uriKeitaiKBN, value);
        }

        public string? Tekiyou1
        {
            get => _tekiyou1;
            set => SetProperty(ref _tekiyou1, value);
        }

        public string? TankaUnitCD
        {
            get => _tankaUnitCD;
            set => SetProperty(ref _tankaUnitCD, value);
        }

        #endregion
    }
}