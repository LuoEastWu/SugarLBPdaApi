using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ApiHelp
{
    public class GYApi
    {

        public void GyFtp(DataTable dt, string ftpPaht)
        {
            Common.CsvHelp.writeCsv(dt,ftpPaht);
            Common.FtpHelper gyFtp = new Common.FtpHelper(new Uri("Ftp://www.ubg.com.tw"), "Dv36g52", "y6^G55kA");
            gyFtp.UploadFile(ftpPaht);
        }

        public DataTable GyDataTable(GyDataInfo gyInfo) 
        {
            
            

            DataTable GyData = new DataTable("GyData");
            //填入'A01'為宅配檔、'A02' 為超商檔" 
            GyData.Columns.Add("發貨方式", Type.GetType("System.String"));
            GyData.Columns.Add("收件人", Type.GetType("System.String"));
            //若發貨方式為"宅配"請 填入正確地址 
            GyData.Columns.Add("收件人地址", Type.GetType("System.String"));
            //行動電話必塡
            GyData.Columns.Add("收件人行動電話", Type.GetType("System.String"));
            //收件人電子郵件
            GyData.Columns.Add("收件人電子郵件", Type.GetType("System.String"));
            //若發貨方式為"超商" 此為必塡 
            GyData.Columns.Add("門市名稱", Type.GetType("System.String"));
            GyData.Columns.Add("門市代碼", Type.GetType("System.String"));
            GyData.Columns.Add("門市地址", Type.GetType("System.String"));
            GyData.Columns.Add("門市電話", Type.GetType("System.String"));
            GyData.Columns.Add("訂單編號 ", Type.GetType("System.String"));
            GyData.Columns.Add("商品名稱", Type.GetType("System.String"));
            GyData.Columns.Add("商品數量", Type.GetType("System.String"));
            GyData.Columns.Add("代收金額", Type.GetType("System.String"));
            GyData.Columns.Add("備註", Type.GetType("System.String"));
            GyData.Columns.Add("重量", Type.GetType("System.String"));
            GyData.Columns.Add("發貨物流", Type.GetType("System.String"));

            GyData.Rows[0][0] = gyInfo.deliveryMethod;
            GyData.Rows[0][1] = gyInfo.recipients;
            GyData.Rows[0][2] = gyInfo.direction;
            GyData.Rows[0][3] = gyInfo.recipientCellPhone;
            GyData.Rows[0][4] = gyInfo.recipientEmail;
            GyData.Rows[0][5] = gyInfo.outletsName;
            GyData.Rows[0][6] = gyInfo.outletsCode;
            GyData.Rows[0][7] = gyInfo.outletsAddress;
            GyData.Rows[0][8] = gyInfo.outletsPhone;
            GyData.Rows[0][9] = gyInfo.orderNumber;
            GyData.Rows[0][10] = gyInfo.productName;
            GyData.Rows[0][11] = gyInfo.quantityCommodity;
            GyData.Rows[0][12] = gyInfo.collectingMoney;
            GyData.Rows[0][13] = gyInfo.remark;
            GyData.Rows[0][14] = gyInfo.weight;
            GyData.Rows[0][15] = gyInfo.shippingLogistics;
            return GyData;
        }

       
    }

    public  class GyDataInfo 
    {
        /// <summary>
        /// 發貨方式
        /// 填入'A01'為宅配檔、'A02' 為超商檔
        /// </summary>
        public string deliveryMethod { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string recipients { get; set; }
        /// <summary>
        /// 收件人地址
        /// 若發貨方式為"宅配"請填入正確地址
        /// </summary>
        public string direction { get; set; }
        /// <summary>
        /// 收件人行動電話 
        /// 行動電話必塡
        /// </summary>
        public string recipientCellPhone { get; set; }
        /// <summary>
        /// 收件人電子郵件
        /// </summary>
        public string recipientEmail { get; set; }
        /// <summary>
        /// 門市名稱 
        /// 若發貨方式為"超商"門市代碼 此為必塡
        /// </summary>
        public string outletsName { get; set; }
        /// <summary>
        /// 門市代碼 
        /// 若發貨方式為"超商"門市代碼 此為必塡
        /// </summary>
        public string outletsCode { get; set; }
        /// <summary>
        /// 門市地址 
        /// 若發貨方式為"超商"門市代碼 此為必塡
        /// </summary>
        public string outletsAddress { get; set; }
        /// <summary>
        /// 門市電話 
        /// 若發貨方式為"超商"門市代碼 此為必塡
        /// </summary>
        public string outletsPhone { get; set; }
        /// <summary>
        /// 訂單編號 
        /// 請填入區段編號
        /// </summary>
        public string orderNumber { get; set; }
        /// <summary>
        /// 商品名稱
        /// </summary>
        public string productName { get; set; }
        /// <summary>
        /// 商品數量
        /// </summary>
        public string quantityCommodity { get; set; }
        /// <summary>
        /// 代收货款
        /// </summary>
        public string collectingMoney { get; set; }
        /// <summary>
        /// 備註
        /// 請填入大號 
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 重量
        /// 請以克重 g 為單位
        /// </summary>
        public string weight { get; set; }
        /// <summary>
        /// 發貨物流
        /// 1.郵局2.宅配通3.黑貓4.超商
        /// </summary>
        public string shippingLogistics { get; set; }
       

    } 
}
