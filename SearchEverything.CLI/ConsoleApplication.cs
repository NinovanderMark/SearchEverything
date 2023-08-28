using Microsoft.Extensions.Logging;
using SearchEverything.ApplicationCore;
using SearchEverything.CLI.Models;
using System.Text;

namespace SearchEverything.CLI
{
    public class ConsoleApplication
    {
        private readonly ILogger<ConsoleApplication> _logger;
        private readonly SearchEngine _searchEngine;

        public ConsoleApplication(ILogger<ConsoleApplication> logger, SearchEngine searchEngine) 
        {
            _logger = logger;
            _searchEngine = searchEngine;
        }

        public async Task<int> Run(SearchArguments arguments)
        {
            _logger.LogInformation($"Searching for '{arguments.Text}' in path '{arguments.Path}' {(arguments.InFile ? "including file contents" : string.Empty)}");
            var result = await _searchEngine.Find(arguments.Text, arguments.Path, arguments.InFile);
            foreach (var row in result.Rows)
            {
               Console.WriteLine($"\t{row.Filename}:{row.LineNumber}\t{row.Path}");
            }

            return 0;
        }
    }
}
