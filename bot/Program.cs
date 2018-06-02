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
            var connection = @"Server=localhost;Database=tradingbot;User=sa;Password=yourStrong(!)Password;";
            serviceCollection.AddDbContext<BotContext>(options => options.UseSqlServer(connection));

            // add bot
            serviceCollection.AddTransient<Bot>();
        }
    }  
}
