using IMIP.Tochu.Core.Models;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using System.Windows;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class MasterViewModel : ViewModelBaseWPF
    {
        private string _jIGYOUSHO = string.Empty;
        public string JIGYOUSHO
        {
            get => _jIGYOUSHO;
            set => SetProperty(ref _jIGYOUSHO, value);
        }

        private string _text1 = string.Empty;
        public string Text1
        {
            get => _text1;
            set => SetProperty(ref _text1, value);
        }

        private SI_TANTOU_Model _user { get; set; }
        public SI_TANTOU_Model User
        {
            get => _user;
            set  {
                _user = value;
                OnPropertyChanged();
            }
        }
        public void SetUser(SI_TANTOU_Model user)
        {
            User = user;
            JIGYOUSHO = user.JIGYOUSHO;
            Text1 = user.TEXT1;
        }

        public ICommand GoBackCommand { get; }

        public MasterViewModel(INavigationService nav) : base(nav)
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            GoBackCommand = new RelayCommand(() => _navigation.GoBack());
        }
    }
}
