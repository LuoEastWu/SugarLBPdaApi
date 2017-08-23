using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_NumberOffShelf
    {
        public class Request
        {
            
            /// <summary>
            /// 发货单号
            /// </summary>
            [Model.Mode.Mode(Rem = "发货单号", IsNull = false)]
            public string out_barcode { get; set; }
            /// <summary>
            /// 快递单号
            /// </summary>
            [Model.Mode.Mode(Rem = "快递单号", IsNull = false)]
            public string kd_billcode { get; set; }
            /// <summary>
            /// 扫描人
            /// </summary>
             [Model.Mode.Mode(Rem = "扫描人", IsNull = false)]
            public string scan_emp { get; set; }
        }
    }
}
