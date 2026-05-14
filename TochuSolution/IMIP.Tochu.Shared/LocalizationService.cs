using System.Globalization;
using System.Resources;

namespace IMIP.Tochu.Shared
{
    public interface ILocalizationService
    {
        string Get(string key);
        CultureInfo CurrentCulture { get; }
    }

    public class LocalizationService : ILocalizationService
    {
        private readonly ResourceManager _rm;
        public CultureInfo CurrentCulture { get; }

        public LocalizationService(string locale, ResourceManager resourceManager)
        {
            CurrentCulture = new CultureInfo(locale);
            _rm = resourceManager;
        }

        public string Get(string key) =>
            _rm.GetString(key, CurrentCulture) ?? key;
    }
}
