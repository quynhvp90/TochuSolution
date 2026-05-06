using IMIP.Tochu.Shared;
using IMIP.Tochu.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels.Shared
{
    public class PagingViewModel : NotifyBase
    {
        private int _currentPage = 1;
        private int _totalCount = 0;
        private int _pageSize = 20;

        public List<int> PageSizeOptions { get; } = new() { 10, 20, 50, 100 };
        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                var clamped = Math.Clamp(value, 1, Math.Max(1, TotalPages));
                if (SetProperty(ref _currentPage, clamped))
                { 
                    NotifyAll();
                    PageChanged?.Invoke(CurrentPage, PageSize);
                }
            }
        }

        public int TotalCount
        {
            get => _totalCount;
            set
            {
                if (SetProperty(ref _totalCount, value))
                    NotifyAll();
            }
        }

        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (SetProperty(ref _pageSize, value))
                {
                    CurrentPage = 1; // reset to first page when size changes
                    NotifyAll();
                    PageChanged?.Invoke(CurrentPage, PageSize);
                }
            }
        }

        public int TotalPages => Math.Max(1, (int)Math.Ceiling((double)TotalCount / PageSize));
        public bool CanGoPrev => CurrentPage > 1;
        public bool CanGoNext => CurrentPage < TotalPages;

        // Event for notifying parent ViewModel to load data for the new page
        public event Action<int, int>? PageChanged; // (pageIndex, pageSize)

        public ICommand FirstPageCommand { get; }
        public ICommand PrevPageCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand LastPageCommand { get; }
        public ICommand GoToPageCommand { get; }

        public PagingViewModel()
        {
            FirstPageCommand = new RelayCommand(() => GoTo(1), () => CanGoPrev);
            PrevPageCommand = new RelayCommand(() => GoTo(CurrentPage - 1), () => CanGoPrev);
            NextPageCommand = new RelayCommand(() => GoTo(CurrentPage + 1), () => CanGoNext);
            LastPageCommand = new RelayCommand(() => GoTo(TotalPages), () => CanGoNext);
            GoToPageCommand = new RelayCommand<object>(param =>
            {
                if (param == null) return;
                var page = Convert.ToInt32(param); // Convert xử lý được cả double, string, int
                GoTo(page);
            });
        }

        public void GoTo(int page)
        {
            CurrentPage = page;
            PageChanged?.Invoke(CurrentPage, PageSize);
        }

        // Gọi sau khi nhận kết quả từ API để update TotalCount
        public void Update(int totalCount)
        {
            TotalCount = totalCount;
        }

        private void NotifyAll()
        {
            OnPropertyChanged(nameof(TotalPages));
            OnPropertyChanged(nameof(CanGoPrev));
            OnPropertyChanged(nameof(CanGoNext));
            ((RelayCommand)FirstPageCommand).RaiseCanExecuteChanged();
            ((RelayCommand)PrevPageCommand).RaiseCanExecuteChanged();
            ((RelayCommand)NextPageCommand).RaiseCanExecuteChanged();
            ((RelayCommand)LastPageCommand).RaiseCanExecuteChanged();
            ((RelayCommand<object>)GoToPageCommand).RaiseCanExecuteChanged();
        }
    }
}
