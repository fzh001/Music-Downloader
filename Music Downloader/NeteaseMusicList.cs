using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Downloader.NeteaseMusiclist
{
    public class NeateaseMusicList
    {
        public DataItem data { set; get; }
    }
    public class DataItem
    {
        public List<TracksItem> tracks { set; get; }
    }
    public class TracksItem
    {
        public long id { set; get; }
        public string name { set; get; }
        public AlbumItem album { set; get; }
        public List<ArtistsItem> artists { set; get; }
    }
    public class ArtistsItem
    {
        public string name { set; get; }
    }
    public class AlbumItem
    {
        public string name { set; get; }
    }
}
