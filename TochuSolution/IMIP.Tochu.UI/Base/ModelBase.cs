namespace IMIP.Tochu.UI.Base
{
    public abstract class ModelBase : NotifyBase
    {
        private Guid _id = Guid.NewGuid();
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
    }
}
