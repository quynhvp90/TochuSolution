using IMIP.Tochu.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMIP.Tochu.WPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : UserControl
    {
        private MainViewModel VM => (MainViewModel)DataContext;
        public Main()
        {
            InitializeComponent();
        }

        private void btnMaster_Clicked(object sender, Infragistics.Controls.Inputs.ButtonClickEventArgs args)
        {
            VM.GoToMaster();
        }

        private void btnSearch_Clicked(object sender, Infragistics.Controls.Inputs.ButtonClickEventArgs args)
        {
            VM.GoToSearch();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Master_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
