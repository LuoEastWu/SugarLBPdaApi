using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 极光推送接口模型
    /// </summary>
    public struct JPushMode
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public int MsgType { get; set; }
        /// <summary>
        /// 手机类型
        /// </summary>
        public int PhoneType { get; set; }
        /// <summary>
        /// 消息标题
        /// </summary>
        public string MsgTitle { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string MsgText { get; set; }
        /// <summary>
        /// 接收用户
        /// </summary>
        public List<String> Uid { get; set; }
        /// <summary>
        /// 分组
        /// </summary>
        public String TageType { get; set; }

        public int Type { get; set; }
    }
}
