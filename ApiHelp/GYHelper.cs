using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ApiHelp
{
    /// <summary>
    /// 国阳接口帮助类
    /// </summary>
    public class GYHelper
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public GYHelper() { }
        /// <summary>
        /// ftp地址
        /// </summary>
        public String Address = "FTP://www.ubg.com.tw";
        /// <summary>
        /// ftp账号
        /// </summary>
        public String Uid = @"Dv36g52";
        /// <summary>
        /// ftp密码
        /// </summary>
        public String Pwd = @"y6^G55kA";
        /// <summary>
        /// 客户代号
        /// </summary>
        public String ClientNo = "C000240817";
        /// <summary>
        /// 当前订单数据集合
        /// </summary>
        private List<Data> NowData = new List<Data>();
        #region 公共类方法
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="data"></param>
        public void AddData(Data data)
        {
            this.NowData.Add(data);
        }
        /// <summary>
        /// 清空数据
        /// </summary>
        public void ClearData()
        {
            this.NowData.Clear();
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<Data> GetData()
        {
            return NowData;
        }
        /// <summary>
        /// 导出到SCV文件
        /// </summary>
        /// <param name="FileName"></param>
        public Boolean ToCsv(String FileName, Boolean UpFtp)
        {
            if (FileName.Trim() == String.Empty && this.NowData.Count == 0)
            {
                return false;
            }
            String SentPath = FileName + "/Gy_Send_Temp/";
            if (!Directory.Exists(SentPath))
            {
                Directory.CreateDirectory(SentPath);
            }

            String NowNo = GetNo(SentPath);
            String SaveFileName = SentPath + "Dv_" + DateTime.Now.ToString("yyyyMMdd") + "_" + ClientNo + "_" + NowNo + ".Csv";
            Boolean State = this.DataToCsv(SaveFileName);
            if (State && UpFtp)
            {
                String SentBackPath = FileName + "/Gy_Send_Back/";
                if (!Directory.Exists(SentBackPath))
                {
                    Directory.CreateDirectory(SentBackPath);
                }
                DirectoryInfo Dr = new DirectoryInfo(SentPath);
                var Files = Dr.GetFiles().ToList();
                if (Files.Count(x => !x.Name.ToLower().Equals(Path.GetFileName(SaveFileName.ToLower()))) > 0)
                {
                    Common.FtpHelper Ftp = new Common.FtpHelper(new Uri(Address), Uid, Pwd);
                    Ftp.DirectoryPath = @"/upload/";
                    foreach (var a in Files.Where(x => !x.Name.ToLower().Equals(Path.GetFileName(SaveFileName.ToLower()))))
                    {
                        if (Ftp.UploadFile(a.FullName))
                        {
                            File.Move(a.FullName, SentBackPath + Path.GetFileName(a.FullName));
                        }
                    }
                }
            }
            return State;
        }
        /// <summary>
        /// 将当前数据写入到文件
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        private Boolean DataToCsv(String FileName)
        {
            String WriteText = String.Empty;
            if (!File.Exists(FileName))
            {
                WriteText = "發貨方式,收件人,收件人地址,收件人行動電話,收件人電子郵件,門市名稱,門市代碼,門市地址,門市電話,訂單編號,商品名稱,商品數量,代收金額,備註,重量,發貨物流\r\n";
            }
            foreach (var a in NowData)
            {
                WriteText += a.SentType + ",";
                WriteText += a.Signer + ",";
                WriteText += a.SignAddress + ",";
                WriteText += a.SignPhone + ",";
                WriteText += a.SignEmail + ",";
                WriteText += a.StoreName + ",";
                WriteText += a.StoreCode + ",";
                WriteText += a.StoreAddress + ",";
                WriteText += a.StorePhone + ",";
                WriteText += a.OrderCode + ",";
                WriteText += a.GoodsName + ",";
                WriteText += a.GoodsAccount + ",";
                WriteText += a.DsMoney + ",";
                WriteText += a.Rem + ",";
                WriteText += a.Weight + ",";
                WriteText += a.SentFastType + "\r\n";
            }
            try
            {
                FileStream Fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                Byte[] EODByte = System.Text.Encoding.GetEncoding("Big5").GetBytes(WriteText);
                Fs.Position = Fs.Length;
                Fs.Write(EODByte, 0, EODByte.Length);
                Fs.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取当前流水号
        /// </summary>
        /// <param name="PathName"></param>
        /// <returns></returns>
        private String GetNo(String PathName)
        {
            DirectoryInfo Dr = new DirectoryInfo(PathName);
            var Files = Dr.GetFiles().ToList();
            if (Files.Count == 0) return "0001";
            var a = Files.Last(x => x.CreationTime == Files.Max(s => s.CreationTime));
            var b = a.Name.Split(new string[] { "_", "." }, StringSplitOptions.RemoveEmptyEntries);
            if (a.CreationTime.ToString("yyyyMMddHH") == DateTime.Now.ToString("yyyyMMddHH"))
            {
                return b[b.Length - 2];
            }
            else
            {
                return (int.Parse(b[b.Length - 2]) + 1).ToString().PadLeft(4, '0');
            }
        }
        #endregion
        /// <summary>
        /// 获取订单数据模型
        /// </summary>
        public class Data
        {
            /// <summary>
            /// 【必填】发货方式 A01 宅配 A02 超商
            /// </summary>
            public String SentType { get; set; }
            /// <summary>
            /// 【必填】收件人
            /// </summary>
            public String Signer { get; set; }
            /// <summary>
            /// 【必填】收件地址
            /// </summary>
            public String SignAddress { get; set; }
            /// <summary>
            /// 【可空】收件电话
            /// </summary>
            public String SignPhone { get; set; }
            /// <summary>
            /// 【可空】收件邮箱
            /// </summary>
            public String SignEmail { get; set; }
            /// <summary>
            /// 【可空】超商门店名称
            /// </summary>
            public String StoreName { get; set; }
            /// <summary>
            /// 【可空】超商门店代码
            /// </summary>
            public String StoreCode { get; set; }
            /// <summary>
            /// 【可空】超商门店地址
            /// </summary>
            public String StoreAddress { get; set; }
            /// <summary>
            /// 【可空】超商门店电话
            /// </summary>
            public String StorePhone { get; set; }
            /// <summary>
            /// 【必填】国阳发货单号
            /// </summary>
            public String OrderCode { get; set; }
            /// <summary>
            /// 【必填】商品名称
            /// </summary>
            public String GoodsName { get; set; }
            /// <summary>
            /// 【必填】商品件数
            /// </summary>
            public int GoodsAccount { get; set; }
            /// <summary>
            /// 【必填】代收货款金额
            /// </summary>
            public int DsMoney { get; set; }
            /// <summary>
            /// 【必填】备注 请填大包号
            /// </summary>
            public String Rem { get; set; }
            /// <summary>
            /// 【必填】重量 
            /// </summary>
            public int Weight { get; set; }
            /// <summary>
            /// 【可空】 1 邮局 2 宅配通 3 黑猫 4 萊爾富 5 OK 6:7‐11 7全家  8立邦 9新竹
            /// </summary>
            public int SentFastType { get; set; }
        }
    }
}
