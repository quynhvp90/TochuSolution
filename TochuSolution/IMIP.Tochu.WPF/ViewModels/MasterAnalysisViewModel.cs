using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class MasterAnalysisViewModel : ViewModelBaseWPF
    {
        public MasterAnalysisViewModel(INavigationService navigation, IAppDataContext appDataContext) : base(navigation, appDataContext)
        {
        }
    }
}
