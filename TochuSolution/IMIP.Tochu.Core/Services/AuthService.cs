using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Mappers;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Shared.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool IsLoggedIn()
        {
            // check token / file / cache
            return false;
        }

        public async Task<UserModel?> Login(string user, string pass)
        {
            var dbUser = await _userRepository.GetByUserName(user);
            if (dbUser == null) return null; // or throw an exception
            if (PasswordHelper.VerifyPassword(pass, dbUser.PasswordHash))
            {
                // generate token / file / cache
                return dbUser.Mapping();
            }
            return null;
        }
    }
}
