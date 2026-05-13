using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class ReportChartPoint
    {
        public string Label { get; set; } = string.Empty;
        public double Value { get; set; }
    }

    public class ReportViewModel : NotifyBase
    {
        // ── Header ────────────────────────────────────────────────────────────
        public string CompanyName { get; set; } = string.Empty;
        public string PrintDate { get; set; } = string.Empty;

        // ── Info table ────────────────────────────────────────────────────────
        public string ProductName { get; set; } = string.Empty;
        public string ResinContent { get; set; } = string.Empty;
        public string LotNo { get; set; } = string.Empty;
        public string Tantou1 { get; set; } = string.Empty;
        public string Tantou2 { get; set; } = string.Empty;
        public string Tantou3 { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty;

        // ── 検査結果 ──────────────────────────────────────────────────────────
        public string XN { get; set; } = string.Empty; // 抗折力X N/cm²
        public string XK { get; set; } = string.Empty; // 抗折力X kgf/cm²
        public string YN { get; set; } = string.Empty; // 抗折力R N/cm²
        public string YK { get; set; } = string.Empty; // 抗折力R kgf/cm²
        public string AdhesionPoint { get; set; } = string.Empty; // 粘着点

        // ── Mesh distribution ─────────────────────────────────────────────────
        public string M14 { get; set; } = string.Empty;
        public string M18 { get; set; } = string.Empty;
        public string M26 { get; set; } = string.Empty;
        public string M36 { get; set; } = string.Empty;
        public string M50 { get; set; } = string.Empty;
        public string M70 { get; set; } = string.Empty;
        public string M100 { get; set; } = string.Empty;
        public string M140 { get; set; } = string.Empty;
        public string M200 { get; set; } = string.Empty;
        public string M250 { get; set; } = string.Empty;
        public string Pan { get; set; } = string.Empty;

        // ── Footer ────────────────────────────────────────────────────────────
        public string Remarks { get; set; } = string.Empty;

        // ── Chart ─────────────────────────────────────────────────────────────
        public ObservableCollection<ReportChartPoint> ChartPoints { get; private set; } = new();
        public double ChartMaxY { get; private set; } = 40;

        // ── Factory ───────────────────────────────────────────────────────────
        public static ReportViewModel From(
            SI_SEINOUDATA_Model seinouData,
            T0000RR_Juchuu_RCS_Model juchuuRCS,
            string tantou1, string tantou2, string tantou3)
        {
            var vm = new ReportViewModel
            {
                CompanyName = juchuuRCS.NouSSNM ?? string.Empty,
                PrintDate = (seinouData.PRINTDT ?? DateTime.Now).ToString("yyyy年MM月dd日"),
                ProductName = juchuuRCS.UserHinmei ?? string.Empty,
                ResinContent = seinouData.T10?.ToString() ?? string.Empty,
                LotNo = seinouData.LOTNO ?? string.Empty,
                Tantou1 = tantou1,
                Tantou2 = tantou2,
                Tantou3 = tantou3,
                Quantity = $"P {juchuuRCS.JuchuuSuu} {juchuuRCS.TankaUnitCD}",
                XN = seinouData.MA20?.ToString() ?? string.Empty,
                XK = seinouData.T20?.ToString() ?? string.Empty,
                YN = seinouData.MA30?.ToString() ?? string.Empty,
                YK = seinouData.T30?.ToString() ?? string.Empty,
                AdhesionPoint = seinouData.T40?.ToString() ?? string.Empty,
                M14 = seinouData.T50?.ToString() ?? string.Empty,
                M18 = seinouData.T60?.ToString() ?? string.Empty,
                M26 = seinouData.T70?.ToString() ?? string.Empty,
                M36 = seinouData.T80?.ToString() ?? string.Empty,
                M50 = seinouData.T90?.ToString() ?? string.Empty,
                M70 = seinouData.T100?.ToString() ?? string.Empty,
                M100 = seinouData.T110?.ToString() ?? string.Empty,
                M140 = seinouData.T120?.ToString() ?? string.Empty,
                M200 = seinouData.T130?.ToString() ?? string.Empty,
                M250 = seinouData.T140?.ToString() ?? string.Empty,
                Pan = seinouData.T150?.ToString() ?? string.Empty,
                Remarks = seinouData.COMM ?? string.Empty,
            };

            vm.BuildChartPoints(seinouData);
            return vm;
        }

        private void BuildChartPoints(SI_SEINOUDATA_Model d)
        {
            var points = new[]
            {
                new ReportChartPoint { Label = "14",   Value = ToDouble(d.T50)  },
                new ReportChartPoint { Label = "18.5", Value = ToDouble(d.T60)  },
                new ReportChartPoint { Label = "26",   Value = ToDouble(d.T70)  },
                new ReportChartPoint { Label = "36",   Value = ToDouble(d.T80)  },
                new ReportChartPoint { Label = "50",   Value = ToDouble(d.T90)  },
                new ReportChartPoint { Label = "70",   Value = ToDouble(d.T100) },
                new ReportChartPoint { Label = "100",  Value = ToDouble(d.T110) },
                new ReportChartPoint { Label = "140",  Value = ToDouble(d.T120) },
                new ReportChartPoint { Label = "200",  Value = ToDouble(d.T130) },
                new ReportChartPoint { Label = "250",  Value = ToDouble(d.T140) },
                new ReportChartPoint { Label = "PAN",  Value = ToDouble(d.T150) },
            };

            ChartPoints = new ObservableCollection<ReportChartPoint>(points);

            // Round up max Y to next multiple of 10
            var max = points.Max(p => p.Value);
            ChartMaxY = Math.Ceiling(max / 10.0) * 10 + 10;
        }

        private static double ToDouble(object? val)
        {
            if (val == null) return 0;
            return double.TryParse(val.ToString(), out var d) ? d : 0;
        }
    }

}
