using System;
using bot.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace bot.DataModel
{
    // This is so that EF Code First can know how to create a BotContext
    public class BotContextFactory : IDesignTimeDbContextFactory<BotContext>
    {
        public const string SqlConnection = @"Server=localhost;Database=tradingbot;User=sa;Password=yourStrong(!)Password;";

        public static DbContextOptions<BotContext> BuildSqlOptions() 
        { 
            var optionsBuilder = new DbContextOptionsBuilder<BotContext>();
            optionsBuilder.UseSqlServer(SqlConnection);

            return optionsBuilder.Options;
        }

        public BotContext CreateDbContext(string[] args)
        {
            var options = BuildSqlOptions();
            return new BotContext(options);
        }
    }
}