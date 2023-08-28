namespace SearchEverything.CLI.Models
{
    public class SearchArguments
    {
        public string Text { get; internal set; }
        public string Path { get; internal set; }
        public bool InFile { get; internal set; }
    }
}