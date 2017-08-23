using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 通用的返回类
    /// </summary>
    public class GeneralReturns
    {
        /// <summary>
        /// 状态
        /// </summary>
       [Model.Mode.Mode(Rem = "状态", IsNull = false)]
        public bool State { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        [Model.Mode.Mode(Rem = "消息", IsNull = false)]
        public string MsgText { get; set; }
        /// <summary>
        /// 详细返回信息
        /// </summary>
       [Model.Mode.Mode(Rem = "详细返回信息", IsNull = false)]
        public String ReturnJson { get; set; }

        /// <summary>
        /// 其他备注
        /// </summary>
       [Model.Mode.Mode(Rem = "其他备注", IsNull = false)]
        public String Mb { get; set; }
    }
    /// <summary>
    /// 核对返回数据
    /// </summary>
    public class CheckBackData
    {
        /// <summary>
        /// 返回对象
        /// </summary>
       [Model.Mode.Mode(Rem = "返回对象", IsNull = false)]
        public GeneralReturns ReturnMode { get; set; }
        /// <summary>
        /// Json解析对象
        /// </summary>
        [Model.Mode.Mode(Rem = "Json解析对象", IsNull = false)]
        public Object JsonObject { get; set; }
        /// <summary>
        /// 验证状态
        /// </summary>
       [Model.Mode.Mode(Rem = "验证状态", IsNull = false)]
        public bool State { get; set; }

        
    }

    
     
}
