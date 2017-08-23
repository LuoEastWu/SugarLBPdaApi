using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Mode;

namespace Model
{
    [ModeClass("入库上架或盘点")]
    public class M_inplaceRequest
    {
        /// <summary>
        /// 库位号
        /// </summary>
        [Mode(Rem = "库位号", IsNull = false)]
        public string place_code { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        [Mode(Rem = "快递单号", IsNull = false)]
        public string billcode { get; set; }
        /// <summary>
        /// 上架人
        /// </summary>
        [Mode(Rem = "上架人", IsNull = false)]
        public string emp { get; set; }
        /// <summary>
        /// 上架或盘点
        /// </summary>
        [Mode(Rem = "上架或盘点", IsNull = false)]
        public int in_type { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
       [Mode(Rem = "仓库名称", IsNull = false)]
        public string wavehouse_name { get; set; }
    }
    [ModeClass("入库上架或盘点")]
    public class M_inplaceReturn
    {
        [Model.Mode.Mode(Rem = "上架状态", IsNull = false)]
        public bool state { get; set; }
        [Model.Mode.Mode(Rem = "错误消息", IsNull = false)]
        public string message { get; set; }
    }
}
