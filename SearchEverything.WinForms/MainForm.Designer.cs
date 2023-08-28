namespace SearchEverything.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            panel6 = new Panel();
            txt_SearchString = new TextBox();
            panel5 = new Panel();
            txt_SearchPath = new TextBox();
            label1 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            chk_InFiles = new CheckBox();
            btn_Search = new Button();
            panel2 = new Panel();
            data_ResultDisplay = new DataGridView();
            col_Filename = new DataGridViewTextBoxColumn();
            col_Path = new DataGridViewTextBoxColumn();
            col_LineNumber = new DataGridViewTextBoxColumn();
            statusStrip1 = new StatusStrip();
            lbl_Status = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)data_ResultDisplay).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(904, 54);
            panel1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(txt_SearchString);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(704, 27);
            panel6.TabIndex = 3;
            // 
            // txt_SearchString
            // 
            txt_SearchString.Dock = DockStyle.Fill;
            txt_SearchString.Location = new Point(0, 0);
            txt_SearchString.Name = "txt_SearchString";
            txt_SearchString.Size = new Size(704, 23);
            txt_SearchString.TabIndex = 1;
            txt_SearchString.Text = "<Search String>";
            // 
            // panel5
            // 
            panel5.Controls.Add(txt_SearchPath);
            panel5.Controls.Add(label1);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 27);
            panel5.Name = "panel5";
            panel5.Size = new Size(704, 27);
            panel5.TabIndex = 2;
            // 
            // txt_SearchPath
            // 
            txt_SearchPath.Dock = DockStyle.Fill;
            txt_SearchPath.Location = new Point(105, 0);
            txt_SearchPath.Margin = new Padding(6, 3, 3, 3);
            txt_SearchPath.Name = "txt_SearchPath";
            txt_SearchPath.Size = new Size(599, 23);
            txt_SearchPath.TabIndex = 1;
            txt_SearchPath.Text = "C:\\";
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(3, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(105, 27);
            label1.TabIndex = 0;
            label1.Text = "Search in directory";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(btn_Search);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(704, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 54);
            panel3.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(chk_InFiles);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(125, 54);
            panel4.TabIndex = 1;
            // 
            // chk_InFiles
            // 
            chk_InFiles.AutoSize = true;
            chk_InFiles.Dock = DockStyle.Top;
            chk_InFiles.Location = new Point(0, 0);
            chk_InFiles.Name = "chk_InFiles";
            chk_InFiles.Size = new Size(125, 19);
            chk_InFiles.TabIndex = 0;
            chk_InFiles.Text = "Search in files";
            chk_InFiles.UseVisualStyleBackColor = true;
            // 
            // btn_Search
            // 
            btn_Search.Dock = DockStyle.Right;
            btn_Search.Location = new Point(125, 0);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(75, 54);
            btn_Search.TabIndex = 0;
            btn_Search.Text = "Search";
            btn_Search.UseVisualStyleBackColor = true;
            btn_Search.Click += btn_Search_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(data_ResultDisplay);
            panel2.Controls.Add(statusStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 54);
            panel2.Name = "panel2";
            panel2.Size = new Size(904, 540);
            panel2.TabIndex = 1;
            // 
            // data_ResultDisplay
            // 
            data_ResultDisplay.AllowUserToAddRows = false;
            data_ResultDisplay.AllowUserToDeleteRows = false;
            data_ResultDisplay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            data_ResultDisplay.Columns.AddRange(new DataGridViewColumn[] { col_Filename, col_Path, col_LineNumber });
            data_ResultDisplay.Dock = DockStyle.Fill;
            data_ResultDisplay.Location = new Point(0, 0);
            data_ResultDisplay.Name = "data_ResultDisplay";
            data_ResultDisplay.ReadOnly = true;
            data_ResultDisplay.RowTemplate.Height = 25;
            data_ResultDisplay.Size = new Size(904, 518);
            data_ResultDisplay.TabIndex = 0;
            // 
            // col_Filename
            // 
            col_Filename.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_Filename.FillWeight = 50F;
            col_Filename.HeaderText = "Filename";
            col_Filename.Name = "col_Filename";
            col_Filename.ReadOnly = true;
            // 
            // col_Path
            // 
            col_Path.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_Path.HeaderText = "Path";
            col_Path.Name = "col_Path";
            col_Path.ReadOnly = true;
            // 
            // col_LineNumber
            // 
            col_LineNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_LineNumber.FillWeight = 25F;
            col_LineNumber.HeaderText = "Line";
            col_LineNumber.Name = "col_LineNumber";
            col_LineNumber.ReadOnly = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lbl_Status });
            statusStrip1.Location = new Point(0, 518);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(904, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbl_Status
            // 
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(39, 17);
            lbl_Status.Text = "Ready";
            // 
            // MainForm
            // 
            AcceptButton = btn_Search;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(904, 594);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Search Everything";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)data_ResultDisplay).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox txt_SearchString;
        private Panel panel3;
        private Panel panel4;
        private CheckBox chk_InFiles;
        private Button btn_Search;
        private DataGridView data_ResultDisplay;
        private DataGridViewTextBoxColumn col_Filename;
        private DataGridViewTextBoxColumn col_Path;
        private DataGridViewTextBoxColumn col_LineNumber;
        private Panel panel6;
        private Panel panel5;
        private TextBox txt_SearchPath;
        private Label label1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbl_Status;
    }
}