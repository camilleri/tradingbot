using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel
{
    public class PercentageOfChangeConfiguration
    {
        [Key]
        [Column(Order = 1)]
        [MaxLength(3), MinLength(3)]
        public string BaseCurrency { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(3), MinLength(3)]
        public string QuoteCurrency { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Time { get; set; }

        [Required]
        public double PercentageForChange { get; set; }

        [Required]
        public int DaysForChange { get; set; }

        [Required]
        public Decimal AmountToTrade { get; set; }

    }
}