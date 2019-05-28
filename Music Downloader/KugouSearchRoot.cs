using System.Collections.Generic;

namespace Music_Downloader.Kugou
{
    public class KugouSearchRoot
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
    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public long total { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long istagresult { get; set; }

        /// <summary>
        /// 全部
        /// </summary>
        public string tab { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long correctiontype { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long forcecorrection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public List<AggregationItem> aggregation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string correctiontip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long istag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long allowerr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<InfoItem> info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long timestamp { get; set; }

    }
    public class InfoItem
    {
        public string hash { get; set; }
        public string songname { get; set; }
        public string singername { get; set; }
        public string album_name { get; set; }
    }
}

