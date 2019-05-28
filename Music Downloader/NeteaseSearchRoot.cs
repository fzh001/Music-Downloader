using System.Collections.Generic;

namespace Music_Downloader.Netease
{


    public class Privilege
    {
        /// <summary>
        /// 
        /// </summary>
        public int st { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int flag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int subp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int fl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int fee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int dl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int cp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string cs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string toast { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int maxbr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int pl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int sp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int payed { get; set; }

    }



    public class H
    {
        /// <summary>
        /// 
        /// </summary>
        public int br { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int fid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float vd { get; set; }

    }



    public class Al
    {
        /// <summary>
        /// 
        /// </summary>
        public string picUrl { get; set; }

        /// <summary>
        /// 和自己对话 From M.E. To Myself
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> tns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pic_str { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long pic { get; set; }

    }



    public class L
    {
        /// <summary>
        /// 
        /// </summary>
        public int br { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int fid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float vd { get; set; }

    }



    public class M
    {
        /// <summary>
        /// 
        /// </summary>
        public int br { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int fid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float vd { get; set; }

    }



    public class ArItem
    {
        /// <summary>
        /// 林俊杰
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> tns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> alias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

    }



    public class SongsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int no { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int copyright { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int fee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Privilege privilege { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int mst { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int pst { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float pop { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int dt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int rtype { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int s_id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> rtUrls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int st { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string cd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long publishTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string cf { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public H h { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int mv { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Al al { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public L l { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public M m { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int cp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> alia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int djId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ArItem> ar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ftype { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int t { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int v { get; set; }

        /// <summary>
        /// 关键词
        /// </summary>
        public string name { get; set; }

    }



    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<SongsItem> songs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int songCount { get; set; }

    }



    public class NeteaseSearchRoot
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
        public Data data { get; set; }

    }
}

