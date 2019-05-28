using System.Collections.Generic;

namespace Music_Downloader.Baidu
{
    public class Song_listItem
    {
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
        /// 
        /// </summary>
        public string toneid { get; set; }

        /// <summary>
        /// 明智之举
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long relate_status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string song_source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string all_rate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string song_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long cluster_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long havehigh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string lrclink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string file_duration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string info { get; set; }

        /// <summary>
        /// 华宇世博音乐文化（北京）有限公司-普通代理
        /// </summary>
        public string si_proxycompany { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long charge { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long has_mv_mobile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long learn { get; set; }

        /// <summary>
        /// 许嵩
        /// </summary>
        public string author { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string all_artist_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string has_filmtv { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long resource_type { get; set; }

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
        public string pic_small { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string artist_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long data_source { get; set; }

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
        /// 寻宝游戏
        /// </summary>
        public string album_title { get; set; }

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
        public List<Song_listItem> song_list { get; set; }

    }



    public class BaiduSearchRoot
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
