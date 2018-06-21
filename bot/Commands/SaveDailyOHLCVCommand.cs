using System;
using System.Collections.Generic;
using bot.DataModel;
using Paramore.Brighter;

namespace bot.Commands
{
    public class SaveDailyOHLCVCommand : IRequest
    {
        public SaveDailyOHLCVCommand(IEnumerable<DailyOHLCV> dailyOHLCVs)
        {
            DailyOHLCVs = dailyOHLCVs;
            Id = Guid.NewGuid();
        }

        public IEnumerable<DailyOHLCV> DailyOHLCVs { get; }
        public Guid Id { get; set; }
    }
}