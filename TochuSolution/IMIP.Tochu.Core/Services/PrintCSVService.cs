using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.models;
using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Services
{
    public class PrintCSVService : IPrintCSVService
    {
        public async Task PrintAsync(string filePath, SI_SEINOUDATA_Model seinouData, T0000RR_Juchuu_RCS_Model juchuuRCS, VI_SeinouMstSE_Model seinouMst, string tantou1, string tantou2, string tantou3)
        {
            var date = seinouData.PRINTDT ?? DateTime.Now;

            // ── Build CSV ─────────────────────────────────────────────────────
            var sb = new StringBuilder();

            sb.AppendLine(
                "COMPANY,M14,M18,M26,M36,M50,M70,M100,M140,M200,M250,PAN,APS," +
                "PRODUCT,JUSHI,Lot,DATE,TANTOU1,TANTOU2,TANTOU3,SU,X_N,X_K,Y_N,Y_K,NEN,BIKOU");

            sb.AppendLine(string.Join(",",
                EscapeCsv(juchuuRCS.NouSSNM),                               // COMPANY  ⑤
                EscapeCsv(seinouData.T50),                                   // M14      23
                EscapeCsv(seinouData.T60),                                   // M18      24
                EscapeCsv(seinouData.T70),                                   // M26      25
                EscapeCsv(seinouData.T80),                                   // M36      26
                EscapeCsv(seinouData.T90),                                   // M50      27
                EscapeCsv(seinouData.T100),                                  // M70      28
                EscapeCsv(seinouData.T110),                                  // M100     29
                EscapeCsv(seinouData.T120),                                  // M140     30
                EscapeCsv(seinouData.T130),                                  // M200     31
                EscapeCsv(seinouData.T140),                                  // M250(M280) 32
                EscapeCsv(seinouData.T150),                                  // PAN      33
                EscapeCsv(seinouData.T160),                                  // APS.FN   39
                EscapeCsv(juchuuRCS.UserHinmei),                             // PRODUCT  ⑧
                EscapeCsv(seinouData.T10),                                   // JUSHI    21
                EscapeCsv(seinouData.LOTNO),                                 // Lot      ①
                EscapeCsv(date.ToString("yyyy年MM月dd日")),                   // DATE     ⑰
                EscapeCsv(tantou1),                                          // TANTOU1  ⑫
                EscapeCsv(tantou2),                                          // TANTOU2  ⑬
                EscapeCsv(tantou3),                                          // TANTOU3  ⑭
                EscapeCsv($"P {juchuuRCS.JuchuuSuu} {juchuuRCS.TankaUnitCD}"), // SU   ⑩+⑪
                EscapeCsv(seinouData.T20),                                   // X_N  35
                EscapeCsv(seinouData.MA20),                                  // X_K  36
                EscapeCsv(seinouData.T30),                                   // Y_N  37
                EscapeCsv(seinouData.MA30),                                  // Y_K  38
                EscapeCsv(seinouData.T40),                                   // NEN  22
                EscapeCsv(seinouData.COMM)                                   // BIKOU 40
            ));

            // ── Write UTF-8 with BOM ──────────────────────────────────────────
            await File.WriteAllTextAsync(filePath, sb.ToString(),
                new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

            // ── Open file ────────────────────────────────────────────────────
            Process.Start(new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            });
        }

        private static string EscapeCsv(object? value)
        {
            var str = value?.ToString() ?? string.Empty;
            if (str.Contains(',') || str.Contains('"') || str.Contains('\n'))
                return $"\"{str.Replace("\"", "\"\"")}\"";
            return str;
        }
    }
}
