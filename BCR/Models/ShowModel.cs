using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCR.Models
{
    public class ShowModel
    {
        public string roomname { get; set; }
        /// <summary>
        /// 小时
        /// </summary>
        public int hour { get; set; }
        /// <summary>
        /// 1-15分钟颜色
        /// </summary>
        public string color_115 { get; set; }
        public string color_115_user { get; set; }

        /// <summary>
        /// 15-30分钟颜色
        /// </summary>
        public string color_1530 { get; set; }
        public string color_1530_user { get; set; }
        /// <summary>
        /// 30-45分钟颜色
        /// </summary>
        public string color_3045 { get; set; }
        public string color_3045_user { get; set; }
        /// <summary>
        /// 45-60分钟颜色
        /// </summary>
        public string color_4560 { get; set; }
        public string color_4560_user { get; set; }

    }
}
