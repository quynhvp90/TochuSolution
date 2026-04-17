using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.Helpers
{
    public static class SecureStorage
    {
        public static void Save(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            var protectedData = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);

            File.WriteAllBytes("tochu_session.dat", protectedData);
        }

        public static string Load()
        {
            if (!File.Exists("tochu_session.dat")) return null;

            var protectedData = File.ReadAllBytes("tochu_session.dat");
            var bytes = ProtectedData.Unprotect(protectedData, null, DataProtectionScope.CurrentUser);

            return Encoding.UTF8.GetString(bytes);
        }
        public static void Remove()
        {
            if (File.Exists("tochu_session.dat"))
            {
                File.Delete("tochu_session.dat");
            }
        }
    }
}
