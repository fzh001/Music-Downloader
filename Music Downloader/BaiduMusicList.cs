using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Downloader.BaiduMusiclist
{
    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string pic_s130 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string resource_type_ext { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string piao_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string mv_provider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string biaoshi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long is_first_publish { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string del_status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string korean_bb_song { get; set; }

        /// <summary>
        /// 味道
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string distribution { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string toneid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string relate_status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pic_big { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string all_rate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string song_source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string song_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string is_ksong { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string file_duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long havehigh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string share { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pic_radio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long has_mv_mobile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long charge { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long learn { get; set; }

        /// <summary>
        /// 辛晓琪
        /// </summary>
        public string author { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string all_artist_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string resource_type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long has_mv { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string bitrate_fee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string high_rate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string versions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string album_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string copy_type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ting_uid { get; set; }

        /// <summary>
        /// 味道
        /// </summary>
        public string album_title { get; set; }

    }



    public class BaiduMusicList
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
        public List<DataItem> data { get; set; }

    }
}
