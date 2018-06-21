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
            // todo get latest entry and query only from latest entry until today
            var dailyOHLCVs = _queryProcessor.Execute(new FetchDailyOHLCVFromAPIQuery());
            _commandProcessor.Send(new SaveDailyOHLCVCommand(dailyOHLCVs));
        }
    }
}