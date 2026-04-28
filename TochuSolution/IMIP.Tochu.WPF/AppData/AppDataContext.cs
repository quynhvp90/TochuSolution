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
        private static AppDataContext _instance;
        public static AppDataContext Instance => _instance ??= new AppDataContext();
        public string BranchCode { get; private set; }

        public SI_TANTOU_Model? CurrentUser { get; private set; } = null;

        public void SetBranchCode(string branchCode)
        {
            BranchCode = branchCode;
        }

        public void SetCurrentUser(SI_TANTOU_Model user)
        {
            CurrentUser = user;
        }
    }
}
