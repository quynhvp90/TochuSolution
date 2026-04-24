using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.AppData
{
    public class AppDataContext : IAppDataContext
    {
        public string BranchCode { get; private set; }

        public UserModel? CurrentUser { get; private set; } = null;

        public void SetBranchCode(string branchCode)
        {
            BranchCode = branchCode;
        }

        public void SetCurrentUser(UserModel user)
        {
            CurrentUser = user;
        }
    }
}
