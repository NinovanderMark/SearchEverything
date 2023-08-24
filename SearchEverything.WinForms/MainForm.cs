using SearchEverything.ApplicationCore;

namespace SearchEverything.WinForms
{
    public partial class MainForm : Form
    {
        private SearchEngine _searchEngine;

        public MainForm()
        {
            InitializeComponent();
            _searchEngine = new SearchEngine();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btn_Search_Click(object sender, EventArgs e)
        {
            var result = await _searchEngine.Find(txt_SearchString.Text, txt_SearchPath.Text, chk_InFiles.Checked);
            data_ResultDisplay.Rows.Clear();

            foreach (var row in result.Rows)
            {
                data_ResultDisplay.Rows.Add(new string[] { row.Filename, row.Path, row.LineNumber.ToString() });
            }
        }
    }
}