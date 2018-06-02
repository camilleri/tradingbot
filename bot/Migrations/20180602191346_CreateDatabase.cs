using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bot.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyOHLCVs",
                columns: table => new
                {
                    BaseCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    QuoteCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Open = table.Column<decimal>(nullable: false),
                    Close = table.Column<decimal>(nullable: false),
                    High = table.Column<decimal>(nullable: false),
                    VolumeFrom = table.Column<double>(nullable: false),
                    VolumeTo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyOHLCVs", x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
                });

            migrationBuilder.CreateTable(
                name: "PercentageOfChangeActions",
                columns: table => new
                {
                    BaseCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    QuoteCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    TradeAction = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PercentageOfChangeActions", x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
                });

            migrationBuilder.CreateTable(
                name: "PercentageOfChangeConfigurations",
                columns: table => new
                {
                    BaseCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    QuoteCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    PercentageForChange = table.Column<double>(nullable: false),
                    DaysForChange = table.Column<int>(nullable: false),
                    AmountToTrade = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PercentageOfChangeConfigurations", x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
                });

            migrationBuilder.CreateTable(
                name: "PercentageOfChangeTrends",
                columns: table => new
                {
                    BaseCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    QuoteCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    DaysTrendingUp = table.Column<int>(nullable: false),
                    DaysTrendingDown = table.Column<int>(nullable: false),
                    DaysWithNoTrend = table.Column<int>(nullable: false),
                    TradeAction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PercentageOfChangeTrends", x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfChangeActions",
                columns: table => new
                {
                    BaseCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    QuoteCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    TradeAction = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfChangeActions", x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfChangeConfigurations",
                columns: table => new
                {
                    BaseCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    QuoteCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    UnitsForChange = table.Column<decimal>(nullable: false),
                    DaysForChange = table.Column<int>(nullable: false),
                    AmountToTrade = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfChangeConfigurations", x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfChangeTrends",
                columns: table => new
                {
                    BaseCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    QuoteCurrency = table.Column<string>(maxLength: 3, nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    DaysTrendingUp = table.Column<int>(nullable: false),
                    DaysTrendingDown = table.Column<int>(nullable: false),
                    DaysWithNoTrend = table.Column<int>(nullable: false),
                    TradeAction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfChangeTrends", x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyOHLCVs");

            migrationBuilder.DropTable(
                name: "PercentageOfChangeActions");

            migrationBuilder.DropTable(
                name: "PercentageOfChangeConfigurations");

            migrationBuilder.DropTable(
                name: "PercentageOfChangeTrends");

            migrationBuilder.DropTable(
                name: "UnitsOfChangeActions");

            migrationBuilder.DropTable(
                name: "UnitsOfChangeConfigurations");

            migrationBuilder.DropTable(
                name: "UnitsOfChangeTrends");
        }
    }
}
