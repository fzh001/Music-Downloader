using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Music_Downloader
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        //全局变量
        Music_Downloader.Root1 musiclist;
        SearchRoot smusiclist;
        bool onlydownloadlrc;
        int MusicAPICode;
        ArrayList downloadindices = new ArrayList();
        Thread a;


        public string GetMusiclistJson(string id, int musicapicode)
        {
            string url = null;
            WebClient wc = new WebClient();
            Stream stream;
            StreamReader sr = null;

            if (musicapicode == 1)
            {
                string left = "playlist?id=";
                if (id.IndexOf(left) != -1)
                {
                    if (id.IndexOf("&userid") != -1)
                    {
                        url = "https://v1.itooi.cn/netease/songList?id=" + GetMidText(id, left, "&userid") + "&format=1";
                    }
                    else
                    {
                        url = "https://v1.itooi.cn/netease/songList?id=" + id.Substring(id.IndexOf(left) + left.Length) + "&format=1";
                    }
                }
                else
                {
                    url = "https://v1.itooi.cn/netease/songList?id=" + id + "&format=1";
                }
            }
            if (musicapicode == 2)
            {
                url = "https://v1.itooi.cn/kugou/songList?id=" + IDtextBox.Text;
            }
            if (musicapicode == 3)
            {
                if (IDtextBox.Text.IndexOf("http://url.cn/") != -1 || IDtextBox.Text.IndexOf("https://") != -1)
                {
                    string qqid = GetRealUrl(IDtextBox.Text);
                    url = "https://v1.itooi.cn/tencent/songList?id=" + qqid.Substring(qqid.IndexOf("id=") + 3);
                }
                else
                {
                    if (IDtextBox.Text.IndexOf("/playlist/") != -1)
                    {
                        url = "https://v1.itooi.cn/tencent/songList?id=" + GetMidText(IDtextBox.Text, "/playlist/", ".html");
                    }
                    else
                    {
                        url = "https://v1.itooi.cn/tencent/songList?id=" + IDtextBox.Text;
                    }
                }
            }
            try
            {
                stream = wc.OpenRead(url);
                sr = new StreamReader(stream);
                return sr.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 取文本中间
        /// </summary>
        /// <param name="text">源文本</param>
        /// <param name="left">前文本</param>
        /// <param name="right">后文本</param>
        /// <returns></returns>
        public string GetMidText(string text, string left, string right)
        {
            try
            {
                int leftnum = text.IndexOf(left);
                int rightnum = text.IndexOf(right);
                return text.Substring(leftnum + left.Length, rightnum - (leftnum + left.Length));
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void ParsingJson(string url)
        {
            Music_Downloader.Root1 re = JsonConvert.DeserializeObject<Music_Downloader.Root1>(url);
            musiclist = re;
            for (int i = 0; i < re.data.Count; i++)
            {
                listView1.Items.Add(re.data[i].name);
                listView1.Items[i].SubItems.Add(musiclist.data[i].singer);
                listView1.Items[i].SubItems.Add("未下载");
            }
        }

        public string GetRealUrl(string url)
        {
            HttpWebRequest wbrequest = (HttpWebRequest)WebRequest.Create(url);
            wbrequest.Method = "GET";
            wbrequest.KeepAlive = true;
            HttpWebResponse wbresponse = (HttpWebResponse)wbrequest.GetResponse();
            return wbresponse.ResponseUri.ToString();
        }

        public class Songs
        {
            public string id { get; set; }
            public string name { get; set; }
            public string singer { get; set; }
            public string pic { get; set; }
            public string lrc { get; set; }
            public string url { get; set; }
            public int time { get; set; }
        }

        public class Data
        {
            public string songListId { get; set; }
            public string songListName { get; set; }
            public string songListPic { get; set; }
            public int songListCount { get; set; }
            public int songListPlayCount { get; set; }
            public string songListDescription { get; set; }
            public int songListUserId { get; set; }
            public List<Songs> songs { get; set; }
        }

        public class MusiclistRoot
        {
            public string result { get; set; }
            public int code { get; set; }
            public Data data { get; set; }
        }

        public void GetMusicListThread()
        {
            if (IDtextBox.Text == null || IDtextBox.Text == "")
            {
                MessageBox.Show("ID不能为空", caption: "警告：");
                return;
            }
            if (IDtextBox.Text.IndexOf("qq.com") != -1)
            {
                radioButton3.Checked = true;
            }
            if (IDtextBox.Text.IndexOf("163.com") != -1)
            {
                radioButton1.Checked = true;
            }
            listView1.Items.Clear();
            musiclist = null;
            smusiclist = null;
            MusicAPICode = GetApiCode();
            string musiclistjson = GetMusiclistJson(IDtextBox.Text, GetApiCode());
            if (musiclistjson == null)
            {
                MessageBox.Show("歌单获取错误", caption: "警告：");
                return;
            }
            ParsingJson(musiclistjson);
            Musicnumlabel.Text = "歌曲总数：" + listView1.Items.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = new Thread(GetMusicListThread);
            a.Start();
        }

        public string NameCheck(string name)
        {
            string re = name.Replace("*", " ");
            re = re.Replace("\\", " ");
            re = re.Replace("\"", " ");
            re = re.Replace("<", " ");
            re = re.Replace(">", " ");
            re = re.Replace("|", " ");
            re = re.Replace("?", " ");
            re = re.Replace("/", ",");
            re = re.Replace(":", "：");
            return re;
        }

        public void Download()
        {
            WebClient wc = new WebClient();
            string url="";
            string songname;
            string lrcurl;
            Stream s;
            string singer;
            int wrongdownload = 0;
            for (int i = 0; i < downloadindices.Count; i++)
            {
                if (GetApiCode() == 1)
                {
                    url = "https://v1.itooi.cn/netease/url?id=" + musiclist.data[(int)downloadindices[i]].id + "&quality=320";
                }
                if (GetApiCode() == 2)
                {
                    url = "https://v1.itooi.cn/kugou/url?id=" + musiclist.data[(int)downloadindices[i]].id + "&quality=320";
                }
                if (GetApiCode() == 3)
                {
                    url = "https://v1.itooi.cn/tencent/url?id=" + musiclist.data[(int)downloadindices[i]].id + "&quality=320";
                }
                //url = "https://v1.itooi.cn/tencent/url?id="+musiclist.data[(int)downloadindices[i]].id + "&quality=320";
                WebClient wb = new WebClient();
                listView1.Items[(int)downloadindices[i]].SubItems[2].Text = "正在下载";
                songname = NameCheck(musiclist.data[(int)downloadindices[i]].name);
                singer = NameCheck(musiclist.data[(int)downloadindices[i]].singer);
                try
                {
                    if (onlydownloadlrc == false)
                    {
                        if (!File.Exists(DownloadPathtextBox.Text + "\\" + songname + " - " + singer + ".mp3"))
                        {
                            wb.DownloadFile(url, DownloadPathtextBox.Text + "\\" + songname + " - " + singer + ".mp3");
                        }
                    }
                    if (checkBox1.Checked == true)
                    {
                        if (!File.Exists(DownloadPathtextBox.Text + "\\" + songname + " - " + singer + ".lrc"))
                        {
                            lrcurl = musiclist.data[(int)downloadindices[i]].lrc;
                            s = wb.OpenRead(lrcurl);
                            StreamReader sr = new StreamReader(s);
                            File.WriteAllText(DownloadPathtextBox.Text + "\\" + songname + " - " + singer + ".lrc", sr.ReadToEnd(), Encoding.Default);
                        }
                    }
                    listView1.Items[(int)downloadindices[i]].SubItems[2].Text = "下载完成";
                }
                catch (Exception)
                {
                    //MessageBox.Show(e.Message, caption: "警告：");
                    listView1.Items[(int)downloadindices[i]].SubItems[2].Text = "下载错误";
                    wrongdownload++;
                }
                listView1.EnsureVisible((int)downloadindices[i]);
            }
            if (downloadindices.Count > 1)
            {
                MessageBox.Show("下载完成" + "\r\n" + "下载成功:" + (downloadindices.Count - wrongdownload).ToString() + "\r\n" + "下载失败:" + wrongdownload.ToString(), caption: "提示：");
            }
        }

        public void sDownload()
        {
            string url="";
            string songname;
            string lrcurl;
            Stream s;
            int wrongdownload = 0;
            string singer;
            for (int i = 0; i < downloadindices.Count; i++)
            {
                if (GetApiCode() == 1)
                {
                    url = "https://v1.itooi.cn/netease/url?id=" + smusiclist.data[(int)downloadindices[i]].id + "&quality=320";
                }
                if (GetApiCode() == 2)
                {
                    url = "https://v1.itooi.cn/kugou/url?id=" + smusiclist.data[(int)downloadindices[i]].id + "&quality=320";
                }
                if (GetApiCode() == 3)
                {
                    url = "https://v1.itooi.cn/tencent/url?id=" + smusiclist.data[(int)downloadindices[i]].id + "&quality=320";
                }
                //url = smusiclist.data[(int)downloadindices[i]].url;
                singer = NameCheck(smusiclist.data[(int)downloadindices[i]].singer);
                WebClient wb = new WebClient();
                listView1.Items[(int)downloadindices[i]].SubItems[2].Text = "正在下载";
                songname = NameCheck(smusiclist.data[(int)downloadindices[i]].name);
                try
                {
                    if (onlydownloadlrc == false)
                    {
                        if (!File.Exists(DownloadPathtextBox.Text + "\\" + songname + " - " + singer + ".mp3"))
                        {
                            wb.DownloadFile(url, DownloadPathtextBox.Text + "\\" + songname + " - " + singer + ".mp3");
                        }
                    }
                    if (checkBox1.Checked == true)
                    {
                        if (!File.Exists(DownloadPathtextBox.Text + "\\" + songname + " - " + singer + ".lrc"))
                        {
                            lrcurl = smusiclist.data[(int)downloadindices[i]].lrc;
                            s = wb.OpenRead(lrcurl);
                            StreamReader sr = new StreamReader(s);
                            File.WriteAllText(DownloadPathtextBox.Text + "\\" + songname + " - " + singer + ".lrc", sr.ReadToEnd(), Encoding.Default);
                        }
                    }
                    listView1.Items[(int)downloadindices[i]].SubItems[2].Text = "下载完成";
                }
                catch (Exception)
                {
                    //MessageBox.Show(e.Message, caption: "警告：");
                    listView1.Items[(int)downloadindices[i]].SubItems[2].Text = "下载错误";
                    wrongdownload++;
                }
                listView1.EnsureVisible((int)downloadindices[i]);
            }
            if (downloadindices.Count > 1)
            {
                MessageBox.Show("下载完成" + "\r\n" + "下载成功:" + (downloadindices.Count - wrongdownload).ToString() + "\r\n" + "下载失败:" + wrongdownload.ToString(), caption: "提示：");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onlydownloadlrc = false;
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("未获取歌曲", caption: "警告：");
                return;
            }
            if (smusiclist != null)
            {
                Thread a = new Thread(sDownload);
                a.Start();
            }
            if (musiclist != null)
            {
                Thread a = new Thread(Download);
                a.Start();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            DownloadPathtextBox.Text = fbd.SelectedPath;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread a = new Thread(update);
            a.Start();
            if (File.Exists(Environment.CurrentDirectory + "\\Newtonsoft.Json.dll") != true)
            {
                File.WriteAllBytes(Environment.CurrentDirectory + "\\Newtonsoft.Json.dll", Properties.Resources.Newtonsoft_Json);
                Application.Restart();
            }
            if (File.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Netease Music Downloader\\SavePath.ini") == true)
            {
                DownloadPathtextBox.Text = File.ReadAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Netease Music Downloader\\SavePath.ini");
            }
            else
            {
                DownloadPathtextBox.Text = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic);
            }
        }

        private void IDtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void SearchtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Searchbutton_Click(this, new EventArgs());
            }
        }

        /// <summary>
        /// 音乐搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="api">音乐接口 网易云音乐：1|酷狗音乐：2|QQ音乐：3</param>
        /// <returns></returns>
        public SearchRoot SearchMusic(string key, int api)
        {
            string url = null;
            if (api == 1)
            {
                url = "https://v1.itooi.cn/netease/search?keyword=" + key+ "&type=song&pageSize=100&page=0&format=1"; //网易云音乐接口
            }
            if (api == 2)   
            {
                url = "https://v1.itooi.cn/kugou/search?keyword=" + key + "&type=song&pageSize=100&page=0&format=1";  //酷狗音乐接口
            }
            if (api == 3)
            {
                url = "https://v1.itooi.cn/tencent/search?keyword=" + key + "&type=song&pageSize=100&page=0&format=1"; //QQ音乐接口
            }
            if (api == 4)
            {
                url = "https://v1.itooi.cn/kuwo/search?keyword=" + key + "&type=song&pageSize=100&page=0&format=1"; //酷我音乐接口
            }
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url);
                StreamReader sr = new StreamReader(stream);
                SearchRoot re = JsonConvert.DeserializeObject<SearchRoot>(sr.ReadToEnd());
                return re;
            }
            catch
            {
                return null;
            }
        }

        public int GetApiCode()
        {
            if (radioButton1.Checked)
            {
                return 1;
            }
            if (radioButton2.Checked)
            {
                return 2;
            }
            if (radioButton3.Checked)
            {
                return 3;
            }
            if (radioButton4.Checked)
            {
                return 4;
            }
            return 0;
        }

        public void SearchThread()
        {
            if (SearchtextBox.Text == null || SearchtextBox.Text == "")
            {
                MessageBox.Show("搜索内容不能为空", caption: "警告：");
                return;
            }
            listView1.Items.Clear();
            musiclist = null;
            smusiclist = SearchMusic(SearchtextBox.Text, GetApiCode());
            if (smusiclist == null)
            {
                MessageBox.Show("未搜索到相关内容", caption: "警告：");
                return;
            }
            MusicAPICode = GetApiCode();
            for (int i = 0; i < smusiclist.data.Count; i++)
            {
                listView1.Items.Add(smusiclist.data[i].name);
                listView1.Items[i].SubItems.Add(smusiclist.data[i].singer);
                listView1.Items[i].SubItems.Add("未下载");
            }
            Musicnumlabel.Text = "歌曲总数：" + listView1.Items.Count;
        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            a = new Thread(SearchThread);
            a.Start();
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            onlydownloadlrc = false;
            downloadindices.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                downloadindices.Add(i);
            }
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("未获取歌曲", caption: "警告：");
                return;
            }
            if (smusiclist != null)
            {
                a = new Thread(sDownload);
                a.Start();
            }
            if (musiclist != null)
            {
                a = new Thread(Download);
                a.Start();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            onlydownloadlrc = false;
            downloadindices = GetListViewSelectedIndices();
            if (smusiclist != null)
            {
                a = new Thread(sDownload);
                a.Start();
            }
            if (musiclist != null)
            {
                a = new Thread(Download);
                a.Start();
            }
        }

        private void 下载所有歌词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onlydownloadlrc = true;
            downloadindices.Clear();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                downloadindices.Add(i);
            }
            if (musiclist != null)
            {
                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("未获取歌曲", caption: "警告：");
                    return;
                }
                onlydownloadlrc = true;
                checkBox1.Checked = true;
                a = new Thread(Download);
                a.Start();
            }
            if (smusiclist != null)
            {
                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("未获取歌曲", caption: "警告：");
                    return;
                }
                onlydownloadlrc = true;
                checkBox1.Checked = true;
                a = new Thread(sDownload);
                a.Start();
            }
        }

        private void 下载选中歌词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onlydownloadlrc = true;
            checkBox1.Checked = true;
            downloadindices = GetListViewSelectedIndices();
            if (smusiclist != null)
            {
                a = new Thread(sDownload);
                a.Start();
            }
            if (musiclist != null)
            {
                a = new Thread(Download);
                a.Start();
            }
        }

        public class Data1
        {
            /// <summary>
            /// 569200213
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 消愁
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 毛不易
            /// </summary>
            public string singer { get; set; }
            /// <summary>
            /// http://p2.music.126.net/vmCcDvD1H04e9gm97xsCqg==/109951163350929740.jpg?param=400y400
            /// </summary>
            public string pic { get; set; }
            /// <summary>
            /// https://v1.itooi.cn/netease/lrc?id=569200213&
            /// </summary>
            public string lrc { get; set; }
            /// <summary>
            /// https://v1.itooi.cn/netease/url?id=569200213&
            /// </summary>
            public string url { get; set; }
            /// <summary>
            /// Time
            /// </summary>
            public int time { get; set; }
        }

        public class SearchRoot
        {
            /// <summary>
            /// SUCCESS
            /// </summary>
            public string result { get; set; }
            /// <summary>
            /// Code
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// Data
            /// </summary>
            public List<Data1> data { get; set; }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            toolStripMenuItem2_Click(this, new EventArgs());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Netease Music Downloader") == false)
            {
                Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Netease Music Downloader");
            }
            File.WriteAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Netease Music Downloader\\SavePath.ini", DownloadPathtextBox.Text);
        }

        public void update()
        {
            string ver = "1.2.6";
            WebClient wb = new WebClient();
            Stream webdata = wb.OpenRead("http://96.45.180.29/Update/NeteaseMusicDownloader.txt");
            StreamReader sr = new StreamReader(webdata);
            string data = sr.ReadToEnd();
            if (ver != data)
            {
                if (MessageBox.Show("检测到新版本，是否打开更新页面？", caption: "提示：", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", "https://www.52pojie.cn/thread-929956-1-1.html");
                }
            }
        }

        public ArrayList GetListViewSelectedIndices()
        {
            ArrayList a = new ArrayList();
            string mes = null;
            for (int i = 0; i < listView1.SelectedIndices.Count; i++)
            {
                a.Add(listView1.SelectedIndices[i]);
            }
            foreach (int i in a)
            {
                mes += i.ToString();
            }
            return a;
        }

        private void 停止下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            a.Abort();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer.exe", DownloadPathtextBox.Text);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
