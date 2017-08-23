using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_Picking
    {
        public class Request 
        {
            /// <summary>
            /// 订单识别号
            /// </summary>
            [Model.Mode.Mode(Rem = "订单识别号", IsNull = false)]
            public string out_barcode { get; set; }
            /// <summary>
            /// 扫描站点
            /// </summary>
            [Model.Mode.Mode(Rem = "扫描站点", IsNull = false)]
            public string scan_site { get; set; }
            /// <summary>
            /// 扫描人
            /// </summary>
           [Model.Mode.Mode(Rem = "扫描人", IsNull = false)]
            public string scan_emp { get; set; }
        }
    }
}
