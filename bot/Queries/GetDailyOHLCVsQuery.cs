using System.Collections.Generic;
using System.Linq;
using bot.DataModel;
using Paramore.Darker;

namespace bot.Queries
{
    public class GetDailyOHLCVsQuery : IQuery<IOrderedEnumerable<DailyOHLCV>>
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