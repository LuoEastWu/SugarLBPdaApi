using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Common
{
    public class Collections
    {
         /// <summary>
        /// 通用常规验证函数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="FunctionName"></param>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public String FormalVerification<T>(String FunctionName, String JsonData, String CusID, String KeyMd5, Func<Model.GeneralReturns, T, Model.GeneralReturns> func)
        {
            
            Model.CheckBackData _RetObject =new Common.CheckPostDataValidity().CheckPostData<T>(FunctionName, JsonData, CusID, KeyMd5);
            Model.GeneralReturns Now_RetObject = _RetObject.ReturnMode;

            if (_RetObject.State)
            {
                var _Object = (T)_RetObject.JsonObject;
                Now_RetObject.State = false;
                Now_RetObject.MsgText = string.Empty;
                try
                {
                    Now_RetObject = func(Now_RetObject, _Object);
                }
                catch (Exception ex)
                {
                    Now_RetObject.State = false;
                    Now_RetObject.MsgText = ex.Message;
                }
            }

            return Common.DataHandling.ObjToJson(Now_RetObject);
        }


       

        /// <summary>
        /// 黑猫接口帮助类
        /// </summary>
        public class HmHelper
        {
            public static bool uploadingHMState { get; set; }
            #region 内部属性

            /// <summary>
            /// ApiUrl-EGS
            /// </summary>
            public static String ApiUrl = "http://47.90.48.6:8800/egs?";
            /// <summary>
            /// API 版本号
            /// </summary>
            public static VisonInfo VisonNo { get; set; }
            #endregion
            #region 初始化
            /// <summary>
            /// 初始化类
            /// </summary>
            public HmHelper()
            {
                VisonNo = GetEGSVersion();
            }
            #endregion
            #region 内部架构
            /// <summary>
            /// 数据集合
            /// </summary>
            private List<Data> DataList = new List<Data>();
            /// <summary>
            /// 签约编号
            /// </summary>
            private static String ClientNo = "1212023701";
            #endregion
            #region 公共类方法
            /// <summary>
            /// 添加数据
            /// </summary>
            /// <param name="data"></param>
            public void AddData(Data data)
            {
                this.DataList.Add(data);
            }
            /// <summary>
            /// 清空数据
            /// </summary>
            public void ClearData()
            {
                this.DataList.Clear();
            }
            /// <summary>
            /// 获取数据
            /// </summary>
            /// <returns></returns>
            public List<Data> GetData()
            {
                return DataList;
            }
            /// <summary>
            /// 导出到Execl文件
            /// </summary>
            /// <param name="FileName"></param>
            public Boolean ToEOD(String FileName, Boolean UpFtp)
            {
                if (FileName.Trim() == String.Empty && this.DataList.Count == 0)
                {
                    return false;
                }
                String SentPath = FileName + "/Hm_Send_Temp/";
                if (!Directory.Exists(SentPath))
                {
                    Directory.CreateDirectory(SentPath);
                }
                String SaveFileName = SentPath + DateTime.Now.ToString("yyyyMMddHH") + ".EOD";
                Boolean State = DataToEOD(SaveFileName);
                if (UpFtp)
                {
                    String SentBackPath = FileName + "/Hm_Send_Back/";
                    if (!Directory.Exists(SentBackPath))
                    {
                        Directory.CreateDirectory(SentBackPath);
                    }
                    DirectoryInfo Dr = new DirectoryInfo(SentPath);
                    var Files = Dr.GetFiles().ToList();
                    if (Files.Count(x => !x.Name.ToLower().Equals(Path.GetFileName(SaveFileName.ToLower()))) > 0)
                    {
                        Common.FtpHelper Ftp = new FtpHelper(new Uri("ftp://61.57.227.35"), "yjy", "y2016j03y07");
                        Ftp.DirectoryPath = @"/Send/";
                        foreach (var a in Files.Where(x => !x.Name.ToLower().Equals(Path.GetFileName(SaveFileName.ToLower()))))
                        {
                            if (Ftp.UploadFile(a.FullName))
                            {
                                if (File.Exists(SentBackPath + Path.GetFileName(a.FullName)))
                                {
                                    File.Delete(SentBackPath + Path.GetFileName(a.FullName));
                                }
                                File.Move(a.FullName, SentBackPath + Path.GetFileName(a.FullName));
                            }
                        }
                    }
                }
                return State;
            }
            #endregion
            #region EOD文件操作方法
            private Boolean DataToEOD(String PathName)
            {
                try
                {

                    String EODText = String.Empty;
                    foreach (var a in this.DataList)
                    {
                        EODText += a.OrderType + "|";
                        EODText += a.HmBillCode + "|";
                        EODText += a.OrderCode + "|";
                        EODText += a.ClientNo + "|";
                        EODText += a.WD + "|";
                        EODText += DataHandling.ToTraditionalChinese(a.Area) + "|";
                        EODText += a.Code + "|";
                        EODText += a.Dshk + "|";
                        EODText += a.Dshk_Money + "|";
                        EODText += a.Df + "|";
                        EODText += a.PayType + "|";
                        EODText += DataHandling.ToTraditionalChinese(a.Signer) + "|";
                        EODText += a.SignerTel + "|";
                        EODText += a.SignerPhone + "|";
                        EODText += a.SignerZip + "|";
                        EODText += DataHandling.ToTraditionalChinese(a.SignerAddress) + "|";
                        EODText += DataHandling.ToTraditionalChinese(a.Senter) + "|";
                        EODText += a.SenterTel + "|";
                        EODText += a.SenterPhone + "|";
                        EODText += a.SenterZip + "|";
                        EODText += DataHandling.ToTraditionalChinese(a.SenterAddress) + "|";
                        EODText += a.SentDate + "|";
                        EODText += a.GetTime + "|";
                        EODText += a.SendTime + "|";
                        EODText += a.Client + "|";
                        EODText += DataHandling.ToTraditionalChinese(a.GoodsName) + "|";
                        EODText += a.Goods_Ys + "|";
                        EODText += a.Goods_Yq + "|";
                        EODText += a.Rem.Replace("\r\n", "").Replace("\r", "").Replace("\n", "") + "|";
                        EODText += a.SDCode + "|\r\n";
                    }
                    FileStream Fs = new FileStream(PathName, FileMode.Append);
                    Byte[] EODByte = System.Text.Encoding.Default.GetBytes(EODText);
                    Fs.Write(EODByte, 0, EODByte.Length);
                    Fs.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            #endregion
            #region Http方法
            /// <summary>
            /// Nvc
            /// </summary>
            /// <param name="FunctionName"></param>
            /// <param name="JsonData"></param>
            /// <param name="CusID"></param>
            /// <param name="KeyMd5"></param>
            /// <returns></returns>
            public static NameValueCollection GetNvc(Dictionary<String, String> Obj)
            {
                NameValueCollection Nvc = new NameValueCollection();
                foreach (var a in Obj)
                {
                    Nvc.Add(a.Key, a.Value);
                }
                return Nvc;

            }
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
            /// GET请求与获取结果  
            /// </summary>  
            private static Zip HttpGet(string Url, string postDataStr, string ContentType = "text/html;charset=UTF-8")
            {
                Zip z = new Zip();
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + postDataStr);
                    request.Method = "GET";
                    request.Timeout = 3000;
                    request.ContentType = ContentType;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                    string retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                    var Edi = JsonToObject<EdiJson>(retString);
                    z = new Zip()
                    {
                        EDI = Edi.sttn_no,
                        Code = Edi.zip3,
                        Jm = Edi.sttn_map
                    };
                    return z;
                }
                catch (Exception)
                {
                    return z;
                }
            }
            /// <summary>  
            /// GET请求与获取结果  
            /// </summary>  
            private static String Http_Get(string Url, string postDataStr, string ContentType = "text/html;charset=UTF-8")
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + postDataStr);
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
                catch (Exception)
                {
                    return String.Empty;
                }
            }
            /// <summary>
            /// 序列号Json文本为T数据类型
            /// </summary>
            /// <typeparam name="T">数据类型</typeparam>
            /// <param name="JsonText">Json字符串</param>
            /// <returns>T数据类型</returns>
            private static T JsonToObject<T>(string JsonText)
            {
                try
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
                    T list = js.Deserialize<T>(JsonText);    //将json数据转化为对象类型并赋值给list
                    return list;
                }
                catch (Exception ex)
                {
                    return default(T);
                }
            }
            /// <summary>
            /// 将&链接字符串转换为Json格式
            /// </summary>
            /// <param name="ReqText"></param>
            /// <returns></returns>
            public static String ToJson(String ReqText)
            {
                ReqText = System.Web.HttpUtility.UrlDecode(ReqText, Encoding.UTF8);
                String[] Texts = ReqText.Split(new String[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
                String Json = String.Empty;
                foreach (var a in Texts)
                {
                    String[] KeyValue = a.Split(new String[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                    if (KeyValue.Length == 2)
                    {
                        Json += Json == string.Empty ? "{\"" + KeyValue[0] + "\":\"" + KeyValue[1] + "\"" : ",\"" + KeyValue[0] + "\":\"" + KeyValue[1] + "\"";
                    }
                }
                Json += Json == String.Empty ? "{}" : "}";
                return Json;
            }
            #endregion
            #region EGS Api
            /// <summary>
            /// 获取EGS版本号
            /// </summary>
            /// <returns></returns>
            public static VisonInfo GetEGSVersion()
            {
                var Temp = new Dictionary<string, string>();
                Temp.Add("cmd", "query_egs_info");
                return JsonToObject<VisonInfo>(ToJson(Send(ApiUrl, Encoding.UTF8, GetNvc(Temp))));
            }
            /// <summary>
            /// 获取5位区号
            /// </summary>
            /// <param name="Address"></param>
            /// <returns></returns>
            public static query_suda5_Response query_suda5(String Address)
            {
                var Temp = new Dictionary<string, string>();
                Temp.Add("cmd", "query_suda5");
                Temp.Add("address_1", System.Web.HttpUtility.UrlEncode(Address, Encoding.UTF8));
                return JsonToObject<query_suda5_Response>(ToJson(Send(ApiUrl, Encoding.UTF8, GetNvc(Temp))));
            }
            /// <summary>
            /// 获取7位区号
            /// </summary>
            /// <param name="Address"></param>
            /// <returns></returns>
            public static query_suda7_Response query_suda7(String Address)
            {
                var Temp = new Dictionary<string, string>();
                Temp.Add("cmd", "query_suda7_dash");
                String aaa = System.Web.HttpUtility.UrlEncode(Address, Encoding.UTF8);
                Temp.Add("address_1", aaa);

                //return JsonToObject<query_suda7_Response>(ToJson(Send(ApiUrl, Encoding.UTF8, GetNvc(Temp))));
                return JsonToObject<query_suda7_Response>(ToJson(Http_Get(ApiUrl, "cmd=query_suda7_dash&address_1=" + aaa)));
            }
            /// <summary>
            /// 查询剩余单号数量
            /// </summary>
            /// <returns></returns>
            public static query_waybill_id_remain_Response query_waybill_id_remain()
            {
                var Temp = new Dictionary<string, string>();
                Temp.Add("cmd", "query_waybill_id_remain");
                Temp.Add("customer_id", ClientNo);
                Temp.Add("waybill_type", "A");
                return JsonToObject<query_waybill_id_remain_Response>(ToJson(Send(ApiUrl, Encoding.UTF8, GetNvc(Temp))));
            }
            /// <summary>
            /// 查询客户资料
            /// </summary>
            /// <returns></returns>
            public static query_customers_Response query_customers()
            {
                var Temp = new Dictionary<string, string>();
                Temp.Add("cmd", "query_customers");
                return JsonToObject<query_customers_Response>(ToJson(Send(ApiUrl, Encoding.UTF8, GetNvc(Temp))));
            }
            /// <summary>
            /// 申請速達託運單號碼 
            /// </summary>
            /// <param name="Count"></param>
            /// <returns></returns>
            public static query_waybill_id_range_Response query_waybill_id_range(int Count)
            {
                var Temp = new Dictionary<string, string>();
                Temp.Add("cmd", "query_waybill_id_range");
                Temp.Add("customer_id", ClientNo);
                Temp.Add("waybill_type", "A");
                Temp.Add("count", Count.ToString());
                return JsonToObject<query_waybill_id_range_Response>(ToJson(Send(ApiUrl, Encoding.UTF8, GetNvc(Temp))));
            }
            /// <summary>
            /// 上传运单信息
            /// </summary>
            /// <returns></returns>
            public static transfer_waybill_Response transfer_waybill()
            {
                var Temp = new Dictionary<string, string>();
                Temp.Add("cmd", "query_waybill_id_range");
                Temp.Add("customer_id", ClientNo);
                Temp.Add("waybill_type", "A");
                return JsonToObject<transfer_waybill_Response>(ToJson(Send(ApiUrl, Encoding.UTF8, GetNvc(Temp))));
            }
            #endregion
            #region 数据类
            /// <summary>
            /// 当前数据类
            /// </summary>
            public class Data
            {
                /// <summary>
                /// 託運類別
                /// 1:客戶自行列印託運單
                /// 2:速達協助列印(由速達系統分配託運單號)
                /// 3:已有單號，由速達列印(A4二模) –逆物流收退貨
                /// </summary>
                public String OrderType = "1";
                /// <summary>
                /// 託運單號 若上欄為2時，則此欄空白
                /// </summary>
                public String HmBillCode { get; set; }
                /// <summary>
                /// 訂單編號(客戶端) 契約客戶端之訂單編號
                /// </summary>
                public String OrderCode { get; set; }
                /// <summary>
                /// 契客代號 簽約後，速達建完主檔提供之「契約客戶」代號
                /// </summary>
                public String ClientNo = HmHelper.ClientNo;
                /// <summary>
                /// 溫層 0001:常溫  0002:冷藏 0003:冷凍  (default 0001)
                /// </summary>
                public String WD = "0001";
                /// <summary>
                /// 距離 00:同縣市 01:外縣市 02:離島   (default 00)
                /// </summary>
                public String Area = "00";
                /// <summary>
                /// 規格 0001: 60cm   0002: 90cm   0003: 120cm  0004: 150cm (default 0001)
                /// </summary>
                public String Code = "0001";
                /// <summary>
                /// 是否代收貨款 N:否  Y:是 (default N)
                /// </summary>
                public String Dshk = "N";
                /// <summary>
                /// 代收金額 若上一欄為Y，則為代收金額,例如：100元，則值為100 若上一欄為N，此欄固定帶0即可
                /// </summary>
                public int Dshk_Money = 0;
                /// <summary>
                /// 是否到付 無作用，請固定填N
                /// </summary>
                public String Df = "N";
                /// <summary>
                /// 是否付現 00:付現 01:月結  (default 01) 
                /// </summary>
                public String PayType = "01";
                /// <summary>
                /// 收件人姓名 若「託運類別」為1：為客戶自行印託運單，因應資訊安全，收件人姓名帶* 即可
                /// </summary>
                public String Signer = "*";
                /// <summary>
                /// 收件人電話 若「託運類別」為1：為客戶自行印託運單因應資訊安全，收件人電話帶* 即可
                /// </summary>
                public String SignerTel = "*";
                /// <summary>
                /// 收件人手機 若「託運類別」為1：為客戶自行印託運單因應資訊安全，收件人手機帶* 即可
                /// </summary>
                public String SignerPhone = "*";
                /// <summary>
                /// 收件人郵遞區號 必須輸入 
                /// </summary>
                public String SignerZip { get; set; }
                private string _SignerAddress { get; set; }
                private string _SenterAddress { get; set; }
                /// <summary>
                /// 收件人地址 必須輸入 
                /// </summary>
                public String SignerAddress
                {
                    set
                    {
                        _SignerAddress = value;
                        var a = query_suda7(_SignerAddress);
                        SignerZip = a.suda7_1 != null && a.suda7_1.Replace("-", "").Length > 5 ? a.suda7_1.Replace("-", "").Substring(a.suda7_1.Replace("-", "").Length - 5) : "";
                    }
                    get { return _SignerAddress; }
                }
                /// <summary>
                /// 寄件人姓名 必須輸入 
                /// </summary>
                public String Senter { get; set; }
                /// <summary>
                /// 寄件人電話
                /// </summary>
                public String SenterTel { get; set; }
                /// <summary>
                /// 寄件人手機 
                /// </summary>
                public String SenterPhone { get; set; }
                /// <summary>
                /// 寄件人地址 必須輸入，速達前往集貨地址
                /// </summary>
                public String SenterAddress
                {
                    get { return _SenterAddress; }
                    set
                    {
                        _SenterAddress = value;
                        var a = query_suda7(_SenterAddress);
                        SenterZip = a.suda7_1 != null && a.suda7_1.Replace("-", "").Length > 5 ? a.suda7_1.Replace("-", "").Substring(a.suda7_1.Replace("-", "").Length - 5) : "";
                    }
                }
                /// <summary>
                /// 寄件人郵遞區號 必須輸入，速達前往集貨地址的五碼郵號
                /// </summary>
                public String SenterZip { get; set; }
                /// <summary>
                /// 契客出貨日期 或速達印託運單日期 YYYYMMDDhhmmss，或系統日期ss秒數若無的話，ss用00補齊14位或是只提供到YYYYMMDD即可
                /// </summary>
                public String SentDate { get; set; }
                /// <summary>
                /// 預定取件時段 1: 9~12    2: 12~17    3: 17~20   4: 不限時(固定4不限時)
                /// </summary>
                public String GetTime = "4";
                /// <summary>
                /// 預定配達時段 1: 9~12    2: 12~17   3: 17~20   4: 不限時  5:20~21(需限定區域)
                /// </summary>
                public String SendTime = "4";
                /// <summary>
                /// 會員編號 可選擇性填入
                /// </summary>
                public String Client { get; set; }
                /// <summary>
                /// 物品名稱 可選擇性填入
                /// </summary>
                public String GoodsName { get; set; }
                /// <summary>
                /// 易碎物品 N:否  Y:是  (default N) 目前無作用：固定填N 
                /// </summary>
                public String Goods_Ys = "N";
                /// <summary>
                /// 精密儀器 N:否  Y:是  (default N) 目前無作用：固定填N 
                /// </summary>
                public String Goods_Yq = "N";
                /// <summary>
                /// 備註 可選擇性填入
                /// </summary>
                public String Rem { get; set; }
                /// <summary>
                /// 30	SD路線代碼 不必填
                /// </summary>
                public String SDCode { get; set; }
            }
            /// <summary>
            /// EDI邮政编码类
            /// </summary>
            private class Zip
            {
                /// <summary>
                /// 邮政区号
                /// </summary>
                public String Code { get; set; }
                /// <summary>
                /// 列印简码
                /// </summary>
                public String Jm { get; set; }
                /// <summary>
                /// EDI站码
                /// </summary>
                public String EDI { get; set; }
                /// <summary>
                /// 站所简称
                /// </summary>
                public String Name { get; set; }
                /// <summary>
                /// 特殊标记
                /// </summary>
                public String Bj { get; set; }
                /// <summary>
                /// 是否特殊标记
                /// </summary>
                /// <returns></returns>
                public Boolean IsTs()
                {
                    return this.Jm.Contains("K") || this.Bj == "K";
                }
            }
            /// <summary>
            /// EDI接口JSON格式
            /// </summary>
            private class EdiJson
            {
                /// <summary>
                /// 列印简码
                /// </summary>
                public String sttn_map { get; set; }
                /// <summary>
                /// EDI站码
                /// </summary>
                public String sttn_no { get; set; }
                /// <summary>
                /// 邮政区号
                /// </summary>
                public String zip3 { get; set; }
            }
            /// <summary>
            /// EGS版本信息
            /// </summary>
            public class VisonInfo
            {
                /// <summary>
                /// OK|ERROR
                /// </summary>
                public String status { get; set; }
                /// <summary>
                /// 錯誤訊息
                /// </summary>
                public String message { get; set; }
                /// <summary>
                /// :EGS 目前版本
                /// </summary>
                public String egs_version { get; set; }
                /// <summary>
                /// 速達五碼郵號地址庫目前版本
                /// </summary>
                public String address_db_version { get; set; }
                /// <summary>
                /// 0 or 1:處於 Sandbox 模式>
                /// </summary>
                public String sandbox_mode { get; set; }
                /// <summary>
                /// 0 or 1:啟用網際網路連線>
                /// </summary>
                public String internet_online { get; set; }
            }
            /// <summary>
            /// 申請速達託運單號碼 返回
            /// </summary>
            public class query_waybill_id_range_Response
            {
                /// <summary>
                /// OK|ERROR
                /// </summary>
                public String status { get; set; }
                /// <summary>
                /// 錯誤訊息
                /// </summary>
                public String message { get; set; }
                /// <summary>
                /// 託運單類別 "A"=一般託運單|"B"=代收託運單
                /// </summary>
                public String waybill_type { get; set; }
                /// <summary>
                /// 速達託運單號  1，2，3，4，5
                /// </summary>
                public String waybill_id { get; set; }
            }
            /// <summary>
            /// 查询7段码返回类
            /// </summary>
            public class query_suda7_Response
            {
                /// <summary>
                /// OK|ERROR
                /// </summary>
                public string status { get; set; }
                /// <summary>
                /// 錯誤訊息>
                /// </summary>
                public string message { get; set; }
                /// <summary>
                /// 速達五碼郵遞區號
                /// </summary>
                public string suda7_1 { get; set; }
            }
            /// <summary>
            /// 查询5段码返回类
            /// </summary>
            public class query_suda5_Response
            {
                /// <summary>
                /// OK|ERROR
                /// </summary>
                public string status { get; set; }
                /// <summary>
                /// 錯誤訊息>
                /// </summary>
                public string message { get; set; }
                /// <summary>
                /// 速達五碼郵遞區號
                /// </summary>
                public string suda5_1 { get; set; }
            }
            /// <summary>
            /// 查询5段码返回类
            /// </summary>
            public class query_waybill_id_remain_Response
            {
                /// <summary>
                /// OK|ERROR
                /// </summary>
                public string status { get; set; }
                /// <summary>
                /// 錯誤訊息>
                /// </summary>
                public string message { get; set; }
                /// <summary>
                /// 託運單類別 "A"=一般託運單|"B"=代收託運單
                /// </summary>
                public string waybill_type { get; set; }
                /// <summary>
                /// 速達託運單號剩餘存量
                /// </summary>
                public string waybill_id_remain { get; set; }
            }
            /// <summary>
            /// 查詢契客資料返回类
            /// </summary>
            public class query_customers_Response
            {
                /// <summary>
                /// OK|ERROR
                /// </summary>
                public string status { get; set; }
                /// <summary>
                /// 錯誤訊息
                /// </summary>
                public string message { get; set; }
                /// <summary>
                /// 契客代號,契客名稱,0 or 1:已驗證通過,0 or 1:屬 於客樂得契約客戶
                /// </summary>
                public string customer_1 { get; set; }
            }
            /// <summary>
            /// 上传运单信息返回类
            /// </summary>
            public class transfer_waybill_Response
            {
                /// <summary>
                /// OK|ERROR
                /// </summary>
                public string status { get; set; }
                /// <summary>
                /// 錯誤訊息>
                /// </summary>
                public string message { get; set; }
            }
            #endregion
        }
        /// <summary>
        /// 超峰接口帮助类
        /// </summary>
        public class CFHelper
        {
            public static bool uploadingCFState { get; set; }
            #region 初始化
            /// <summary>
            /// 初始化类
            /// </summary>
            public CFHelper()
            {
                SetCellsName();
            }
            #endregion

            #region 内部架构
            /// <summary>
            /// 当前EDI列表
            /// </summary>
            private List<Zip> ZipList = new List<Zip>();
            /// <summary>
            /// 数据集合
            /// </summary>
            private List<Data> DataList = new List<Data>();
            /// <summary>
            /// Execl列名集合
            /// </summary>
            private Dictionary<int, String> Cells = new Dictionary<int, string>();
            /// <summary>
            /// 定义列名
            /// </summary>
            private void SetCellsName()
            {
                Cells.Add(0, "發送站");
                Cells.Add(1, "客戶編號");
                Cells.Add(2, "寄件聯絡人");
                Cells.Add(3, "寄件人電話1");
                Cells.Add(4, "寄件人電話2");
                Cells.Add(5, "寄件人地址");
                Cells.Add(6, "出貨日期");
                Cells.Add(7, "出貨批號");
                Cells.Add(8, "序號");
                Cells.Add(9, "客戶出貨編號");
                Cells.Add(10, "收件人姓名");
                Cells.Add(11, "收件人統編");
                Cells.Add(12, "收件人電話1");
                Cells.Add(13, "郵遞區號1");
                Cells.Add(14, "收件人地址1");
                Cells.Add(15, "收件人電話2");
                Cells.Add(16, "郵遞區號2");
                Cells.Add(17, "收件人地址2");
                Cells.Add(18, "運送日期");
                Cells.Add(19, "超峰託運單號");
                Cells.Add(20, "到著站");
                Cells.Add(21, "貨件類別");
                Cells.Add(22, "貨件名稱");
                Cells.Add(23, "件數");
                Cells.Add(24, "重量");
                Cells.Add(25, "貨號");
                Cells.Add(26, "代收貨款");
                Cells.Add(27, "注意事項");
                Cells.Add(28, "外袋號");
            }
            /// <summary>
            /// 定义EDI数据
            /// </summary>
            private void SetEdiData()
            {
                ZipList.Add(new Zip() { Code = "", Jm = "", EDI = "", Name = "", Bj = "" });
            }
            /// <summary>
            /// Edi获取接口地址
            /// </summary>
            public static String EdiUrl = "http://webserv1.express.com.tw:8081/webapi/api/getsttninfo/";
            #endregion

            #region 公共类方法
            /// <summary>
            /// 添加数据
            /// </summary>
            /// <param name="data"></param>
            public void AddData(Data data)
            {
                this.DataList.Add(data);
            }
            /// <summary>
            /// 清空数据
            /// </summary>
            public void ClearData()
            {
                this.DataList.Clear();
            }
            /// <summary>
            /// 获取数据
            /// </summary>
            /// <returns></returns>
            public List<Data> GetData()
            {
                return DataList;
            }
            /// <summary>
            /// 导出到Execl文件
            /// </summary>
            /// <param name="FileName"></param>
            public Boolean ToExecl(String FileName, Boolean UpFtp)
            {
                if (FileName.Trim() == String.Empty && this.DataList.Count == 0)
                {
                    return false;
                }
                String SentPath = FileName + "/CF_Send_Temp/";
                if (!Directory.Exists(SentPath))
                {
                    Directory.CreateDirectory(SentPath);
                }
                String SaveFileName = SentPath + DateTime.Now.ToString("yyyyMMddHH") + ".txt";
                Boolean State = DataToTxt(SaveFileName);
                if (UpFtp)
                {
                    String SentBackPath = FileName + "/CF_Send_Back/";
                    if (!Directory.Exists(SentBackPath))
                    {
                        Directory.CreateDirectory(SentBackPath);
                    }
                    DirectoryInfo Dr = new DirectoryInfo(SentPath);
                    var Files = Dr.GetFiles().ToList();
                    if (Files.Count(x => !x.Name.ToLower().Equals(Path.GetFileName(SaveFileName.ToLower()))) > 0)
                    {
                        Common.FtpHelper Ftp = new FtpHelper(new Uri("Ftp://ftp.kerryexpress.com.tw"), "opoacc", "www.1-one.com.cn");
                        Ftp.DirectoryPath = @"/edi/";
                        foreach (var a in Files.Where(x => !x.Name.ToLower().Equals(Path.GetFileName(SaveFileName.ToLower()))))
                        {
                            if (Ftp.UploadFile(a.FullName))
                            {
                                if (File.Exists(SentBackPath + Path.GetFileName(a.FullName)))
                                {
                                    File.Delete(SentBackPath + Path.GetFileName(a.FullName));
                                }
                                File.Move(a.FullName, SentBackPath + Path.GetFileName(a.FullName));
                            }
                        }
                    }
                }
                return State;
            }
            #endregion

            #region 保存TXT
            private Boolean DataToTxt(String FileName)
            {
                try
                {
                    String SaveTxt = String.Empty;
                    foreach (var Obj in this.DataList)
                    {
                        SaveTxt += Obj.SentSite + "	";
                        SaveTxt += Obj.ClientID + "	";
                        SaveTxt += Obj.Senter + "	";
                        SaveTxt += Obj.SenterPhone + "	";
                        SaveTxt += Obj.SenterTel + "	";
                        SaveTxt += Obj.SenterAddress + "	";
                        SaveTxt += Obj.SentDate + "	";
                        SaveTxt += Obj.SentNo + "	";
                        SaveTxt += Obj.DescNo + "	";
                        SaveTxt += Obj.ClientOrderNo + "	";
                        SaveTxt += DataHandling.ToTraditionalChinese(Obj.Signer) + "	";
                        SaveTxt += Obj.SignerNo + "	";
                        SaveTxt += Obj.SignerPhone + "	";
                        SaveTxt += Obj.ZipCode + "	";
                        SaveTxt += DataHandling.ToTraditionalChinese(Obj.SignerAddress) + "	";
                        SaveTxt += Obj.SignerTel + "	";
                        SaveTxt += Obj.Zip_Code + "	";
                        SaveTxt += DataHandling.ToTraditionalChinese(Obj.SignerAddress_2) + "	";
                        SaveTxt += Obj.SendDate + "	";
                        SaveTxt += Obj.CFBillCode + "	";
                        SaveTxt += Obj.SignSite + "	";
                        SaveTxt += Obj.GoodsType + "	";
                        SaveTxt += Obj.GoodsName + "	";
                        SaveTxt += Obj.GoodsCount + "	";
                        SaveTxt += Obj.GoodsWeight + "	";
                        SaveTxt += Obj.GoodsNo + "	";
                        SaveTxt += Obj.GetMoney + "	";
                        SaveTxt += Obj.Rem.Replace("\r\n", "").Replace("\r", "").Replace("\n", "") + "	";
                        SaveTxt += Obj.PackNo + "	";
                        SaveTxt += "\r\n";
                    }
                    FileStream Fs = new FileStream(FileName, FileMode.Append);
                    Byte[] EODByte = System.Text.Encoding.Default.GetBytes(SaveTxt);
                    Fs.Write(EODByte, 0, EODByte.Length);
                    Fs.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            #endregion

            #region Http方法
            /// <summary>  
            /// GET请求与获取结果  
            /// </summary>  
            public static Zip HttpGet(string Url, string postDataStr, string ContentType = "text/html;charset=UTF-8")
            {
                Zip z = new Zip();
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + postDataStr);
                    request.Method = "GET";
                    request.Timeout = 3000;
                    request.ContentType = ContentType;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream myResponseStream = response.GetResponseStream();
                    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                    string retString = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                    myResponseStream.Close();
                    var Edi = JsonToObject<EdiJson>(retString);
                    z = new Zip()
                    {
                        EDI = Edi.sttn_no,
                        Code = Edi.zip3,
                        Jm = Edi.sttn_map
                    };
                    return z;
                }
                catch (Exception)
                {
                    return z;
                }
            }
            /// <summary>
            /// 序列号Json文本为T数据类型
            /// </summary>
            /// <typeparam name="T">数据类型</typeparam>
            /// <param name="JsonText">Json字符串</param>
            /// <returns>T数据类型</returns>
            private static T JsonToObject<T>(string JsonText)
            {
                try
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();   //实例化一个能够序列化数据的类
                    T list = js.Deserialize<T>(JsonText);    //将json数据转化为对象类型并赋值给list
                    return list;
                }
                catch (Exception ex)
                {
                    return default(T);
                }
            }
            #endregion

            #region 数据类
            /// <summary>
            /// 当前数据类
            /// </summary>
            public class Data
            {
                /// <summary>
                /// 寄件站点
                /// </summary>
                public String SentSite { get; set; }
                /// <summary>
                /// 寄件客户编号
                /// </summary>
                public String ClientID { get; set; }
                /// <summary>
                /// 寄件人
                /// </summary>
                public String Senter { get; set; }
                /// <summary>
                /// 寄件电话
                /// </summary>
                public String SenterPhone { get; set; }
                /// <summary>
                /// 寄件电话
                /// </summary>
                public String SenterTel { get; set; }
                /// <summary>
                /// 寄件地址
                /// </summary>
                public String SenterAddress { get; set; }
                /// <summary>
                /// 寄件日期
                /// </summary>
                public String SentDate { get; set; }
                /// <summary>
                /// 出货批号
                /// </summary>
                public String SentNo { get; set; }
                /// <summary>
                /// 序号
                /// </summary>
                public String DescNo { get; set; }
                /// <summary>
                /// 客户订单号码
                /// </summary>
                public String ClientOrderNo { get; set; }
                /// <summary>
                /// 收件人
                /// </summary>
                public String Signer { get; set; }
                /// <summary>
                /// 收件人编号
                /// </summary>
                public String SignerNo { get; set; }
                /// <summary>
                /// 收件电话
                /// </summary>
                public String SignerPhone { get; set; }
                /// <summary>
                /// 邮政编号
                /// </summary>
                public String ZipCode { get; set; }
                private String SignerAddress_ { get; set; }
                public Zip Zip { get; set; }
                /// <summary>
                /// 收件地址
                /// </summary>
                public String SignerAddress
                {
                    get
                    {
                        return SignerAddress_;
                    }
                    set
                    {
                        var a = HttpGet(EdiUrl, value);
                        this.Zip = a;
                        this.ZipCode = a.Code;
                        this.SignSite = a.Jm;
                        SignerAddress_ = value;
                    }
                }
                /// <summary>
                /// 收件电话
                /// </summary>
                public String SignerTel { get; set; }
                /// <summary>
                /// 邮政编号
                /// </summary>
                public String Zip_Code { get; set; }
                /// <summary>
                /// 收件地址2
                /// </summary>
                public String SignerAddress_2 { get; set; }
                /// <summary>
                /// 运送日期
                /// </summary>
                public String SendDate { get; set; }
                /// <summary>
                /// 超峰单号 正式配撥：91340000-91389999
                /// </summary>
                public String CFBillCode { get; set; }
                /// <summary>
                /// 签收站
                /// </summary>
                public String SignSite { get; set; }
                /// <summary>
                /// 货物类型
                /// </summary>
                public String GoodsType { get; set; }
                /// <summary>
                /// 货物名称
                /// </summary>
                public String GoodsName { get; set; }
                /// <summary>
                /// 件数
                /// </summary>
                public String GoodsCount { get; set; }
                /// <summary>
                /// 重量
                /// </summary>
                public int GoodsWeight { get; set; }
                /// <summary>
                /// 货号
                /// </summary>
                public String GoodsNo { get; set; }
                /// <summary>
                /// 代收货款
                /// </summary>
                public int GetMoney { get; set; }
                /// <summary>
                /// 备注 注意事项
                /// </summary>
                public String Rem { get; set; }
                /// <summary>
                /// 包装袋号
                /// </summary>
                public String PackNo { get; set; }
            }
            /// <summary>
            /// EDI邮政编码类
            /// </summary>
            public class Zip
            {
                /// <summary>
                /// 邮政区号
                /// </summary>
                public String Code { get; set; }
                /// <summary>
                /// 列印简码
                /// </summary>
                public String Jm { get; set; }
                /// <summary>
                /// EDI站码
                /// </summary>
                public String EDI { get; set; }
                /// <summary>
                /// 站所简称
                /// </summary>
                public String Name { get; set; }
                /// <summary>
                /// 特殊标记
                /// </summary>
                public String Bj { get; set; }
                /// <summary>
                /// 是否特殊标记
                /// </summary>
                /// <returns></returns>
                public Boolean IsTs()
                {
                    return this.Jm.Contains("K") || this.Bj == "K";
                }
            }
            /// <summary>
            /// EDI接口JSON格式
            /// </summary>
            private class EdiJson
            {
                /// <summary>
                /// 列印简码
                /// </summary>
                public String sttn_map { get; set; }
                /// <summary>
                /// EDI站码
                /// </summary>
                public String sttn_no { get; set; }
                /// <summary>
                /// 邮政区号
                /// </summary>
                public String zip3 { get; set; }
            }
            #endregion
        }


        /// <summary>
        /// 京广快递专用的加密方式
        /// </summary>
        /// <param name="FuncName"></param>
        /// <param name="JsonText"></param>
        /// <returns></returns>
        public static NameValueCollection GetNameValueCollection(string JsonText, string Cusid, string Keytext)
        {
            
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("JsonData", JsonText);
            nvc.Add("CusID", Cusid);
            nvc.Add("KeyMd5", Common.DataHandling.GetMD5Hash(JsonText + Keytext));
            return nvc;
        }

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
        /// 程序配置文件路径名称
        /// </summary>
        public static string ConnfigFile { get; set; }


        public static string PostUrl { get; set; }
    }


   


   

}
