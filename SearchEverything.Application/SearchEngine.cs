using static System.Net.Mime.MediaTypeNames;

namespace SearchEverything.ApplicationCore
{
    public class SearchEngine
    {
        private List<Action<string>> _searchPathListeners { get; } = new List<Action<string>>();
        private List<Action<SearchResultRow>> _searchResultListeners { get; } = new List<Action<SearchResultRow>>();

        /// <summary>
        /// Add a function that is called each time a new path is searched
        /// </summary>
        /// <param name="listener"></param>
        public void AddSearchPathListener(Action<string> listener)
        {
            _searchPathListeners.Add(listener);
        }

        /// <summary>
        /// Add a function that is called each time a new result is found
        /// </summary>
        /// <param name="listener"></param>
        public void AddSearchResultListener(Action<SearchResultRow> listener)
        {
            _searchResultListeners.Add(listener);
        }

        /// <summary>
        /// Search for files matching either a certain path, based on the contents of the file, or both
        /// </summary>

        public async Task<SearchResult> Find(SearchArguments arguments)
        {
            string? sanitizedPath = arguments.PathSearch == null ? null : arguments.PathSearch.Replace("*", "");
            return await GetResultsFromDirectory(new SearchArguments(arguments.BasePath)
            {
                PathSearch = sanitizedPath?.ToLower(),
                ContentSearch = arguments.ContentSearch?.ToLower(),
                Recursive = arguments.Recursive,
            });
        }

        private async Task<SearchResult> GetResultsFromDirectory(SearchArguments arguments)
        {
            var directories = GetDirectories(arguments.BasePath);
            var taskResults = new List<Task<List<SearchResultRow>>>();
            foreach(var dir in directories)
            {
                if (string.IsNullOrEmpty(dir))
                    continue;

                taskResults.Add(SearchDirectory(new SearchArguments(dir, arguments)));
            }

            var files = GetFiles(arguments.BasePath);
            foreach (var file in files) 
            {
                if (string.IsNullOrEmpty(file))
                    continue;

                taskResults.Add(SearchFile(new SearchArguments(file, arguments)));
            }

            var result = new SearchResult();
            foreach(var res in taskResults)
            {
                result.Rows.AddRange(await res);
            }

            return result;
        }

        private void SearchingPath(string path)
        {
            foreach(var listener in _searchPathListeners)
            {
                listener.Invoke(path);
            }
        }

        private void FoundResult(SearchResultRow result)
        {
            foreach(var listener in _searchResultListeners)
            {
                listener.Invoke(result);
            }
        }

        private string[] GetDirectories(string path)
        {
            try
            {
                return Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException)
            {
                // We don't care about unauthorized exceptions
                return new string[0];
            }
        }

        private string[] GetFiles(string path)
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch (UnauthorizedAccessException)
            {
                // We don't care about unauthorized exceptions
                return new string[0];
            }
        }

        private async Task<List<SearchResultRow>> SearchDirectory(SearchArguments arguments)
        {
            SearchingPath(arguments.BasePath);
            var results = new List<SearchResultRow>();
            if (string.IsNullOrEmpty(arguments.PathSearch) || arguments.BasePath.ToLower().Contains(arguments.PathSearch))
            {
                var newResult = new SearchResultRow
                {
                    Filename = "",
                    LineNumber = -1,
                    Path = arguments.BasePath
                };

                FoundResult(newResult);
                results.Add(newResult);
            }

            if (arguments.Recursive)
            {
                var intermediate = await GetResultsFromDirectory(new SearchArguments(arguments.BasePath, arguments));
                results.AddRange(intermediate.Rows);
            }

            return results;
        }

        private async Task<List<SearchResultRow>> SearchFile(SearchArguments arguments)
        {
            SearchingPath(arguments.BasePath);

            var results = new List<SearchResultRow>();
            if (arguments.PathSearch == null || arguments.BasePath.ToLower().Contains(arguments.PathSearch))
            {
                if (!string.IsNullOrEmpty(arguments.ContentSearch))
                {
                    var intermediate = await GetResultsFromFile(arguments.ContentSearch, arguments.BasePath);
                    results.AddRange(intermediate.Rows);
                }
                else
                {
                    var newResult = new SearchResultRow
                    {
                        Filename = Path.GetFileName(arguments.BasePath),
                        LineNumber = -1,
                        Path = arguments.BasePath
                    };
                    FoundResult(newResult);
                    results.Add(newResult);
                }
            }

            return results;
        }

        private async Task<SearchResult> GetResultsFromFile(string text, string file)
        {
            string fileName = Path.GetFileName(file);
            var result = new SearchResult();
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    long lineNumber = 0;
                    while (!sr.EndOfStream)
                    {
                        string? line = await sr.ReadLineAsync();
                        if (line != null && line.ToLower().Contains(text))
                        {
                            var newResult = new SearchResultRow
                            {
                                Filename = fileName,
                                LineNumber = lineNumber,
                                Path = file
                            };
                            FoundResult(newResult);
                            result.Rows.Add(newResult);
                        }

                        lineNumber++;
                    }
                }
            }
            catch(IOException exception)
            {
                result.Errors.Add(new SearchError(file, exception));
            }

            return result;
        }
    }
}