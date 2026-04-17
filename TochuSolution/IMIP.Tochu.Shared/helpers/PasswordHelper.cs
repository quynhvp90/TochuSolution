using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Shared.helpers
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16;     // 128 bit
        private const int KeySize = 32;      // 256 bit
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

        // format lưu: {iterations}.{salt}.{hash}
        public static string HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                Algorithm,
                KeySize);

            return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split('.', 3);
            if (parts.Length != 3) return false;

            var iterations = int.Parse(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var hash = Convert.FromBase64String(parts[2]);

            var inputHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                Algorithm,
                hash.Length);

            return CryptographicOperations.FixedTimeEquals(hash, inputHash);
        }
    }
}
