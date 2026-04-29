using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMIP.Tochu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

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
                name: "SI_CODEMST",
                schema: "dbo",
                columns: table => new
                {
                    KBN = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    NM = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ENUM = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    EYOBI = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SI_CODEMST", x => new { x.KBN, x.ID });
                });

            migrationBuilder.CreateTable(
                name: "SI_MEMO",
                schema: "dbo",
                columns: table => new
                {
                    JIGYOUSHO = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    NUM = table.Column<int>(type: "int", nullable: false),
                    MEMO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SI_MEMO", x => new { x.JIGYOUSHO, x.NUM });
                });

            migrationBuilder.CreateTable(
                name: "SI_SEINOUDATA",
                schema: "dbo",
                columns: table => new
                {
                    JUCHUUNO = table.Column<int>(type: "int", nullable: false),
                    NUM = table.Column<int>(type: "int", nullable: false),
                    LOTNO = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    USERHINBAN = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    NOUSCD = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    T10 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T20 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T30 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T40 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T50 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T60 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T70 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T80 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T90 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T100 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T110 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T120 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T130 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T140 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T150 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    T160 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    UPTIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NOUKI = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NOUSSNM = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    NISUGATACD = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    JUCHUSUU = table.Column<int>(type: "int", nullable: true),
                    SUUJP = table.Column<string>(type: "varchar(24)", unicode: false, maxLength: 24, nullable: true),
                    TANTOU1 = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    TANTOU2 = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    TANTOU3 = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    COMM = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    PRINTDT = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(9999, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    MA150 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    MA20 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    MA30 = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SI_SEINOUDATA", x => new { x.JUCHUUNO, x.NUM });
                });

            migrationBuilder.CreateTable(
                name: "SI_SEINOUMST",
                schema: "dbo",
                columns: table => new
                {
                    PRODUCT = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    NOUSCD = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    NUM = table.Column<int>(type: "int", nullable: false),
                    MIN = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    MAX = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SI_SEINOUMST", x => new { x.PRODUCT, x.NOUSCD, x.NUM });
                });

            migrationBuilder.CreateTable(
                name: "SI_TANTOU",
                schema: "dbo",
                columns: table => new
                {
                    JIGYOUSHO = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    NUM = table.Column<int>(type: "int", nullable: false),
                    TEXT1 = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SI_TANTOU", x => new { x.JIGYOUSHO, x.NUM });
                });

            migrationBuilder.CreateTable(
                name: "T0000MS_Item_RCS",
                columns: table => new
                {
                    UserHinban = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    UserHinmei = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T0000MS_Item_RCS", x => x.UserHinban);
                });

            migrationBuilder.CreateTable(
                name: "T0000RR_Juchuu_RCS",
                columns: table => new
                {
                    JuchuuNO = table.Column<int>(type: "int", nullable: false),
                    JuchuuDenpyouNO = table.Column<int>(type: "int", nullable: false),
                    JuchuuKyotenCD = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    JuchuuKyotenNM = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    JuchuuYMD = table.Column<DateTime>(type: "date", nullable: true),
                    Nouki = table.Column<DateTime>(type: "date", nullable: true),
                    ShukkaKyotenCD = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    ShukkaBashoCD = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    JuchuuKBN = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    HaisouCD = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    ChikuCD = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    NouSCD = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    NouSSNM = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    UserHinban = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: true),
                    UserHinmei = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ItemCD = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    ItemNM = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    JuchuuSuu = table.Column<int>(type: "int", nullable: true),
                    NisugataCD = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: true),
                    UriKeitaiKBN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Tekiyou1 = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    TankaUnitCD = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T0000RR_Juchuu_RCS", x => x.JuchuuNO);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Juchuu_KyotenCD",
                table: "T0000RR_Juchuu_RCS",
                column: "JuchuuKyotenCD");

            migrationBuilder.CreateIndex(
                name: "IX_NouSCD",
                table: "T0000RR_Juchuu_RCS",
                column: "NouSCD");

            migrationBuilder.CreateIndex(
                name: "IX_NouSSNM",
                table: "T0000RR_Juchuu_RCS",
                column: "NouSSNM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "SI_CODEMST",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SI_MEMO",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SI_SEINOUDATA",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SI_SEINOUMST",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SI_TANTOU",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "T0000MS_Item_RCS");

            migrationBuilder.DropTable(
                name: "T0000RR_Juchuu_RCS");
        }
    }
}
