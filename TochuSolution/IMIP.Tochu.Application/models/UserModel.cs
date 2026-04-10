using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Application.Models
{
    public class UserModel : BaseModel
    {
        private Guid _id;
        public Guid Id { get => _id; set => SetProperty(ref _id, value); }
        private DateTime _createdAt;
        public DateTime CreatedAt { get => _createdAt; set => SetProperty(ref _createdAt, value); }
        private DateTime? _updatedAt;
        public DateTime? UpdatedAt { get => _updatedAt; set => SetProperty(ref _updatedAt, value); }
        private string _name;
        public string Name { get => _name; set => SetProperty(ref _name,  value); }
        private string _email;
        public string Email { get => _email; set => SetProperty(ref _email, value); }
        private string _passwordHash;
        public string PasswordHash { get => _passwordHash; set => SetProperty(ref _passwordHash, value); }
        private bool _isActive;
        public bool IsActive { get => _isActive; set => SetProperty(ref _isActive, value); }
    }
}
