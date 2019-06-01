using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Downloader
{
    public class LrcDetails
    {
        public string Title { set; get; }
        public string Artist { set; get; }
        public string Album { get; set; }
        public string LrcBy { get; set; }
        public string Offset { get; set; }
        public List<LrcContent> LrcWord { set; get; }
        public string url { get; set; }
    }
    public class LrcContent
    {
        public double Time { set; get; }
        public string Ci { set; get; }
    }
}
