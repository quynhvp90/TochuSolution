using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace IMIP.Tochu.WPF.Converters
{
    public class SortIconConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is not string sortField || values[2] is not string fieldName)
                return parameter as string == "__opacity" ? 0.4 : "⇅";

            bool isActive = sortField == fieldName;

            // Opacity mode
            if (parameter as string == "__opacity")
                return isActive ? 1.0 : 0.4;

            // Icon mode
            if (!isActive) return "⇅";
            return values[1] is true ? "▲" : "▼";
        }

        public object[] ConvertBack(object[] values, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
