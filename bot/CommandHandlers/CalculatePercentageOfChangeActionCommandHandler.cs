using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using bot.Commands;
using bot.DataModel;
using bot.Queries;
using Paramore.Brighter;
using Paramore.Darker;

namespace bot.CommandHandlers
{
    public class CalculatePercentageOfChangeActionCommandHandler : RequestHandler<CalculatePercentageOfChangeActionCommand>
    {
        private readonly BotContext _dbContext;
        private readonly IQueryProcessor _queryProcessor;

        private enum Trend { Up, Down, NoTrend };

        public CalculatePercentageOfChangeActionCommandHandler(BotContext dbContext, IQueryProcessor queryProcessor)
        {
            _dbContext = dbContext;
            _queryProcessor = queryProcessor;
        }

        public override CalculatePercentageOfChangeActionCommand Handle(CalculatePercentageOfChangeActionCommand command)
        {
            var trend = _dbContext.PercentageOfChangeTrends.First(x => x.Time.Date == command.Time.Date);

            if (trend.DaysTrendingDown >= command.DaysForChange)
            {
                var action = new PercentageOfChangeAction()
                {
                    BaseCurrency = command.BaseCurrency,
                    QuoteCurrency = command.QuoteCurrency,
                    Time = command.Time,
                    Amount = command.AmountToTrade,
                    TradeAction = TradeAction.Sell
                };
                _dbContext.PercentageOfChangeActions.Add(action);
                _dbContext.SaveChanges();

                // todo: execute sell command
            }
            else if (trend.DaysTrendingUp >= command.DaysForChange)
            {
                var action = new PercentageOfChangeAction()
                {
                    BaseCurrency = command.BaseCurrency,
                    QuoteCurrency = command.QuoteCurrency,
                    Time = command.Time,
                    Amount = command.AmountToTrade,
                    TradeAction = TradeAction.Buy
                };
                _dbContext.PercentageOfChangeActions.Add(action);
                _dbContext.SaveChanges();

                // todo: execute buy command
            }

            return base.Handle(command);
        }

        private Trend CalculateClosingPriceTrend(IEnumerable<DailyOHLCV> dailyOHLCVs, DateTime time, decimal percentageForChange)
        {
            var previousClosingPrice = dailyOHLCVs.FirstOrDefault(x => x.Time.Date == time.Date)?.Close;
            if (previousClosingPrice == null)
            {
                return Trend.NoTrend;
            }

            var closingPrice = dailyOHLCVs.First(x => x.Time.Date == time.Date).Close;
            var pecentageOfChange = (closingPrice - previousClosingPrice.Value) / previousClosingPrice.Value;
            if (Math.Abs(pecentageOfChange) < percentageForChange)
            {
                return Trend.NoTrend;
            }

            if (pecentageOfChange > 0)
            {
                return Trend.Down;
            }

            return Trend.Up;
        }
    }
}