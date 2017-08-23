using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_PeerDeliverBill
    {
        public class Request
        {
            /// <summary>
            /// 客户名称
            /// </summary>
           [Model.Mode.Mode(Rem = "客户名称", IsNull = false)]
            public String KD_com { get; set; }
            /// <summary>
            /// 发货单号（Order）
            /// </summary>
            [Model.Mode.Mode(Rem = "发货单号", IsNull = false)]
            public String billcode { get; set; }
            /// <summary>
            /// 扫描站点
            /// </summary>
           [Model.Mode.Mode(Rem = "扫描站点", IsNull = false)]
            public String scan_site { get; set; }
            /// <summary>
            /// 扫描人
            /// </summary>
           [Model.Mode.Mode(Rem = "扫描人", IsNull = false)]
            public String scan_emp { get; set; }
        }
    }
}
