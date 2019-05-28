using System.Collections.Generic;

namespace Music_Downloader.QQMusicList
{
    public class TagsItem
    {
        /// <summary>
        /// 日语
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long pid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }

    }



    public class SingerItem
    {
        /// <summary>
        /// 加治ひとみ
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string mid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 加治ひとみ (加治瞳)
        /// </summary>
        public string title { get; set; }

    }



    public class File
    {
        /// <summary>
        /// 
        /// </summary>
        public long size_320mp3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_96aac { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_aac { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_dts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_128 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long try_end { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long e_30s { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long b_30s { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_24aac { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_48aac { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_320 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long try_begin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_128mp3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_192aac { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_ogg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_flac { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string media_mid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_ape { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_192ogg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long size_try { get; set; }

    }



    public class Action
    {
        /// <summary>
        /// 
        /// </summary>
        public long msgpay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long alert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long msgid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long icons { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public long switch { get; set; }

    }



    public class Ksong
    {
        /// <summary>
        /// 
        /// </summary>
        public string mid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }

    }



    public class Album
    {
        /// <summary>
        /// 《双星之阴阳师》TV动画第2-13集片尾曲
        /// </summary>
        public string subtitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string mid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }

    }



    public class Mv
    {
        /// <summary>
        /// 
        /// </summary>
        public string vid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }

    }



    public class Pay
    {
        /// <summary>
        /// 
        /// </summary>
        public long pay_play { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long pay_status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long price_track { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long time_free { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long price_album { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long pay_month { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long pay_down { get; set; }

    }



    public class Volume
    {
        /// <summary>
        /// 
        /// </summary>
        public long lra { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long peak { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long gain { get; set; }

    }



    public class SonglistItem
    {
        /// <summary>
        /// 
        /// </summary>
        public List<SingerItem> singer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long fnote { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string mid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public File file { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long genre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Action action { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Ksong ksong { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long index_cd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long songtype { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long isonly { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Album album { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Mv mv { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Pay pay { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Volume volume { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string time_public { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string subtitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long longerval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long index_album { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long status { get; set; }

    }



    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public long isdj { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string singermid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long song_begin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long songnum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string encrypt_uin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long likeit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long scoreusercount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string login { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long mtime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long isvip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nick { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string coveradurl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pic_mid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string songids { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ctime { get; set; }

        /// <summary>
        /// 【日系】无法忘怀の旋律
        /// </summary>
        public string dissname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string logo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long cmtnum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long dirid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string uin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long isAd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string scoreavage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long cur_song_num { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long dissid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long buynum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long cm_count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string headurl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string songtypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long total_song_num { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string disstid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long owndir { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string album_pic_mid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ifpicurl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long pic_dpi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TagsItem> tags { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long visitnum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long singerid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long dir_show { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long disstype { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string dir_pic_url2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long song_update_time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long song_update_num { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<SonglistItem> songlist { get; set; }

        /// <summary>
        /// 带上耳机，用心感受二次元的美好。
        //收录了我们曾单曲循环过的动漫歌曲。
        /// </summary>
        public string desc { get; set; }

    }



    public class QQMusicList
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
