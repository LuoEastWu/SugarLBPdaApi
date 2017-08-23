using System;
using System.Linq;
using System.Text;

namespace Model.LBTable
{
    public class Forwarder
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 id {get;set;}

        /// <summary>
        /// Desc:承运商名称 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string ForwarderName {get;set;}

        /// <summary>
        /// Desc:承运商查件地址 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string ForwarderURL {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string ForwarderCode {get;set;}

        /// <summary>
        /// Desc:清关表ID关联 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 clearance_id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 country_id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? order_id {get;set;}

    }
}
