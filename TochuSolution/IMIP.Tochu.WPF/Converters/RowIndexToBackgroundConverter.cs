using Infragistics.Windows.DataPresenter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace IMIP.Tochu.WPF.Converters
{
    public class RowIndexToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DataRecord record)
            {
                return record.DataItemIndex % 2 == 0
                    ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"))
                    : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EEF4FB"));
            }
            return Brushes.White;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
