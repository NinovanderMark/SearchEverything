namespace SearchEverything.ApplicationCore
{
    public class SearchArguments
    {
        public string? ContentSearch { get; set; }
        public string? PathSearch { get; set; }
        public string BasePath { get; set; }

        public SearchArguments(string basePath)
        {
            BasePath = basePath;
        }
    }
}