using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Shared
{
    public abstract class NotifyBase : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetProperty<T>(ref T field, T value,
            [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #region NotifyDataErrorInfo Implementation
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public bool HasErrors => _errors.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return null;

            return _errors.ContainsKey(propertyName)
                ? _errors[propertyName]
                : null;
        }
        protected void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }

            if (!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearErrors(string propertyName)
        {
            if (_errors.Remove(propertyName))
            {
                OnErrorsChanged(propertyName);
            }
        }

        protected void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this,
                new DataErrorsChangedEventArgs(propertyName));
        }
        protected bool ValidateRange(
            decimal? value,
            decimal? min,
            decimal? max,
            string propertyName,
            string displayName = null)
        {
            ClearErrors(propertyName);
            var valueMin = min < max ? min : max;
            var valueMax = max > min ? max : min;
            if (!value.HasValue)
                return false;

            if (min.HasValue && value < valueMin)
            {
                AddError(
                    propertyName,
                    $"{displayName ?? propertyName} must be greater than or equal to {valueMin}.");

                return false;
            }

            if (max.HasValue && value > valueMax)
            {
                AddError(
                    propertyName,
                    $"{displayName ?? propertyName} must be less than or equal to {valueMax}.");
                return false;
            }
            return true;
        }
        #endregion NotifyDataErrorInfo Implementation
    }
}
