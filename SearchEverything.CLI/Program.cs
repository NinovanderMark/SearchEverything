using SearchEverything.ApplicationCore;

namespace SearchEverything.CLI
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            var searchEngine = new SearchEngine();
            var result = await searchEngine.Find(args[0], args[1]);
            foreach(var row in result.Rows)
            {
                Console.WriteLine($"{row.Filename}:{row.LineNumber} - {row.Path}");
            }

            return 0;
        }
    }
}