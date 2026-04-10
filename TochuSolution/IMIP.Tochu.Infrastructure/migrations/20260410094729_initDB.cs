using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMIP.Tochu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Source = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    OrderQuantity = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PackagingCD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PackagingName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LotNumber = table.Column<int>(type: "int", nullable: false),
                    PerformanceM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ForCustomers = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Insured = table.Column<bool>(type: "bit", nullable: false),
                    Printing = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ResinContent = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransverseRuptureStrengthX = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransverseRuptureStrengthR = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StickyPoint = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AFS_FN = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    m14 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    m18_5 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    m26 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    m36 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    m50 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    m70 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    m100 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    m140 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    m200 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    m280 = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    mPAN = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    AF_FN = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartNumber = table.Column<int>(type: "int", nullable: false),
                    PerformanceTable = table.Column<int>(type: "int", nullable: false),
                    PrintingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SI_Codemst",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Nm = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Enum = table.Column<int>(type: "int", nullable: false),
                    Kbn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Eyobi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SI_Codemst", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SI_Seinoumst",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Num = table.Column<int>(type: "int", nullable: false),
                    Product = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Min = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Max = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SI_Seinoumst", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductMesh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ResinContextMin = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ResinContextMax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StrengthXMin = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StrengthXMax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StrengthRMin = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StrengthRMax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StickyPointMin = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StickyPointMax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M14Active = table.Column<bool>(type: "bit", nullable: false),
                    M14Min = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M14Max = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M18_5Active = table.Column<bool>(type: "bit", nullable: false),
                    M18_5Min = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M18_5Max = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M26Active = table.Column<bool>(type: "bit", nullable: false),
                    M26Min = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M26Max = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M36Active = table.Column<bool>(type: "bit", nullable: false),
                    M36Min = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M36Max = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M50Active = table.Column<bool>(type: "bit", nullable: false),
                    M50Min = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M50Max = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M70Active = table.Column<bool>(type: "bit", nullable: false),
                    M70Min = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M70Max = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M100Active = table.Column<bool>(type: "bit", nullable: false),
                    M100Min = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M100Max = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M140Active = table.Column<bool>(type: "bit", nullable: false),
                    M140Min = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M140Max = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M200Active = table.Column<bool>(type: "bit", nullable: false),
                    M200Min = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M200Max = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M280Active = table.Column<bool>(type: "bit", nullable: false),
                    M280Min = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    M280Max = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MPanActive = table.Column<bool>(type: "bit", nullable: false),
                    MPanMin = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MPanMax = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMesh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMesh_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedAt",
                table: "Product",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CustomerName",
                table: "Product",
                column: "CustomerName");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductName",
                table: "Product",
                column: "ProductName");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductName_CustomerName",
                table: "Product",
                columns: new[] { "ProductName", "CustomerName" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMesh_ProductId",
                table: "ProductMesh",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "ProductMesh");

            migrationBuilder.DropTable(
                name: "SI_Codemst");

            migrationBuilder.DropTable(
                name: "SI_Seinoumst");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
