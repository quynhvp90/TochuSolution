using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.AppData
{
    public class AppDataContext : IAppDataContext, INotifyPropertyChanged
    {
        private string _branchCode;

        public string BranchCode
        {
            get => _branchCode;
            set
            {
                if (_branchCode != value)
                {
                    _branchCode = value;
                    OnPropertyChanged(nameof(BranchCode));
                }
            }
        }

        public SI_TANTOU_Model? CurrentUser { get; private set; } = null;

        public void SetCurrentUser(SI_TANTOU_Model user)
        {
            CurrentUser = user;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
