using Microsoft.Extensions.Logging;
using SearchEverything.CLI.Models;

namespace SearchEverything.CLI
{
    public class ArgumentParser
    {
        public ArgumentParser() { }

        public SearchArguments Parse(string[] args)
        {
            if (args.Length < 1)
                throw new ArgumentException("Unable to parse argument(s), did you provide any?");

            string searchText = args[0];
            string searchPath = Environment.CurrentDirectory;
            bool searchInFile = false;
            if (args.Length > 1)
                searchPath = Path.GetFullPath(args[1]);

            if ( args.Length > 2)
                bool.TryParse(args[2], out searchInFile);

            return new SearchArguments
            {
                Text = searchText,
                Path = searchPath,
                InFile = searchInFile
            };
        }
    }
}
