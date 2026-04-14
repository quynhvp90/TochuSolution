using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMIP.Tochu.UI.ViewModels
{
    public class MasterViewModel : ViewModelBase
    {
        private readonly INavigationService _nav;

        public string MasterName { get; set; }

        public ICommand GoBackCommand { get; }

        public MasterViewModel(INavigationService nav)
        {
            _nav = nav;

            GoBackCommand = new RelayCommand(() => _nav.GoBack());
        }
    }
}
