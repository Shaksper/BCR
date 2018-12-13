using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class JwtClaim
    {
        //暂时未用
        public string iss { get; set; }
        //暂时未用
        public string sub { get; set; }
        /// <summary>
        /// uid
        /// </summary>
        public string uid { get; set; }
        public string username { get; set; }
        public bool isadmin { get; set; }
        public int area { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public long exp { get; set; }
    }
}
