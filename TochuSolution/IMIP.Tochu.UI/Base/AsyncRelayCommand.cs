using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMIP.Tochu.UI.Base
{
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<Task> _execute;

        public AsyncRelayCommand(Func<Task> execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public async void Execute(object parameter) => await _execute();
    }
}
