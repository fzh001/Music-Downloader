namespace Music_Downloader
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.IDtextBox = new System.Windows.Forms.TextBox();
            this.GetMusicbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DownloadPathtextBox = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Browsebutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Searchbutton = new System.Windows.Forms.Button();
            this.SearchtextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.下载所有歌词ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载选中歌词ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.Musicnumlabel = new System.Windows.Forms.Label();
            this.停止下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDtextBox
            // 
            resources.ApplyResources(this.IDtextBox, "IDtextBox");
            this.IDtextBox.Name = "IDtextBox";
            this.IDtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDtextBox_KeyPress);
            // 
            // GetMusicbutton
            // 
            resources.ApplyResources(this.GetMusicbutton, "GetMusicbutton");
            this.GetMusicbutton.Name = "GetMusicbutton";
            this.GetMusicbutton.UseVisualStyleBackColor = true;
            this.GetMusicbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // DownloadPathtextBox
            // 
            resources.ApplyResources(this.DownloadPathtextBox, "DownloadPathtextBox");
            this.DownloadPathtextBox.Name = "DownloadPathtextBox";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // Browsebutton
            // 
            resources.ApplyResources(this.Browsebutton, "Browsebutton");
            this.Browsebutton.Name = "Browsebutton";
            this.Browsebutton.UseVisualStyleBackColor = true;
            this.Browsebutton.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Searchbutton
            // 
            resources.ApplyResources(this.Searchbutton, "Searchbutton");
            this.Searchbutton.Name = "Searchbutton";
            this.Searchbutton.UseVisualStyleBackColor = true;
            this.Searchbutton.Click += new System.EventHandler(this.Searchbutton_Click);
            // 
            // SearchtextBox
            // 
            resources.ApplyResources(this.SearchtextBox, "SearchtextBox");
            this.SearchtextBox.Name = "SearchtextBox";
            this.SearchtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchtextBox_KeyPress);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Name = "label6";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.下载所有歌词ToolStripMenuItem,
            this.下载选中歌词ToolStripMenuItem,
            this.toolStripSeparator2,
            this.停止下载ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 下载所有歌词ToolStripMenuItem
            // 
            this.下载所有歌词ToolStripMenuItem.Name = "下载所有歌词ToolStripMenuItem";
            resources.ApplyResources(this.下载所有歌词ToolStripMenuItem, "下载所有歌词ToolStripMenuItem");
            this.下载所有歌词ToolStripMenuItem.Click += new System.EventHandler(this.下载所有歌词ToolStripMenuItem_Click);
            // 
            // 下载选中歌词ToolStripMenuItem
            // 
            this.下载选中歌词ToolStripMenuItem.Name = "下载选中歌词ToolStripMenuItem";
            resources.ApplyResources(this.下载选中歌词ToolStripMenuItem, "下载选中歌词ToolStripMenuItem");
            this.下载选中歌词ToolStripMenuItem.Click += new System.EventHandler(this.下载选中歌词ToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Checked = true;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // Musicnumlabel
            // 
            resources.ApplyResources(this.Musicnumlabel, "Musicnumlabel");
            this.Musicnumlabel.Name = "Musicnumlabel";
            // 
            // 停止下载ToolStripMenuItem
            // 
            this.停止下载ToolStripMenuItem.Name = "停止下载ToolStripMenuItem";
            resources.ApplyResources(this.停止下载ToolStripMenuItem, "停止下载ToolStripMenuItem");
            this.停止下载ToolStripMenuItem.Click += new System.EventHandler(this.停止下载ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.SearchtextBox);
            this.Controls.Add(this.Musicnumlabel);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Searchbutton);
            this.Controls.Add(this.Browsebutton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.DownloadPathtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetMusicbutton);
            this.Controls.Add(this.IDtextBox);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDtextBox;
        private System.Windows.Forms.Button GetMusicbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DownloadPathtextBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button Browsebutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Searchbutton;
        private System.Windows.Forms.TextBox SearchtextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem 下载所有歌词ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载选中歌词ToolStripMenuItem;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label Musicnumlabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 停止下载ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

