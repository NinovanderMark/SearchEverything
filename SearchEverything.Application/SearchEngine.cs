using static System.Net.Mime.MediaTypeNames;

namespace SearchEverything.ApplicationCore
{
    public class SearchEngine
    {
        private List<Action<string>> _searchPathListeners { get; set; } = new List<Action<string>>();

        /// <summary>
        /// Add a function that is called each time a new path is searched
        /// </summary>
        /// <param name="listener"></param>
        public void AddSearchPathListener(Action<string> listener)
        {
            _searchPathListeners.Add(listener);
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
            var result = new SearchResult();
            var directories = GetDirectories(arguments.BasePath);
            foreach(var dir in directories)
            {
                if (string.IsNullOrEmpty(dir))
                    continue;
                
                SearchingPath(dir);
                if ( string.IsNullOrEmpty(arguments.PathSearch) || dir.ToLower().Contains(arguments.PathSearch))
                {
                    result.Rows.Add(new SearchResultRow
                    {
                        Filename = "",
                        LineNumber = -1,
                        Path = dir
                    });
                }

                if ( arguments.Recursive )
                {
                    var intermediate = await GetResultsFromDirectory(new SearchArguments(dir)
                    {
                        ContentSearch = arguments.ContentSearch,
                        PathSearch = arguments.PathSearch,
                    });

                    result.Rows.AddRange(intermediate.Rows);
                }
            }

            var files = GetFiles(arguments.BasePath);
            foreach (var file in files) 
            {
                if (string.IsNullOrEmpty(file))
                    continue;

                SearchingPath(file);
                
                if ( arguments.PathSearch == null || file.ToLower().Contains(arguments.PathSearch))
                {
                    if ( !string.IsNullOrEmpty(arguments.ContentSearch))
                    {
                        var intermediate = await GetResultsFromFile(arguments.ContentSearch, file);
                        result.Rows.AddRange(intermediate.Rows);
                    }
                    else
                    {
                        result.Rows.Add(new SearchResultRow
                        {
                            Filename = Path.GetFileName(file),
                            LineNumber = -1,
                            Path = file
                        });
                    }
                }
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
                            result.Rows.Add(new SearchResultRow
                            {
                                Filename = fileName,
                                LineNumber = lineNumber,
                                Path = file
                            });
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