using System.Collections.Generic;
using bot.DataModel;
using Paramore.Darker;

namespace bot.Queries
{
    public class GetDailyOHLCVsQuery : IQuery<IEnumerable<DailyOHLCV>>
    {
        public string BaseCurrency { get; }
        public string QuoteCurrency { get; }        

        public GetDailyOHLCVsQuery(string baseCurrency, string quoteCurrency)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
        }
    }    
}