using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_ShopList
    {
        public class Request 
        {
            
        }
        public List<Return> tbiList { get; set; }
        public class Return
        {
            [Model.Mode.Mode(Rem = "店铺ID", IsNull = false)]
            public long ID { get; set; }
            [Model.Mode.Mode(Rem = "店铺名称", IsNull = false)]
            public string name { get; set; }
        }
    }
}
