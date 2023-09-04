using Microsoft.Extensions.Logging;
using SearchEverything.ApplicationCore;

namespace SearchEverything.CLI
{
    public class ArgumentParser
    {
        private readonly ILogger<ArgumentParser> _logger;

        public ArgumentParser(ILogger<ArgumentParser> logger)
        {
            _logger = logger;
        }

        public SearchArguments? Parse(string[] args)
        {
            if (args.Length < 2 )
            {
                _logger.LogInformation("SearchEverything supports the following arguments, where the first 2 are required:\n" +
                    "\t- Path to match against\n" +
                    "\t- Content to search for\n" +
                    "\t- Base path to search from\n" +
                    "\t- Boolean indicating whether to search subdirectories");
                return null;
            }

            string pathMatch = args[0];
            string contentMatch = args[1];
            string basePath = Environment.CurrentDirectory;
            bool recursive = false;
            if (args.Length > 2)
                basePath = Path.GetFullPath(args[2]);

            if (args.Length > 3)
                bool.TryParse(args[3], out recursive);

            return new SearchArguments(basePath)
            {
                PathSearch = pathMatch,
                ContentSearch = contentMatch,
                Recursive = recursive
            };
        }
    }
}
