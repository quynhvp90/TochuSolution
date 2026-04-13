using CommunityToolkit.Mvvm.ComponentModel;
using IMIP.Tochu.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.UI.ViewModels.Users
{
    public partial class UserRowModel : ObservableObject
    {
        public Guid Id { get; init; }

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _email = string.Empty;

        [ObservableProperty]
        private bool _isSelected;      // UI-only, không có trong DTO

        [ObservableProperty]
        private bool _isEditing;       // UI-only

        // Map từ DTO — không để ViewModel làm việc này
        public static UserRowModel FromDto(UserModel dto) => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
        };
    }
}
