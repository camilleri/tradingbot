using System;
using bot.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Paramore.Darker.AspNetCore;
using Paramore.Brighter.AspNetCore;
using HttpClientLogic;

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
            var bot = serviceProvider.GetService<Bot>();
            bot.Initialise();
            bot.Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<BotContext>(options => options.UseSqlServer(BotContextFactory.SqlConnection));

            serviceCollection.AddDarker().AddHandlersFromAssemblies(typeof(Program).Assembly);
               // .AddJsonQueryLogging() todo https://github.com/BrighterCommand/Darker
               // .AddDefaultPolicies(); todo https://github.com/BrighterCommand/Darker            
            serviceCollection.AddBrighter().HandlersFromAssemblies(typeof(Program).Assembly);

            // add bot
            serviceCollection.AddTransient<Bot>();

            // application services
            serviceCollection.AddTransient<IHttpClient, CryptoCompareHttpClient>();
        }
    }
}
