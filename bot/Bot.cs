using System;
using bot.Strategies;
using Paramore.Brighter;
using Paramore.Darker;

namespace bot
{
    public class Bot
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IAmACommandProcessor _commandProcessor;

        public Bot(IQueryProcessor queryProcessor, IAmACommandProcessor commandProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
        }

        public void Initialise()
        {
            var strategy = new PercentageOfChangeStrategy(_queryProcessor, _commandProcessor); // todo: register a list of strategies
            strategy.Initialise();
        }

        public void Run()
        {
            Console.WriteLine("Bot has been run!");
        }
    }
}