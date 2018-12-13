using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class AreaBook
    {
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }
        public int status { get; set; }
        public string meetname { get; set; }
        public string username { get; set; }
        public string roomname { get; set; }
    }
}
