using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEverything.ApplicationCore
{
    public class SearchResult
    {
        public List<SearchResultRow> Rows { get; set; } = new List<SearchResultRow>();
        public List<SearchError> Errors { get; set; } = new List<SearchError>();
    }
}
