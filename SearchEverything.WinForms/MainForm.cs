using SearchEverything.ApplicationCore;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;

namespace SearchEverything.WinForms
{
    public partial class MainForm : Form
    {
        private SearchEngine _searchEngine;
        private string? _lastSearchPath;
        private SynchronizedCollection<SearchResultRow> _currentResults;

        public MainForm()
        {
            InitializeComponent();
            Text += " - v" + Assembly.GetExecutingAssembly().GetName().Version;
            _currentResults = new SynchronizedCollection<SearchResultRow>();
            _searchEngine = new SearchEngine();
            _searchEngine.AddSearchPathListener((value) => _lastSearchPath = value);
            _searchEngine.AddSearchResultListener((value) => _currentResults.Add(value));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Search.Enabled = false;
            lbl_Status.Text = "Searching...";

            _currentResults.Clear();
            data_ResultDisplay.Rows.Clear();

            var result = await Task.Run(async () => await _searchEngine.Find(new SearchArguments(txt_BasePath.Text)
            {
                ContentSearch = txt_ContentSearch.Text,
                PathSearch = txt_PathSearch.Text,
                Recursive = chk_Recursive.Checked
            }));

            if (result.Errors.Any())
            {
                data_ResultDisplay.Rows.Add(new string[] { "Error messages", string.Empty, string.Empty });
                foreach (var row in result.Errors)
                {
                    data_ResultDisplay.Rows.Add(new string[] { row.ErrorMessage, row.Path, string.Empty });
                }
            }

            btn_Search.Enabled = true;
            lbl_Status.Text = $"Returned {result.Rows.Count} results, with {result.Errors.Count} errors";
        }

        private void btn_BrowserDirectory_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    txt_BasePath.Text = fbd.SelectedPath;
                }
            }
        }

        private void tmr_GuiUpdate_Tick(object sender, EventArgs e)
        {
            if (!btn_Search.Enabled && _lastSearchPath != null)
            {
                lbl_Status.Text = $"Searching {_lastSearchPath}";
            }

            if (data_ResultDisplay.Rows.Count != _currentResults.Count)
            {
                for (int t = data_ResultDisplay.Rows.Count; t < _currentResults.Count; t++)
                {
                    var row = _currentResults.ElementAt(t);
                    data_ResultDisplay.Rows.Add(new string[] { row.Filename, row.Path, row.LineNumber >= 0 ? row.LineNumber.ToString() : string.Empty });
                }
            }
        }
    }
}