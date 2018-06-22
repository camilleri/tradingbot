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
    public class GetDailyOHLCVsQueryHandler : QueryHandler<GetDailyOHLCVsQuery, IOrderedEnumerable<DailyOHLCV>>
    {
        private readonly BotContext _dbContext;

        public GetDailyOHLCVsQueryHandler(BotContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override IOrderedEnumerable<DailyOHLCV> Execute(GetDailyOHLCVsQuery query)
        {        
            return _dbContext.DailyOHLCVs
                .Where(x => x.BaseCurrency == query.BaseCurrency && x.QuoteCurrency == x.QuoteCurrency)
                .AsEnumerable()
                .OrderByDescending(x => x.Time);
        }
    }
}