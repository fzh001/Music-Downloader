using System.Collections.Generic;

namespace Music_Downloader.QQ
{
    public class QQSearchRoot
    {
        public Data data { get; set; }
    }
    public class Data
    {
        public List<ListItem> list { get; set; }
    }
    public class ListItem
    {
        public string songname { get; set; }
        public string albumname { get; set; }
        public string songmid { get; set; }
        public List<SingerItem> singer { get; set; }
    }
    public class SingerItem
    {
        /// <summary>
        /// 许嵩
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 许嵩
        /// </summary>
        public string name_hilight { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string mid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

    }
}
