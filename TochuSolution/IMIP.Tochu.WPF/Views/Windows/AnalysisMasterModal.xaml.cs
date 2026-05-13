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
    /// Interaction logic for AnalysisMasterModal.xaml
    /// </summary>
    public partial class AnalysisMasterModal : Window
    {
        public AnalysisMasterModal()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is AnalysisMasterModalViewModel vm)
            {
                // RequestClose từ VM → đóng dialog, DialogResult = true nếu có selection
                vm.RequestClose += (nouscd) =>
                {
                    DialogResult = !string.IsNullOrEmpty(nouscd);
                    // Gọi Close() không cần thiết vì set DialogResult tự close dialog
                };
            }
        }

        private void MasterGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is AnalysisMasterModalViewModel vm)
            {
                vm.SelectCommand.Execute(null);
            }
        }
    }
}
