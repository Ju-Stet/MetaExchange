using MetaExchange.ConsoleApp;
using MetaExchange.Services;
using MetaExchange.Services.Mappings;
using MetaExchange.Services.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace MetaExchange.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            host.Services.GetService<IService>().Go(args);

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
