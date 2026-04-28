using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Shared.helpers
{
    public static class ExcelHelper
    {
        public static List<Dictionary<string, object>> ReadExcelToJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found", filePath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage(new FileInfo(filePath));
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null)
                throw new Exception("NotFound worksheet");

            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

            var result = new List<Dictionary<string, object>>();

            // get header (row 1)
            var headers = new List<string>();
            for (int col = 1; col <= colCount; col++)
            {
                var header = worksheet.Cells[1, col].Text?.Trim();

                if (string.IsNullOrEmpty(header))
                    header = $"Column{col}";

                headers.Add(header);
            }

            // get data (row >= 2)
            for (int row = 2; row <= rowCount; row++)
            {
                var rowData = new Dictionary<string, object>();

                for (int col = 1; col <= colCount; col++)
                {
                    var value = worksheet.Cells[row, col].Value;
                    rowData[headers[col - 1]] = value;
                }

                result.Add(rowData);
            }

            return result;
        }
        public static List<T> ReadExcel<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File Not Found", filePath);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using var package = new ExcelPackage(new FileInfo(filePath));
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null)
                throw new Exception("Worksheet Not Found");

            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

            // Get header
            var headers = new Dictionary<int, string>();
            for (int col = 1; col <= colCount; col++)
            {
                var header = worksheet.Cells[1, col].Text?.Trim();
                if (!string.IsNullOrEmpty(header))
                    headers[col] = header;
            }

            // Mapping property
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var propMap = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<ExcelColumnAttribute>();
                var name = attr?.Name ?? prop.Name;

                propMap[name] = prop;
            }

            var result = new List<T>();

            // Read data
            for (int row = 2; row <= rowCount; row++)
            {
                var item = new T();

                foreach (var col in headers)
                {
                    var headerName = col.Value;

                    if (!propMap.ContainsKey(headerName))
                        continue;

                    var prop = propMap[headerName];
                    var cellValue = worksheet.Cells[row, col.Key].Value;

                    if (cellValue == null)
                        continue;

                    try
                    {
                        var convertedValue = ConvertToPropertyType(cellValue, prop.PropertyType);
                        prop.SetValue(item, convertedValue);
                    }
                    catch
                    {
                        // Log warning or ignore conversion errors
                        continue;
                    }
                }

                result.Add(item);
            }

            return result;
        }

        private static object ConvertToPropertyType(object value, Type targetType)
        {
            if (value == null) return null;

            var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            if (underlyingType == typeof(string))
                return value.ToString();

            if (underlyingType == typeof(int))
                return Convert.ToInt32(value);

            if (underlyingType == typeof(double))
                return Convert.ToDouble(value);

            if (underlyingType == typeof(decimal))
                return Convert.ToDecimal(value);

            if (underlyingType == typeof(bool))
            {
                if (value is string str)
                    return str == "1" || str.Equals("true", StringComparison.OrdinalIgnoreCase);

                return Convert.ToBoolean(value);
            }

            if (underlyingType == typeof(DateTime))
                return Convert.ToDateTime(value);

            // fallback
            return Convert.ChangeType(value, underlyingType);
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelColumnAttribute : Attribute
    {
        public string Name { get; }

        public ExcelColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
