using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Models;
using IMIP.Tochu.UI.Navigation;
using MediatR;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace IMIP.Tochu.UI.ViewModels
{
    public class SearchViewModel : ViewModelBase, IAsyncLoad
    {
        public SearchViewModel()
        {
            SearchCommand = new AsyncRelayCommand(SearchAsync);
            ClearCommand = new RelayCommand(Clear);
        }

        private string _searchName = string.Empty;
        public string SearchName
        {
            get => _searchName;
            set => SetProperty(ref _searchName, value);
        }

        private string _searchCode = string.Empty;
        public string SearchCode
        {
            get => _searchCode;
            set => SetProperty(ref _searchCode, value);
        }

        private string _searchStatus = string.Empty;
        public string SearchStatus
        {
            get => _searchStatus;
            set => SetProperty(ref _searchStatus, value);
        }

        private UserRowModel? _selectedRow;
        public UserRowModel? SelectedRow
        {
            get => _selectedRow;
            set => SetProperty(ref _selectedRow, value);
        }

        private int _totalCount;
        public int TotalCount
        {
            get => _totalCount;
            set => SetProperty(ref _totalCount, value);
        }

        public ObservableCollection<UserRowModel> Rows { get; } = new();

        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }

        public async Task LoadAsync() => await SearchAsync();

        private async Task SearchAsync()
        {
            IsBusy = true;
            ClearError();
            try
            {
                //var query = new SearchUsersQuery(SearchName, SearchCode, SearchStatus);
                //var result = await _mediator.Send(query);

                //Rows.Clear();
                //foreach (var dto in result.Items)
                //    Rows.Add(UserRowModel.FromDto(dto));

                //TotalCount = result.TotalCount;
            }
            catch (Exception ex) { ErrorMessage = ex.Message; }
            finally { IsBusy = false; }
        }

        private void Clear()
        {
            SearchName = SearchCode = SearchStatus = string.Empty;
            Rows.Clear();
            TotalCount = 0;
        }
    }
}
