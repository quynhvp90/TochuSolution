using IMIP.Tochu.UI.Base;
using System.Windows;

namespace IMIP.Tochu.UI.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly Func<Type, ViewModelBase> _factory;
        private readonly Func<Type, Window> _factoryWindow;
        private readonly Stack<ViewModelBase> _history = new();

        public NavigationService(Func<Type, ViewModelBase> factory, Func<Type, Window> factoryWindow)
        {
            _factory = factory;
            _factoryWindow = factoryWindow;
        }

        private ViewModelBase? _currentView;
        public ViewModelBase? CurrentView
        {
            get => _currentView;
            private set
            {
                if (_currentView == value) return;
                _currentView = value;
                CurrentViewChanged?.Invoke();
            }
        }

        public bool CanGoBack => _history.Count > 1;

        public event Action? CurrentViewChanged;
        public event EventHandler<ViewModelBase>? WindowRequested;

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
            => NavigateTo<TViewModel>(null!);

        public void NavigateTo<TViewModel>(Action<TViewModel>? configure)
            where TViewModel : ViewModelBase
        {
            var vm = Resolve<TViewModel>(configure);
            _history.Push(vm);
            CurrentView = vm;

            if (vm is IAsyncLoad loader)
                _ = loader.LoadAsync();
        }

        

        public void GoBack()
        {
            if (!CanGoBack) return;
            _history.Pop();
            CurrentView = _history.Peek();

            if (CurrentView is IAsyncLoad loader)
                _ = loader.LoadAsync();
        }

        private TViewModel Resolve<TViewModel>(Action<TViewModel>? configure)
            where TViewModel : ViewModelBase
        {
            var vm = (TViewModel)_factory(typeof(TViewModel));
            configure?.Invoke(vm);
            return vm;
        }
        private TWindow ResolveWindow<TWindow>(Action<TWindow>? configure)
            where TWindow : Window
        {
            var window = (TWindow)_factoryWindow(typeof(TWindow));
            configure?.Invoke(window);
            return window;
        }

        public void OpenWindow<TWindow, TViewModel>(Action<TViewModel>? configureVm = null, Action<TWindow>? configureWindow = null)
            where TWindow : Window
            where TViewModel : ViewModelBase
        {
            var vm = Resolve<TViewModel>(configureVm);
            if (vm is IAsyncLoad loader)
                _ = loader.LoadAsync();
            var window = ResolveWindow<TWindow>(configureWindow);
            configureWindow?.Invoke(window);
            window.DataContext = vm;
            window.Owner = Application.Current.MainWindow;
            window.Show();
        }

        public bool? OpenDialog<TWindow, TViewModel>(Action<TViewModel>? configureVm = null, Action<TWindow>? configureWindow = null)
            where TWindow : Window
            where TViewModel : ViewModelBase
        {
            var vm = Resolve<TViewModel>(configureVm);
            if (vm is IAsyncLoad loader)
                _ = loader.LoadAsync();
            var window = ResolveWindow<TWindow>(configureWindow);
            configureWindow?.Invoke(window);
            window.DataContext = vm;
            window.Owner = Application.Current.MainWindow;
            return window.ShowDialog();
        }
    }
}
