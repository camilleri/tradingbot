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
    public class CalculatePercentageOfChangeTrendCommandHandler : RequestHandler<CalculatePercentageOfChangeTrendCommand>
    {
        private readonly BotContext _dbContext;
        private readonly IQueryProcessor _queryProcessor;

        private enum Trend { Up, Down, NoTrend };

        public CalculatePercentageOfChangeTrendCommandHandler(BotContext dbContext, IQueryProcessor queryProcessor)
        {
            _dbContext = dbContext;
            _queryProcessor = queryProcessor;
        }

        public override CalculatePercentageOfChangeTrendCommand Handle(CalculatePercentageOfChangeTrendCommand command)
        {
            var percentageOfChangeTrends = _dbContext.PercentageOfChangeTrends.Where(x => x.BaseCurrency == command.BaseCurrency && command.QuoteCurrency == x.QuoteCurrency);
            PercentageOfChangeTrend previousTrend = null;
            if (percentageOfChangeTrends.Any())
            {
                var lastTime = percentageOfChangeTrends.Max(x => x.Time);
                previousTrend = percentageOfChangeTrends.FirstOrDefault(x => x.Time == lastTime);
            }

            var trend = new PercentageOfChangeTrend()
            {
                BaseCurrency = command.BaseCurrency,
                QuoteCurrency = command.QuoteCurrency,
                Time = command.Time,
                DaysTrendingDown = previousTrend?.DaysTrendingDown ?? 0,
                DaysTrendingUp = previousTrend?.DaysTrendingUp ?? 0,
                DaysWithNoTrend = previousTrend?.DaysWithNoTrend ?? 0
            };

            if (previousTrend == null)
            {
                trend.DaysWithNoTrend++;
            }
            else
            {
                var closingPriceTrend = CalculateClosingPriceTrend(command.DailyOHLCVs, command.Time, command.PercentageForChange);
                switch (closingPriceTrend)
                {
                    case Trend.Down:
                        trend.DaysTrendingDown++;
                        trend.DaysTrendingUp = 0;
                        trend.DaysWithNoTrend = 0;
                        break;
                    case Trend.Up:
                        trend.DaysTrendingUp++;
                        trend.DaysTrendingDown = 0;
                        trend.DaysWithNoTrend = 0;                        
                        break;
                    case Trend.NoTrend:
                        trend.DaysWithNoTrend++;
                        trend.DaysTrendingUp = 0;
                        trend.DaysWithNoTrend = 0;                        
                        break;
                }
            }

            _dbContext.PercentageOfChangeTrends.Add(trend);
            _dbContext.SaveChanges();

            return base.Handle(command);
        }

        private Trend CalculateClosingPriceTrend(IEnumerable<DailyOHLCV> dailyOHLCVs, DateTime time, decimal percentageForChange)
        {
            var previousClosingPrice = dailyOHLCVs.FirstOrDefault(x => (x.Time.AddDays(-1).Date == time.Date))?.Close;
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

            if (pecentageOfChange < 0)
            {
                return Trend.Down;
            }

            return Trend.Up;
        }
    }
}