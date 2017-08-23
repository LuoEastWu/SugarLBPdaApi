using System;
using System.Linq;
using System.Text;

namespace Model.LBTable
{
    public class Pmw_MemberLVDiscount
    {
        
        /// <summary>
        /// Desc:ID 主键 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 ID {get;set;}

        /// <summary>
        /// Desc:店铺ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 Shop {get;set;}

        /// <summary>
        /// Desc:会员等级ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public int MemberLV {get;set;}

        /// <summary>
        /// Desc:显示名称 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// Desc:折扣 
        /// Default:((1)) 
        /// Nullable:False 
        /// </summary>
        public Decimal Discount {get;set;}

        /// <summary>
        /// Desc:升级金额 
        /// Default:((1000)) 
        /// Nullable:False 
        /// </summary>
        public Decimal UpMoney {get;set;}

        /// <summary>
        /// Desc:是否有效 
        /// Default:((1)) 
        /// Nullable:False 
        /// </summary>
        public int Valid {get;set;}

    }
}
