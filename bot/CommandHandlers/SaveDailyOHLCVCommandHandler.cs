using System.Threading;
using System.Threading.Tasks;
using bot.Commands;
using bot.DataModel;
using Paramore.Brighter;

namespace bot.CommandHandlers
{
    public class SaveDailyOHLCVCommandHandler : RequestHandler<SaveDailyOHLCVCommand>
    {
        private readonly BotContext _dbContext;

        public SaveDailyOHLCVCommandHandler(BotContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override SaveDailyOHLCVCommand Handle(SaveDailyOHLCVCommand command)
        {
            _dbContext.DailyOHLCVs.AddRange(command.DailyOHLCVs);
            _dbContext.SaveChanges();

            return base.Handle(command);
        }
    }
}