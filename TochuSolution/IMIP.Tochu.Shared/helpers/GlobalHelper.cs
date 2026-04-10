using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace IMIP.Tochu.Shared.Helpers
{
    public static class GlobalHelper
    {
        private static readonly Random _random = new Random();
        public static decimal RandomFloat2Decimal(decimal a, decimal b)
        {
            if (a > b)
            {
                decimal temp = a;
                a = b;
                b = temp;
            }
            int minInt = (int)Math.Round(a * 100);
            int maxInt = (int)Math.Round(b * 100);

            int valueInt = _random.Next(minInt, maxInt + 1);

            return (decimal)(valueInt / 100f);
        }
        public static int GetSize(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var matches = Regex.Matches(text, @"\d+");

            if (matches.Count != 1)
                return 0;

            return int.Parse(matches[0].Value);
        }
        public static bool Between(double a, double b, double value)
        {
            try
            {
                if (a > b)
                {
                    var temp = a; a = b; b = temp;
                }
                if (value >= a && value <= b) return true;
                return false;
            }
            catch (Exception ex) {
                return false;
            }
        }
        public static bool CheckFieldName<TSource>(string field)
        {
            var result = false;
            var destProps = typeof(TSource).GetProperties();

            foreach (var prop in destProps) {
                if (prop.Name == field) {
                    result = true; break;
                }
            }

            return result;
        }
        public static void MapMatchingProperties<TSource, TDestination>(TSource source, TDestination destination)
        {
            if (source == null || destination == null) return;

            var sourceProps = typeof(TSource).GetProperties();
            var destProps = typeof(TDestination).GetProperties();

            // Convert destProps thành dictionary để lookup nhanh
            var destDict = destProps.ToDictionary(p => p.Name);

            foreach (var sProp in sourceProps)
            {
                // Check có tồn tại property cùng tên không
                if (destDict.TryGetValue(sProp.Name, out var dProp))
                {
                    // Check writable + cùng kiểu
                    if (dProp.CanWrite && dProp.PropertyType == sProp.PropertyType)
                    {
                        var value = sProp.GetValue(source);
                        dProp.SetValue(destination, value);
                    }
                }
            }
        }
        public static IQueryable<T> OrderByField<T>(
        this IQueryable<T> query,
        string fieldName,
        bool descending = false)
        {
            var param = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(param, fieldName);
            var lambda = Expression.Lambda(property, param);

            string methodName = descending ? "OrderByDescending" : "OrderBy";

            var result = Expression.Call(
                typeof(Queryable),
                methodName,
                new Type[] { typeof(T), property.Type },
                query.Expression,
                Expression.Quote(lambda)
            );

            return query.Provider.CreateQuery<T>(result);
        }
    }
}
