using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
        //Music_Downloader.Root1 musiclist;
        //SearchRoot Searchresult;
        List<SearchResult> Searchresult;
        ArrayList downloadindices = new ArrayList();
        Thread a;
        List<PlayList> pl = new List<PlayList>();
        string playmode = "shunxu";
        LrcDetails lrcd = new LrcDetails();
        public List<SearchResult> GetMusiclistJson(string id, int musicapicode)
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
                        url = "https://v1.itooi.cn/netease/songList?id=" + GetMidText(id, left, "&userid") + "&pageSize=100&page=0";
                    }
                    else
                    {
                        url = "https://v1.itooi.cn/netease/songList?id=" + id.Substring(id.IndexOf(left) + left.Length) + "&pageSize=100&page=0";
                    }
                }
                else
                {
                    url = "https://v1.itooi.cn/netease/songList?id=" + id + "&pageSize=100&page=0";
                }
                try
                {
                    stream = wc.OpenRead(url);
                    sr = new StreamReader(stream);
                    NeteaseMusiclist.NeateaseMusicList json = JsonConvert.DeserializeObject<NeteaseMusiclist.NeateaseMusicList>(sr.ReadToEnd());
                    List<SearchResult> re = new List<SearchResult>();
                    for (int i = 0; i < json.data.tracks.Count; i++)
                    {
                        SearchResult s = new SearchResult
                        {
                            id = json.data.tracks[i].id.ToString(),
                            Album = json.data.tracks[i].album.name,
                            lrcurl = "https://v1.itooi.cn/netease/lrc?id=" + json.data.tracks[i].id.ToString(),
                            url = "https://v1.itooi.cn/netease/url?id=" + json.data.tracks[i].id.ToString(),
                            SongName = json.data.tracks[i].name,
                            SingerName = json.data.tracks[i].artists[0].name
                        };
                        re.Add(s);
                    }
                    return re;
                }
                catch
                {
                    return null;
                }
            }
            if (musicapicode == 2)
            {
                url = "https://v1.itooi.cn/kugou/songList?id=" + id + "&pageSize=100&page=0";
                if (id.IndexOf("https://www.kugou.com") != -1)
                {
                    url = "https://v1.itooi.cn/kugou/songList?id=" + GetMidText(id, "/single/", ".html") + "&pageSize=100&page=0";
                }
                try
                {
                    stream = wc.OpenRead(url);
                    sr = new StreamReader(stream);
                    string ss = sr.ReadToEnd();
                    KugouMusicList.KugouMusicList json = JsonConvert.DeserializeObject<KugouMusicList.KugouMusicList>(ss);
                    List<SearchResult> re = new List<SearchResult>();
                    for (int i = 0; i < json.data.info.Count; i++)
                    {
                        string[] n = json.data.info[i].filename.Replace(" ", "").Split('-');
                        SearchResult s = new SearchResult
                        {
                            id = json.data.info[i].hash,
                            Album = json.data.info[i].remark,
                            lrcurl = "https://v1.itooi.cn/netease/lrc?id=" + json.data.info[i].hash,
                            url = "https://v1.itooi.cn/netease/url?id=" + json.data.info[i].hash,
                            SongName = n[1],
                            SingerName = n[0]
                        };
                        re.Add(s);
                    }
                    return re;
                }
                catch(Exception e)
                {
                    return null;
                }
            }
            if (musicapicode == 3)
            {
                if (id.IndexOf("http://url.cn/") != -1 || id.IndexOf("https://c.y.qq.com/") != -1)
                {
                    string qqid = GetRealUrl(id);
                    url = "https://v1.itooi.cn/tencent/songList?id=" + qqid.Substring(qqid.IndexOf("id=") + 3) + "&pageSize=100&page=0";
                }
                else
                {
                    if (id.IndexOf("/playlist/") != -1)
                    {
                        url = "https://v1.itooi.cn/tencent/songList?id=" + GetMidText(id, "/playlist/", ".html") + "&pageSize=100&page=0";
                    }
                    else
                    {
                        url = "https://v1.itooi.cn/tencent/songList?id=" + id + "&pageSize=100&page=0";
                    }
                }
                try
                {
                    stream = wc.OpenRead(url);
                    sr = new StreamReader(stream);
                    QQMusicList.QQMusicList json = JsonConvert.DeserializeObject<QQMusicList.QQMusicList>(sr.ReadToEnd());
                    List<SearchResult> re = new List<SearchResult>();
                    string sn = "";
                    for (int i = 0; i < json.data[0].songlist.Count; i++)
                    {
                        for (int x = 0; x < json.data[0].songlist[i].singer.Count; x++)
                        {
                            if (json.data[0].songlist[i].singer.Count - x == 1)
                            {
                                sn += json.data[0].songlist[i].singer[x].name;
                            }
                            else
                            {
                                sn += json.data[0].songlist[i].singer[x].name + "、";
                            }
                        }
                        SearchResult s = new SearchResult
                        {
                            id = json.data[0].songlist[i].mid,
                            Album = json.data[0].songlist[i].album.name,
                            lrcurl = "https://v1.itooi.cn/tencent/lrc?id=" + json.data[0].songlist[i].id.ToString(),
                            url = "https://v1.itooi.cn/tencent/url?id=" + json.data[0].songlist[i].id.ToString(),
                            SongName = json.data[0].songlist[i].name,
                            SingerName = sn
                        };
                        sn = "";
                        re.Add(s);
                    }
                    return re;
                }
                catch
                {
                    return null;
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
                        url = "https://v1.itooi.cn/kuwo/songList?id=" + a[a.Length - 1] + "&pageSize=100&page=0";
                    }
                }
                else
                {
                    url = "https://v1.itooi.cn/kuwo/songList?id=" + id + "&pageSize=100&page=0";
                }
                try
                {
                    stream = wc.OpenRead(url);
                    sr = new StreamReader(stream);
                    KuwoMusiclist.KuwoMusicList json = JsonConvert.DeserializeObject<KuwoMusiclist.KuwoMusicList>(sr.ReadToEnd());
                    List<SearchResult> re = new List<SearchResult>();
                    for (int i = 0; i < json.data.musiclist.Count; i++)
                    {
                        SearchResult s = new SearchResult
                        {
                            id = json.data.musiclist[i].id,
                            Album = json.data.musiclist[i].album,
                            lrcurl = "https://v1.itooi.cn/netease/lrc?id=" + json.data.musiclist[i].id,
                            url = "https://v1.itooi.cn/netease/url?id=" + json.data.musiclist[i].id,
                            SongName = json.data.musiclist[i].name,
                            SingerName = json.data.musiclist[i].artist
                        };
                        re.Add(s);
                    }
                    return re;
                }
                catch
                {
                    return null;
                }
            }
            if (musicapicode == 5)
            {
                if (id.IndexOf("http://") != -1)
                {
                    string[] a = id.Split('/');
                    url = "https://v1.itooi.cn/baidu/songList?id=" + a[a.Length - 1];
                }
                else
                {
                    url = "https://v1.itooi.cn/baidu/songList?id=" + id;
                }
                try
                {
                    stream = wc.OpenRead(url);
                    sr = new StreamReader(stream);
                    BaiduMusiclist.BaiduMusicList json = JsonConvert.DeserializeObject<BaiduMusiclist.BaiduMusicList>(sr.ReadToEnd());
                    List<SearchResult> re = new List<SearchResult>();
                    for (int i = 0; i < json.data.Count; i++)
                    {
                        SearchResult s = new SearchResult
                        {
                            id = json.data[i].song_id,
                            Album = json.data[i].album_title,
                            lrcurl = "https://v1.itooi.cn/netease/lrc?id=" + json.data[i].song_id,
                            url = "https://v1.itooi.cn/netease/url?id=" + json.data[i].song_id,
                            SongName = json.data[i].title,
                            SingerName = json.data[i].author
                        };
                        re.Add(s);
                    }
                    return re;
                }
                catch
                {
                    return null;
                }
            }
            return null;
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
        public void GetMusicListThread(object id)
        {
            if ((string)id == null || (string)id == "")
            {
                MessageBox.Show("ID不能为空", caption: "警告：");
                return;
            }
            if (id.ToString().IndexOf("qq.com") != -1)
            {
                radioButton3.Checked = true;
            }
            if (id.ToString().IndexOf("163.com") != -1)
            {
                radioButton1.Checked = true;
            }
            Searchresult = GetMusiclistJson(id.ToString(), GetApiCode());
            if (Searchresult == null)
            {
                MessageBox.Show("歌单获取错误", caption: "警告：");
                return;
            }
            listView1.Items.Clear();
            for (int i = 0; i < Searchresult.Count; i++)
            {
                listView1.Items.Add(Searchresult[i].SongName);
                listView1.Items[i].SubItems.Add(Searchresult[i].SingerName);
                listView1.Items[i].SubItems.Add(Searchresult[i].Album);
            }
            Musicnumlabel.Text = "歌曲总数：" + listView1.Items.Count;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Items.Add("搜索中...");
            skinTabControl1.SelectedIndex = 0;
            a = new Thread(new ParameterizedThreadStart(GetMusicListThread));
            a.Start(IDtextBox.Text);
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
                songname = NameCheck(dl[i].Songname);
                ID = dl[i].ID;
                singername = NameCheck(dl[i].Singername);
                downloadpath = dl[i].Savepath;
                if (dl[i].Api == 1)
                {
                    url = "https://v1.itooi.cn/netease/url?id=" + ID + "&quality=" + dl[i].DownloadQuality;
                }
                if (dl[i].Api == 2)
                {
                    url = "https://v1.itooi.cn/kugou/url?id=" + ID + "&quality=" + dl[i].DownloadQuality;
                }
                if (dl[i].Api == 3)
                {
                    url = "https://v1.itooi.cn/tencent/url?id=" + ID + "&quality=" + dl[i].DownloadQuality;
                }
                if (dl[i].Api == 4)
                {
                    url = "https://v1.itooi.cn/kuwo/url?id=" + ID + "&quality=" + dl[i].DownloadQuality;
                }
                if (dl[i].Api == 5)
                {
                    url = "https://v1.itooi.cn/baidu/url?id=" + ID + "&quality=" + dl[i].DownloadQuality;
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
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message, caption: "警告：");
                    listView3.Items[(int)a[i]].SubItems[2].Text = "下载错误";
                }
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
            skinTabControl1.ItemSize = new Size(0, 1);
            axWindowsMediaPlayer1.settings.volume = 50;
            string settingpath = Environment.CurrentDirectory + "\\Setting.json";
            axWindowsMediaPlayer1.settings.setMode("shuffle", false);
            if (File.Exists(settingpath))
            {
                StreamReader sr = new StreamReader(settingpath);
                Setting s = JsonConvert.DeserializeObject<Music_Downloader.Setting>(sr.ReadToEnd());
                pl = s.PlayList;
                metroTrackBar2.Value = s.Volume;
                sr.Close();
                DownloadPathtextBox.Text = s.SavePath;
                metroComboBox1.SelectedIndex = s.DownloadQuality;
                IWMPPlaylist l = axWindowsMediaPlayer1.currentPlaylist;
                for (int i = 0; i < s.PlayList.Count; i++)
                {
                    IWMPMedia media = axWindowsMediaPlayer1.newMedia(s.PlayList[i].Url);
                    l.appendItem(media);
                    listView2.Items.Add(s.PlayList[i].SongName);
                    listView2.Items[i].SubItems.Add(s.PlayList[i].SingerName);
                    listView2.Items[i].SubItems.Add(s.PlayList[i].Album);
                }
                axWindowsMediaPlayer1.currentPlaylist = l;
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
            else
            {
                DownloadPathtextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                metroComboBox1.SelectedIndex = 4;
            }
            //MessageBox.Show(axWindowsMediaPlayer1.currentPlaylist.count.ToString());
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
        public class SearchResult
        {
            public string SongName;
            public string SingerName;
            public string Album;
            public string url;
            public string lrcurl;
            public string id;
        }
        /// <summary>
        /// 音乐搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="api"></param>
        /// <returns></returns>
        public List<SearchResult> SearchMusic(string key, int api, string quality)
        {
            string url = null;
            List<SearchResult> re = new List<SearchResult>();
            if (api == 1)
            {
                url = "https://v1.itooi.cn/netease/search?keyword=" + key + "&type=song&pageSize=100&page=0"; //网易云音乐接口
                try
                {
                    WebClient wc = new WebClient();
                    Stream stream = wc.OpenRead(url);
                    StreamReader sr = new StreamReader(stream);
                    Music_Downloader.Netease.NeteaseSearchRoot root = JsonConvert.DeserializeObject<Music_Downloader.Netease.NeteaseSearchRoot>(sr.ReadToEnd());
                    string sn = "";
                    for (int i = 0; i < root.data.songs.Count; i++)
                    {
                        for (int x = 0; x < root.data.songs[i].ar.Count; x++)
                        {
                            if (root.data.songs[i].ar.Count - x == 1)
                            {
                                sn += root.data.songs[i].ar[x].name;
                            }
                            else
                            {
                                sn += root.data.songs[i].ar[x].name + "、";
                            }
                        }
                        SearchResult s = new SearchResult
                        {
                            SongName = root.data.songs[i].name,
                            SingerName = sn,
                            Album = root.data.songs[i].al.name,
                            id = root.data.songs[i].id.ToString(),
                            url = "https://v1.itooi.cn/netease/url?id=" + root.data.songs[i].id.ToString() + "&quality=" + quality,
                            lrcurl = "https://v1.itooi.cn/netease/lrc?id=" + root.data.songs[i].id.ToString()
                        };
                        sn = "";
                        re.Add(s);
                    }
                    return re;
                }
                catch
                {
                    return null;
                }
            }
            if (api == 2)
            {
                url = "https://v1.itooi.cn/kugou/search?keyword=" + key + "&type=song&pageSize=100&page=0"; //酷狗音乐接口
                try
                {
                    WebClient wc = new WebClient();
                    Stream stream = wc.OpenRead(url);
                    StreamReader sr = new StreamReader(stream);
                    Music_Downloader.Kugou.KugouSearchRoot root = JsonConvert.DeserializeObject<Music_Downloader.Kugou.KugouSearchRoot>(sr.ReadToEnd());
                    for (int i = 0; i < root.data.info.Count; i++)
                    {
                        SearchResult s = new SearchResult
                        {
                            SongName = root.data.info[i].songname,
                            SingerName = root.data.info[i].singername,
                            Album = root.data.info[i].album_name,
                            id = root.data.info[i].hash.ToString(),
                            url = "https://v1.itooi.cn/kugou/url?id=" + root.data.info[i].hash.ToString(),
                            lrcurl = "https://v1.itooi.cn/kugou/lrc?id=" + root.data.info[i].hash.ToString()
                        };
                        re.Add(s);
                    }
                    return re;
                }
                catch
                {
                    return null;
                }
            }
            if (api == 3)
            {
                url = "https://v1.itooi.cn/tencent/search?keyword=" + key + "&type=song&pageSize=100&page=0"; //QQ音乐接口
                try
                {
                    WebClient wc = new WebClient();
                    Stream stream = wc.OpenRead(url);
                    StreamReader sr = new StreamReader(stream);
                    Music_Downloader.QQ.QQSearchRoot root = JsonConvert.DeserializeObject<Music_Downloader.QQ.QQSearchRoot>(sr.ReadToEnd());
                    string sn = "";
                    for (int i = 0; i < root.data.list.Count; i++)
                    {
                        for (int x = 0; x < root.data.list[i].singer.Count; x++)
                        {
                            if (root.data.list[i].singer.Count - x == 1)
                            {
                                sn += root.data.list[i].singer[x].name;
                            }
                            else
                            {
                                sn += root.data.list[i].singer[x].name + "、";
                            }
                        }
                        SearchResult s = new SearchResult
                        {
                            SongName = root.data.list[i].songname,
                            SingerName = sn,
                            Album = root.data.list[i].albumname,
                            id = root.data.list[i].songmid,
                            url = "https://v1.itooi.cn/tencent/url?id=" + root.data.list[i].songmid + "&quality=" + quality,
                            lrcurl = "https://v1.itooi.cn/tencent/lrc?id=" + root.data.list[i].songmid
                        };
                        sn = "";
                        re.Add(s);
                    }
                    return re;
                }
                catch
                {
                    return null;
                }
            }
            if (api == 4)
            {
                url = "https://v1.itooi.cn/kuwo/search?keyword=" + key + "&type=song&pageSize=100&page=0"; //酷我音乐接口
                try
                {
                    WebClient wc = new WebClient();
                    Stream stream = wc.OpenRead(url);
                    StreamReader sr = new StreamReader(stream);
                    Music_Downloader.Kuwo.KuwoSearchRoot root = JsonConvert.DeserializeObject<Music_Downloader.Kuwo.KuwoSearchRoot>(sr.ReadToEnd());
                    for (int i = 0; i < root.data.Count; i++)
                    {
                        SearchResult s = new SearchResult
                        {
                            SongName = root.data[i].SONGNAME,
                            SingerName = root.data[i].ARTIST,
                            Album = root.data[i].ALBUM,
                            id = root.data[i].MUSICRID.Replace("MUSIC_", ""),
                            url = "https://v1.itooi.cn/kuwo/url?id=" + root.data[i].MUSICRID.Replace("MUSIC_", "") + "&quality=" + quality,
                            lrcurl = "https://v1.itooi.cn/kuwo/lrc?id=" + root.data[i].MUSICRID.Replace("MUSIC_", "")
                        };
                        re.Add(s);
                    }
                    return re;
                }
                catch
                {
                    return null;
                }
            }
            if (api == 5)
            {
                url = "https://v1.itooi.cn/baidu/search?keyword=" + key + "&type=song&pageSize=100&page=0"; //咪咕音乐接口
                try
                {
                    WebClient wc = new WebClient();
                    Stream stream = wc.OpenRead(url);
                    StreamReader sr = new StreamReader(stream);
                    Music_Downloader.Baidu.BaiduSearchRoot root = JsonConvert.DeserializeObject<Music_Downloader.Baidu.BaiduSearchRoot>(sr.ReadToEnd());
                    for (int i = 0; i < root.data.song_list.Count; i++)
                    {
                        SearchResult s = new SearchResult
                        {
                            SongName = root.data.song_list[i].title,
                            SingerName = root.data.song_list[i].author,
                            Album = root.data.song_list[i].album_title,
                            id = root.data.song_list[i].song_id,
                            url = "https://v1.itooi.cn/baidu/url?id=" + root.data.song_list[i].song_id + "&quality=" + quality,
                            lrcurl = "https://v1.itooi.cn/baidu/lrc?id=" + root.data.song_list[i].song_id
                        };
                        re.Add(s);
                    }
                    return re;
                }
                catch
                {
                    return null;
                }
            }
            return null;
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
        public string GetQuality()
        {
            if (metroComboBox1.SelectedIndex == 0)
            {
                return "48";
            }
            if (metroComboBox1.SelectedIndex == 1)
            {
                return "96";
            }
            if (metroComboBox1.SelectedIndex == 2)
            {
                return "128";
            }
            if (metroComboBox1.SelectedIndex == 3)
            {
                return "192";
            }
            if (metroComboBox1.SelectedIndex == 4)
            {
                return "320";
            }
            return "";
        }
        public void SearchThread()
        {
            if (SearchtextBox.Text == null || SearchtextBox.Text == "")
            {
                MessageBox.Show("搜索内容不能为空", caption: "警告：");
                return;
            }
            Searchresult = SearchMusic(SearchtextBox.Text, GetApiCode(), GetQuality());
            if (Searchresult == null)
            {
                MessageBox.Show("搜索异常", caption: "警告：");
                return;
            }
            listView1.Items.Clear();
            for (int i = 0; i < Searchresult.Count; i++)
            {
                listView1.Items.Add(Searchresult[i].SongName);
                listView1.Items[i].SubItems.Add(Searchresult[i].SingerName);
                listView1.Items[i].SubItems.Add(Searchresult[i].Album);
            }
            Musicnumlabel.Text = "歌曲总数：" + listView1.Items.Count;
        }
        private void Searchbutton_Click(object sender, EventArgs e)
        {
            skinTabControl1.SelectedIndex = 0;
            listView1.Items.Clear();
            listView1.Items.Add("搜索中...");
            try
            {
                a = new Thread(SearchThread);
                a.Start();
            }
            catch
            {

            }
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
            if (Searchresult != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), Searchresult[(int)downloadindices[i]].id, checkBox1.Checked, true, DownloadPathtextBox.Text, Searchresult[(int)downloadindices[i]].SongName, Searchresult[(int)downloadindices[i]].SingerName, Searchresult[(int)downloadindices[i]].url, Searchresult[(int)downloadindices[i]].lrcurl, Searchresult[(int)downloadindices[i]].Album, GetQuality()));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
            }
        }
        public DownloadList SetDownloadMedia(int Api, string ID, bool IfDownloadlrc, bool IfDownloadSong, string Savepath, string Songname, string Singername, string Url, string LrcUrl, string Album, string DownloadQulity)
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
                LrcUrl = LrcUrl,
                Album = Album,
                DownloadQuality = DownloadQulity
            };
            return dd;
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<DownloadList> dl = new List<DownloadList>();
            downloadindices = GetListViewSelectedIndices();
            if (Searchresult != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), Searchresult[(int)downloadindices[i]].id, checkBox1.Checked, true, DownloadPathtextBox.Text, Searchresult[(int)downloadindices[i]].SongName, Searchresult[(int)downloadindices[i]].SingerName, Searchresult[(int)downloadindices[i]].url, Searchresult[(int)downloadindices[i]].lrcurl, Searchresult[(int)downloadindices[i]].Album, GetQuality()));
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
            if (Searchresult != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), Searchresult[(int)downloadindices[i]].id, true, false, DownloadPathtextBox.Text, Searchresult[(int)downloadindices[i]].SongName, Searchresult[(int)downloadindices[i]].SingerName, Searchresult[(int)downloadindices[i]].url, Searchresult[(int)downloadindices[i]].lrcurl, Searchresult[(int)downloadindices[i]].Album, GetQuality()));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
            }
        }
        private void 下载选中歌词ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<DownloadList> dl = new List<DownloadList>();
            downloadindices = GetListViewSelectedIndices();
            if (Searchresult != null)
            {
                for (int i = 0; i < downloadindices.Count; i++)
                {
                    dl.Add(SetDownloadMedia(GetApiCode(), Searchresult[(int)downloadindices[i]].id, true, false, DownloadPathtextBox.Text, Searchresult[(int)downloadindices[i]].SongName, Searchresult[(int)downloadindices[i]].SingerName, Searchresult[(int)downloadindices[i]].url, Searchresult[(int)downloadindices[i]].lrcurl, Searchresult[(int)downloadindices[i]].Album, GetQuality()));
                }
                Thread t = new Thread(new ParameterizedThreadStart(Download));
                t.Start(dl);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Setting s = new Setting
            {
                SavePath = DownloadPathtextBox.Text,
                PlayList = pl,
                DownloadQuality = metroComboBox1.SelectedIndex,
                Volume = metroTrackBar2.Value
            };
            string json = JsonConvert.SerializeObject(s);
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\Setting.json");
            sw.Write(json);
            sw.Flush();
            sw.Close();
        }
        public void update()
        {
            try
            {
                string ver = "1.3.2";
                WebClient wb = new WebClient();
                Stream webdata = wb.OpenRead("http://wqq1024028162.lofter.com/post/30925c26_1c5d90636");
                StreamReader sr = new StreamReader(webdata);
                string data = sr.ReadToEnd();
                if (ver != GetMidText(data, "{", "}"))
                {
                    if (MessageBox.Show("检测到新版本，是否打开更新页面？", caption: "提示：", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start("explorer.exe", "http://wqq1024028162.lofter.com/post/30925c26_1c5d90636");
                    }
                }
            }
            catch
            {
                //MessageBox.Show("检查更新失败", caption: "警告: ");
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
                pictureBox1.Image = Properties.Resources.play;
                return;
            }
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pictureBox1.Image = Properties.Resources.pause;
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
            try
            {
                ArrayList a = new ArrayList();
                a = GetListViewSelectedIndices();
                if (Searchresult != null)
                {
                    Play(Searchresult[(int)a[0]].url, (int)a[0]);
                }
                WebClient wc = new WebClient();
                Stream s = wc.OpenRead(Searchresult[(int)a[0]].lrcurl);
                StreamReader sr = new StreamReader(s);
                string lrc = sr.ReadToEnd();
                LrcDetails lrcdd = LrcReader(lrc);
                label9.Text = Searchresult[(int)a[0]].SongName + " - " + Searchresult[(int)a[0]].SingerName;
                label9.Location = new Point((424 - label9.Width) / 2, label9.Location.Y);
            }
            catch
            {

            }
        }
        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ArrayList a = new ArrayList();
            a = GetListViewSelectedIndices();
            if (Searchresult != null)
            {
                Play(Searchresult[(int)a[0]].url, (int)a[0]);
            }
        }
        public void Play(string url, int n)
        {
            int ret = CheckRepeat(url);
            if (ret != -1)
            {
                axWindowsMediaPlayer1.Ctlcontrols.currentItem = axWindowsMediaPlayer1.currentPlaylist.Item[ret];
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pictureBox1.Image = Properties.Resources.pause;
            }
            else
            {
                PlayList p = new PlayList()
                {
                    Album = Searchresult[n].Album,
                    ID = Searchresult[n].id,
                    LrcUrl = Searchresult[n].lrcurl,
                    Url = Searchresult[n].url,
                    SongName = Searchresult[n].SongName,
                    SingerName = Searchresult[n].SingerName
                };
                pl.Add(p);
                IWMPMedia media = axWindowsMediaPlayer1.newMedia(url);
                axWindowsMediaPlayer1.currentPlaylist.appendItem(media);
                axWindowsMediaPlayer1.Ctlcontrols.currentItem = axWindowsMediaPlayer1.currentPlaylist.Item[axWindowsMediaPlayer1.currentPlaylist.count - 1];
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pictureBox1.Image = Properties.Resources.pause;

                listView2.Items.Add(Searchresult[n].SongName);
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(Searchresult[n].SingerName);
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(Searchresult[n].Album);
                //timer2.Enabled = true;
            }
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
            try
            {
                metroTrackBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                if (axWindowsMediaPlayer1.currentMedia.duration != 0)
                {
                    metroTrackBar1.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration + 2;
                    //timer2.Enabled = false;
                }
            }
            catch
            {

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
                if (Searchresult != null)
                {
                    PlayList p = new PlayList
                    {
                        SongName = Searchresult[(int)a[i]].SongName,
                        SingerName = Searchresult[(int)a[i]].SingerName,
                        Url = Searchresult[(int)a[i]].url,
                        LrcUrl = Searchresult[(int)a[i]].lrcurl,
                        ID = Searchresult[(int)a[i]].id,
                        Album = Searchresult[(int)a[i]].Album
                    };
                    AddMusicToList(p);
                }
            }
        }
        public void AddMusicToList(PlayList p)
        {
            pl.Add(p);
            listView2.Items.Add(p.SongName);
            listView2.Items[listView2.Items.Count - 1].SubItems.Add(p.SingerName);
            listView2.Items[listView2.Items.Count - 1].SubItems.Add(p.Album);
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
            public string DownloadQuality { set; get; }
            public string Album { get; set; }
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
                dl.Add(SetDownloadMedia(GetApiCode(), pl[i].ID, checkBox1.Checked, true, DownloadPathtextBox.Text, pl[i].SongName, pl[i].SingerName, pl[i].Url, pl[i].LrcUrl, pl[i].Album, GetQuality()));
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
                dl.Add(SetDownloadMedia(GetApiCode(), pl[(int)downloadindices[i]].ID, checkBox1.Checked, true, DownloadPathtextBox.Text, pl[(int)downloadindices[i]].SongName, pl[(int)downloadindices[i]].SingerName, pl[(int)downloadindices[i]].Url, pl[(int)downloadindices[i]].LrcUrl, pl[(int)downloadindices[i]].Album, GetQuality()));
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
                dl.Add(SetDownloadMedia(GetApiCode(), pl[(int)downloadindices[i]].ID, true, false, DownloadPathtextBox.Text, pl[(int)downloadindices[i]].SongName, pl[(int)downloadindices[i]].SingerName, pl[(int)downloadindices[i]].Url, pl[(int)downloadindices[i]].LrcUrl, pl[(int)downloadindices[i]].Album, GetQuality()));
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
                dl.Add(SetDownloadMedia(GetApiCode(), pl[(int)downloadindices[i]].ID, true, false, DownloadPathtextBox.Text, pl[(int)downloadindices[i]].SongName, pl[(int)downloadindices[i]].SingerName, pl[(int)downloadindices[i]].Url, pl[(int)downloadindices[i]].LrcUrl, pl[(int)downloadindices[i]].Album, GetQuality()));
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
        public ArrayList GetListViewSelectedIndices_downloadlist()
        {
            ArrayList a = new ArrayList();
            string mes = null;
            for (int i = 0; i < listView3.SelectedIndices.Count; i++)
            {
                a.Add(listView3.SelectedIndices[i]);
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
                ArrayList a = new ArrayList();
                a = GetListViewSelectedIndices_downloadlist();
                for (int i = 0; i < a.Count; i++)
                {
                    listView3.Items[(int)a[i] - i].Remove();
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
        private void ListView2_DoubleClick(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                ToolStripMenuItem10_Click(this, new EventArgs());
            }
            else
            {
                ToolStripMenuItem6_Click(this, new EventArgs());
            }
        }
        private void ToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList a = new ArrayList();
                a = GetListViewSelectedIndices_musiclist();
                IWMPMedia media = axWindowsMediaPlayer1.newMedia(pl[(int)a[0]].Url);
                axWindowsMediaPlayer1.Ctlcontrols.currentItem = axWindowsMediaPlayer1.currentPlaylist.Item[(int)a[0]];
                axWindowsMediaPlayer1.Ctlcontrols.play();
                pictureBox1.Image = Properties.Resources.pause;
                LrcDetails lrcdd = LrcReader(pl[(int)a[0]].LrcUrl);
                label9.Text = Searchresult[(int)a[0]].SongName + " - " + Searchresult[(int)a[0]].SingerName;
                label9.Location = new Point((424 - label9.Width) / 2, label9.Location.Y);
            }
            catch
            {

            }
            //MessageBox.Show(axWindowsMediaPlayer1.currentPlaylist.count.ToString());
        }
        public LrcDetails LrcReader(string url)
        {
            WebClient wc = new WebClient();
            Stream s = wc.OpenRead(url);
            StreamReader sr = new StreamReader(s);
            string lrc = sr.ReadToEnd();
            lrcd.url = url;
            lrcd.LrcWord = new List<LrcContent>();
            lrc.Replace("\r\n", "");
            string[] a = lrc.Split('[');
            string nlrc = "";
            for (int i = 1; i < a.Length; i++)
            {
                nlrc += "[" + a[i];
            }
            string[] c = { "\r", "\n" };
            string[] b = nlrc.Split(new char[2] { '\r', '\n' });
            foreach (string d in b)
            {
                if (d.StartsWith("[ti:"))
                {
                    lrcd.Title = SplitInfo(d);
                }
                else if (d.StartsWith("[ar:"))
                {
                    lrcd.Artist = SplitInfo(d);
                }
                else if (d.StartsWith("[al:"))
                {
                    lrcd.Album = SplitInfo(d);
                }
                else if (d.StartsWith("[by:"))
                {
                    lrcd.LrcBy = SplitInfo(d);
                }
                else if (d.StartsWith("[offset:"))
                {
                    lrcd.Offset = SplitInfo(d);
                }
                else
                {
                    try
                    {
                        Regex regexword = new Regex(@".*\](.*)");
                        Match mcw = regexword.Match(d);
                        string word = mcw.Groups[1].Value;
                        Regex regextime = new Regex(@"\[([0-9.:]*)\]", RegexOptions.Compiled);
                        MatchCollection mct = regextime.Matches(d);
                        foreach (Match item in mct)
                        {
                            double time = TimeSpan.Parse("00:" + item.Groups[1].Value).TotalSeconds;
                            LrcContent l = new LrcContent()
                            {
                                Time = time,
                                Ci = word
                            };
                            lrcd.LrcWord.Add(l);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            return lrcd;
        }
        static string SplitInfo(string line)
        {
            return line.Substring(line.IndexOf(":") + 1).TrimEnd(']');
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsPlaying)
            {
                for (int i = 0; i < lrcd.LrcWord.Count; i++)
                {
                    try
                    {
                        if (((int)lrcd.LrcWord[i].Time - 1) <= metroTrackBar1.Value && metroTrackBar1.Value <= ((int)lrcd.LrcWord[i + 1].Time - 1))
                        {
                            label8.Text = lrcd.LrcWord[i].Ci;
                            i++;
                            label8.Location = new Point((424 - label8.Width) / 2, label8.Location.Y);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                    if (i > lrcd.LrcWord.Count)
                    {
                        timer3.Enabled = false;
                    }
                }
            }
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsMediaEnded)
            {
                label8.Text = "当前无音乐播放";
                label8.Location = new Point((424 - label8.Width) / 2, label8.Location.Y);
                label9.Text = "歌曲名";
            }
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsBuffering)
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    if (axWindowsMediaPlayer1.currentMedia.sourceURL == pl[i].Url)
                    {
                        //label8.Text = "加载中";
                        label8.Location = new Point((424 - label8.Width) / 2, label8.Location.Y);
                        label9.Text = pl[i].SongName + " - " + pl[i].SingerName;
                        label9.Location = new Point((424 - label9.Width) / 2, label9.Location.Y);
                    }
                }
            }
        }
        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsMediaEnded)
            {
                label8.Text = "当前无音乐播放";
                label9.Text = "歌曲名";
                label8.Location = new Point((424 - label8.Width) / 2, label8.Location.Y);
                label9.Location = new Point((424 - label9.Width) / 2, label9.Location.Y);
            }
        }
        private void MediaEndAndChangeLrc(object i)
        {
            try
            {
                LrcDetails lrcdd = LrcReader(pl[(int)i].LrcUrl);
            }
            catch
            {

            }
        }
        public int CheckRepeat(string url)
        {
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                if (url == pl[i].Url)
                {
                    return i;
                }
            }
            return -1;
        }
        public void HotMusicList()
        {
            skinTabControl1.SelectedIndex = 0;
            Searchresult = GetMusiclistJson("3778678", 1);
            listView1.Items.Clear();
            if (Searchresult != null)
            {
                for (int i = 0; i < Searchresult.Count; i++)
                {
                    listView1.Items.Add(Searchresult[i].SongName);
                    listView1.Items[i].SubItems.Add(Searchresult[i].SingerName);
                    listView1.Items[i].SubItems.Add(Searchresult[i].Album);
                }
            }
        }
        private void ToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Items.Add("获取中...");
            Thread a = new Thread(HotMusicList);
            a.Start();
        }

        private void AxWindowsMediaPlayer1_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            //MessageBox.Show("MediaChange");
            for (int i = 0; i < pl.Count; i++)
            {
                if (axWindowsMediaPlayer1.currentMedia.sourceURL == pl[i].Url)
                {
                    if (pl[i].LrcUrl != lrcd.url)
                    {
                        MediaEndAndChangeLrc(i);
                    }
                }
            }
        }
        private void LinkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}