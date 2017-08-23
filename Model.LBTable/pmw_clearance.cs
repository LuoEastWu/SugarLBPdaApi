using System;
using System.Linq;
using System.Text;

namespace EJETableData
{
    public class pmw_clearance
    {
        
        /// <summary>
        /// Desc:清关公司编号 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 clearance_id {get;set;}

        /// <summary>
        /// Desc:清关公司 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string clearance_name {get;set;}

        /// <summary>
        /// Desc:清关公司代码 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string clearance_code {get;set;}

        /// <summary>
        /// Desc:排序 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? sort_id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string ShortCode {get;set;}

    }
}
