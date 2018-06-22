using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using bot.DataModel;
using HttpClientLogic;
using Paramore.Darker;
using bot.Queries;
using System;
using System.Linq;

namespace bot.QueryHandlers
{
    public class GetPercentageOfChangeConfigurationQueryHandler : QueryHandler<GetPercentageOfChangeConfigurationQuery, PercentageOfChangeConfiguration>
    {
        private readonly BotContext _dbContext;

        public GetPercentageOfChangeConfigurationQueryHandler(BotContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override PercentageOfChangeConfiguration Execute(GetPercentageOfChangeConfigurationQuery query)
        {        
            var configurations = _dbContext.PercentageOfChangeConfigurations.Where(x => x.BaseCurrency == query.BaseCurrency && x.QuoteCurrency == x.QuoteCurrency);
            var lastConfigurationTime = configurations.Max(x => x.Time);
            return configurations.First(x => x.Time == lastConfigurationTime);
        }
    }
}