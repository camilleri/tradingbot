using System;
using System.Collections.Generic;
using bot.DataModel;
using Paramore.Brighter;

namespace bot.Commands
{
    public class CalculatePercentageOfChangeActionCommand : IRequest
    {
        public CalculatePercentageOfChangeActionCommand(
                DateTime time,
                string baseCurrency,
                string quoteCurrency,
                int daysForChange,
                Decimal amountToTrade)
        {
            Id = Guid.NewGuid();
            Time = time;
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
            DaysForChange = daysForChange;
            AmountToTrade = amountToTrade;
        }

        public Guid Id { get; set; }
        public DateTime Time { get; }
        public string BaseCurrency { get; }
        public string QuoteCurrency { get; }
        public int DaysForChange { get; }
        public Decimal AmountToTrade { get; }
    }
}