using Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Common
{
    public class ApiMode
    {
        /// <summary>
        /// API_Url
        /// </summary>
        public static string Url = "http://47.90.52.40:8888/RcominfoApi/PushOrderInfo";
        /// <summary>
        /// 验证密码
        /// </summary>
        public static string Key = "5ferfDfadveg45Kp";
        /// <summary>
        /// 消息提供者ID (加盟商)
        /// </summary>
        public static string CusID = "1001";
        /// <summary>
        /// 当前使用的编码格式
        /// </summary>
        public static Encoding NowEncode = Encoding.UTF8;
        /// <summary>
        /// 京广快递专用的加密方式
        /// </summary>
        /// <param name="FuncName"></param>
        /// <param name="JsonText"></param>
        /// <returns></returns>
        public static NameValueCollection GetNameValueCollection(Model.Mode.DataMode.PostMode R)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("FunctionName", R.FunctionName);
            nvc.Add("JsonData", R.JsonData);
            nvc.Add("CusID", R.CusID);
            nvc.Add("KeyMd5", HttpHelper.GetMD5Hash(R.JsonData + R.Key));
            return nvc;
        }
    }
}
