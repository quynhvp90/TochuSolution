using IMIP.Tochu.Core.Models;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using Infragistics;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class RegistrationViewModel : ViewModelBaseWPF
    {
        private T0000RR_Juchuu_RCS_Model? _juchuuRCS;
        public T0000RR_Juchuu_RCS_Model? JuchuuRCS
        {
            get => _juchuuRCS;
            set => SetProperty(ref _juchuuRCS, value);
        }
        private SI_SEINOUDATA_Model? _seinouData;
        public SI_SEINOUDATA_Model? SeinouData
        {
            get => _seinouData;
            set => SetProperty(ref _seinouData, value);
        }
        private string _statusAddnew = "New";
        public string StatusAddnew
        {
            get => _statusAddnew;
            set => SetProperty(ref _statusAddnew, value);
        }

        private SI_TANTOU_Model? _tantouSelected;
        public SI_TANTOU_Model? TantouSelected
        {
            get => _tantouSelected;
            set => SetProperty(ref _tantouSelected, value);
        }
        private ObservableCollection<SI_TANTOU_Model> _tantouList;
        public ObservableCollection<SI_TANTOU_Model> TantouList
        {
            get => _tantouList;
            set => SetProperty(ref _tantouList, value);
        }

        public RegistrationViewModel(INavigationService nav, IAppDataContext appDataContext) : base(nav, appDataContext)
        {
            InitializeMeshItems();
            InitializeChartData();
            InitializeDropdowns();
            InitializeCommands();

        }

        public void SetJuchuuRCS(T0000RR_Juchuu_RCS_Model? model)
        {
            JuchuuRCS = model;
        }
        // ──────────────────────────────────────────────
        //  Dropdowns ⑫⑬⑭
        // ──────────────────────────────────────────────

        private ObservableCollection<string> _tantou1Items;
        public ObservableCollection<string> Tantou1Items
        {
            get => _tantou1Items;
            set => SetProperty(ref _tantou1Items, value);
        }

        private string _selectedTantou1;
        public string SelectedTantou1
        {
            get => _selectedTantou1;
            set => SetProperty(ref _selectedTantou1, value);
        }


        private ObservableCollection<string> _tantou2Items;
        public ObservableCollection<string> Tantou2Items
        {
            get => _tantou2Items;
            set => SetProperty(ref _tantou2Items, value);
        }

        private string _selectedTantou2;
        public string SelectedTantou2
        {
            get => _selectedTantou2;
            set => SetProperty(ref _selectedTantou2, value);
        }

        private ObservableCollection<string> _tantou3Items;
        public ObservableCollection<string> Tantou3Items
        {
            get => _tantou3Items;
            set => SetProperty(ref _tantou3Items, value);
        }

        private string _selectedTantou3;
        public string SelectedTantou3       
        {
            get => _selectedTantou3;
            set => SetProperty(ref _selectedTantou3, value);
        }

    

        private void InitializeMeshItems()
        {
            
        }

        
        // ══════════════════════════════════════════════
        //  SECTION 4 — Chart data
        // ══════════════════════════════════════════════

        private ObservableCollection<ChartDataPoint> _chartData;
        public ObservableCollection<ChartDataPoint> ChartData
        {
            get => _chartData;
            set => SetProperty(ref _chartData, value);
        }

        private void InitializeChartData()
        {
            ChartData = new ObservableCollection<ChartDataPoint>
            {
                new ChartDataPoint { MeshLabel = "14"   , Value = 0 },
                new ChartDataPoint { MeshLabel = "18.5" , Value = 0 },
                new ChartDataPoint { MeshLabel = "26"   , Value = 0 },
                new ChartDataPoint { MeshLabel = "36"   , Value = 0 },
                new ChartDataPoint { MeshLabel = "50"   , Value = 0 },
                new ChartDataPoint { MeshLabel = "70"   , Value = 0 },
                new ChartDataPoint { MeshLabel = "100"  , Value = 0 },
                new ChartDataPoint { MeshLabel = "140"  , Value = 0 },
                new ChartDataPoint { MeshLabel = "200"  , Value = 0 },
                new ChartDataPoint { MeshLabel = "280"  , Value = 0 },
                new ChartDataPoint { MeshLabel = "PAN"  , Value = 0 },
            };
        }

        /// <summary>Sync MeshItems values → ChartData for live chart update.</summary>
        private void RefreshChartData()
        {
            
        }

        // ══════════════════════════════════════════════
        //  SECTION 5 — Remarks
        // ══════════════════════════════════════════════

        /// <summary>Field ㊵: 備考 / Ghi chú</summary>
        private string _remarks;
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }

        // ══════════════════════════════════════════════
        //  Commands
        // ══════════════════════════════════════════════

        public ICommand LoadMasterCommand { get; private set; }
        public ICommand AutoCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        public ICommand PrintCommand { get; private set; }

        private void InitializeCommands()
        {
            LoadMasterCommand = new RelayCommand(ExecuteLoadMaster);
            AutoCommand = new RelayCommand(ExecuteAuto);
            ClearCommand = new RelayCommand(ExecuteClear);
            PrintCommand = new RelayCommand(ExecutePrint);
        }

        private void ExecuteLoadMaster(object parameter)
        {
            // TODO: Open master lookup dialog and populate fields
        }

        private void ExecuteAuto(object parameter)
        {
            // TODO: Auto-calculate derived values
        }

        private void ExecuteClear(object parameter)
        {
            //OrderSlipNumber = null;
            //OrderDate = null;
            //DeliveryDate = null;
            //CustomerName = null;
            //CustomerCode = null;
            //PartNumber = null;
            //ProductName = null;
            //PackagingStyle = null;
            //Quantity = null;
            //Unit = null;
            //LotNumber = null;
            //Field15 = null;
            //Field16 = null;
            //Field20 = null;
            //ResinContent = null;
            //AdhesionPoint = null;
            //BendingStrength1 = null;
            //BendingStrengthN1 = null;
            //BendingStrength2 = null;
            //BendingStrengthN2 = null;
            //AfsValue = null;
            //Remarks = null;
            //SelectedDropdown12 = null;
            //SelectedDropdown13 = null;
            //SelectedDropdown14 = null;
            //PrintDate = DateTime.Today;

            //foreach (var item in MeshItems)
            //    item.Value = null;

            RefreshChartData();
        }

        private void ExecutePrint(object parameter)
        {
            // TODO: Trigger print / export flow
        }

        // ──────────────────────────────────────────────
        //  Helpers
        // ──────────────────────────────────────────────

        private void InitializeDropdowns()
        {
            //// Populate with placeholder items — replace from service/repository
            //Dropdown12Items = new ObservableCollection<string> { "選択1", "選択2", "選択3" };
            //Dropdown13Items = new ObservableCollection<string> { "選択1", "選択2", "選択3" };
            //Dropdown14Items = new ObservableCollection<string> { "選択1", "選択2", "選択3" };
        }
    }
    // ══════════════════════════════════════════════════
    //  Supporting classes
    // ══════════════════════════════════════════════════

    /// <summary>Represents one MESH row (m14 ~ mPAN)</summary>
    public class MeshItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

        public string MeshLabel { get; set; }
        public string ALabel { get; set; }
        public string BLabel { get; set; }
        public int FieldNo { get; set; }

        private decimal? _value;
        public decimal? Value
        {
            get => _value;
            set { if (_value != value) { _value = value; OnPropertyChanged(); } }
        }
    }

    /// <summary>One point in the grain-size distribution chart</summary>
    public class ChartDataPoint : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));

        public string MeshLabel { get; set; }

        private double _value;
        public double Value
        {
            get => _value;
            set { if (_value != value) { _value = value; OnPropertyChanged(); } }
        }
    }

}
