using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace Common
{
    /// <summary>
    /// 数据处理类
    /// </summary>
    public class DataHandling
    {
        public static string JsonErrorText { get; set; }
        /// <summary>
        /// 将对象序列号为Json字符串
        /// </summary>
        /// <param name="Obj">要序列话的对象</param>
        /// <returns>String</returns>
        public static String ObjToJson(object Obj)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
            string json = js.Serialize(Obj);
            return json;
        }
        /// <summary>
        /// 序列号Json文本为T数据类型
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="JsonText">Json字符串</param>
        /// <returns>T数据类型</returns>
        public static T JsonToObject<T>(string JsonText)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
                T list = js.Deserialize<T>(JsonText);    //将json数据转化为对象类型并赋值给list
                JsonErrorText = string.Empty;
                return list;
            }
            catch (Exception ex)
            {
                JsonErrorText = ex.Message;
                return default(T);
            }
        }


        /// <summary>
        /// 字符串简体转繁体
        /// </summary>
        /// <param name="strSimple"></param>
        /// <returns></returns>
        public static string ToTraditionalChinese(string strSimple)
        {
            string strTraditional = Microsoft.VisualBasic.Strings.StrConv(strSimple, Microsoft.VisualBasic.VbStrConv.TraditionalChinese, 0);
            return strTraditional;
        }

        /// <summary>
        /// 获取字符串MD5值
        /// </summary>
        /// <param name="input">要转换的文本</param>
        /// <returns>Md5值</returns>
        public static string GetMD5Hash(String input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }
            return sBuilder.ToString().ToLower();
        }

        /// <summary>
        /// 把dataset数据转换成json的格式
        /// </summary>
        /// <param name="ds">dataset数据集</param>
        /// <returns>json格式的字符串</returns>
        public static string GetJsonByDataset(DataSet ds)
        {
            if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                //如果查询到的数据为空则返回标记ok:false
                return "{\"State\":false}";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"State\":true,");
            foreach (DataTable dt in ds.Tables)
            {
                sb.Append(string.Format("\"{0}\":[", dt.TableName));

                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("{");
                    for (int i = 0; i < dr.Table.Columns.Count; i++)
                    {
                        sb.AppendFormat("\"{0}\":\"{1}\",", dr.Table.Columns[i].ColumnName.Replace("\"", "\\\"").Replace("\'", "\\\'"), ObjToStr(dr[i]).Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                    sb.Remove(sb.ToString().LastIndexOf(','), 1);
                    sb.Append("},");
                }

                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("],");
            }
            sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// 将object转换成为string
        /// </summary>
        /// <param name="ob">obj对象</param>
        /// <returns></returns>
        public static string ObjToStr(object ob)
        {
            if (ob == null)
            {
                return string.Empty;
            }
            else
                return ob.ToString();
        }
       
    }
}
