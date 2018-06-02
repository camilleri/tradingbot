using System;
using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bot
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
    
            // entry to run bot
            serviceProvider.GetService<Bot>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BotContext>(options => BotContextFactory.BuildSqlOptions());
            
            // add bot
            serviceCollection.AddTransient<Bot>();
        }
    }  
}
