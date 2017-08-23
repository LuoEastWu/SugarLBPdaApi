using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using SqlSugar;
using Model;
using Model.Mode;
using System.Web;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// 系统实体方法
    /// </summary>
    public class EntityProcess
    {
        /// <summary>
        /// 服务器列表
        /// </summary>
        public static Dictionary<int, SererInfo> ServerList = new Dictionary<int, SererInfo>();
        /// <summary>
        /// 获取当前服务器信息
        /// </summary>
        /// <returns></returns>
        public static SererInfo GetNowServer()
        {
            try
            {
                return ServerList.Last(x => x.Value.NowServer).Value;
            }
            catch
            {
                return new SererInfo();
            }
        }

        /// <summary>
        /// SqlSugar静态执行方法
        /// </summary>
        public static void StartSqlSugar(Action<SqlSugarClient> func)
        {
            using (SqlSugar.SqlSugarClient db = new SqlSugarClient(new ConnectionConfig(){
                DbType = DbType.SqlServer,
                ConnectionString = SqlHelper.Connectioning,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true
            }))
            {
                try
                {
                    func(db);
                }
                catch (Exception ex)
                {
                    SystemLog.WriteSystemLog("SugarError", ex.Message);
                }
            }
        }
        #region 内部处理函数
        /// <summary>
        /// 获取客户端的IP
        /// </summary>
        /// <returns></returns>
        public static string GetIp(HttpRequestBase Request)
        {
            if (Request==null)
            {
                return "";
            }
            return Request.UserHostAddress;
        }
        /// <summary>
        /// 检查Post数据准确性
        /// </summary>
        public static DataMode.AllCheckReturn CheckPostData(HttpRequestBase Request, Type NowType, string FunctionName, string JsonData, string CusID, string KeyMd5)
        {
            DataMode.AllCheckReturn CheckReturn = new DataMode.AllCheckReturn();
            CheckReturn.State = false;
            var _RetObject = new Model.GeneralReturns();
            _RetObject.State = true;
            _RetObject.MsgText = string.Empty;
            string CusKey = InsertData.SaveClientInfo(GetIp(Request), FunctionName, CusID, KeyMd5);
            if (CusKey == string.Empty)
            {
                _RetObject.State = false;
                _RetObject.MsgText = "错误的CusID";
            }
            else
            {
                if (HttpHelper.GetMD5Hash(JsonData + CusKey) != KeyMd5)
                {
                    _RetObject.State = false;
                    _RetObject.MsgText = "Key验证错误";
                }
                else
                {
                    JsonData = HttpUtility.UrlDecode(JsonData, Encoding.UTF8);
                    JsonData = UniDecode(JsonData);
                    string str = System.Text.RegularExpressions.Regex.Replace(JsonData, @"\\s*|\t|\r|\n|\\", "");
                    var Obj = HttpHelper.JsonToObject(str, NowType);
                    if (HttpHelper.JsonErrorText != string.Empty)
                    {
                        _RetObject.State = false;
                        _RetObject.MsgText = "错误的Json格式数据[" + HttpHelper.JsonErrorText + "]";
                    }
                    else
                    {
                        CheckReturn.State = true;
                        CheckReturn.JsonObject = Obj;
                    }
                }
            }
            CheckReturn.ReturnMode = _RetObject;
            return CheckReturn;
        }
        /// <summary>
        /// UniDeCode 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UniDecode(string str)
        {
            string outStr = "";
            Regex reg = new Regex(@"(?i)//u([0-9a-f]{4})");
            outStr = reg.Replace(str, delegate (Match m1)
            {
                return ((char)Convert.ToInt32(m1.Groups[1].Value, 16)).ToString();
            });
            return outStr;
        }
        #endregion
    }
}
