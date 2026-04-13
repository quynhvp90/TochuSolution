using CommunityToolkit.Mvvm.ComponentModel;
using IMIP.Tochu.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.UI.Navigation
{
    public partial class NavigationService : ObservableObject, INavigationService
    {
        private readonly Func<Type, ViewModelBase> _vmFactory;
        private readonly Stack<ViewModelBase> _history = new();

        // Func<Type, ViewModelBase> được inject từ DI container
        public NavigationService(Func<Type, ViewModelBase> vmFactory)
        {
            _vmFactory = vmFactory;
        }

        [ObservableProperty]
        private ViewModelBase? _currentPage;

        public bool CanGoBack => _history.Count > 1;

        Action<object, object> INavigationService.PropertyChanged { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
            => NavigateTo<TViewModel>(null!);

        public void NavigateTo<TViewModel>(Action<TViewModel>? configure)
            where TViewModel : ViewModelBase
        {
            var vm = (TViewModel)_vmFactory(typeof(TViewModel));
            configure?.Invoke(vm);          // truyền param vào VM trước khi hiển thị

            _history.Push(vm);
            CurrentPage = vm;

            // Gọi LoadAsync nếu VM có implement
            if (vm is IAsyncLoad asyncLoad)
                _ = asyncLoad.LoadAsync();
        }

        public void GoBack()
        {
            if (!CanGoBack) return;
            _history.Pop();
            CurrentPage = _history.Peek();
        }
    }
}
