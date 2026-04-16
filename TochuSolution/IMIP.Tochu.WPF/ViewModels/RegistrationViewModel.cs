using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly INavigationService _nav;

        public RegistrationViewModel(INavigationService nav)
        {
            _nav = nav;
        }
    }
}
