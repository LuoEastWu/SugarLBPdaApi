using System;
using System.Linq;
using System.Text;

namespace EJETableData
{
    public class pmw_AriPack
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 ID {get;set;}

        /// <summary>
        /// Desc:包号 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string serialNo {get;set;}

        /// <summary>
        /// Desc:清关单号 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string qgCode {get;set;}

        /// <summary>
        /// Desc:清关公司 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string qgCom {get;set;}

        /// <summary>
        /// Desc:派件公司 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string pjCom {get;set;}

        /// <summary>
        /// Desc:集中包数据 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string sendAryyCode {get;set;}

        /// <summary>
        /// Desc:发货重量 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string sendWeight {get;set;}

        /// <summary>
        /// Desc:打包实重 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string netWeight {get;set;}

        /// <summary>
        /// Desc:打包时间 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? packTime {get;set;}

        /// <summary>
        /// Desc:仓库 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string warehouse {get;set;}

        /// <summary>
        /// Desc:员工 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string empName {get;set;}

        /// <summary>
        /// Desc:备注 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string note {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 airID {get;set;}

        /// <summary>
        /// Desc:航空包类型 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string AriPackType {get;set;}

        /// <summary>
        /// Desc:订单表打包标识列 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string order_AriCode {get;set;}

        /// <summary>
        /// Desc:转单号品名 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string TurnOrderGoods {get;set;}

        /// <summary>
        /// Desc:集运商名称 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string consolidatorName {get;set;}

        /// <summary>
        /// Desc:收件人统编 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Recipient {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 OrderID {get;set;}

        /// <summary>
        /// Desc:转单件数 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? TurnNumber {get;set;}

        /// <summary>
        /// Desc:重量错误时 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string weightError {get;set;}

    }
}
