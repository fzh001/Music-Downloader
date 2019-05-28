using System.Collections.Generic;

namespace Music_Downloader.Kuwo
{
    public class KuwoSearchRoot
    {
        public List<DataItem> data { get; set; }
    }
    public class DataItem
    {
        public string SONGNAME { get; set; }
        public string ARTIST { get; set; }
        public string ALBUM { get; set; }
        public string MUSICRID { get; set; }
    }

}
