using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Downloader
{
    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string singer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string lrc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }

    }



    public class Root1
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }

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
        public List<DataItem> data { get; set; }

    }
}
