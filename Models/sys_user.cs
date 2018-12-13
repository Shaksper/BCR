using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models
{
    public class SYS_USER
    {
        public string ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public int AREA { get; set; }
        public DateTime UPDATETIME { get; set; }
    }
}