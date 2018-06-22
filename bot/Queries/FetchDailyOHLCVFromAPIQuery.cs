using System.Collections.Generic;
using Paramore.Darker;
using bot.DataModel;
using System;

namespace bot.Queries
{
    public class FetchDailyOHLCVFromAPIQuery : IQuery<IEnumerable<DailyOHLCV>>
    {
        public string BaseCurrency { get; }
        public string QuoteCurrency { get; }   

        public DateTime? LastTime { get; }

        public FetchDailyOHLCVFromAPIQuery(string baseCurrency, string quoteCurrency, DateTime? lastTime = null)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
            LastTime = lastTime;
        }               
    }
}