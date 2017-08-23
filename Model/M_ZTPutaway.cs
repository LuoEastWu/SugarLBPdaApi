using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_ZTPutaway
    {
        public class Request
        {
            [Model.Mode.Mode(Rem = "位置", IsNull = false)]
            public string place_code { get; set; }
            [Model.Mode.Mode(Rem = "快递单号", IsNull = false)]
            public string billcode { get; set; }
            [Model.Mode.Mode(Rem = "扫描人", IsNull = false)]
            public string emp { get; set; }
            [Model.Mode.Mode(Rem = "仓库名称", IsNull = false)]
            public string wavehouse_name { get; set; }
        }
    }
}
