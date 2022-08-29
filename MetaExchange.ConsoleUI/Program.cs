using MetaExchange.ConsoleApp;
using MetaExchange.Services;
using MetaExchange.Services.Mappings;
using MetaExchange.Services.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MetaExchange.ConsoleUI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await host.Services.GetService<IService>().Go();

            Console.ReadKey();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IOrderBookService, OrderBookService>();
                    services.AddTransient<IOrderService, OrderService>();
                    services.AddTransient<IInputDataService, InputDataService>();
                    services.AddTransient<IRequestValidator, RequestValidator>();
                    services.AddTransient<IOrderMapper, OrderMapper>();
                    services.AddTransient<IService, Service>();
                });

            return hostBuilder;
        }
    }
}
