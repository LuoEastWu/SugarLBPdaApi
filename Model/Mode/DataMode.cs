using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Mode
{
    public class DataMode
    {
        /// <summary>
        /// 通用检查返回数据
        /// </summary>
        public class AllCheckReturn
        {
            /// <summary>
            /// 返回对象
            /// </summary>
            public Model.GeneralReturns ReturnMode { get; set; }
            /// <summary>
            /// Json解析对象
            /// </summary>
            public Object JsonObject { get; set; }
            /// <summary>
            /// 验证状态
            /// </summary>
            public bool State { get; set; }
        }

        /// <summary>
        /// 返回数据格式
        /// </summary>
        public class ReturnMode
        {
            /// <summary>
            /// 状态
            /// </summary>
            public bool State { get; set; }
            /// <summary>
            /// 消息
            /// </summary>
            public string MsgText { get; set; }
        }

        /// <summary>
        /// 通用返回类型
        /// </summary>
        public class AllReturnMode
        {
            /// <summary>
            /// 状态
            /// </summary>
            public bool State { get; set; }
            /// <summary>
            /// 消息
            /// </summary>
            public string MsgText { get; set; }
            /// <summary>
            /// 详细返回信息
            /// </summary>
            public String ReturnJson { get; set; }
        }

        /// <summary>
        /// 网页Post数据
        /// </summary>
        public class PostMode
        {
            /// <summary>
            /// 控制器名称
            /// </summary>
            public String ControllerName { get; set;}
            /// <summary>
            /// 接口函数名称
            /// </summary>
            public string FunctionName { get; set; }
            /// <summary>
            /// 接口说明
            /// </summary>
            public string Rem { get; set; }
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

            public Decimal Time { get; set; }
        }

        /// <summary>
        /// 客户信息
        /// </summary>
        public class CusInfo
        {
            /// <summary>
            /// 客户ID
            /// </summary>
            public string CusID { get; set; }
            /// <summary>
            /// 客户Key
            /// </summary>
            public string KeyText { get; set; }
            /// <summary>
            /// 客户名称
            /// </summary>
            public string CusName { get; set; }
            /// <summary>
            /// 客户使用数量
            /// </summary>
            public string Count { get; set; }
        }
    }
}
