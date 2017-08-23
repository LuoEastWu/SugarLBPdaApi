using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_PeerInfo
    {
        public class Request { }
        public List<Return> PD { get; set; }
        public class Return 
        {
            [Model.Mode.Mode(Rem = "同行名称", IsNull = false)]
            public string customerName { get; set; }
        }
    }
}
