using Microsoft.EntityFrameworkCore.Migrations;

namespace bot.Migrations
{
    public partial class ChangePercentageForChangeToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PercentageForChange",
                table: "PercentageOfChangeConfigurations",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PercentageForChange",
                table: "PercentageOfChangeConfigurations",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
