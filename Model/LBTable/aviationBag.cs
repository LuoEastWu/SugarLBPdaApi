using System;
using System.Linq;
using System.Text;

namespace Model.LBTable
{
    public class aviationBag
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 id {get;set;}

        /// <summary>
        /// Desc:清关单号 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string clearCode {get;set;}

        /// <summary>
        /// Desc:发货重量 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? sendWeight {get;set;}

        /// <summary>
        /// Desc:实重 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? netWeight {get;set;}

        /// <summary>
        /// Desc:转运单件数 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? TurnNumber {get;set;}

        /// <summary>
        /// Desc:包数 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? bagNumber {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 airID {get;set;}

        /// <summary>
        /// Desc:标记 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string aviationMark {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:(getdate()) 
        /// Nullable:True 
        /// </summary>
        public DateTime? createTime {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string createEmployee {get;set;}

    }
}
