using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
    public class PercentageOfChangeTrend
    {
        [Key]
        [Column(Order = 1)]
        [MaxLength(3),MinLength(3)]
        public string BaseCurrency { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(3),MinLength(3)]        
        public string QuoteCurrency { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Time { get; set; }

        [Required]
        public int DaysTrendingUp { get; set; } = 0;

        [Required]
        public int DaysTrendingDown { get; set; } = 0;

        [Required]
        public int DaysWithNoTrend { get; set; } = 0;

        [ForeignKey(nameof(DataModel.TradeAction))]
        public TradeAction TradeAction { get; set; }
    }
}