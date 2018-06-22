using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bot.Migrations
{
    public partial class PopulateConfigurations : Migration
    {
        private DateTime firstConfigurationDate = new DateTime(2018, 6, 22);

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("PercentageOfChangeConfigurations",
                new string[] { "BaseCurrency", "QuoteCurrency", "Time", "PercentageForChange", "DaysForChange" , "AmountToTrade"},
                new object[] { "ETH", "USD", firstConfigurationDate, 0.01, 2, 100 });

            migrationBuilder.InsertData("UnitsOfChangeConfigurations",
                new string[] { "BaseCurrency", "QuoteCurrency", "Time", "UnitsForChange", "DaysForChange" , "AmountToTrade"},
                new object[] { "ETH", "USD", firstConfigurationDate, 10, 2, 100 });                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("PercentageOfChangeConfigurations", 
                new string[] { "BaseCurrency", "QuoteCurrency", "Time"},
                new object[] { "ETH", "USD", firstConfigurationDate});
            migrationBuilder.DeleteData("UnitsOfChangeConfigurations",
                new string[] { "BaseCurrency", "QuoteCurrency", "Time"},
                new object[] { "ETH", "USD", firstConfigurationDate});                
        }
    }
}
