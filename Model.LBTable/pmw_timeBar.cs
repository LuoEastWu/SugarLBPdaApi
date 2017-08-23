using System;
using System.Linq;
using System.Text;

namespace EJETableData
{
    public class pmw_timeBar
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
        public string timeBarName {get;set;}

        /// <summary>
        /// Desc:仓库ID 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 houseID {get;set;}

        /// <summary>
        /// Desc:截单时间 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string cutBillTime {get;set;}

        /// <summary>
        /// Desc:到货时间 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string ArrivalGoodsTime {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:(getdate()) 
        /// Nullable:True 
        /// </summary>
        public DateTime? creationTime {get;set;}

        /// <summary>
        /// Desc:创建人 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string creationEmp {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Rem {get;set;}

    }
}
