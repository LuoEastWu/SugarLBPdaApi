using Model.Mode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class LoginMode
    {
        /// <summary>
        /// 登陆请求的数据模型
        /// </summary>
        public class LoginRequest
        {
            /// <summary>
            /// 登陆名
            /// </summary>
             [ModeAttribute(Rem = "登陆名", IsNull = false)]
            public string Uid { get; set; }
            /// <summary>
            /// 登陆密码
            /// </summary>
            [ModeAttribute(Rem = "登陆密码", IsNull = false)]
            public string Pwd { get; set; }
        }
        /// <summary>
        /// 用户登陆成功返回信息
        /// </summary>
        public class LoginReturn
        {
            public string Uid { get; set; }
            /// <summary>
            /// 用户名
            /// </summary>
            public string username { get; set; }
            /// <summary>
            /// 昵称
            /// </summary>
            public string nickname { get; set; }
            /// <summary>
            /// 库位id
            /// </summary>
            public string houseid { get; set; }
            /// <summary>
            /// 库位名称
            /// </summary>
            public string house_name { get; set; }
            /// <summary>
            /// 库位类型
            /// </summary>
            public string house_type { get; set; }
            /// <summary>
            /// 权限
            /// </summary>
            public int permission { get; set; }
            /// <summary>
            /// 所属货区
            /// </summary>
            public string areaCode { get; set; }
            /// <summary>
            /// PDA权限
            /// </summary>
            public string PDA_role { get; set; }
            /// <summary>
            /// 国家ID
            /// </summary>
            public int country_id { get; set; }
        }
    }
}
