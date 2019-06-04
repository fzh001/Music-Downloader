using System.Collections.Generic;

namespace Music_Downloader.KugouMusicList
{
    public class KugouMusicList
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public List<InfoItem> info { get; set; }
    }
    public class InfoItem
    {
        public string audio_id { set; get; }
        /// <summary>
        /// 歌手 - 歌名
        /// </summary>
        public string filename { set; get; }
        /// <summary>
        /// 专辑
        /// </summary>
        public string remark { set; get; }
        /// <summary>
        /// ID
        /// </summary>
        public string hash { set; get; }
    }
}
