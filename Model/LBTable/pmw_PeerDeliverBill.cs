using System;
using System.Linq;
using System.Text;

namespace Model.LBTable
{
    public class pmw_PeerDeliverBill
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
        /// Nullable:False 
        /// </summary>
        public string CusName {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string billcode {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:(getdate()) 
        /// Nullable:False 
        /// </summary>
        public DateTime createTime {get;set;}

        /// <summary>
        /// Desc:是否到达 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? is_arrive {get;set;}

        /// <summary>
        /// Desc:扫描人 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string scan_emp {get;set;}

        /// <summary>
        /// Desc:扫描站点 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string scan_site {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? arrive_time {get;set;}

    }
}
