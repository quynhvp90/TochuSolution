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
using System.Windows.Shapes;

namespace IMIP.Tochu.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for PrintPreviewWindow.xaml
    /// </summary>
    public partial class PrintPreviewWindow : Window
    {
        public PrintPreviewWindow()
        {
            InitializeComponent();
            Loaded += PrintPreviewWindow_Loaded;
        }

        private void PrintPreviewWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is PrintPreviewViewModel vm)
            {
                vm.InitFormView(ReportContent, Close);
            }
        }
    }
}
