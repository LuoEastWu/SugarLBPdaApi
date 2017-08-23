using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 客户信息
    /// </summary>
    public class CusInfo
    {
        /// <summary>
        /// 客户ID
        /// </summary>
        [Model.Mode.Mode(Rem = "客户ID", IsNull = false)]
        public string CusID { get; set; }
        /// <summary>
        /// 客户Key
        /// </summary>
        [Model.Mode.Mode(Rem = "客户Key", IsNull = false)]
        public string KeyText { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [Model.Mode.Mode(Rem = "客户名称", IsNull = false)]
        public string CusName { get; set; }
        /// <summary>
        /// 客户使用数量
        /// </summary>
        [Model.Mode.Mode(Rem = "客户使用数量", IsNull = false)]
        public string Count { get; set; }
    }
}
