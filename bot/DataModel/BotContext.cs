using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataModel
{
    public class BotContext : DbContext
    {
        public BotContext(DbContextOptions<BotContext> options) : base(options)
        { }

        public DbSet<DailyOHLCV> DailyOHLCVs { get; set; }
        public DbSet<PercentageOfChangeAction> PercentageOfChangeActions { get; set; }
        public DbSet<PercentageOfChangeConfiguration> PercentageOfChangeConfigurations { get; set; }
        public DbSet<PercentageOfChangeTrend> PercentageOfChangeTrends { get; set; }                
        public DbSet<UnitsOfChangeAction> UnitsOfChangeActions { get; set; }
        public DbSet<UnitsOfChangeConfiguration> UnitsOfChangeConfigurations { get; set; }
        public DbSet<UnitsOfChangeTrend> UnitsOfChangeTrends { get; set; }                   
    }
}