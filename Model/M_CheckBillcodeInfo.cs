using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_CheckBillcodeInfo
    {
        public class Request 
        {
            /// <summary>
            /// 快递单号
            /// </summary>
            [Model.Mode.Mode(Rem = "快递单号", IsNull = false)]
            public string billcode { get; set; }
            
        }
        public List<Return> cbr { get; set; }
        public class Return 
        {
            /// <summary>
            /// 重量
            /// </summary>
           [Model.Mode.Mode(Rem = "重量", IsNull = false)]
            public string billcodeWeight { get; set; }
            /// <summary>
            /// 会员名称
            /// </summary>
           [Model.Mode.Mode(Rem = "会员名称", IsNull = false)]
            public string username { get; set; }
            /// <summary>
            /// 快递公司
            /// </summary>
          [Model.Mode.Mode(Rem = "快递公司", IsNull = false)]
            public string kd_com { get; set; }
            /// <summary>
            /// 商品名称
            /// </summary>
           [Model.Mode.Mode(Rem = "商品名称", IsNull = false)]
            public string goods { get; set; }
            /// <summary>
            /// 体积
            /// </summary>
            [Model.Mode.Mode(Rem = "体积", IsNull = false)]
            public string dd_size { get; set; }
        }
    }
}
