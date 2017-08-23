using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 网页Post数据
    /// </summary>
    public class PostMode
    {
        /// <summary>
        /// 接口函数名称
        /// </summary>
        public string FunctionName { get; set; }
        /// <summary>
        /// Json信息
        /// </summary>
        public string JsonData { get; set; }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CusID { get; set; }
        /// <summary>
        /// Key值
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 当前加密后的数据
        /// </summary>
        public string KeyMd5 { get; set; }
    }
}
