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
    public class GetPercentageOfChangeActionsQueryHandler : QueryHandler<GetPercentageOfChangeActionsQuery, IEnumerable<PercentageOfChangeAction>>
    {
        private readonly BotContext _dbContext;

        public GetPercentageOfChangeActionsQueryHandler(BotContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override IEnumerable<PercentageOfChangeAction> Execute(GetPercentageOfChangeActionsQuery query)
        {        
            return _dbContext.PercentageOfChangeActions.Where(x => x.BaseCurrency == query.BaseCurrency && x.QuoteCurrency == x.QuoteCurrency);
        }
    }
}