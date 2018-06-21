using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bot.DataModel
{
    public class DailyOHLCV
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
        public Decimal Open { get; set; }

        [Required]
        public Decimal Close { get; set; }        

        [Required]
        public Decimal High { get; set; }        

        [Required]
        public double VolumeFrom { get; set; }      

        [Required]
        public double VolumeTo { get; set; }          
    }
}