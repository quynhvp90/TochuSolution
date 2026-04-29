using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Shared;
using IMIP.Tochu.Shared.Enums;
using IMIP.Tochu.Shared.helpers;
using Newtonsoft.Json;
using static IMIP.Tochu.Infrastructure.SeedData.MasterData;

namespace IMIP.Tochu.Infrastructure.Data
{
    public static class DbSeeder
    {
        private static readonly string[] _sampleComments =
        {
            "AAAAAAAAAAAAAAAA BBBBBBBBBBBBBBB CCCCCCCCCCCCCCCC",
            "あああああああああああああ\r\nいいいいいいいいいいい\r\nうううううううううううううう",
            "1111111111111\r\n2222222222222222\r\n44444444444444444444444\r\n55555555555555555555",
            "うううううううううううううう",
            "唖唖唖唖唖唖唖唖唖唖唖唖唖",
        };

        public static async Task SeedAsync(TochuDBContext context, bool isProduction = false)
        {
            try
            {
                AppLogger.Info("Start seeding database...");

                await SeedSI_TANTOU(context);
                await SeedSI_MEMO(context);
                await SeedSI_SEINOUMSTDATA(context);
                await SeedSI_SEINOUMST(context);
                await SeedSI_SEINOUMST(context);
                await SeedT0000MS_Item_RCS(context);
                await SeedT0000RR_Juchuu_RCS(context);

                await context.SaveChangesAsync();

                AppLogger.Info("Seeding completed successfully.");
            }
            catch (Exception ex)
            {
                AppLogger.Error($"Seed error: {ex.Message}");
                throw;
            }
        }

        // ───────────────── SI_TANTOU ─────────────────
        private static async Task SeedSI_TANTOU(TochuDBContext context)
        {
            if (context.SI_TANTOUs.Any()) return;

            context.SI_TANTOUs.AddRange(
                new SI_TANTOU
                {
                    JIGYOUSHO = "310",
                    NUM = 1,
                    TEXT1 = "AAAAAAA"
                },
                new SI_TANTOU
                {
                    JIGYOUSHO = "310",
                    NUM = 2,
                    TEXT1 = "BBBBBBB"
                },
                new SI_TANTOU
                {
                    JIGYOUSHO = "310",
                    NUM = 3,
                    TEXT1 = "CCCCCCC"
                }
            );

            await Task.CompletedTask;
        }

        // ───────────────── SI_MEMO ─────────────────
        private static async Task SeedSI_MEMO(TochuDBContext context)
        {
            if (context.SI_MEMOs.Any()) return;

            context.SI_MEMOs.AddRange(
                _sampleComments.Select((c, i) => new SI_MEMO
                {
                    JIGYOUSHO = "310",
                    NUM = i + 1,
                    MEMO = c
                })
            );
            context.SI_MEMOs.Add(new SI_MEMO
            {
                JIGYOUSHO = "590",
                NUM = 5,
                MEMO = "唖唖唖唖唖唖唖唖唖唖唖唖唖"
            });

            await Task.CompletedTask;
        }

        // ───────────────── SI_SEINOUMST ─────────────────
        private static async Task SeedSI_SEINOUMST(TochuDBContext context)
        {
            if (context.SI_SEINOUMSTs.Any()) return;

            //// path excel file in folder documents in project root
            //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "documents", "dbo.SI_SEINOUMST.csv");
            //var data = ExcelHelper.ReadExcel<SI_SEINOUMST>(filePath);
            //// insert data to database
            //context.SI_SEINOUMSTs.AddRange(data);

            await Task.CompletedTask;
        }

        // ───────────────── SI_SEINOUMSTDATA ─────────────────
        private static async Task SeedSI_SEINOUMSTDATA(TochuDBContext context)
        {
            if (context.SI_SEINOUDATAs.Any()) return;

            //// path excel file in folder documents in project root
            //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "documents", "dbo.SI_SEINOUDATA.csv");
            //var data = ExcelHelper.ReadExcel<SI_SEINOUDATA>(filePath);
            //// insert data to database
            //context.SI_SEINOUDATAs.AddRange(data);

            await Task.CompletedTask;
        }
        // ───────────────── SI_CODEMST ─────────────────
        private static async Task SeedSI_CODEMST(TochuDBContext context)
        {
            if (context.SI_CODEMSTs.Any()) return;

            //// path excel file in folder documents in project root
            //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "documents", "dbo.SI_CODEMST.csv");
            //var data = ExcelHelper.ReadExcel<SI_CODEMST>(filePath);
            //// insert data to database
            //context.SI_CODEMSTs.AddRange(data);

            await Task.CompletedTask;
        }
        // ---------------- T0000MS_Item_RCS ----------------
        private static async Task SeedT0000MS_Item_RCS(TochuDBContext context)
        {
            if (context.T0000MS_Item_RCSs.Any()) return;
            //// path excel file in folder documents in project root
            //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "documents", "dbo.T0000MS_Item_RCS.csv");
            //var data = ExcelHelper.ReadExcel<T0000MS_Item_RCS>(filePath);
            //// insert data to database
            //context.T0000MS_Item_RCSs.AddRange(data);
            await Task.CompletedTask;
        }
        // ----------------- dbo.T0000RR_Juchuu_RCS -----------------
        private static async Task SeedT0000RR_Juchuu_RCS(TochuDBContext context)
        {
            if (context.T0000RR_Juchuu_RCSs.Any()) return;
            //// path excel file in folder documents in project root
            //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "documents", "dbo.T0000RR_Juchuu_RCS.csv");
            //var data = ExcelHelper.ReadExcel<T0000RR_Juchuu_RCS>(filePath);
            //// insert data to database
            //context.T0000RR_Juchuu_RCSs.AddRange(data);
            await Task.CompletedTask;
        }
    }
}