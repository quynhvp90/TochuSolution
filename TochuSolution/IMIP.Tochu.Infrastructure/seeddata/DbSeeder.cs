using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Shared;
using IMIP.Tochu.Shared.Enums;
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
            "Product meets quality standards.",
            "Need to re-check technical specifications.",
            "Confirmed with customer.",
            "This batch has packaging issues.",
            "Good quality, delivered on time.",
            "Additional inspection documents required.",
            "QC inspection completed.",
            "Customer requested earlier delivery.",
            "Product meets durability requirements.",
            "Packaging process needs to be reviewed."
        };

        public static async Task SeedAsync(TochuDBContext context, bool isProduction = false)
        {
            try
            {
                AppLogger.Info("Start seeding database...");

                await SeedUsers(context);
                await SeedProducts(context, isProduction);
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

        // ───────────────── USERS ─────────────────
        private static async Task SeedUsers(TochuDBContext context)
        {
            if (context.Users.Any()) return;

            context.Users.AddRange(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "admin",
                    PasswordHash = "admin", // TODO: hash
                    Email = "admin@gmail.com",
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "user1",
                    PasswordHash = "user",
                    Email = "user1@gmail.com",
                    CreatedAt = DateTime.Now
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "user2",
                    PasswordHash = "user",
                    Email = "user2@gmail.com",
                    CreatedAt = DateTime.Now
                }
            );

            await Task.CompletedTask;
        }

        // ───────────────── PRODUCTS ─────────────────
        private static async Task SeedProducts(TochuDBContext context, bool isProduction)
        {
            if (context.Products.Any()) return;

            var baseOrderDate = new DateTime(2024, 1, 1);

            int total = isProduction ? 200 : 3000;

            for (int i = 1; i <= total; i++)
            {
                var orderDate = baseOrderDate.AddDays(_rnd.Next(0, 365));

                context.Products.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    ProductId = 1000 + i,
                    OrderNumber = 2000 + i,
                    OrderDate = orderDate,
                    DeliveryDate = orderDate.AddDays(_rnd.Next(7, 60)),
                    PrintingDate = orderDate.AddDays(_rnd.Next(1, 6)),

                    CustomerName = _customerNames[_rnd.Next(_customerNames.Length)],
                    PartNumber = _rnd.Next(10000, 99999),
                    ProductName = _productNames[_rnd.Next(_productNames.Length)],

                    OrderQuantity = _rnd.Next(100, 1000),
                    Unit = _units[_rnd.Next(_units.Length)],

                    PackagingCD = _packagingCDs[_rnd.Next(_packagingCDs.Length)],
                    PackagingName = _packagingNames[_rnd.Next(_packagingNames.Length)],

                    LotNumber = _rnd.Next(100, 999),
                    PerformanceM = _performanceMs[_rnd.Next(_performanceMs.Length)],
                    ForCustomers = _forCustomers[_rnd.Next(_forCustomers.Length)],

                    PerformanceTable = _performanceTables[_rnd.Next(_performanceTables.Length)],

                    Insured = _rnd.Next(0, 2) == 1,
                    Printing = _rnd.Next(0, 2) == 1,

                    ResinContent = Math.Round((decimal)(_rnd.NextDouble() * 10 + 90), 2),
                    TransverseRuptureStrengthX = Math.Round((decimal)(_rnd.NextDouble() * 50 + 200), 2),
                    TransverseRuptureStrengthR = Math.Round((decimal)(_rnd.NextDouble() * 20 + 10), 2),
                    StickyPoint = Math.Round((decimal)(_rnd.NextDouble() * 30 + 100), 2),
                    AFS_FN = Math.Round((decimal)(_rnd.NextDouble() * 10 + 40), 2),
                });
            }

            await Task.CompletedTask;
        }

        // ───────────────── MASTER DATA (JSON) ─────────────────
        private static async Task SeedMasterData(TochuDBContext context)
        {
            if (context.SI_Codemsts.Any() || context.SI_Seinoumsts.Any()) return;

            var basePath = AppContext.BaseDirectory;
            var filePath = Path.Combine(basePath, "SeedData", "masterdata.json");

            if (!File.Exists(filePath))
            {
                AppLogger.Error("masterdata.json not found");
                return;
            }

            var jsonData = File.ReadAllText(filePath);
            var masterData = JsonConvert.DeserializeObject<MasterDataSet>(jsonData);

            if (masterData == null) return;

            if (masterData.ProductSpecs?.Count > 0)
            {
                context.SI_Seinoumsts.AddRange(masterData.ProductSpecs.Select(ps => new SI_Seinoumst
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    CustomerName = ps.CustomerName,
                    Product = ps.ProductName,
                    Min = (decimal)ps.Min,
                    Max = (decimal)ps.Max,
                    Num = (int)ps.Id
                }));
            }

            if (masterData.Properties?.Count > 0)
            {
                context.SI_Codemsts.AddRange(masterData.Properties.Select(p => new SI_Codemst
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Num = (int)p.Id,
                    Nm = p.Nm,
                    Enum = (int)p.Enum,
                    Kbn = p.Kbn,
                    Eyobi = p.Eyobi
                }));
            }

            await Task.CompletedTask;
        }

        // ───────────────── COMMENTS ─────────────────
        private static async Task SeedComments(TochuDBContext context)
        {
            if (context.Comments.Any()) return;

            context.Comments.AddRange(
                _sampleComments.Select((c, i) => new Comment
                {
                    Id = Guid.NewGuid(),
                    Content = c ?? "123",
                    IsActive = true,
                    UpdatedAt = DateTime.Now,
                    CreatedAt = DateTime.Now.AddDays(-i)
                })
            );

            await Task.CompletedTask;
        }
    }
}