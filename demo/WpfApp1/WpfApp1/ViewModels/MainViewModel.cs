using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ObservableCollection<UserModel> Users { get; set; } = new();

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private int _age;
        public int Age
        {
            get => _age;
            set { _age = value; OnPropertyChanged(); }
        }
        public ICommand ShowMessageCommand { get; }
        public ICommand OpenWindowCommand { get; }
        public ICommand LoadUserControlCommand { get; }
        public ICommand GoPage1Command { get; }
        public ICommand GoPage2Command { get; }
        public ICommand AddUserCommand { get; private set;  }

        private void InitModelCommands()
        {
            AddUserCommand = new RelayCommand(() =>
            {
                Users.Add(new UserModel { Name = Name, Age = Age });
                Name = string.Empty;
                Age = 0;
            });
        }
        public MainViewModel()
        {
            ShowMessageCommand = new RelayCommand(() =>
            {
                MessageBox.Show("Hello MVVM", "Info");
            });

            OpenWindowCommand = new RelayCommand(() =>
            {
                new SecondWindow().Show();
            });

            LoadUserControlCommand = new RelayCommand(() =>
            {
                CurrentView = new SampleUserControl();
            });

            GoPage1Command = new RelayCommand(() =>
            {
                CurrentView = new Page1();
            });

            GoPage2Command = new RelayCommand(() =>
            {
                CurrentView = new Page2();
            });
            InitModelCommands();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
