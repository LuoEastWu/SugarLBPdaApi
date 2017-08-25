using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_Print
    {
        public  class Request
        {
            /// <summary>
            /// 订单ID
            /// </summary>
           [Model.Mode.Mode(Rem = "订单ID", IsNull = false)]
            public String orderID { get; set; }
            /// <summary>
            /// 操做人
            /// </summary>
           [Model.Mode.Mode(Rem = "操做人", IsNull = false)]
            public string operateMan { get; set; }
            /// <summary>
            /// 操作站点
            /// </summary>
           [Model.Mode.Mode(Rem = "操作站点", IsNull = false)]
            public string operateSite { get; set; }
            /// <summary>
            /// 发货快递公司
            /// </summary>
           [Model.Mode.Mode(Rem = "发货承运商", IsNull = false)]
            public string express { get; set; }
            /// <summary>
            /// 重量
            /// </summary>
           [Model.Mode.Mode(Rem = "重量", IsNull = false)]
            public string weight { get; set; }

            /// <summary>
            /// 打包快递单号List
            /// </summary>
           [Model.Mode.Mode(Rem = "打包快单号List", IsNull = false)]
            public List<RequestList> PackaginBillcode { get; set; }

            /// <summary>
            /// 补单
            /// </summary>
           [Model.Mode.Mode(Rem = "补单快递号", IsNull = false)]
            public string repair { get; set; }
            /// <summary>
            /// 是否为大货
            /// </summary>
           [Model.Mode.Mode(Rem = "是否为大货", IsNull = false)]
            public int is_Big { get; set; }
            /// <summary>
            /// 分包
            /// </summary>
           [Model.Mode.Mode(Rem = "分包", IsNull = false)]
            public int fbPrint { get; set; }
        }

        public class RequestList 
        {
            [Model.Mode.Mode(Rem = "快递单号", IsNull = false)]
            public string billcode { get; set; }
            [Model.Mode.Mode(Rem = "快递公司", IsNull = false)]
            public string kd_com { get; set; }
        }


        public class Return
        {
            /// <summary>
            /// 运单号
            /// </summary>
          [Model.Mode.Mode(Rem = "运单号", IsNull = false)]
            public string WaybillNo { get; set; }
            /// <summary>
            /// 总重量
            /// </summary>
           [Model.Mode.Mode(Rem = "总重量", IsNull = false)]
            public string z_weight { get; set; }
            /// <summary>
            /// 订单ID
            /// </summary>
            [Model.Mode.Mode(Rem = "订单ID", IsNull = false)]
            public string orderID { get; set; }
            /// <summary>
            /// 快递单号
            /// </summary>
            [Model.Mode.Mode(Rem = "快递单号", IsNull = false)]
            public string billcode { get; set; }
            /// <summary>
            /// 商品名称
            /// </summary>
            [Model.Mode.Mode(Rem = "商品名称", IsNull = false)]
            public string goodsName { get; set; }
            /// <summary>
            /// 收货地址
            /// </summary>
           [Model.Mode.Mode(Rem = "收货地址", IsNull = false)]
            public string address { get; set; }

            /// <summary>
            /// 员工
            /// </summary>
           [Model.Mode.Mode(Rem = "员工", IsNull = false)]
            public string employee { get; set; }
            /// <summary>
            /// 电话号码
            /// </summary>
           [Model.Mode.Mode(Rem = "电话号码", IsNull = false)]
            public string Phone { get; set; }
            /// <summary>
            /// 件数
            /// </summary>
           [Model.Mode.Mode(Rem = "件数", IsNull = false)]
            public int Js_number { get; set; }
            /// <summary>
            /// 收件人
            /// </summary>
           [Model.Mode.Mode(Rem = "收件人", IsNull = false)]
            public string recipients { get; set; }
            /// <summary>
            /// 简码
            /// </summary>
           [Model.Mode.Mode(Rem = "简码", IsNull = false)]
            public string briefCode { get; set; }

            /// <summary>
            /// 货物类型
            /// </summary>
           [Model.Mode.Mode(Rem = "货物类型", IsNull = false)]
            public string goodsType { get; set; }
            /// <summary>
            /// 店铺名称
            /// </summary>
           [Model.Mode.Mode(Rem = "店铺名称", IsNull = false)]
            public string shopName { get; set; }
            /// <summary>
            /// 客户代码
            /// </summary>
           [Model.Mode.Mode(Rem = "客户代码", IsNull = false)]
            public string CusCode { get; set; }
            /// <summary>
            /// 货物类型备注
            /// </summary>
          [Model.Mode.Mode(Rem = "货物类型备注", IsNull = false)]
            public string OrderGoodsNotes { get; set; }
            /// <summary>
            /// 到付费用
            /// </summary>
           [Model.Mode.Mode(Rem = "到付费用", IsNull = false)]
            public string DFFeer { get; set; }
            /// <summary>
            /// 签收站点编码（黑猫七位码）
            /// </summary>
          [Model.Mode.Mode(Rem = "签收站点编码", IsNull = false)]
            public string SignerCode { get; set; }
            /// <summary>
            /// 版本号
            /// </summary>
           [Model.Mode.Mode(Rem = "版本号", IsNull = false)]
            public string VersionCode { get; set; }
            /// <summary>
            /// 地址区号
            /// </summary>
           [Model.Mode.Mode(Rem = "地址区号", IsNull = false)]
            public string addressCode { get; set; }
            /// <summary>
            /// 航班时效
            /// </summary>
           [Model.Mode.Mode(Rem = "航班时效", IsNull = false)]
            public string timeBarName { get; set; }
            /// <summary>
            /// 到付代收费用
            /// </summary>
           [Model.Mode.Mode(Rem = "到付代收费用", IsNull = false)]
            public string ds_mdgj_Free { get; set; }
            /// <summary>
            /// 货物标识
            /// </summary>
            [Model.Mode.Mode(Rem = "货物标识", IsNull = false)]
            public string IdentificationGoods { get; set; }

            /// <summary>
            /// 计费重量
            /// </summary>
            [Model.Mode.Mode(Rem = "计费重量", IsNull = false)]
            public string  chargedWeight { get; set; }

        }
    }
}
