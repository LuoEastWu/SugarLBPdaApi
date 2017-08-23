using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_wavehouse
    {
        public class Request
        {

        }
        public List<Return> houseInfo { get; set; }
        public class Return
        {
            [Model.Mode.Mode(Rem = "仓库ID", IsNull = false)]
            public string ID { get; set; }
            [Model.Mode.Mode(Rem = "仓库名称", IsNull = false)]
            public string house_name { get; set; }
            [Model.Mode.Mode(Rem = "仓库类型", IsNull = false)]
            public string house_type { get; set; }
        }
    }
}
