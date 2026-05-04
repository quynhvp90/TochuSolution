using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class DashboardViewModel : ViewModelBaseWPF
    {
        public string UserName => $"{GetUsername()} for {BranchCode}";
        public DashboardViewModel(INavigationService navigation, IAppDataContext appDataContext) : base(navigation, appDataContext)
        {
            if (appDataContext is INotifyPropertyChanged notify)
            {
                notify.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(BranchCode))
                    {
                        OnPropertyChanged(nameof(UserName));
                    }
                };
            }
        }
    }
}
