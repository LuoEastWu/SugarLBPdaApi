using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_ZTsendGoods
    {
        public class Request
        {
            /// <summary>
            /// 发货单号
            /// </summary>
            [Model.Mode.Mode(Rem = "发货单号", IsNull = false)]
            public string out_barcode { get; set; }
            [Model.Mode.Mode(Rem = "扫描站点", IsNull = false)]
            public string scan_site { get; set; }
            [Model.Mode.Mode(Rem = "扫描人", IsNull = false)]
            public string scan_emp { get; set; }
            [Model.Mode.Mode(Rem = "下一站", IsNull = false)]
            public string next_site { get; set; }
            [Model.Mode.Mode(Rem = "包号", IsNull = false)]
            public string packno { get; set; }
        }
    }
}
