using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class RegistrationViewModel : ViewModelBaseWPF
    {

        public RegistrationViewModel(INavigationService nav, IAppDataContext appDataContext) : base(nav, appDataContext)
        {
        }
    }
}
