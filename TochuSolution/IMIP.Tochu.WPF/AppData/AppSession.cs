using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.AppData
{
    public static class AppSession
    {
        public static UserModel? CurrentUser { get; set; } = null;
    }
}
