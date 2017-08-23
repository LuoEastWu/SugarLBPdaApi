using System;
using System.Linq;
using System.Text;

namespace EJETableData
{
    public class GoodsCatalog
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string goodsName {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string goodsType {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? goodsMoney {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 exp_prot {get;set;}

        /// <summary>
        /// Desc:简码 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string briefCode {get;set;}

        /// <summary>
        /// Desc:优先级别 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? priority {get;set;}

    }
}
