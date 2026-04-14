using IMIP.Tochu.UI.Base;

namespace IMIP.Tochu.UI.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly Func<Type, ViewModelBase> _factory;
        private readonly Stack<ViewModelBase> _history = new();

        public NavigationService(Func<Type, ViewModelBase> factory)
        {
            _factory = factory;
        }

        private ViewModelBase? _currentPage;
        public ViewModelBase? CurrentPage
        {
            get => _currentPage;
            private set
            {
                if (_currentPage == value) return;
                _currentPage = value;
                CurrentPageChanged?.Invoke();
            }
        }

        public bool CanGoBack => _history.Count > 1;

        public event Action? CurrentPageChanged;
        public event EventHandler<ViewModelBase>? WindowRequested;

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
            => NavigateTo<TViewModel>(null!);

        public void NavigateTo<TViewModel>(Action<TViewModel>? configure)
            where TViewModel : ViewModelBase
        {
            var vm = Resolve<TViewModel>(configure);
            _history.Push(vm);
            CurrentPage = vm;

            if (vm is IAsyncLoad loader)
                _ = loader.LoadAsync();
        }

        public void OpenWindow<TViewModel>() where TViewModel : ViewModelBase
            => OpenWindow<TViewModel>(null!);

        public void OpenWindow<TViewModel>(Action<TViewModel>? configure)
            where TViewModel : ViewModelBase
        {
            var vm = Resolve<TViewModel>(configure);
            WindowRequested?.Invoke(this, vm);
        }

        public void GoBack()
        {
            if (!CanGoBack) return;
            _history.Pop();
            CurrentPage = _history.Peek();

            if (CurrentPage is IAsyncLoad loader)
                _ = loader.LoadAsync();
        }

        private TViewModel Resolve<TViewModel>(Action<TViewModel>? configure)
            where TViewModel : ViewModelBase
        {
            var vm = (TViewModel)_factory(typeof(TViewModel));
            configure?.Invoke(vm);
            return vm;
        }
    }
}
