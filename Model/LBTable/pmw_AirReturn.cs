using System;
using System.Linq;
using System.Text;

namespace Model.LBTable
{
    public class pmw_AirReturn
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 id {get;set;}

        /// <summary>
        /// Desc:单号 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string billCode {get;set;}

        /// <summary>
        /// Desc:单号类型 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string billCodeType {get;set;}

        /// <summary>
        /// Desc:货物类型（1：有单号0无单号） 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string billType {get;set;}

        /// <summary>
        /// Desc:说明 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string explain {get;set;}

        /// <summary>
        /// Desc:仓库操作员 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string warehouseOperator {get;set;}

        /// <summary>
        /// Desc:操作时间 
        /// Default:(getdate()) 
        /// Nullable:False 
        /// </summary>
        public DateTime warehouseTime {get;set;}

        /// <summary>
        /// Desc:操作站点 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string warehouseSize {get;set;}

        /// <summary>
        /// Desc:出货类型：1（重出）2（转仓） 
        /// Default:((0)) 
        /// Nullable:False 
        /// </summary>
        public int shipmentType {get;set;}

        /// <summary>
        /// Desc:客服操作员 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string cusSer {get;set;}

        /// <summary>
        /// Desc:客服操作时间 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? cusSerTime {get;set;}

        /// <summary>
        /// Desc:重量 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? weight {get;set;}

        /// <summary>
        /// Desc:品名 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string goods {get;set;}

        /// <summary>
        /// Desc:店铺 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string shop {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 member_id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string memberName {get;set;}

        /// <summary>
        /// Desc:操作状态 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string operationStatus {get;set;}

    }
}
