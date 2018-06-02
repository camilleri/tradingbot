using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataModel
{
    public class BotContext : DbContext
    {
        public BotContext(DbContextOptions<BotContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DailyOHLCV>()
                .HasKey(x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
            modelBuilder.Entity<PercentageOfChangeAction>()
                .HasKey(x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
            modelBuilder.Entity<PercentageOfChangeConfiguration>()
                .HasKey(x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
            modelBuilder.Entity<PercentageOfChangeTrend>()
                .HasKey(x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
            modelBuilder.Entity<UnitsOfChangeAction>()
                .HasKey(x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
            modelBuilder.Entity<UnitsOfChangeConfiguration>()
                .HasKey(x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });
            modelBuilder.Entity<UnitsOfChangeTrend>()                                                                                                            
                .HasKey(x => new { x.BaseCurrency, x.QuoteCurrency, x.Time });            
        }

        public DbSet<DailyOHLCV> DailyOHLCVs { get; set; }
        public DbSet<PercentageOfChangeAction> PercentageOfChangeActions { get; set; }
        public DbSet<PercentageOfChangeConfiguration> PercentageOfChangeConfigurations { get; set; }
        public DbSet<PercentageOfChangeTrend> PercentageOfChangeTrends { get; set; }                
        public DbSet<UnitsOfChangeAction> UnitsOfChangeActions { get; set; }
        public DbSet<UnitsOfChangeConfiguration> UnitsOfChangeConfigurations { get; set; }
        public DbSet<UnitsOfChangeTrend> UnitsOfChangeTrends { get; set; }                   
    }
}