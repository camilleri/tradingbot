using System.Collections.Generic;
using bot.DataModel;
using Paramore.Darker;

namespace bot.Queries
{
    public class GetPercentageOfChangeActionsQuery : IQuery<IEnumerable<PercentageOfChangeAction>>
    {
        public string BaseCurrency { get; }
        public string QuoteCurrency { get; }        

        public GetPercentageOfChangeActionsQuery(string baseCurrency, string quoteCurrency)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
        }
    }    
}