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
        private readonly IStrategy _strategy;

        public Bot(IQueryProcessor queryProcessor, IAmACommandProcessor commandProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandProcessor = commandProcessor;
            _strategy = new PercentageOfChangeStrategy(_queryProcessor, _commandProcessor); // todo: register a list of strategies
        }

        public void Initialise()
        {            
            _strategy.Initialise();
        }

        public void Run()
        {
            _strategy.Run();
        }
    }
}