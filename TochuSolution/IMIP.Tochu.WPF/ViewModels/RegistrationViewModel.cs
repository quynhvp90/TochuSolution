using IMIP.Tochu.Core.interfaces;
using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.models;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Core.Services;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using IMIP.Tochu.WPF.Views.Windows;
using Infragistics;
using Microsoft.Win32;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class RegistrationViewModel : ViewModelBaseWPF
    {
        private readonly ISENINOUDATAService _sENINOUDATAService;
        private readonly IJuchuuRCSService _juchuuRCSService;
        private readonly ITANTOUService _tantouService;
        private readonly IVI_SeinouMstService _seinouMstService;
        private readonly IVI_SeinouMstSEService _seinouMstSEService;
        private readonly IPrintCSVService _printCSVService;

        private int numDefault = 1;
        #region Fields and Properties
        private T0000RR_Juchuu_RCS_Model _juchuuRCS;
        public T0000RR_Juchuu_RCS_Model JuchuuRCS
        {
            get => _juchuuRCS;
            set => SetProperty(ref _juchuuRCS, value);
        }
        private SI_SEINOUDATA_Model _seinouData = new SI_SEINOUDATA_Model();
        public SI_SEINOUDATA_Model SeinouData
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

        private ObservableCollection<SI_TANTOU_Model> _tantouList;
        public ObservableCollection<SI_TANTOU_Model> TantouList
        {
            get => _tantouList;
            set => SetProperty(ref _tantouList, value);
        }

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
            set
            {
                if (SetProperty(ref _selectedTantou1, value))
                {
                    UpdateTantouItems();
                }
            }
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
            set
            {
                if (SetProperty(ref _selectedTantou2, value))
                {
                    UpdateTantouItems();
                }
            }
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
            set
            {
                if (SetProperty(ref _selectedTantou3, value))
                {
                    UpdateTantouItems();
                }
            }   
        }

        private ObservableCollection<ChartDataPoint> _chartData;
        public ObservableCollection<ChartDataPoint> ChartData
        {
            get => _chartData;
            set => SetProperty(ref _chartData, value);
        }
        private VI_SeinouMstSE_Model? _seinouMstSE;
        public VI_SeinouMstSE_Model? SeinouMstSE
        {
            get => _seinouMstSE;
            set => SetProperty(ref _seinouMstSE, value);
        }
        private VI_SeinouMst_Model? _seinouMst;

        public VI_SeinouMst_Model? SeinouMst
        {
            get => _seinouMst;
            set => SetProperty(ref _seinouMst, value);
        }
        #endregion Fields and Properties

        #region Commands
        public ICommand AutoCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        public ICommand PrintCommand { get; private set; }
        public ICommand LoadMasterCommand { get; private set; }
        #endregion Commands


        public RegistrationViewModel(INavigationService nav, IAppDataContext appDataContext, 
            ISENINOUDATAService sENINOUDATAService, IJuchuuRCSService juchuuRCSService, 
            ITANTOUService tantouService, IVI_SeinouMstSEService seinouMstSEService, 
            IPrintCSVService printCSVService,
            IVI_SeinouMstService seinouMstService) : base(nav, appDataContext)
        {
            _printCSVService = printCSVService;
            _sENINOUDATAService = sENINOUDATAService;
            _juchuuRCSService = juchuuRCSService;
            _tantouService = tantouService;
            _seinouMstSEService = seinouMstSEService;
            _seinouMstService = seinouMstService;
            InitializeChartData();
            InitializeCommands();
            _ = GetTantouList();

            // Events
            if (appDataContext is INotifyDataErrorInfo notify)
            {
                notify.ErrorsChanged += (s, e) =>
                {
                    if (notify.GetErrors(e.PropertyName) is IEnumerable errors)
                    {
                        // Handle validation errors (e.g., show messages in the UI)
                        // get list errors and show in MessageBox for demo purposes
                        var errorList = errors.Cast<string>().ToList();
                        if (errorList.Any())
                        {
                            MessageBox.Show(string.Join("\n", errorList), "Validation Errors", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                };
            }
            if (appDataContext is INotifyPropertyChanged propNotify)
            {
                propNotify.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(BranchCode))
                    {
                        refreshChartData();
                    }
                };
            }
            SeinouData.ChartValidated += OnChartValidated;
        }
        
        private void OnChartValidated(string field, bool isValid)
        {
            refreshChartData();
        }

        private void InitializeChartData()
        {
            ChartData = new ObservableCollection<ChartDataPoint>
            {
                new ChartDataPoint { MeshLabel = "14"   , Value = Convert.ToDouble(SeinouData.T50) },
                new ChartDataPoint { MeshLabel = "18.5" , Value = Convert.ToDouble(SeinouData.T60) },
                new ChartDataPoint { MeshLabel = "26"   , Value = Convert.ToDouble(SeinouData.T70) },
                new ChartDataPoint { MeshLabel = "36"   , Value = Convert.ToDouble(SeinouData.T80) },
                new ChartDataPoint { MeshLabel = "50"   , Value = Convert.ToDouble(SeinouData.T90) },
                new ChartDataPoint { MeshLabel = "70"   , Value = Convert.ToDouble(SeinouData.T100) },
                new ChartDataPoint { MeshLabel = "100"  , Value = Convert.ToDouble(SeinouData.T110) },
                new ChartDataPoint { MeshLabel = "140"  , Value = Convert.ToDouble(SeinouData.T120) },
                new ChartDataPoint { MeshLabel = "200"  , Value = Convert.ToDouble(SeinouData.T130) },
                new ChartDataPoint { MeshLabel = "280"  , Value = Convert.ToDouble(SeinouData.T140) },
                new ChartDataPoint { MeshLabel = "PAN"  , Value = Convert.ToDouble(SeinouData.T150) },
            };
        }
        private void refreshChartData()
        {
            foreach (var point in ChartData)
            {
                switch (point.MeshLabel)
                {
                    case "14": point.Value = Convert.ToDouble(SeinouData.T50); break;
                    case "18.5": point.Value = Convert.ToDouble(SeinouData.T60); break;
                    case "26": point.Value = Convert.ToDouble(SeinouData.T70); break;
                    case "36": point.Value = Convert.ToDouble(SeinouData.T80); break;
                    case "50": point.Value = Convert.ToDouble(SeinouData.T90); break;
                    case "70": point.Value = Convert.ToDouble(SeinouData.T100); break;
                    case "100": point.Value = Convert.ToDouble(SeinouData.T110); break;
                    case "140": point.Value = Convert.ToDouble(SeinouData.T120); break;
                    case "200": point.Value = Convert.ToDouble(SeinouData.T130); break;
                    case "280": point.Value = Convert.ToDouble(SeinouData.T140); break;
                    case "PAN": point.Value = Convert.ToDouble(SeinouData.T150); break;
                }
            }
        }

        private void InitializeCommands()
        {
            AutoCommand = new RelayCommand(ExecuteAuto);
            ClearCommand = new RelayCommand(ExecuteClear);
            PrintCommand = new RelayCommand(ExecutePrint);
            LoadMasterCommand = new RelayCommand(ExecuteLoadMaster);

        }
        public async void SetJuchuuRCS(T0000RR_Juchuu_RCS_Model model, SI_SEINOUDATA_Model? seinoidataModel = null, int num = 1)
        {
            JuchuuRCS = model;
            numDefault = num;
            if (seinoidataModel != null)
            {
                SeinouData = seinoidataModel;
                StatusAddnew = "Edit";
                SeinouData = await GetSeinouData(SeinouData.NUM);
            } else
            {
                StatusAddnew = "New";
                SeinouData.NUM = numDefault;
                
            }
            SeinouData.JUCHUUNO = JuchuuRCS.JuchuuDenpyouNO;
            await GetSeinouMSTSE();
            await GetSeinouMST();
            refreshChartData();
        }
        public async Task GetSeinouMSTSE()
        {
            if (JuchuuRCS == null) return;
            SeinouMstSE = await _seinouMstSEService.GetByProductAndNouscdAsync(JuchuuRCS.UserHinban!, JuchuuRCS.NouSCD!);
        }
        public async Task GetSeinouMST()
        {
            if (JuchuuRCS == null) return;
            SeinouMst = await _seinouMstService.GetByProductAndNouscdAsync(JuchuuRCS.UserHinban!, JuchuuRCS.NouSCD!);
            SeinouData.SeinouMst = SeinouMst;
        }
        public async Task GetTantouList()
        {
            var items = await _tantouService.GetTantouListAsync();
            TantouList = new ObservableCollection<SI_TANTOU_Model>(items.Distinct());
            UpdateTantouItems();
        }
        private void UpdateTantouItems()
        {
            if (TantouList == null) return;
            var list1 = TantouList.Where(t => t.TEXT1 != SelectedTantou2 && t.TEXT1 != SelectedTantou3).Distinct().Select(t => t.TEXT1).ToList();
            // add null/empty option at the top
            list1.Insert(0, string.Empty);
            Tantou1Items = new ObservableCollection<string>(list1);

            var list2 = TantouList.Where(t => t.TEXT1 != SelectedTantou1 && t.TEXT1 != SelectedTantou3).Distinct().Select(t => t.TEXT1).ToList();
            // add null/empty option at the top
            list2.Insert(0, string.Empty);
            Tantou2Items = new ObservableCollection<string>(list2);

            var list3 = TantouList.Where(t => t.TEXT1 != SelectedTantou1 && t.TEXT1 != SelectedTantou2).Distinct().Select(t => t.TEXT1).ToList();
            // add null/empty option at the top
            list3.Insert(0, string.Empty);
            Tantou3Items = new ObservableCollection<string>(list3);
        }
        private async Task<SI_SEINOUDATA_Model?> GetSeinouData(int num)
        {
            if (JuchuuRCS == null) return null;
            var seinouData = await _sENINOUDATAService.GetSENINOUDATAByIdAsync(JuchuuRCS.JuchuuDenpyouNO, num);
            if (seinouData == null) seinouData = new SI_SEINOUDATA_Model() { NUM = num };
            seinouData.SeinouMst = SeinouMst == null ? new VI_SeinouMst_Model() : SeinouMst;
            return seinouData;
        }   

        private void ExecuteAuto()
        {
            var autoResult = _sENINOUDATAService.MeshAutomatically(SeinouData, SeinouMst!);
            // set values T50 - T150 from autoResult
            if (autoResult == null) return;
            SeinouData.T50 = autoResult.T50;
            SeinouData.T60 = autoResult.T60;
            SeinouData.T70 = autoResult.T70;
            SeinouData.T80 = autoResult.T80;
            SeinouData.T90 = autoResult.T90;
            SeinouData.T100 = autoResult.T100;
            SeinouData.T110 = autoResult.T110;
            SeinouData.T120 = autoResult.T120;
            SeinouData.T130 = autoResult.T130;
            SeinouData.T140 = autoResult.T140;
            SeinouData.T150 = autoResult.T150;
            refreshChartData();
        }

        private void ExecuteClear()
        {
            JuchuuRCS.NouSCD = null;
            SeinouData.T10 = null;
            SeinouData.T20 = null;
            SeinouData.T30 = null;
            SeinouData.T40 = null;
            SeinouData.T50 = null;
            SeinouData.T60 = null;
            SeinouData.T70 = null;
            SeinouData.T80 = null;
            SeinouData.T90 = null;
            SeinouData.T100 = null;
            SeinouData.T110 = null;
            SeinouData.T120 = null;
            SeinouData.T130 = null;
            SeinouData.T140 = null;
            SeinouData.T150 = null;
            SeinouData.T160 = null;
            SeinouData.MA150 = null;
            SeinouData.MA20 = null;
            SeinouData.MA30 = null;
            SeinouData.COMM = "";
            refreshChartData();
        }
        private async void ExecutePrint()
        {
            try
            {
                await Save();
                OpenPrintPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Save failed.\n{ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void OpenPrintPreview()
        {
             _navigation.OpenDialog<PrintPreviewWindow, PrintPreviewViewModel>(
                configureWindow: win => win.Owner = Application.Current.MainWindow,
                configureVm: vm => vm.Initialize(
                    seinouData: SeinouData,
                    juchuuRCS: JuchuuRCS,
                    tantou1: SelectedTantou1 ?? string.Empty,
                    tantou2: SelectedTantou2 ?? string.Empty,
                    tantou3: SelectedTantou3 ?? string.Empty
                )
            );
        }


        private async Task Save()
        {
            SeinouData.PRINTDT = DateTime.Now;
            if (JuchuuRCS.NouSCD == null) throw (new Exception("NouScd don't empty!"));
            SeinouData.NOUSCD = JuchuuRCS.NouSCD;
            SeinouData.USERHINBAN = JuchuuRCS.UserHinban;
            await _sENINOUDATAService.Save(SeinouData);
        }

        //// save data file to local and delegate to Core service to print, instead of generating the file in Core and then having to deal with file dialogs in Core
        //private async Task Print()
        //{
        //    // ── SaveFileDialog ở tầng WPF (ViewModel) ────────────────────────────
        //    var date = SeinouData.PRINTDT ?? DateTime.Now;
        //    var defaultFileName = $"{SeinouData.LOTNO}_{JuchuuRCS.JuchuuDenpyouNO}_{date:yyyyMMdd}.csv";

        //    var dialog = new SaveFileDialog
        //    {
        //        Title = "Save CSV File",
        //        FileName = defaultFileName,
        //        DefaultExt = ".csv",
        //        Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
        //        OverwritePrompt = true,
        //    };

        //    if (dialog.ShowDialog() != true)
        //        return; // User cancelled

        //    // ── Delegate file writing to Core service ─────────────────────────────
        //    await _printCSVService.PrintAsync(
        //        filePath: dialog.FileName,
        //        seinouData: SeinouData,
        //        juchuuRCS: JuchuuRCS,
        //        seinouMst: SeinouMstSE,
        //        tantou1: SelectedTantou1?.ToString() ?? string.Empty,
        //        tantou2: SelectedTantou2?.ToString() ?? string.Empty,
        //        tantou3: SelectedTantou3?.ToString() ?? string.Empty
        //    );
        //}
        private void ExecuteLoadMaster()
        {
            var userHinban = JuchuuRCS?.UserHinban ?? string.Empty;

            _navigation.OpenDialog<AnalysisMasterModal, AnalysisMasterModalViewModel>(
                configureWindow: null,
                configureVm: vm => vm.Initialize(userHinban, (selectedNouscd) =>
                {
                    if (!string.IsNullOrEmpty(selectedNouscd) && JuchuuRCS != null)
                        JuchuuRCS.NouSCD = selectedNouscd;
                })
            );
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
