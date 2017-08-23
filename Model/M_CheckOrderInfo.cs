using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_CheckOrderInfo
    {
        public class Request 
        {
            [Model.Mode.Mode(Rem = "快递单号", IsNull = false)]
            public string billcode { get; set; }
        }


        public List<Return> coir { get; set; }
        public class Return 
        {
            /// <summary>
            /// 发货单号
            /// </summary>
           [Model.Mode.Mode(Rem = "订单ID", IsNull = false)]
            public long OrderId { get; set; }
            /// <summary>
            /// 快递单号
            /// </summary>
           [Model.Mode.Mode(Rem = "快递单号", IsNull = false)]
            public string kd_billcode { get; set; }
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

           [Model.Mode.Mode(Rem = "订单重量", IsNull = false)]
            public string OrderWeight { get; set; }

            /// <summary>
            /// 体积
            /// </summary>
            [Model.Mode.Mode(Rem = "体积", IsNull = false)]
            public string dd_size { get; set; }
            /// <summary>
            ///货物类型
            /// </summary>
           [Model.Mode.Mode(Rem = "货物类型", IsNull = false)]
            public string isSensitive { get; set; }
            /// <summary>
            /// 发货类型
            /// </summary>
           [Model.Mode.Mode(Rem = "发货类型", IsNull = false)]
            public string cforhm { get; set; }

            /// <summary>
            /// 客户代码
            /// </summary>
            [Model.Mode.Mode(Rem = "客户代码", IsNull = false)]
            public string CForHMCusCode { get; set; }
            /// <summary>
            /// 问题件是否处理
            /// </summary>
           [Model.Mode.Mode(Rem = "问题件类型", IsNull = false)]
            public int is_lock { get; set; }
            /// <summary>
            /// 库位号
            /// </summary>
           [Model.Mode.Mode(Rem = "库位号", IsNull = false)]
            public string stockArea { get; set; }
            /// <summary>
            /// 国家ID
            /// </summary>
            [Model.Mode.Mode(Rem = "国家ID", IsNull = false)]
            public int country_id { get; set; }
        }

        [Model.Mode.Mode(Rem = "承运商List", IsNull = false)]
        public List<ReturnCys> cysList { get; set; }

        public class ReturnCys 
        {
            /// <summary>
            /// 序号
            /// </summary>
            [Model.Mode.Mode(Rem = "承运商ID", IsNull = false)]
            public long id { get; set; }
            /// <summary>
            /// 承运商名称
            /// </summary>
            [Model.Mode.Mode(Rem = "承运商名称", IsNull = false)]
            public string ForwarderName { get; set; }
            /// <summary>
            /// 承运商代码
            /// </summary>
           [Model.Mode.Mode(Rem = "承运商代码", IsNull = false)]
            public string ForwarderCode { get; set; }
            /// <summary>
            /// 国家ID
            /// </summary>
            [Model.Mode.Mode(Rem = "国家ID", IsNull = false)]
            public int country_id { get; set; }
        }
    }
}
