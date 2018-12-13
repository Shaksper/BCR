using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models
{
    public class SYS_TODOLIST
    {
        public string ID { get; set; }
        public string TITLE { get; set; }
        public string CONTENT { get; set; }
        public int PRIORITY { get; set; }
        public string ENDTIME { get; set; }
        public double PROGRESS { get; set; }
        public string UID { get; set; }
        public DateTime CREATETIME { get; set; }
    }
}