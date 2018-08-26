using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bot.Commands;
using bot.DataModel;
using bot.Queries;
using Paramore.Brighter;
using Paramore.Darker;

namespace bot.Strategies
{
    public class PercentageOfChangeStrategy : IStrategy
    {
        private string _baseCurrency { get; set; } = "ETH"; // todo
        private string _quoteCurrency { get; set; } = "EUR"; // todo
        private decimal _percentageForChange { get; set; } = 0.00025m; // todo 
        private int _daysForChange { get; set; } = 2; // todo
        private decimal _amountToTrade { get; set; } = 10;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IAmACommandProcessor _commandProcessor;

        private IOrderedEnumerable<DailyOHLCV> DailyOHLCVs { get; set; }

        private DateTime? LastDailyOHLCVTime => DailyOHLCVs.Any() ? DailyOHLCVs.Max(x => x.Time) : (DateTime?)null;

        private PercentageOfChangeConfiguration _configuration { get; set; }

        public PercentageOfChangeStrategy(IQueryProcessor queryProcessor, IAmACommandProcessor commandProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
        }

        public void Initialise()
        {
            DailyOHLCVs = _queryProcessor.Execute(new GetDailyOHLCVsQuery(_baseCurrency, _quoteCurrency));

            var newDailyOHLCVs = _queryProcessor.Execute(new FetchDailyOHLCVFromAPIQuery(_baseCurrency, _quoteCurrency, LastDailyOHLCVTime));

            _commandProcessor.Send(new SaveDailyOHLCVCommand(newDailyOHLCVs));

            // todo account for configuration changing over time and for different currencies
            _configuration = _queryProcessor.Execute(new GetPercentageOfChangeConfigurationQuery(_baseCurrency, _quoteCurrency));
        }

        public void Run()
        {
            var percentageOfChangeActions = _queryProcessor.Execute(new GetPercentageOfChangeActionsQuery(_baseCurrency, _quoteCurrency));

            var lastActionDate = DailyOHLCVs.Min(x => x.Time);
            if (percentageOfChangeActions.Any()) // we already have actions for this pair
            {
                lastActionDate = percentageOfChangeActions.Max(a => a.Time);
            }
            else
            {
                lastActionDate = new DateTime(2017, 1, 1);
            }

            DateTime nextActionDate = lastActionDate;
            do
            {
                nextActionDate = nextActionDate.AddDays(1);
                _commandProcessor.Send(new CalculatePercentageOfChangeTrendCommand(DailyOHLCVs, nextActionDate, _baseCurrency, _quoteCurrency, _percentageForChange));
                _commandProcessor.Send(new CalculatePercentageOfChangeActionCommand(nextActionDate, _baseCurrency, _quoteCurrency, _daysForChange, _amountToTrade));
            } while (DailyOHLCVs.Any(x => x.Time > nextActionDate));
        }
    }
}