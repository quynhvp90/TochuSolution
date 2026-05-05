using IMIP.Tochu.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;

namespace IMIP.Tochu.WPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        SearchViewModel _vm;
        public SearchView(SearchViewModel vm)
        {
            InitializeComponent();
            _vm = vm;
        }

        private void SearchButton_Click(object sender, Infragistics.Controls.Inputs.ButtonClickEventArgs args)
        {
            _vm.GetJuchuuRCS();
        }
    }
}
