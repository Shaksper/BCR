using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class JwtHeader
    {
        public string typ { get { return "JWT"; } set { this.typ = typ; } }
        public AlgEnum alg { get; set; }

    }
}
