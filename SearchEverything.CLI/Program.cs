using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SearchEverything.ApplicationCore;
using System;
using System.Reflection;

namespace SearchEverything.CLI
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            Console.WriteLine($"SearchEverything - v{Assembly.GetExecutingAssembly().GetName().Version}");

            IConfiguration configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables()
              .Build();

            bool.TryParse(configuration["verbose"], out bool verbose);
            var serviceProvider = ConfigureServices(configuration);

            try
            {
                var arguments = serviceProvider.GetRequiredService<ArgumentParser>().Parse(args);
                if ( arguments == null)
                    return 0;

                return await serviceProvider.GetRequiredService<ConsoleApplication>().Run(arguments);
            }
            catch (Exception ex)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;

                if ( verbose) 
                    Console.WriteLine(ex.ToString());
                else
                    Console.WriteLine(ex.Message);

                Console.ForegroundColor = color;
                return -1;
            }
        }

        private static ServiceProvider ConfigureServices(IConfiguration configuration)
            => new ServiceCollection()
                .AddSingleton(configuration)
                .AddTransient<ArgumentParser>()
                .AddTransient<ConsoleApplication>()
                .AddTransient<SearchEngine>()
                .AddLogging(configure => configure.AddConsole())
                .BuildServiceProvider();
    }
}