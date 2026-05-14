using IMIP.Tochu.Shared;
using IMIP.Tochu.WPF.ViewModels;
using Infragistics.Windows.DataPresenter;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace IMIP.Tochu.WPF.Views.UserControls
{
    public partial class Search : UserControl
    {
        private static readonly Dictionary<string, string> _fieldKeys = new()
        {
            { "JuchuuDenpyouNO", "Col_OrderNo" },
            { "JuchuuYMD",       "Col_OrderDate" },
            { "Nouki",           "Col_DeliveryDate" },
            { "NouSSNM",         "Col_CustomerName" },
            { "UserHinban",      "Col_CustomerPartNo" },
            { "UserHinmei",      "Col_ProductName" },
            { "JuchuuSuu",       "Col_OrderQty" },
            { "NouSCD",          "Col_CustomerCode" },
            { "TankaUnitCD",     "Col_Unit" },
            { "NisugataCD",      "Col_Package" },
            { "Tekiyou1",        "Col_Note" },
        };

        private static readonly Dictionary<string, string> _seninouFieldKeys = new()
        {
            { "JUCHUUNO", "Col_OrderNo" },
            { "NOUSCD",   "Col_Code" },
            { "NUM",      "Col_Sequence" },
            { "LOTNO",    "Col_LotNo" },
            { "PRINTDT",  "Col_PrintDate" },
        };

        public Search()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            DataContextChanged += OnDataContextChanged;
            JuchuuRCSGrid.MouseLeftButtonUp += JuchuuRCSGrid_LabelMouseUp;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var loc = App.Services?.GetService<ILocalizationService>();
            if (loc == null) return;

            var layout = SeninouDataGrid.FieldLayouts.FirstOrDefault();
            if (layout == null) return;

            foreach (var field in layout.Fields)
            {
                if (field.Name != null && _seninouFieldKeys.TryGetValue(field.Name, out var key))
                    field.Label = loc.Get(key);
            }
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
            if (!_fieldKeys.TryGetValue(fieldName, out var key))
                return fieldName;

            var loc = App.Services?.GetService<ILocalizationService>();
            var text = loc != null ? loc.Get(key) : key;

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
