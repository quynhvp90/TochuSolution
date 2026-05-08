using IMIP.Tochu.Core.Models;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class RegistrationViewModel : ViewModelBaseWPF
    {
        private T0000RR_Juchuu_RCS_Model? _selectedJuchuuRCS;
        public T0000RR_Juchuu_RCS_Model? SelectedJuchuuRCS
        {
            get => _selectedJuchuuRCS;
            set => SetProperty(ref _selectedJuchuuRCS, value);
        }
        public RegistrationViewModel(INavigationService nav, IAppDataContext appDataContext) : base(nav, appDataContext)
        {
        }
    }
}
