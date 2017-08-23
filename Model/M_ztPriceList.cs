using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_ztPriceList
    {
        public class Request
        {

        }
        public List<Return> ztPrice { get; set; }
        public class Return
        {
            [Model.Mode.Mode(Rem = "自提点名称", IsNull = false)]
            public string type_name { get; set; }
        }
    }
}
