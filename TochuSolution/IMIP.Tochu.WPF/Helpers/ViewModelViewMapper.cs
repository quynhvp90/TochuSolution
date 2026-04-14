using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IMIP.Tochu.WPF.Helpers
{
    public static class ViewModelViewMapper
    {
        public static void Register(Assembly viewModelAssembly, Assembly viewAssembly)
        {
            var viewModels = viewModelAssembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("ViewModel"));

            foreach (var vmType in viewModels)
            {
                var viewName = vmType.Name.Replace("ViewModel", "View");

                var viewType = viewAssembly
                    .GetTypes()
                    .FirstOrDefault(v => v.IsClass &&
                                         !v.IsAbstract &&
                                         typeof(UserControl).IsAssignableFrom(v) &&
                                         v.Name == viewName);

                if (viewType == null)
                    continue;

                RegisterDataTemplate(vmType, viewType);
            }
        }

        private static void RegisterDataTemplate(Type viewModelType, Type viewType)
        {
            var factory = new FrameworkElementFactory(viewType);

            var template = new DataTemplate
            {
                DataType = viewModelType,
                VisualTree = factory
            };

            template.DataType = viewModelType;
            Application.Current.Resources.Add(new DataTemplateKey(viewModelType), template);
        }
    }
}
