using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bot.DataModel
{
    public class UnitsOfChangeAction
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
        [ForeignKey(nameof(bot.DataModel.TradeAction))]        
        public TradeAction TradeAction { get; set; }

        [Required]
        public Decimal Amount { get; set; }        
    }
}