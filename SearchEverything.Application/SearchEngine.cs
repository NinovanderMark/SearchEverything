namespace SearchEverything.ApplicationCore
{
    public class SearchEngine
    {
        public async Task<SearchResult> Find(string text, string basePath, bool inFiles = false)
        {
           return await GetResultsFromDirectory(text, basePath, inFiles);
        }

        private async Task<SearchResult> GetResultsFromDirectory(string text, string path, bool inFiles)
        {
            var result = new SearchResult();
            var directories = GetDirectories(path);
            foreach(var d in directories)
            {
                if ( d.Contains(text))
                {
                    result.Rows.Add(new SearchResultRow
                    {
                        Filename = "",
                        LineNumber = -1,
                        Path = d
                    });
                }

                var intermediate = await GetResultsFromDirectory(text, d, inFiles);
                result.Rows.AddRange(intermediate.Rows);
            }

            var files = GetFiles(path);
            foreach (var file in files) 
            {
                if ( inFiles )
                {
                    var intermediate = await GetResultsFromFile(text, file);
                    result.Rows.AddRange(intermediate.Rows);
                }
                else
                {
                    if ( file.Contains(text))
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
            using (StreamReader sr = new StreamReader(file))
            {
                long lineNumber = 0;
                while (!sr.EndOfStream)
                {
                    string? line = await sr.ReadLineAsync();
                    if ( line != null && line.Contains(text))
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

            return result;
        }
    }
}