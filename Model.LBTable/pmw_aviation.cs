using System;
using System.Linq;
using System.Text;

namespace EJETableData
{
    public class pmw_aviation
    {
        
        /// <summary>
        /// Desc:航空公司编号 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 aviation_Id {get;set;}

        /// <summary>
        /// Desc:航空公司 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string aviation_name {get;set;}

        /// <summary>
        /// Desc:航空公司代码 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string aviation_code {get;set;}

        /// <summary>
        /// Desc:排序 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? sort_id {get;set;}

    }
}
