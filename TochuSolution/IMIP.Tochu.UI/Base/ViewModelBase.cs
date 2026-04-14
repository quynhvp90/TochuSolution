
namespace IMIP.Tochu.UI.Base
{
    public abstract class ViewModelBase : NotifyBase
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        protected void ClearError() => ErrorMessage = null;
    }
}
