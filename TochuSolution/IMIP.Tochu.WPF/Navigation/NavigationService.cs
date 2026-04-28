using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.ViewModels.Shared;
using System.Windows;

namespace IMIP.Tochu.WPF.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly Func<Type, ViewModelBaseWPF> _factory;
        private readonly Func<Type, Window> _factoryWindow;
        private readonly Stack<ViewModelBaseWPF> _history = new();

        public NavigationService(Func<Type, ViewModelBaseWPF> factory, Func<Type, Window> factoryWindow)
        {
            _factory = factory;
            _factoryWindow = factoryWindow;
        }

        private ViewModelBaseWPF? _currentView;
        public ViewModelBaseWPF? CurrentView
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
        public event EventHandler<ViewModelBaseWPF>? WindowRequested;

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBaseWPF
            => NavigateTo<TViewModel>(null!);

        public void NavigateTo<TViewModel>(Action<TViewModel>? configure)
            where TViewModel : ViewModelBaseWPF
        {
            CurrentView?.NavigatedFrom();

            var vm = Resolve<TViewModel>(configure);
            _history.Push(vm);
            CurrentView = vm;
            vm.NavigatedTo(isBack: false);

            if (vm is IAsyncLoad loader)
                _ = loader.LoadAsync();

            CurrentViewChanged?.Invoke();
        }

        

        public void GoBack()
        {
            if (!CanGoBack) return;
            CurrentView?.NavigatedFrom();

            _history.Pop();
            CurrentView = _history.Peek();
            CurrentView.NavigatedTo(isBack: true); // 🔥 back

            if (CurrentView is IAsyncLoad loader)
                _ = loader.LoadAsync();
            CurrentViewChanged?.Invoke();
        }

        private TViewModel Resolve<TViewModel>(Action<TViewModel>? configure)
            where TViewModel : ViewModelBaseWPF
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
            where TViewModel : ViewModelBaseWPF
        {
            var vm = Resolve<TViewModel>(configureVm);
            if (vm is IAsyncLoad loader)
                _ = loader.LoadAsync();
            var window = ResolveWindow<TWindow>(configureWindow);
            configureWindow?.Invoke(window);
            window.DataContext = vm;
            window.Show();
        }

        public bool? OpenDialog<TWindow, TViewModel>(Action<TViewModel>? configureVm = null, Action<TWindow>? configureWindow = null)
            where TWindow : Window
            where TViewModel : ViewModelBaseWPF
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
