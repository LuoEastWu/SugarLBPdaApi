using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_OffShelf
    {
        /// <summary>
        /// 拣货单号
        /// </summary>
        public class OffShelfRequest
        {
            /// <summary>
            /// 运单号
            /// </summary>
            [Model.Mode.Mode(Rem = "运单号", IsNull = false)]
            public string out_barcode { get; set; }
            /// <summary>
            /// 区号
            /// </summary>
             [Model.Mode.Mode(Rem = "区号", IsNull = false)]
            public string areaCode { get; set; }
            /// <summary>
            /// 操作员
            /// </summary>
            [Model.Mode.Mode(Rem = "操作员", IsNull = false)]
            public string Operator { get; set; }
            /// <summary>
            /// 订单号
            /// </summary>
            [Model.Mode.Mode(Rem = "订单号", IsNull = false)]
            public string OrderID { get; set; }
            /// <summary>
            /// 站点
            /// </summary>
            [Model.Mode.Mode(Rem = "站点", IsNull = false)]
            public string site { get; set; }
            /// <summary>
            /// 国家ID
            /// </summary>
            [Model.Mode.Mode(Rem = "国家ID", IsNull = false)]
            public int country_id { get; set; }
            /// <summary>
            /// 店铺ID
            /// </summary>
            [Model.Mode.Mode(Rem = "店铺ID", IsNull = false)]
            public int shopId { get; set; }

        }
        /// <summary>
        /// 拣货单号List
        /// </summary>
        public class OffShelfListRuturn
        {
             [Model.Mode.Mode(Rem = "拣货单号List", IsNull = false)]
            public List<OffShelfRuturn> OffShelfRuturn { get; set; }
        }
        /// <summary>
        /// 拣货单号清单
        /// </summary>
        public class OffShelfRuturn
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
            /// 货架
            /// </summary>
            [Model.Mode.Mode(Rem = "货架", IsNull = false)]
            public string stock_area { get; set; }
            /// <summary>
            /// 包数
            /// </summary>
            [Model.Mode.Mode(Rem = "包数", IsNull = false)]
            public string number { get; set; }
            /// <summary>
            /// 客户名称
            /// </summary>
            [Model.Mode.Mode(Rem = "客户名称", IsNull = false)]
            public string username { get; set; }
            /// <summary>
            /// 重量
            /// </summary>
             [Model.Mode.Mode(Rem = "重量", IsNull = false)]
            public string dd_weight2 { get; set; }
            /// <summary>
            /// 规格
            /// </summary>
           [Model.Mode.Mode(Rem = "规格", IsNull = false)]
            public string guige { get; set; }
            /// <summary>
            /// 是否到达
            /// </summary>
            [Model.Mode.Mode(Rem = "是否到达", IsNull = false)]
            public string is_inplace { get; set; }
            /// <summary>
            /// 订单ID
            /// </summary>
             [Model.Mode.Mode(Rem = "订单ID", IsNull = false)]
            public Int64 OrderId { get; set; }

        }
    }
}
