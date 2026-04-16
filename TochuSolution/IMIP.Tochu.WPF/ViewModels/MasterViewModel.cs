using IMIP.Tochu.Core.Models;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class MasterViewModel : ViewModelBase
    {
        private readonly INavigationService _nav;

        private string _masterName = string.Empty;
        public string MasterName
        {
            get => _masterName;
            set => SetProperty(ref _masterName, value);
        }
        private Guid _userId = Guid.Empty;
        public Guid UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private UserModel _user { get; set; }
        public UserModel User
        {
            get => _user;
            set  {
                _user = value;
                OnPropertyChanged();
            }
        }
        public void SetUser(UserModel user)
        {
            User = user;
            MasterName = user.Name;
            UserId = user.Id;
        }

        public ICommand GoBackCommand { get; }

        public MasterViewModel(INavigationService nav)
        {
            _nav = nav;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            GoBackCommand = new RelayCommand(() => _nav.GoBack());
        }
    }
}
