using IMIP.Tochu.Shared;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Markup;

namespace IMIP.Tochu.WPF.Helpers
{
    [MarkupExtensionReturnType(typeof(string))]
    public class LocExtension : MarkupExtension
    {
        public string Key { get; set; } = string.Empty;

        public LocExtension() { }
        public LocExtension(string key) { Key = key; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (App.Services == null) return Key;
            var loc = App.Services.GetRequiredService<ILocalizationService>();
            return loc.Get(Key);
        }
    }
}
