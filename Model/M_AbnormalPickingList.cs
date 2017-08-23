using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_AbnormalPickingList
    {
        public class Request 
        {
            /// <summary>
            /// 订单标识号
            /// </summary>
           [Model.Mode.Mode(Rem = "订单识别号", IsNull = false)]
            public string out_barcode { get; set; }
        }

        public List<Return> OffShelfRuturn { get; set; }

        public class Return 
        {
            /// <summary>
            /// 快递单号
            /// </summary>
           [Model.Mode.Mode(Rem = "快递单号", IsNull = false)]
            public string kd_billcode { get; set; }
            /// <summary>
            /// 库位
            /// </summary>
           [Model.Mode.Mode(Rem = "库位", IsNull = false)]
            public string stock_area { get; set; }
            /// <summary>
            /// 包数
            /// </summary>
           [Model.Mode.Mode(Rem = "包数", IsNull = false)]
            public int number { get; set; }
            /// <summary>
            /// 用户名称
            /// </summary>
            [Model.Mode.Mode(Rem = "用户名称", IsNull = false)]
            public string username { get; set; }
            /// <summary>
            /// 重量
            /// </summary>
            [Model.Mode.Mode(Rem = "重量", IsNull = false)]
            public double dd_weight2 { get; set; }
            /// <summary>
            /// 规格
            /// </summary>
            [Model.Mode.Mode(Rem = "规格", IsNull = false)]
            public string guige { get; set; }
            /// <summary>
            /// 上架标识
            /// </summary>
            [Model.Mode.Mode(Rem = "上架标识", IsNull = false)]
            public int is_inplace { get; set; }
         
           
        }
    }
}
