using System;
using System.Collections.Generic;
using bot.DataModel;
using Paramore.Brighter;

namespace bot.Commands
{
    public class CalculatePercentageOfChangeTrendCommand : IRequest
    {
        public CalculatePercentageOfChangeTrendCommand(
                IEnumerable<DailyOHLCV> dailyOHLCVs,
                DateTime time,
                string baseCurrency,
                string quoteCurrency,
                decimal percentageForChange)
        {
            Id = Guid.NewGuid();
            DailyOHLCVs = dailyOHLCVs;
            Time = time;
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
            PercentageForChange = percentageForChange;
        }

        public Guid Id { get; set; }
        public IEnumerable<DailyOHLCV> DailyOHLCVs { get; }
        public DateTime Time { get; }
        public string BaseCurrency { get; }
        public string QuoteCurrency { get; }
        public decimal PercentageForChange { get; }
    }
}