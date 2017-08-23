using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_PickingStop
    {
        public class Request 
        {
            /// <summary>
            /// 订单运单号
            /// </summary>
           [Model.Mode.Mode(Rem = "订单运单号", IsNull = false)]
            public string out_billcode { get; set; }
            /// <summary>
            /// 操作员
            /// </summary>
           [Model.Mode.Mode(Rem = "操作员", IsNull = false)]
            public string oper { get; set; }
        }
        
    }
}
