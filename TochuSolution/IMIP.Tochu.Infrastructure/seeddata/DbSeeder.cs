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
        private static readonly Random _rnd = new Random();

        private static readonly string[] _customerNames = {
            "Toyota", "Honda", "Yamaha", "Suzuki", "Mazda",
            "Nissan", "Mitsubishi", "Subaru", "Isuzu", "Daihatsu"
        };

        private static readonly string[] _productNames = {
            "Resin A", "Resin B", "Resin C", "Compound X", "Compound Y",
            "Sand Mix 01", "Sand Mix 02", "Binder Alpha", "Binder Beta", "Coating Z",
            "20-GE", "21-ASP7", "35-713"
        };

        private static readonly string[] _units = { "kg", "g", "pcs", "lot", "bag" };

        private static readonly string[] _packagingCDs = { "PKG-001", "PKG-002", "PKG-003", "PKG-004", "PKG-005" };

        private static readonly string[] _packagingNames = { "Box A (200)", "Box B (100)", "Pallet (200)", "Drum (90)", "Bag (100)" };

        private static readonly string[] _performanceMs = { "PM-A", "PM-B", "PM-C", "PM-D" };

        private static readonly string[] _forCustomers = { "Standard", "Special", "Custom", "OEM", "Export" };

        private static readonly PerformanceTable[] _performanceTables = {
            PerformanceTable.NotCreated,
            PerformanceTable.Created
        };

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
                await SeedMasterData(context);
                await SeedComments(context);

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
    }
}