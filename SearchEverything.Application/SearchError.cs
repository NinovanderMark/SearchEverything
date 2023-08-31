namespace SearchEverything.ApplicationCore
{
    public class SearchError
    {
        public string Path { get; set; }
        public string ErrorMessage { get; set; }
        public Exception? Exception { get; set; }

        public SearchError(string path, string message) 
        {
            Path = path;
            ErrorMessage = message;
        }

        public SearchError(string path, Exception exception) : this(path, exception.Message)
        {
            Exception = exception;
        }
    }
}
