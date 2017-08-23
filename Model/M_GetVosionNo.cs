using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_GetVosionNo
    {
        public class Request 
        {

        }

        public class Return 
        {
            public string vosoin { get; set; }

            public string Rem { get; set; }

            public string geturl { get; set; }
        }
    }
}
