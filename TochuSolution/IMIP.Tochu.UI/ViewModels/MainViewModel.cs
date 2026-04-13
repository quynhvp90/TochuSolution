using CommunityToolkit.Mvvm.Input;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncRelayCommand = IMIP.Tochu.UI.Base.AsyncRelayCommand;

namespace IMIP.Tochu.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService _navigation;
        public ObservableCollection<string> Users { get; set; } = new();

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }
        // View bind vào đây
        public ViewModelBase? CurrentPage => _navigation.CurrentPage;
        public bool CanGoBack => _navigation.CanGoBack;
        public ICommand LoadUsersCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand Navigate { get; }
        public MainViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            LoadUsersCommand = new AsyncRelayCommand(async () => await LoadUsers());
            SaveCommand = new AsyncRelayCommand(async () => await Save());
            Navigate = new AsyncRelayCommand(async () => await NavigateToAnotherPage());
            // Bind ra ngoài để View theo dõi CurrentPage
            navigation.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(INavigationService.CurrentPage))
                    OnPropertyChanged(nameof(CurrentPage));
            };
        }
        // NAVIGATION to SearchPage, DetailPage, etc.
        private string _currentPage;
        private async Task NavigateToPage(string pageName)
        {
            _currentPage = pageName;
            // Logic to update the UI based on _currentPage
        }
        private async Task NavigateToAnotherPage()
        {
            // Navigation logic here
        }
        // LOAD FLOW
        private async Task LoadUsers()
        {
            
        }

        // SAVE FLOW (QUAN TRỌNG)
        private async Task Save()
        {
            if (string.IsNullOrWhiteSpace(UserName))
                return;

            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
