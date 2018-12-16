
using System;

namespace Models
{
    public class SYS_PROJECTINFO
    {
        public string ID { get; set; }
        public string PROJ_NAME { get; set; }
        public int PRIORITY { get; set; }
        public string MANAGER { get; set; }
        public DateTime STARTTIME { get; set; }
        public DateTime ENDTIME { get; set; }
    }
}