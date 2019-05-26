using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WMPLib;
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
        ArrayList downloadindices = new ArrayList();
        Thread a;
        List<PlayList> pl = new List<PlayList>();
        string playmode = "shunxu";
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
                        url = "https://v1.itooi.cn/netease/songList?id=" + GetMidText(id, left, "&userid") + "&pageSize=100&page=0&format=1";
                    }
                    else
                    {
                        url = "https://v1.itooi.cn/netease/songList?id=" + id.Substring(id.IndexOf(left) + left.Length) + "&pageSize=100&page=0&format=1";
                    }
                }
                else
                {
                    url = "https://v1.itooi.cn/netease/songList?id=" + id + "&pageSize=100&page=0&format=1";
                }
            }
            if (musicapicode == 2)
            {
                url = "https://v1.itooi.cn/kugou/songList?id=" + id + "&pageSize=100&page=0&format=1";
            }
            if (musicapicode == 3)
            {
                if (id.IndexOf("http://url.cn/") != -1 || id.IndexOf("https://") != -1)
                {
                    string qqid = GetRealUrl(id);
                    url = "https://v1.itooi.cn/tencent/songList?id=" + qqid.Substring(qqid.IndexOf("id=") + 3) + "&pageSize=100&page=0&format=1";
                }
                else
                {
                    if (id.IndexOf("/playlist/") != -1)
                    {
                        url = "https://v1.itooi.cn/tencent/songList?id=" + GetMidText(id, "/playlist/", ".html") + "&pageSize=100&page=0&format=1";
                    }
                    else
                    {
                        url = "https://v1.itooi.cn/tencent/songList?id=" + id + "&pageSize=100&page=0&format=1";
                    }
                }
            }
            if (musicapicode == 4)
            {
                if (id.IndexOf("http://") != -1)
                {
                    if (id.IndexOf("?channelId") != -1)
                    {
                        GetMidText(id, "playlist/", "?channelId");
                    }
                    else
                    {
                        string[] a = id.Split('/');
                        url = "https://v1.itooi.cn/kuwo/songList?id=" + a[a.Length - 1] + "&pageSize=100&page=0&format=1";
                    }
                }
                else
                {
                    url = "https://v1.itooi.cn/kuwo/songList?id=" + id + "&pageSize=100&page=0&format=1";
                }
            }
            if (musicapicode == 5)
            {
                if (id.IndexOf("http://") != -1)
                {
                    if (id.IndexOf("?channelId") != -1)
                    {
                        GetMidText(id, "playlist/", "?channelId");
                    }
                    else
                    {
                        string[] a = id.Split('/');
                        url = "https://v1.itooi.cn/migu/songList?id=" + a[a.Length - 1] + "&pageSize=100&page=0&format=1";
                    }
                }
                else
                {
                    url = "https://v1.itooi.cn/migu/songList?id=" + id + "&pageSize=100&page=0&format=1";
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
            /*
            if (GetApiCode() == 4)
            {
                MessageBox.Show("暂不支持获取改音源的歌单", caption: "提示：");
            }
            */
            skinTabControl1.SelectedIndex = 0;
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
        public void Download(object o)
        {
            string url = "";
            string songname = "";
            string ID = "";
            string singername = "";
            string lrcurl = "";
            Stream s;

            string downloadpath = "";
            List<DownloadList> dl = (List<DownloadList>)o;
            int listviewindicesnum = listView3.Items.Count;
            ArrayList a = new ArrayList();
            for (int i = 0; i < dl.Count; i++)
            {
                a.Add(listView3.Items.Count);
                listView3.Items.Add(dl[i].Songname);
                listView3.Items[listviewindicesnum + i].SubItems.Add(dl[i].Singername);
                listView3.Items[listviewindicesnum + i].SubItems.Add("准备下载");
            }
            for (int i = 0; i < dl.Count; i++)
            {
                //listView3.Items.Add(dl[i].Songname);
                //listView3.Items[(int)a[i]].SubItems.Add(dl[i].Singername);
                //listView3.Items[(int)a[i]].SubItems.Add("准备下载");
                songname = NameCheck(dl[i].Songname);
                ID = dl[i].ID;
                singername = NameCheck(dl[i].Singername);
                downloadpath = dl[i].Savepath;
                if (dl[i].Api == 1)
                {
                    url = "https://v1.itooi.cn/netease/url?id=" + ID + "&quality=320";
                }
                if (dl[i].Api == 2)
                {
                    url = "https://v1.itooi.cn/kugou/url?id=" + ID + "&quality=320";
                }
                if (dl[i].Api == 3)
                {
                    url = "https://v1.itooi.cn/tencent/url?id=" + ID + "&quality=320";
                }
                if (dl[i].Api == 4)
                {
                    url = "https://v1.itooi.cn/kuwo/url?id=" + ID + "&quality=320";
                }
                WebClient wb = new WebClient();
                //listView3.Items[i].SubItems[2].Text = "正在下载";
                try
                {
                    if (dl[i].IfDownloadSong)
                    {
                        listView3.Items[(int)a[i]].SubItems[2].Text = "下载歌曲中";
                        if (!File.Exists(downloadpath + "\\" + songname + " - " + singername + ".mp3"))
                        {
                            wb.DownloadFile(url, downloadpath + "\\" + songname + " - " + singername + ".mp3");
                        }
                    }
                    if (dl[i].IfDownloadlrc)
                    {
                        listView3.Items[listviewindicesnum + i].SubItems[2].Text = "下载歌词中";
                        if (!File.Exists(downloadpath + "\\" + songname + " - " + singername + ".lrc"))
                        {
                            lrcurl = dl[i].LrcUrl;
                            s = wb.OpenRead(lrcurl);
                            StreamReader sr = new StreamReader(s);
                            File.WriteAllText(downloadpath + "\\" + songname + " - " + singername + ".lrc", sr.ReadToEnd(), Encoding.Default);
                        }
                    }
                    listView3.Items[(int)a[i]].SubItems[2].Text = "下载完成";
                }
                catch (Exception)
                {
                    //MessageBox.Show(e.Message, caption: "警告：");
                    listView3.Items[(int)a[i]].SubItems[2].Text = "下载错误";
                }
            }
        }
        /*
        public void Download()
        {
            WebClient wc = new WebClient();
            string url = "";
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
            string url = "";
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
                if (GetApiCode() == 4)
                {
                    url = "https://v1.itooi.cn/kuwo/url?id=" + smusiclist.data[(int)downloadindices[i]].id + "&quality=320";
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
        */
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
            skinTabControl1.ItemSize = new Size(0, 1);
            axWindowsMediaPlayer1.settings.volume = 50;
            string settingpath = Environment.CurrentDirectory + "\\Setting.json";
            if (File.Exists(settingpath))
            {
                StreamReader sr = new StreamReader(settingpath);
                Setting s = JsonConvert.DeserializeObject<Music_Downloader.Setting>(sr.ReadToEnd());
                pl = s.PlayList;
                sr.Close();
                DownloadPathtextBox.Text = s.SavePath;
                IWMPPlaylist l = axWindowsMediaPlayer1.currentPlaylist;
                for (int i = 0; i < s.PlayList.Count; i++)
                {
                    IWMPMedia media = axWindowsMediaPlayer1.newMedia(s.PlayList[i].Url);
                    l.appendItem(media);
                    listView2.Items.Add(s.PlayList[i].SongName);
                    listView2.Items[i].SubItems.Add(s.PlayList[i].SingerName);
                }
                axWindowsMediaPlayer1.currentPlaylist = l;
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            else
            {
                DownloadPathtextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
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
                url = "https://v1.itooi.cn/netease/search?keyword=" + key + "&type=song&pageSize=100&page=0&format=1"; //网易云音乐接口
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
            if (api == 5)
            {
                url = "https://v1.itooi.cn/migu/search?keyword=" + key + "&type=song&pageSize=100&page=0&format=1"; //咪咕音乐接口
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
            if (radioButton5.Checked)
            {
                return 5;
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
            skinTabControl1.SelectedIndex = 0;
            a = new Thread(SearchThread);
            a.Start();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            downloadindices.Clear();
            List<DownloadList> dl = new List<DownloadList>();
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("未获取歌曲", caption: "警告：");
                return;
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                downloadindices.Add(i);
            }
            if (smusiclist != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), smusiclist.data[(int)downloadindices[i]].id, checkBox1.Checked, true, DownloadPathtextBox.Text, smusiclist.data[(int)downloadindices[i]].name, smusiclist.data[(int)downloadindices[i]].singer, smusiclist.data[(int)downloadindices[i]].url, smusiclist.data[(int)downloadindices[i]].lrc));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
            }
            if (musiclist != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), musiclist.data[(int)downloadindices[i]].id, checkBox1.Checked, true, DownloadPathtextBox.Text, musiclist.data[(int)downloadindices[i]].name, musiclist.data[(int)downloadindices[i]].singer, musiclist.data[(int)downloadindices[i]].url, musiclist.data[(int)downloadindices[i]].lrc));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
            }
        }
        public DownloadList SetDownloadMedia(int Api, string ID, bool IfDownloadlrc, bool IfDownloadSong, string Savepath, string Songname, string Singername, string Url, string LrcUrl)
        {
            DownloadList dd = new DownloadList
            {
                Api = Api,
                ID = ID,
                IfDownloadlrc = IfDownloadlrc,
                IfDownloadSong = IfDownloadSong,
                Savepath = Savepath,
                Songname = Songname,
                Singername = Singername,
                Url = Url,
                LrcUrl = LrcUrl
            };
            return dd;
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<DownloadList> dl = new List<DownloadList>();
            downloadindices = GetListViewSelectedIndices();
            if (smusiclist != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), smusiclist.data[(int)downloadindices[i]].id, checkBox1.Checked, true, DownloadPathtextBox.Text, smusiclist.data[(int)downloadindices[i]].name, smusiclist.data[(int)downloadindices[i]].singer, smusiclist.data[(int)downloadindices[i]].url, smusiclist.data[(int)downloadindices[i]].lrc));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
            }
            if (musiclist != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), musiclist.data[(int)downloadindices[i]].id, checkBox1.Checked, true, DownloadPathtextBox.Text, musiclist.data[(int)downloadindices[i]].name, musiclist.data[(int)downloadindices[i]].singer, musiclist.data[(int)downloadindices[i]].url, musiclist.data[(int)downloadindices[i]].lrc));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
            }
        }
        private void 下载所有歌词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            downloadindices.Clear();
            List<DownloadList> dl = new List<DownloadList>();
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("未获取歌曲", caption: "警告：");
                return;
            }
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                downloadindices.Add(i);
            }
            if (smusiclist != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), smusiclist.data[(int)downloadindices[i]].id, true, false, DownloadPathtextBox.Text, smusiclist.data[(int)downloadindices[i]].name, smusiclist.data[(int)downloadindices[i]].singer, smusiclist.data[(int)downloadindices[i]].url, smusiclist.data[(int)downloadindices[i]].lrc));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
            }
            if (musiclist != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), musiclist.data[(int)downloadindices[i]].id, true, false, DownloadPathtextBox.Text, musiclist.data[(int)downloadindices[i]].name, musiclist.data[(int)downloadindices[i]].singer, musiclist.data[(int)downloadindices[i]].url, musiclist.data[(int)downloadindices[i]].lrc));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
            }
        }
        private void 下载选中歌词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<DownloadList> dl = new List<DownloadList>();
            downloadindices = GetListViewSelectedIndices();
            if (smusiclist != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), smusiclist.data[(int)downloadindices[i]].id, true, false, DownloadPathtextBox.Text, smusiclist.data[(int)downloadindices[i]].name, smusiclist.data[(int)downloadindices[i]].singer, smusiclist.data[(int)downloadindices[i]].url, smusiclist.data[(int)downloadindices[i]].lrc));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
            }
            if (musiclist != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), musiclist.data[(int)downloadindices[i]].id, true, false, DownloadPathtextBox.Text, musiclist.data[(int)downloadindices[i]].name, musiclist.data[(int)downloadindices[i]].singer, musiclist.data[(int)downloadindices[i]].url, musiclist.data[(int)downloadindices[i]].lrc));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
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
            Setting s = new Setting
            {
                SavePath = DownloadPathtextBox.Text,
                PlayList = pl
            };
            string json = JsonConvert.SerializeObject(s);
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\Setting.json");
            sw.Write(json);
            sw.Flush();
            sw.Close();
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
            axWindowsMediaPlayer1.Ctlcontrols.next();
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.previous();
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                pictureBox1.Image = Properties.Resources.pause;
                return;
            }
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pictureBox1.Image = Properties.Resources.play;
                return;
            }
            if (axWindowsMediaPlayer1.currentPlaylist.count != 0)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pictureBox1.Image = Properties.Resources.pause;
            }
        }
        private void PictureBox5_Click(object sender, EventArgs e)
        {
            skinTabControl1.SelectedIndex = 1;
        }
        private void PictureBox6_Click(object sender, EventArgs e)
        {
            skinTabControl1.SelectedIndex = 0;
        }
        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ArrayList a = new ArrayList();
            a = GetListViewSelectedIndices();
            if (smusiclist != null)
            {
                Play(smusiclist.data[(int)a[0]].url);
            }
            if (musiclist != null)
            {
                Play(musiclist.data[(int)a[0]].url);
            }
        }
        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ArrayList a = new ArrayList();
            a = GetListViewSelectedIndices();
            if (smusiclist != null)
            {
                Play(smusiclist.data[(int)a[0]].url);
            }
            if (musiclist != null)
            {
                Play(musiclist.data[(int)a[0]].url);
            }
        }
        public void Play(string url)
        {
            axWindowsMediaPlayer1.URL = url;
            axWindowsMediaPlayer1.Ctlcontrols.play();
            timer2.Enabled = true;
        }
        public void Volumechange(int num)
        {
            axWindowsMediaPlayer1.settings.volume = num;
        }
        public void Positionchange(int p)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = (double)p;
        }
        private void MetroTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            Volumechange(metroTrackBar2.Value);
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            metroTrackBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.currentMedia.duration != 0)
            {
                metroTrackBar1.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;
                timer2.Enabled = false;
            }
        }
        private void MetroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Positionchange(metroTrackBar1.Value);
        }
        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ArrayList a = new ArrayList();
            a = GetListViewSelectedIndices();
            for (int i = 0; i < a.Count; i++)
            {
                PlayList p = new PlayList();
                if (smusiclist != null)
                {
                    p.SongName = smusiclist.data[(int)a[i]].name;
                    p.SingerName = smusiclist.data[(int)a[i]].singer;
                    p.Url = smusiclist.data[(int)a[i]].url;
                    p.LrcUrl = smusiclist.data[(int)a[i]].lrc;
                    p.ID = smusiclist.data[(int)a[i]].id;
                }
                else
                {
                    p.SongName = musiclist.data[(int)a[i]].name;
                    p.SingerName = musiclist.data[(int)a[i]].singer;
                    p.Url = musiclist.data[(int)a[i]].url;
                    p.LrcUrl = musiclist.data[(int)a[i]].lrc;
                    p.ID = musiclist.data[(int)a[i]].id;
                }
                AddMusicToList(p);
            }
        }
        public void AddMusicToList(PlayList p)
        {
            pl.Add(p);
            listView2.Items.Add(p.SongName);
            listView2.Items[listView2.Items.Count - 1].SubItems.Add(p.SingerName);
            IWMPMedia media = axWindowsMediaPlayer1.newMedia(p.Url);
            axWindowsMediaPlayer1.currentPlaylist.appendItem(media);
        }
        private void PictureBox7_Click(object sender, EventArgs e)
        {
            skinTabControl1.SelectedIndex = 2;
        }
        private void ListView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                ToolStripMenuItem3_Click(this, new EventArgs());
            }
            else
            {
                toolStripMenuItem2_Click(this, new EventArgs());
            }
        }
        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (playmode == "shunxu")
            {
                pictureBox4.Image = Properties.Resources.suiji;
                playmode = "suiji";
                axWindowsMediaPlayer1.settings.setMode("shuffle", true);
            }
            else
            {
                pictureBox4.Image = Properties.Resources.shunxu;
                playmode = "shunxu";
                axWindowsMediaPlayer1.settings.setMode("shuffle", false);
            }
        }
        public class DownloadList
        {
            public string Songname { get; set; }
            public string Singername { get; set; }
            public string Url { get; set; }
            public string Savepath { get; set; }
            public string ID { get; set; }
            public int Api { get; set; }
            public bool IfDownloadlrc { get; set; }
            public bool IfDownloadSong { get; set; }
            public string LrcUrl { set; get; }
        }
        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            downloadindices.Clear();
            List<DownloadList> dl = new List<DownloadList>();
            if (listView2.Items.Count == 0)
            {
                MessageBox.Show("未获取歌曲", caption: "警告：");
                return;
            }
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                downloadindices.Add(i);
            }
            for (int i = 0; i < downloadindices.Count; i++)
            {
                dl.Add(SetDownloadMedia(GetApiCode(), pl[i].ID, checkBox1.Checked, true, DownloadPathtextBox.Text, pl[i].SongName, pl[i].SingerName, pl[i].Url, pl[i].LrcUrl));
            }
            Thread t = new Thread(new ParameterizedThreadStart(Download));
            t.Start(dl);
        }
        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            List<DownloadList> dl = new List<DownloadList>();
            downloadindices = GetListViewSelectedIndices_musiclist();
            for (int i = 0; i < downloadindices.Count; i++)
            {
                dl.Add(SetDownloadMedia(GetApiCode(), pl[(int)downloadindices[i]].ID, checkBox1.Checked, true, DownloadPathtextBox.Text, pl[(int)downloadindices[i]].SongName, pl[(int)downloadindices[i]].SingerName, pl[(int)downloadindices[i]].Url, pl[(int)downloadindices[i]].LrcUrl));
            }
            Thread t = new Thread(new ParameterizedThreadStart(Download));
            t.Start(dl);
        }
        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            downloadindices.Clear();
            List<DownloadList> dl = new List<DownloadList>();
            if (listView2.Items.Count == 0)
            {
                MessageBox.Show("未获取歌曲", caption: "警告：");
                return;
            }
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                downloadindices.Add(i);
            }
            for (int i = 0; i < downloadindices.Count; i++)
            {
                dl.Add(SetDownloadMedia(GetApiCode(), pl[(int)downloadindices[i]].ID, true, false, DownloadPathtextBox.Text, pl[(int)downloadindices[i]].SongName, pl[(int)downloadindices[i]].SingerName, pl[(int)downloadindices[i]].Url, pl[(int)downloadindices[i]].LrcUrl));
            }
            Thread t = new Thread(new ParameterizedThreadStart(Download));
            t.Start(dl);
        }
        private void ToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            List<DownloadList> dl = new List<DownloadList>();
            downloadindices = GetListViewSelectedIndices_musiclist();
            for (int i = 0; i < downloadindices.Count; i++)
            {
                dl.Add(SetDownloadMedia(GetApiCode(), pl[(int)downloadindices[i]].ID, true, false, DownloadPathtextBox.Text, pl[(int)downloadindices[i]].SongName, pl[(int)downloadindices[i]].SingerName, pl[(int)downloadindices[i]].Url, pl[(int)downloadindices[i]].LrcUrl));
            }
            Thread t = new Thread(new ParameterizedThreadStart(Download));
            t.Start(dl);
        }
        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ArrayList a = new ArrayList();
            a = GetListViewSelectedIndices_musiclist();
            for (int i = 0; i < a.Count; i++)
            {
                IWMPMedia media = axWindowsMediaPlayer1.currentPlaylist.Item[(int)a[i] - i];
                axWindowsMediaPlayer1.currentPlaylist.removeItem(media);
                ListViewItem l = listView2.Items[(int)a[i] - i];
                listView2.Items.Remove(l);
                pl.Remove(pl[(int)a[i] - i]);
            }
        }
        public ArrayList GetListViewSelectedIndices_musiclist()
        {
            ArrayList a = new ArrayList();
            string mes = null;
            for (int i = 0; i < listView2.SelectedIndices.Count; i++)
            {
                a.Add(listView2.SelectedIndices[i]);
            }
            foreach (int i in a)
            {
                mes += i.ToString();
            }
            return a;
        }
        private void 删除该项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IfAllDownloadFinish())
            {
                MessageBox.Show("该功能不能用于取消下载，请等待所有下载完成后再试。", caption: "提示：");
            }
            else
            {
                for (int i = 0; i < listView3.SelectedIndices.Count; i++)
                {
                    listView3.Items[listView1.SelectedIndices[i]].Remove();
                }
            }
        }
        public bool IfAllDownloadFinish()
        {
            for (int i = 0; i < listView3.Items.Count; i++)
            {
                if (listView3.Items[i].SubItems[2].Text != "下载完成")
                {
                    return false;
                }
            }
            return true;
        }
        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About aboutform = new About();
            aboutform.Show();
        }
    }
}
