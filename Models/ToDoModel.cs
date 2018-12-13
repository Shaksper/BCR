using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ToDoModel
    {
        public string ID { get; set; }
        public string TITLE { get; set; }
        public string CONTENT { get; set; }
        public string PRIORITYCOLOR { get; set; }
        public string ENDTIME { get; set; }
        public int PROGRESS { get; set; }
        public string USERNAME { get; set; }
        public string CREATETIME { get; set; }

    }
}
