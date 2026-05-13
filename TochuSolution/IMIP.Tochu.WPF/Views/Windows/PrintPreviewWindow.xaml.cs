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
        public PrintPreviewWindow(ReportViewModel reportVm)
        {
            InitializeComponent();

            // Truyền ReportContent (visual) và Close action vào ViewModel
            var vm = new PrintPreviewViewModel(reportVm, ReportContent, Close);
            DataContext = vm;

            // Bind ReportContent.DataContext riêng cho ReportView
            ReportContent.DataContext = reportVm;
        }
    }
}
