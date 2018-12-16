using System;

namespace Models
{
    public class SYS_BOOKINFO
    {
        public int ID { get; set; }
        public string ROOMID { get; set; }
        public DateTime STARTTIME { get; set; }
        public DateTime ENDTIME { get; set; }
        public int STATUS { get; set; }
        public string UID { get; set; }
        public string MEETNAME { get; set; }
    }
}