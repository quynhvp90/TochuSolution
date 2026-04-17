using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.WPF.AppData;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IMIP.Tochu.WPF.Helpers
{
    public static class Helper
    {
        public static UserModel GetUserFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var userId = jwt.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var name = jwt.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

            var email = jwt.Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            if (userId == null)
                throw new Exception("Token không chứa UserId");

            return new UserModel
            {
                Id = Guid.Parse(userId),
                Name = name,
                Email = email
            };
        }

        public static bool IsTokenExpired(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            return jwt.ValidTo < DateTime.UtcNow;
        }
        public static string CreateTokenFromUser(UserModel user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // nameid
            new Claim(ClaimTypes.Name, user.Name),                    // unique_name
            new Claim(ClaimTypes.Email, user.Email ?? "")
        };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Constants.ConfigJwt.Key)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: Constants.ConfigJwt.Issuer,
                audience: Constants.ConfigJwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12), // access token
                signingCredentials: creds
            );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return accessToken;
        }
    }
}
