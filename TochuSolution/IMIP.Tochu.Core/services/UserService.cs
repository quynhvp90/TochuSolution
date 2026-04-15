using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;   
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserModel> UpdateFieldAsync(Guid id, string field, object value)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            var prop = typeof(User).GetProperty(field);
            if (prop == null) return null;
            prop.SetValue(user, value);
            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();
            return new UserModel()
            {
                Id = user.Id,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive
            };
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserModel
            {
                Id = u.Id,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt,
                Name = u.Name,
                Email = u.Email,
                IsActive = u.IsActive
            }).ToList();
        }

        public async Task<UserModel> UpdateAsync(UserModel user)
        {
            var userEntity = await _userRepository.GetByIdAsync(user.Id);
            if (userEntity == null) return null;
            userEntity.Name = user.Name;
            userEntity.Email = user.Email;
            _userRepository.Update(userEntity);
            await _unitOfWork.CommitAsync();
            return new UserModel()
            {
                Id = userEntity.Id,
                CreatedAt = userEntity.CreatedAt,
                UpdatedAt = userEntity.UpdatedAt,
                Name = userEntity.Name,
                Email = userEntity.Email,
                IsActive = userEntity.IsActive
            };
        }

        public async Task<UserModel> CreateAsync(UserModel user)
        {
            var userEntity = new User()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive
            };
            if (!string.IsNullOrEmpty(user.PasswordHash))
            {
                userEntity.PasswordHash = user.PasswordHash;
            }
            _userRepository.Add(userEntity);
            await _unitOfWork.CommitAsync();
            return new UserModel()
            {
                Id = userEntity.Id,
                CreatedAt = userEntity.CreatedAt,
                UpdatedAt = userEntity.UpdatedAt,
                Name = userEntity.Name,
                Email = userEntity.Email,
                IsActive = userEntity.IsActive
            };
        }

        public async Task<List<UserModel>> GetUsersAsync(string keyword)
        {
            var users = _userRepository.Query();
            users = users.Where(u => u.Name.Contains(keyword) || u.Email.Contains(keyword));
            users = users.OrderByDescending(u => u.CreatedAt);
            var userList = await users.ToListAsync();
            return userList.Select(u => new UserModel
            {
                Id = u.Id,
                CreatedAt = u.CreatedAt,
                UpdatedAt = u.UpdatedAt,
                Name = u.Name,
                Email = u.Email,
                IsActive = u.IsActive
            }).ToList();
        }
    }
}
