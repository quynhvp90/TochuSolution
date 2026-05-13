using IMIP.Tochu.Shared;
using IMIP.Tochu.UI.Base;
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
    public class PrintPreviewViewModel : NotifyBase
    {
        private readonly FrameworkElement _visual;
        private readonly Action _closeAction;

        public ICommand PrintCommand { get; }
        public ICommand ExportPdfCommand { get; }
        public ICommand CloseCommand { get; }

        public ReportViewModel Report { get; }

        public PrintPreviewViewModel(ReportViewModel report, FrameworkElement visual, Action closeAction)
        {
            Report = report;
            _visual = visual;
            _closeAction = closeAction;

            PrintCommand = new RelayCommand(_ => ExecutePrint());
            ExportPdfCommand = new RelayCommand(_ => ExecuteExportPdf());
            CloseCommand = new RelayCommand(_ => _closeAction());
        }

        // ── Print ─────────────────────────────────────────────────────────────
        private void ExecutePrint()
        {
            var dialog = new PrintDialog();
            if (dialog.ShowDialog() != true) return;

            _visual.Measure(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight));
            _visual.Arrange(new Rect(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight)));

            dialog.PrintVisual(_visual, "コーテッドサンド性能表");
        }

        // ── Export PDF ────────────────────────────────────────────────────────
        private void ExecuteExportPdf()
        {
            var dialog = new SaveFileDialog
            {
                Title = "Export PDF",
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
                    $"PDF export failed.\n{ex.Message}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        // ── Core: WPF Visual → PNG → PdfSharp ────────────────────────────────
        private static void ExportToPdf(FrameworkElement visual, string pdfPath)
        {
            const double wpfWidth = 794;
            const double wpfHeight = 1123;

            visual.Measure(new Size(wpfWidth, wpfHeight));
            visual.Arrange(new Rect(0, 0, wpfWidth, wpfHeight));
            visual.UpdateLayout();

            const double scale = 300.0 / 96.0;
            int bmpW = (int)(wpfWidth * scale);
            int bmpH = (int)(wpfHeight * scale);

            var renderTarget = new RenderTargetBitmap(bmpW, bmpH, 300, 300, PixelFormats.Pbgra32);

            var dv = new DrawingVisual();
            using (var dc = dv.RenderOpen())
            {
                dc.DrawRectangle(Brushes.White, null, new Rect(0, 0, bmpW, bmpH));
                dc.PushTransform(new ScaleTransform(scale, scale));
                dc.DrawRectangle(new VisualBrush(visual), null, new Rect(0, 0, wpfWidth, wpfHeight));
                dc.Pop();
            }
            renderTarget.Render(dv);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(renderTarget));
            byte[] imageBytes;
            using (var ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageBytes = ms.ToArray();
            }

            var pdfDoc = new PdfDocument();
            var pdfPage = pdfDoc.AddPage();
            pdfPage.Size = PdfSharp.PageSize.A4;
            pdfPage.Orientation = PdfSharp.PageOrientation.Portrait;

            using (var gfx = XGraphics.FromPdfPage(pdfPage))
            using (var imgStream = new MemoryStream(imageBytes))
            {
                var xImg = XImage.FromStream(imgStream);
                gfx.DrawImage(xImg, 0, 0, pdfPage.Width, pdfPage.Height);
            }

            pdfDoc.Save(pdfPath);
        }
    }
}
