using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_KD_jd
    {
        public class Request 
        {
            /// <summary>
            /// 快递公司
            /// </summary>
           [Model.Mode.Mode(Rem = "快递公司", IsNull = false)]
            public string KD_com { get; set; }
            /// <summary>
            /// 快递单号
            /// </summary>
           [Model.Mode.Mode(Rem = "快递单号", IsNull = false)]
            public string billcode { get; set; }
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

        public class Return 
        {

        }
    }
}
