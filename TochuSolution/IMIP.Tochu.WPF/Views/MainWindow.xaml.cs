using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using IMIP.Tochu.WPF.ViewModels;
using System.Windows;

namespace IMIP.Tochu.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}