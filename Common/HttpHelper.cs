using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace Common
{
    public class HttpHelper
    {
        /// <summary>
        /// Json序列化错误提示
        /// </summary>
        public static string JsonErrorText { get; set; }
        /// <summary>
        /// Xml序列化错误提示
        /// </summary>
        public static string XmlErrorText { get; set; }
        #region 数据处理方法
        /// <summary>
        /// 获取字符串MD5值
        /// </summary>
        /// <param name="input">要转换的文本</param>
        /// <returns>Md5值</returns>
        public static string GetMD5Hash(String input, String CharSet = "utf-8")
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.GetEncoding(CharSet).GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }
            return sBuilder.ToString().ToLower();
        }
        /// <summary>
        /// 获取字符串64位字符编码格式文本
        /// </summary>
        /// <param name="encode">编码格式</param>
        /// <param name="source">要编码的文本</param>
        /// <returns>编码后的文本</returns>
        public static string EncodeBase64(Encoding encode, string source)
        {
            byte[] bytes = encode.GetBytes(source);
            try
            {
                return Convert.ToBase64String(bytes);
            }
            catch
            {
                return source;
            }
        }
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
            catch(Exception ex)
            {
                JsonErrorText = ex.Message;
                return default(T);
            }
        }
        /// <summary>
        /// 序列化Json文本为指定Object对象
        /// </summary>
        /// <param name="JsonText"></param>
        /// <param name="NowType"></param>
        /// <returns></returns>
        public static Object JsonToObject(string JsonText,Type NowType)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
                var list = js.Deserialize(JsonText, NowType);    //将json数据转化为对象类型并赋值给list
                JsonErrorText = string.Empty;
                return list;
            }
            catch (Exception ex)
            {
                JsonErrorText = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 将对象序列化成XML格式文本
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static String ObjToXml(object Obj)
        {
            using (MemoryStream Stream = new MemoryStream())
            {
                XmlSerializer Xml = new XmlSerializer(Obj.GetType());
                try
                {
                    XmlSerializerNamespaces Xn = new XmlSerializerNamespaces();
                    Xn.Add(string.Empty, string.Empty);
                    Xml.Serialize(Stream, Obj, Xn);
                    Stream.Position = 0;
                    using (StreamReader Sr = new StreamReader(Stream))
                    {
                        String Str = Sr.ReadToEnd();
                        return Str;
                    }
                }
                catch (Exception ex)
                {
                    XmlErrorText = ex.Message;
                    return String.Empty;
                }
            }
        }
        /// <summary>
        /// 将Xml文本反序列化成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="XmlText"></param>
        /// <returns></returns>
        public static T XmlToObjext<T>(string XmlText)
        {
            try
            {
                using (StringReader Sr = new StringReader(XmlText))
                {
                    XmlSerializer xmldes = new XmlSerializer(typeof(T));
                    return (T)xmldes.Deserialize(Sr);
                }
            }
            catch (Exception ex)
            {
                XmlErrorText = ex.Message;
                return default(T);
            }
        }
        #endregion
        /// <summary>
        /// 通过Post方式发送并返回Http结果
        /// </summary>
        /// <param name="Url">Url地址</param>
        /// <param name="Code">编码格式</param>
        /// <param name="postData">参数型POST数据</param>
        /// <returns></returns>
        public static String Send(string Url, Encoding Code, NameValueCollection postData)
        {
            string returns = "";
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    // 向服务器发送POST数据
                    byte[] responseArray = webClient.UploadValues(Url, postData);
                    string response = Code.GetString(responseArray);
                    returns = response;
                }
            }
            catch (Exception e)
            {
                returns = (e.Message);
            }
            return returns;
        }
        /// <summary>
        /// 通过Post方式发送并返回Http结果
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Code"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static String Send(String Url, Encoding Code, String postData, string CertPath = "", string CertPwd = "")
        {
            byte[] data = Code.GetBytes(postData);
            if (Url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback =
                        new RemoteCertificateValidationCallback(CheckValidationResult);
            }
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(Url);
            req.Method = "POST";
            req.Timeout = 6000;
            //req.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            req.ContentType = "text/xml";
            req.ContentLength = data.Length;
            if (!String.IsNullOrEmpty(CertPath))
            {
                req.ClientCertificates.Add(new X509Certificate(CertPath, CertPwd));
            }
            //发送数据
            System.IO.Stream newStream = req.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            System.Net.HttpWebResponse res = (System.Net.HttpWebResponse)req.GetResponse();
            newStream.Close();

            //获取响应
            HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd().Trim();
            return content;
        }
        /// <summary>  
        /// GET请求与获取结果  
        /// </summary>  
        public static string HttpGet(string Url, string postDataStr, string ContentType = "text/html;charset=UTF-8")
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.Timeout = 3000;
                request.ContentType = ContentType;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}
