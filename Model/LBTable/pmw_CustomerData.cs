using System;
using System.Linq;
using System.Text;

namespace Model.LBTable
{
    public class pmw_CustomerData
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public int ID {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string customerName {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string sjhm_mobile {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string email {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:(getdate()) 
        /// Nullable:False 
        /// </summary>
        public DateTime storageTime {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string contactName {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? customer_Delete {get;set;}

        /// <summary>
        /// Desc:客服 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string CusService {get;set;}

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
        public string PassW {get;set;}

        /// <summary>
        /// Desc:经验 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? experience {get;set;}

        /// <summary>
        /// Desc:等级 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? Lev {get;set;}

    }
}
