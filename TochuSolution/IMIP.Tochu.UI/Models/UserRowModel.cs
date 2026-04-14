using IMIP.Tochu.Core.Models;
using IMIP.Tochu.UI.Base;

namespace IMIP.Tochu.UI.Models
{
    public partial class UserRowModel : ModelBase
    {
        public Guid Id { get; init; }

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
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

        public static UserRowModel FromDto(UserModel dto) => new()
        {
            Id = dto.Id,
            _name = dto.Name,
            _email = dto.Email,
        };
    }
}
