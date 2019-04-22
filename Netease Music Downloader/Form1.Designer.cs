namespace Netease_Music_Downloader
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
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDtextBox
            // 
            this.IDtextBox.Location = new System.Drawing.Point(114, 59);
            this.IDtextBox.Name = "IDtextBox";
            this.IDtextBox.Size = new System.Drawing.Size(241, 21);
            this.IDtextBox.TabIndex = 0;
            this.IDtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDtextBox_KeyPress);
            // 
            // GetMusicbutton
            // 
            this.GetMusicbutton.Location = new System.Drawing.Point(361, 59);
            this.GetMusicbutton.Name = "GetMusicbutton";
            this.GetMusicbutton.Size = new System.Drawing.Size(54, 21);
            this.GetMusicbutton.TabIndex = 1;
            this.GetMusicbutton.Text = "获取";
            this.GetMusicbutton.UseVisualStyleBackColor = true;
            this.GetMusicbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "歌单ID（链接）：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "保存地址：";
            // 
            // DownloadPathtextBox
            // 
            this.DownloadPathtextBox.Location = new System.Drawing.Point(80, 90);
            this.DownloadPathtextBox.Name = "DownloadPathtextBox";
            this.DownloadPathtextBox.Size = new System.Drawing.Size(274, 21);
            this.DownloadPathtextBox.TabIndex = 5;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(9, 134);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(406, 317);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "歌名";
            this.columnHeader1.Width = 202;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "歌手";
            this.columnHeader3.Width = 126;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "下载状态";
            this.columnHeader2.Width = 75;
            // 
            // Browsebutton
            // 
            this.Browsebutton.Location = new System.Drawing.Point(360, 90);
            this.Browsebutton.Name = "Browsebutton";
            this.Browsebutton.Size = new System.Drawing.Size(54, 21);
            this.Browsebutton.TabIndex = 9;
            this.Browsebutton.Text = "浏览";
            this.Browsebutton.UseVisualStyleBackColor = true;
            this.Browsebutton.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "搜索歌曲：";
            // 
            // Searchbutton
            // 
            this.Searchbutton.Location = new System.Drawing.Point(362, 12);
            this.Searchbutton.Name = "Searchbutton";
            this.Searchbutton.Size = new System.Drawing.Size(54, 21);
            this.Searchbutton.TabIndex = 11;
            this.Searchbutton.Text = "确定";
            this.Searchbutton.UseVisualStyleBackColor = true;
            this.Searchbutton.Click += new System.EventHandler(this.Searchbutton_Click);
            // 
            // SearchtextBox
            // 
            this.SearchtextBox.Location = new System.Drawing.Point(84, 12);
            this.SearchtextBox.Name = "SearchtextBox";
            this.SearchtextBox.Size = new System.Drawing.Size(272, 21);
            this.SearchtextBox.TabIndex = 0;
            this.SearchtextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchtextBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Location = new System.Drawing.Point(7, 464);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "NiTian Made";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.下载所有歌词ToolStripMenuItem,
            this.下载选中歌词ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "下载所有音乐";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "下载选中音乐";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 下载所有歌词ToolStripMenuItem
            // 
            this.下载所有歌词ToolStripMenuItem.Name = "下载所有歌词ToolStripMenuItem";
            this.下载所有歌词ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.下载所有歌词ToolStripMenuItem.Text = "下载所有歌词";
            this.下载所有歌词ToolStripMenuItem.Click += new System.EventHandler(this.下载所有歌词ToolStripMenuItem_Click);
            // 
            // 下载选中歌词ToolStripMenuItem
            // 
            this.下载选中歌词ToolStripMenuItem.Name = "下载选中歌词ToolStripMenuItem";
            this.下载选中歌词ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.下载选中歌词ToolStripMenuItem.Text = "下载选中歌词";
            this.下载选中歌词ToolStripMenuItem.Click += new System.EventHandler(this.下载选中歌词ToolStripMenuItem_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(349, 455);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "下载歌词";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 39);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 16);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.Text = "网易云音乐";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(104, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 16);
            this.radioButton2.TabIndex = 19;
            this.radioButton2.Text = "酷狗音乐";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(181, 39);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 16);
            this.radioButton3.TabIndex = 20;
            this.radioButton3.Text = "QQ音乐";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // Musicnumlabel
            // 
            this.Musicnumlabel.AutoSize = true;
            this.Musicnumlabel.Location = new System.Drawing.Point(343, 117);
            this.Musicnumlabel.Name = "Musicnumlabel";
            this.Musicnumlabel.Size = new System.Drawing.Size(71, 12);
            this.Musicnumlabel.TabIndex = 21;
            this.Musicnumlabel.Text = "歌曲总数：0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 478);
            this.Controls.Add(this.Musicnumlabel);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Searchbutton);
            this.Controls.Add(this.SearchtextBox);
            this.Controls.Add(this.Browsebutton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.DownloadPathtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GetMusicbutton);
            this.Controls.Add(this.IDtextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Music Downloader Ver.1.2.4";
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
    }
}

