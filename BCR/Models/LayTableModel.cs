using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCR.Models
{
    public  class  LayTableModel<T> 
    {
        public int code { get; set; }
        public string message { get; set; }
        public int total { get; set; }
        public Rows<T> rows { get; set; }
    }
    public class Rows<T> {
        public T item { get; set; }
    }
}
