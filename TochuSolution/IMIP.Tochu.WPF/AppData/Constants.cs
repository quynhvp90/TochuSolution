using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.AppData
{
    public static class Constants
    {
        public static readonly Jwt ConfigJwt = new() { Audience = "tochu-audience", Issuer = "tochu-issuer", Key = "Tochu-HUOK-JKLN-DFSF-NSDV-9Hu7-3FDS-32DS-FHGS-7G8D-HJ78-BNV3-HJKS" };
    }
    public class Jwt
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }
}
