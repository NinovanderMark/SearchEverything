using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SearchEverything.ApplicationCore;
using System.Text;

namespace SearchEverything.CLI
{
    public class ConsoleApplication
    {
        private readonly ILogger<ConsoleApplication> _logger;
        private readonly SearchEngine _searchEngine;
        private readonly bool _verbose;

        public ConsoleApplication(ILogger<ConsoleApplication> logger, IConfiguration configuration, SearchEngine searchEngine) 
        {
            _logger = logger;
            _searchEngine = searchEngine;
            bool.TryParse(configuration["verbose"], out _verbose);
        }

        public async Task<int> Run(SearchArguments arguments)
        {
            _logger.LogInformation($"Searching for files matching '{arguments.PathSearch}' with contents matching '{arguments.ContentSearch}' in path '{arguments.BasePath}'");
            var result = await _searchEngine.Find(arguments);
            foreach (var row in result.Rows)
            {
               Console.WriteLine($"  {row.Path}{(row.LineNumber >= 0 ? $":{row.LineNumber}" : string.Empty )}");
            }

            Console.WriteLine($"Completed with {result.Errors.Count} errors");

            if ( _verbose )
            {
                foreach(var row in result.Errors)
                {
                    Console.WriteLine($" {row.Path} - {row.ErrorMessage}");
                }
            }
                

            return 0;
        }
    }
}
