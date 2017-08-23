using System;
using System.Linq;
using System.Text;

namespace Model.LBTable
{
    public class TaoBaoInfo
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 ID {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:((1)) 
        /// Nullable:True 
        /// </summary>
        public int? Level {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Admin {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Url {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:(getdate()) 
        /// Nullable:True 
        /// </summary>
        public DateTime? CreateTime {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:((1)) 
        /// Nullable:True 
        /// </summary>
        public int? Valid {get;set;}

        /// <summary>
        /// Desc:淘宝旺旺 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string ITWAVE {get;set;}

        /// <summary>
        /// Desc:店铺地址 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string StoreAddress {get;set;}

        /// <summary>
        /// Desc:联系电话 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string phone {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string QQ {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? CusID {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? e_id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? e_id2 {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string PayURL {get;set;}

    }
}
