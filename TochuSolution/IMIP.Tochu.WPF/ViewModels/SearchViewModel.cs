using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using IMIP.Tochu.WPF.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly INavigationService _nav;
        private readonly IUserService _userService;
        private CancellationTokenSource _cts;
        public ObservableCollection<UserModel> Users { get; } = new();
        private string _searchText = string.Empty;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                StartSearch();
            }
        }

        public ICommand GoBackCommand { get; }
        public ICommand LoadUser { get;}
        public ICommand EditCommand { get; }

        public SearchViewModel(INavigationService nav, IUserService userService)
        {
            _nav = nav;
            _userService = userService;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            GoBackCommand = new RelayCommand(() => _nav.GoBack());
            LoadUser = new RelayCommand(async () => await GetUsers());
            EditCommand = new RelayCommand<UserModel>(OnEdit);
            GetUsers();
        }
        private void StartSearch()
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            _ = SearchAsync(_searchText, _cts.Token);
        }
        // --- Edit button handler ---
        private void OnEdit(UserModel? user)
        {
            if (user is null) return;

            //MessageBox.Show(
            //    $"User: {user.Name}\nEmail: {user.Email}",
            //    "Edit User",
            //    MessageBoxButton.OK,
            //    MessageBoxImage.Information);

            _nav.OpenWindow<Registration, RegistrationViewModel>(null, win => { 
                win.InitUI();
            });
        }
        private async Task GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
            OnPropertyChanged(nameof(Users));
        }
        private async Task SearchAsync(string keyword, CancellationToken token)
        {
            try
            {
                // 🔥 debounce (tránh spam API)
                await Task.Delay(300, token);

                if (token.IsCancellationRequested)
                    return;

                var result = await _userService.GetUsersAsync(keyword);

                if (token.IsCancellationRequested)
                    return;

                Users.Clear();
                foreach (var item in result)
                {
                    Users.Add(item);
                }
            }
            catch (TaskCanceledException)
            {
                // ignore
            }
        }
    }
}
