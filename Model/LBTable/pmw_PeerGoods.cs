using System;
using System.Linq;
using System.Text;

namespace Model.LBTable
{
    public class pmw_PeerGoods
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:(getdate()) 
        /// Nullable:False 
        /// </summary>
        public DateTime creationTime {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string kd_com {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string kd_billcode {get;set;}

        /// <summary>
        /// Desc:仓库ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 house_id {get;set;}

        /// <summary>
        /// Desc:重量 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Decimal Weight {get;set;}

        /// <summary>
        /// Desc:核重重量 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? nuclear_heavy {get;set;}

        /// <summary>
        /// Desc:是否核重 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? is_nuclide {get;set;}

        /// <summary>
        /// Desc:尺寸 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string size {get;set;}

        /// <summary>
        /// Desc:件数 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public int pieceAmount {get;set;}

        /// <summary>
        /// Desc:体积重 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Decimal volumeWeight {get;set;}

        /// <summary>
        /// Desc:承运商代码 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string forwarderCode {get;set;}

        /// <summary>
        /// Desc:承运商公司 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string forwarderCom {get;set;}

        /// <summary>
        /// Desc:会员ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 member_id {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string member_name {get;set;}

        /// <summary>
        /// Desc:商品名称 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string goods {get;set;}

        /// <summary>
        /// Desc:备注 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string memo {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string goodsMemo {get;set;}

        /// <summary>
        /// Desc:来源 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string source {get;set;}

        /// <summary>
        /// Desc:国家ID 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public int country_id {get;set;}

        /// <summary>
        /// Desc:货物类型 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string goodsType {get;set;}

        /// <summary>
        /// Desc:总费用 
        /// Default:((0)) 
        /// Nullable:False 
        /// </summary>
        public Decimal TotalCost {get;set;}

        /// <summary>
        /// Desc:其他费用 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public decimal? OtherFree {get;set;}

        /// <summary>
        /// Desc:代收款 
        /// Default:((0)) 
        /// Nullable:False 
        /// </summary>
        public Decimal agency_fund {get;set;}

        /// <summary>
        /// Desc:货物价值 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Decimal goodsWorth {get;set;}

        /// <summary>
        /// Desc:收件人 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string consignee {get;set;}

        /// <summary>
        /// Desc:收件人邮箱 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string consigneeEmail {get;set;}

        /// <summary>
        /// Desc:收件人电话 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string consigneePhone {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string consigneeMobile {get;set;}

        /// <summary>
        /// Desc:收件地址 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string consigneeAddress {get;set;}

        /// <summary>
        /// Desc:统编号码 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string IdentityCard {get;set;}

        /// <summary>
        /// Desc:服务方式 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public int ServicesConcerning {get;set;}

        /// <summary>
        /// Desc:付款类型 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public int paymentType {get;set;}

        /// <summary>
        /// Desc:签收人 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Signer {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Operation {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Operation_house {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? Operation_Time {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public string order_code {get;set;}

        /// <summary>
        /// Desc:时效ID 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 timeBarID {get;set;}

    }
}
