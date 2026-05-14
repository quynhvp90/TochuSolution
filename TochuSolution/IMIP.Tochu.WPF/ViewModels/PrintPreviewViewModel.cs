using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Shared;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class PrintPreviewViewModel : ViewModelBaseWPF
    {
        private FrameworkElement _visual { set; get; }
        private Action _closeAction { set; get; }
        private readonly ILocalizationService _loc;

        public ICommand PrintCommand { get; }
        public ICommand ExportPdfCommand { get; }
        public ICommand CloseCommand { get; }

        public ReportViewModel Report { get; } = new();
        public SI_SEINOUDATA_Model seinouData { set; get; }
        public T0000RR_Juchuu_RCS_Model juchuuRCS { set; get; }
        public string tantou1 { set; get; }
        public string tantou2 { set; get; }
        public string tantou3 { set; get; }


        public PrintPreviewViewModel(INavigationService navigationService, IAppDataContext appDataContext, ILocalizationService loc) : base(navigationService, appDataContext)
        {
            _loc = loc;
            PrintCommand = new RelayCommand(ExecutePrint);
            ExportPdfCommand = new RelayCommand(ExecuteExportPdf);
            CloseCommand = new RelayCommand(ExecuteClose);
        }

        public void Initialize(SI_SEINOUDATA_Model seinouData, T0000RR_Juchuu_RCS_Model juchuuRCS, string tantou1, string tantou2, string tantou3)
        { 
            this.seinouData = seinouData;
            this.juchuuRCS = juchuuRCS;
            this.tantou1 = tantou1;
            this.tantou2 = tantou2;
            this.tantou3 = tantou3;
            Report.Initialize(seinouData, juchuuRCS, tantou1, tantou2, tantou3);
        }
        public void InitFormView(FrameworkElement visual, Action closeAction)
        {
            _visual = visual;
            _closeAction = closeAction;
        }
        // ── Print ─────────────────────────────────────────────────────────────
        private void ExecutePrint()
        {
            var dialog = new PrintDialog();
            if (dialog.ShowDialog() != true) return;

            _visual.Measure(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight));
            _visual.Arrange(new Rect(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight)));

            dialog.PrintVisual(_visual, _loc.Get("Report_Title"));
        }
        private void ExecuteClose()
        {
            _closeAction?.Invoke();
        }   
        // ── Export PDF ────────────────────────────────────────────────────────
        private void ExecuteExportPdf()
        {
            var dialog = new SaveFileDialog
            {
                Title = _loc.Get("Report_ExportPdf"),
                DefaultExt = ".pdf",
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (dialog.ShowDialog() != true) return;

            try
            {
                ExportToPdf(_visual, dialog.FileName);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = dialog.FileName,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(_loc.Get("Report_SaveError"), ex.Message),
                    _loc.Get("Report_SaveError_Title"),
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        // ── Core: WPF Visual → PNG → PdfSharp ────────────────────────────────
        private static void ExportToPdf(FrameworkElement visual, string pdfPath)
        {
            const double width = 794;
            const double height = 1123;

            visual.Measure(new Size(width, height));
            visual.Arrange(new Rect(0, 0, width, height));
            visual.UpdateLayout();

            var renderTarget = new RenderTargetBitmap(
                (int)width,
                (int)height,
                96,
                96,
                PixelFormats.Pbgra32);

            renderTarget.Render(visual);

            byte[] imageBytes;

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderTarget));

            using (var ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageBytes = ms.ToArray();
            }

            var document = new PdfDocument();

            var page = document.AddPage();
            page.Size = PdfSharp.PageSize.A4;
            page.Orientation = PdfSharp.PageOrientation.Portrait;

            using (var gfx = XGraphics.FromPdfPage(page))
            using (var imgStream = new MemoryStream(imageBytes))
            {
                var image = XImage.FromStream(imgStream);

                gfx.DrawImage(
                    image,
                    0,
                    0,
                    page.Width,
                    page.Height);
            }

            document.Save(pdfPath);
        }
    }
}
