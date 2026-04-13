using IMIP.Tochu.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.UI.Navigation
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
        void NavigateTo<TViewModel>(Action<TViewModel> configure)
            where TViewModel : ViewModelBase;
        void GoBack();
        bool CanGoBack { get; }
        Action<object, object> PropertyChanged { get; set; }
    }
}
