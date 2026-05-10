using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMIP.Tochu.UI.Base
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Action<object> _executeObject;
        private readonly Func<bool>? _canExecute;
        private readonly Func<object, bool>? _canExecuteObject;

        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _executeObject = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecuteObject = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;
        public void Execute(object? parameter) => _execute();

        // call this method to manually trigger CanExecute re-evaluation
        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
    }
}