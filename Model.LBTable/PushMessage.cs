using System;
using System.Linq;
using System.Text;

namespace EJETableData
{
    public class PushMessage
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 id {get;set;}

        /// <summary>
        /// Desc:超过限制的单号 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string billcode {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? CreationTime {get;set;}

        /// <summary>
        /// Desc:是否通过 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? Inspection {get;set;}

        /// <summary>
        /// Desc:错误类型 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string ErrorType {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Operation_emp {get;set;}

    }
}
