using SearchEverything.ApplicationCore;
using System.Reflection;

namespace SearchEverything.WinForms
{
    public partial class MainForm : Form
    {
        private SearchEngine _searchEngine;

        public MainForm()
        {
            InitializeComponent();
            Text += " - v" + Assembly.GetExecutingAssembly().GetName().Version;
            _searchEngine = new SearchEngine();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btn_Search_Click(object sender, EventArgs e)
        {
            btn_Search.Enabled = false;
            lbl_Status.Text = "Searching...";

            var result = await Task.Run(() => SearchFor(txt_SearchString.Text, txt_SearchPath.Text, chk_InFiles.Checked));

            data_ResultDisplay.Rows.Clear();
            foreach (var row in result.Rows)
            {
                data_ResultDisplay.Rows.Add(new string[] { row.Filename, row.Path, row.LineNumber.ToString() });
            }

            btn_Search.Enabled = true;
            lbl_Status.Text = $"Returned {result.Rows.Count} results";
        }

        private async Task<SearchResult> SearchFor(string text, string path, bool inFiles)
        {
            return await _searchEngine.Find(text, path, inFiles);
        }
    }
}