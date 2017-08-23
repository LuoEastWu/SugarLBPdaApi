using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Common
{
    public class CheckPostDataValidity
    {
        /// <summary>
        /// 获取客户端的IP
        /// </summary>
        /// <returns></returns>
        private string GetIp()
        {
            string ip = string.Empty;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"]))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            if (string.IsNullOrEmpty(ip))
                ip = Convert.ToString(System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
            return ip;
        }
        /// <summary>
        /// 检查Post数据准确性
        /// </summary>
        public Model.CheckBackData CheckPostData<T>(string FunctionName, string JsonData, string CusID, string KeyMd5)
        {
            Model.CheckBackData CheckReturn = new Model.CheckBackData();
            CheckReturn.State = false;
            var _RetObject = new Model.GeneralReturns();
            _RetObject.State = true;
            _RetObject.MsgText = string.Empty;

            string CusKey = Common.AddRequestData.SaveClientInfo(GetIp(), FunctionName, CusID, KeyMd5);

            if (CusKey == string.Empty)
            {
                _RetObject.State = false;
                _RetObject.MsgText = "错误的CusID";
            }
            else
            {

                if (Common.Encryption.GetMD5Hash(JsonData + CusKey) != KeyMd5)
                {
                    _RetObject.State = false;
                    _RetObject.MsgText = "Key验证错误";
                }
                else
                {
                   
                    JsonData = HttpUtility.UrlDecode(JsonData, Encoding.UTF8);
                    string str = System.Text.RegularExpressions.Regex.Replace(JsonData, @"\\s*|\t|\r|\n|\\", "");
                    var _Ojbect = Common.DataHandling.JsonToObject<T>(str);
                    if (Common.DataHandling.JsonErrorText != string.Empty)
                    {
                        _RetObject.State = false;
                        _RetObject.MsgText = "错误的Json格式数据[" + Common.DataHandling.JsonErrorText + "]";
                    }
                    else
                    {
                        CheckReturn.State = true;
                        CheckReturn.JsonObject = _Ojbect;
                    }
                }
            }
            CheckReturn.ReturnMode = _RetObject;
            return CheckReturn;
        }
    }
}
