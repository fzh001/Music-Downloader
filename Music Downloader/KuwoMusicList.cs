using System.Collections.Generic;

namespace Music_Downloader.KuwoMusiclist
{
    public class MusiclistItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string AARTIST { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string copyright { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tpay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string formats { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string artist { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FARTIST { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string firstrecordtime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nationid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string collect_num { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string isdownload { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string isstar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FSONGNAME { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string isshow { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string score100 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string overseas_copyright { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string isshowtype { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string displayartistname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string displaysongname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string mp3sig1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string mp3sig2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string displayalbumname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FALBUM { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string hasmv { get; set; }

        /// <summary>
        /// 初めてのデート
        /// </summary>
        public string album { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string albumid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string overseas_pay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string artistid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string musicattachinfoid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nsig2 { get; set; }

        /// <summary>
        /// 初めてのデート;SimorE;初めてのデート;3890999498;3538685204;MUSIC_27992881;344760056;896202754;27992881;0;0;MV_0;0
        /// </summary>
        //public string params { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nsig1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string opay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string isbatch { get; set; }

        /// <summary>
        /// 初めてのデート
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string is_polong { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string online { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string muti_ver { get; set; }

    }



    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public string uname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tagid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long playnum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long sharenum { get; set; }

        /// <summary>
        /// 轻音乐/带来舒适心情，放松旋律
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ispub { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<MusiclistItem> musiclist { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long uid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long songtime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long validtotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ctime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long state { get; set; }

        /// <summary>
        /// 放松,治愈,轻音乐
        /// </summary>
        public string tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long rn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long abstime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long pn { get; set; }

        /// <summary>
        /// 看着舒心的熊猫玩偶，希望带给你愉快的心情，忘记烦恼和远方。本封面选自电影《泰迪熊》有兴趣的同学可以看一下哦。
        /// </summary>
        public string info { get; set; }

    }



    public class KuwoMusicList
    {
        /// <summary>
        /// 
        /// </summary>
        public long code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long timestamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Data data { get; set; }

    }
}
