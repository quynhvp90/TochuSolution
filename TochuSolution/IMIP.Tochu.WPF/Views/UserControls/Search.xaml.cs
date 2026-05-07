using IMIP.Tochu.WPF.ViewModels;
using Infragistics.Windows.DataPresenter;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace IMIP.Tochu.WPF.Views.UserControls
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        private static readonly Dictionary<string, string> _fieldLabels = new()
        {
            { "JuchuuDenpyouNO", "Order No." },
            { "JuchuuYMD",       "Order Date" },
            { "Nouki",           "Delivery Date" },
            { "NouSSNM",         "Customer Name" },
            { "UserHinban",      "Customer Part No." },
            { "UserHinmei",      "Product Name" },
            { "JuchuuSuu",       "Order Qty" },
            { "NouSCD",          "Customer Code" },
            { "TankaUnitCD",     "Unit" },
            { "NisugataCD",      "Package" },
            { "Tekiyou1",        "Note" },
        };
        public Search()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
            JuchuuRCSGrid.MouseLeftButtonUp += JuchuuRCSGrid_LabelMouseUp; 
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is SearchViewModel vm)
            {
                vm.PropertyChanged += (s, args) =>
                {
                    if (args.PropertyName is nameof(vm.SortField) or nameof(vm.SortAscending))
                        UpdateSortLabels(vm);
                };
                UpdateSortLabels(vm);
            }
        }
        private void UpdateSortLabels(SearchViewModel vm)
        {
            var layout = JuchuuRCSGrid.FieldLayouts.FirstOrDefault();
            if (layout == null) return;

            foreach (var field in layout.Fields)
            {
                if (field.Name == null) continue;
                field.Label = BuildLabel(field.Name, vm.SortField, vm.SortAscending);
            }
        }

        private static string BuildLabel(string fieldName, string sortField, bool sortAscending)
        {
            if (!_fieldLabels.TryGetValue(fieldName, out var text))
                return fieldName;

            if (sortField != fieldName) return $"{text}  ⇅";
            return sortAscending ? $"{text}  ▲" : $"{text}  ▼";
        }

        private void JuchuuRCSGrid_LabelMouseUp(object sender, MouseButtonEventArgs e)
        {
            var label = FindVisualParent<LabelPresenter>(e.OriginalSource as DependencyObject);
            if (label?.Field == null) return;

            var vm = DataContext as SearchViewModel;
            vm?.OnJuchuuRCSortChanged(label.Field.Name);

            e.Handled = true;
        }

        private static T? FindVisualParent<T>(DependencyObject? child) where T : DependencyObject
        {
            while (child != null)
            {
                if (child is T match) return match;
                child = VisualTreeHelper.GetParent(child);
            }
            return null;
        }

    }
}
