using System.Collections.Generic;
using bot.DataModel;
using Paramore.Darker;

namespace bot.Queries
{
    public class GetPercentageOfChangeConfigurationQuery : IQuery<PercentageOfChangeConfiguration>
    {
        public string BaseCurrency { get; }
        public string QuoteCurrency { get; }        

        public GetPercentageOfChangeConfigurationQuery(string baseCurrency, string quoteCurrency)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
        }
    }    
}