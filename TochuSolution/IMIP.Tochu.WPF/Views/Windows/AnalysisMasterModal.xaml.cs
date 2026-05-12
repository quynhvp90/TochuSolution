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
        public AnalysisMasterModal(string productName)
        {
            InitializeComponent();

            var vm = new AnalysisMasterModalViewModel(productName);

            // When the ViewModel requests close, close this window
            vm.RequestClose += (selectedNouscd) =>
            {
                SelectedNouscd = selectedNouscd;
                DialogResult = selectedNouscd != null;
                Close();
            };

            DataContext = vm;
        }

        /// <summary>
        /// The NOUSCD value selected by the user. Null if cancelled.
        /// </summary>
        public string? SelectedNouscd { get; private set; }

        private void MasterGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is AnalysisMasterModalViewModel vm)
            {
                vm.SelectCommand.Execute(null);
            }
        }
    }
}
