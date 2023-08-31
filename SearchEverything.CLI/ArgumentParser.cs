using Microsoft.Extensions.Logging;
using SearchEverything.ApplicationCore;

namespace SearchEverything.CLI
{
    public class ArgumentParser
    {
        public ArgumentParser() { }

        public SearchArguments Parse(string[] args)
        {
            if (args.Length < 2)
                throw new ArgumentException("Insufficient arguments, needs at least path and content search arguments");

            string pathMatch = args[0];
            string contentMatch = args[1];
            string basePath = Environment.CurrentDirectory;
            if (args.Length > 2)
                basePath = Path.GetFullPath(args[2]);

            return new SearchArguments(basePath)
            {
                PathSearch = pathMatch,
                ContentSearch = contentMatch,
            };
        }
    }
}
