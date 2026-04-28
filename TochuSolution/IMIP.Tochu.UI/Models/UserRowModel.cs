using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Shared;
using IMIP.Tochu.UI.Base;

namespace IMIP.Tochu.UI.Models
{
    public partial class SITantouRowModel : NotifyBase
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

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        private bool _isEditing;


        public bool IsEditing
        {
            get => _isEditing;
            set => SetProperty(ref _isEditing, value);
        }

        public static SITantouRowModel FromDto(SI_TANTOU_Model dto) => new()
        {
            JIGYOUSHO = dto.JIGYOUSHO,
            NUM = dto.NUM,
            TEXT1 = dto.TEXT1,
        };
    }
}
