using System;
using System.Linq;
using System.Text;

namespace EJETableData
{
    public class pmw_transfer
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 id {get;set;}

        /// <summary>
        /// Desc:店铺 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string store {get;set;}

        /// <summary>
        /// Desc:单号（黑猫超峰快递清关） 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string billcode {get;set;}

        /// <summary>
        /// Desc:货物原仓库位 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string stock_area {get;set;}

        /// <summary>
        /// Desc:目的仓库 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string storehouse {get;set;}

        /// <summary>
        /// Desc:创建时间 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? CreationTime {get;set;}

        /// <summary>
        /// Desc:客服操作人 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Airlines_emp {get;set;}

        /// <summary>
        /// Desc:转出仓 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string RollOutHouse {get;set;}

        /// <summary>
        /// Desc:承运单号 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string carrierNumber {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? is_confirm {get;set;}

        /// <summary>
        /// Desc:仓库操作员 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string House_emp {get;set;}

        /// <summary>
        /// Desc:仓库确认时间 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? HouseConfirmTime {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:((0)) 
        /// Nullable:False 
        /// </summary>
        public Decimal PutStorage_weight {get;set;}

        /// <summary>
        /// Desc:收货入库时间 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? PutStorageTime {get;set;}

        /// <summary>
        /// Desc:收货入库人 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string PutStorage_emp {get;set;}

        /// <summary>
        /// Desc:转仓类型 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string transferType {get;set;}

    }
}
