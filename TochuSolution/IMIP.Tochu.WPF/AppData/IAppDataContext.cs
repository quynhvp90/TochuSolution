using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.AppData
{
    public interface IAppDataContext
    {
        string BranchCode { get; }
        UserModel? CurrentUser { get; }
        void SetBranchCode(string branchCode);
        void SetCurrentUser(UserModel user);
    }
}
