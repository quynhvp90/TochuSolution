using IMIP.Tochu.WPF.ViewModels;
using System.Windows;

namespace IMIP.Tochu.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            _vm = vm;
            vm._navigation.NavigateTo<DashboardViewModel>();
        }

        private void btnSearch_Clicked(object sender, Infragistics.Controls.Inputs.ButtonClickEventArgs args)
        {
            _vm._navigation.NavigateTo<SearchViewModel>();
        }

        private void btnMaster_Clicked(object sender, Infragistics.Controls.Inputs.ButtonClickEventArgs args)
        {
            _vm._navigation.NavigateTo<MasterViewModel>();
        }


        private void btnAnalysisMaster_Clicked(object sender, Infragistics.Controls.Inputs.ButtonClickEventArgs args)
        {
            _vm._navigation.NavigateTo<MasterAnalysisViewModel>();
        }
    }
}