using System;
using System.Linq;
using System.Threading.Tasks;
using bot.Commands;
using bot.Queries;
using Paramore.Brighter;
using Paramore.Darker;

namespace bot.Strategies
{
    public class PercentageOfChangeStrategy : IStrategy
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IAmACommandProcessor _commandProcessor;

        public PercentageOfChangeStrategy(IQueryProcessor queryProcessor, IAmACommandProcessor commandProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
        }

        public void Initialise()
        {
            string baseCurrency = "BTC"; // todo
            string quoteCurrency = "EUR"; // todo

            var dailyOHLCVs = _queryProcessor.Execute(new GetDailyOHLCVsQuery(baseCurrency, quoteCurrency));

            var lastTime = dailyOHLCVs.Any() ? dailyOHLCVs.Max(x => x.Time) : (DateTime?)null;            
            var newDailyOHLCVs = _queryProcessor.Execute(new FetchDailyOHLCVFromAPIQuery(baseCurrency, quoteCurrency, lastTime));

            _commandProcessor.Send(new SaveDailyOHLCVCommand(newDailyOHLCVs));
        }
    }
}