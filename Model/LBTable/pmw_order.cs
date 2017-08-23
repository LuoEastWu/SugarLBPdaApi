using SqlSugar;
using System;
using System.Linq;
using System.Text;

namespace Model.LBTable
{
    public class pmw_order
    {
        
        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:False 
        /// </summary>
        public Int64 id {get;set;}

        /// <summary>
        /// Desc:付款码 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string order_code {get;set;}

        /// <summary>
        /// Desc:创建订单时间 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public DateTime? order_time {get;set;}

        /// <summary>
        /// Desc:客户名称 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string cus {get;set;}

        /// <summary>
        /// Desc:计费重量 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public decimal? z_weight {get;set;}

        /// <summary>
        /// Desc:地址编号 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public int? trans_type {get;set;}

        /// <summary>
        /// Desc:使用积分 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public int? use_integral {get;set;}

        /// <summary>
        /// Desc:收件人 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string cname {get;set;}

        /// <summary>
        /// Desc:电话号码 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string mobile {get;set;}

        /// <summary>
        /// Desc:电话号码2 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string mobile2 {get;set;}

        /// <summary>
        /// Desc:收件地址 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string address {get;set;}

        /// <summary>
        /// Desc:是否支付 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? is_payed {get;set;}

        /// <summary>
        /// Desc:是否打单 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? is_sented {get;set;}

        /// <summary>
        /// Desc:打单人 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string sent_emp {get;set;}

        /// <summary>
        /// Desc:打单时间 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public DateTime? sent_time {get;set;}

        /// <summary>
        /// Desc:运单号（打单号码） 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string sent_kd_billcode {get;set;}

        /// <summary>
        /// Desc:发货快递公司（打单选取发货快递） 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string sent_kd_com {get;set;}

        /// <summary>
        /// Desc:仓库编号 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public Int64 wavehouse_id {get;set;}

        /// <summary>
        /// Desc:订单备注 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string order_memo {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public decimal? z_weight2 {get;set;}

        /// <summary>
        /// Desc:是否下架 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public int? is_outplace {get;set;}

        /// <summary>
        /// Desc:下加时间 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public DateTime? outplace_time {get;set;}

        /// <summary>
        /// Desc:下架人 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string outplace_emp {get;set;}

        /// <summary>
        /// Desc:是否发货 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public int? is_senttohk {get;set;}

        /// <summary>
        /// Desc:发货时间 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public DateTime? senttohk_time {get;set;}

        /// <summary>
        /// Desc:发货人 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string senttohk_emp {get;set;}

        /// <summary>
        /// Desc:打单时判断（是否不符合选择规则） 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
       [SugarColumn(ColumnName = "lock",IsIgnore = true)]
        public int? _lock {get;set;}

        /// <summary>
        /// Desc:锁单人 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public string lock_man {get;set;}

        /// <summary>
        /// Desc:锁单时间 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public DateTime? lock_time {get;set;}

        /// <summary>
        /// Desc:来源 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string come {get;set;}

        /// <summary>
        /// Desc:服务方式 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? service_type {get;set;}

        /// <summary>
        /// Desc:付款类型 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? pay_type {get;set;}

        /// <summary>
        /// Desc:会员ID 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 member_id {get;set;}

        /// <summary>
        /// Desc:客户是否签收 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? is_cus_qs {get;set;}

        /// <summary>
        /// Desc:淘宝订单ID 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string taobao_order_id {get;set;}

        /// <summary>
        /// Desc:EDB 订单ID 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Tid {get;set;}

        /// <summary>
        /// Desc:总费用 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public decimal? z_fare {get;set;}

        /// <summary>
        /// Desc:实际运费 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public decimal? free {get;set;}

        /// <summary>
        /// Desc:目的国家到付 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public decimal? country_free {get;set;}

        /// <summary>
        /// Desc:超长费 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public decimal? longFee {get;set;}

        /// <summary>
        /// Desc:地址附加费 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public decimal? add_free {get;set;}

        /// <summary>
        /// Desc:单号附加费 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public decimal? surchargeFee {get;set;}

        /// <summary>
        /// Desc:其他费用 
        /// Default:(NULL) 
        /// Nullable:True 
        /// </summary>
        public decimal? other_fare {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public decimal? Jf_Money {get;set;}

        /// <summary>
        /// Desc:保价金额 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public decimal? bj_money {get;set;}

        /// <summary>
        /// Desc:保价手续费 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public decimal? bj_sxfei {get;set;}

        /// <summary>
        /// Desc:代收货款 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? agencyFund {get;set;}

        /// <summary>
        /// Desc:带收货款手续费 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? dshk_sxf {get;set;}

        /// <summary>
        /// Desc:到付手续费 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? df_sxf {get;set;}

        /// <summary>
        /// Desc:包税费用 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? Bs_Free {get;set;}

        /// <summary>
        /// Desc:原始费用 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? old_Free {get;set;}

        /// <summary>
        /// Desc:优惠金额 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public decimal? yh_Free {get;set;}

        /// <summary>
        /// Desc:优惠说明 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string yh_Rem {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 goods_type {get;set;}

        /// <summary>
        /// Desc:订单里的快递单ID集合 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string billcode_list {get;set;}

        /// <summary>
        /// Desc:集运卷ID 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 volume_id {get;set;}

        /// <summary>
        /// Desc:包数 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? bag_num {get;set;}

        /// <summary>
        /// Desc:国家id 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? country_id {get;set;}

        /// <summary>
        /// Desc:异常状态 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Boolean? Abnormal {get;set;}

        /// <summary>
        /// Desc:清关单号 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string CCnumber {get;set;}

        /// <summary>
        /// Desc:是否已打航空包 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? is_AriPack {get;set;}

        /// <summary>
        /// Desc:Order类型（是否同行货导入） 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string OrderType {get;set;}

        /// <summary>
        /// Desc:客户代码 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string CForHMCusCode {get;set;}

        /// <summary>
        /// Desc:发货类型 
        /// Default:('黑猫') 
        /// Nullable:False 
        /// </summary>
        public string cforhmType {get;set;}

        /// <summary>
        /// Desc:是否即到即走 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? immediately {get;set;}

        /// <summary>
        /// Desc:订单表打航空包标识 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string order_AriCode {get;set;}

        /// <summary>
        /// Desc:是否合重 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? is_confirm_weight {get;set;}

        /// <summary>
        /// Desc:加急件 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? is_urgent {get;set;}

        /// <summary>
        /// Desc:是否推送（淘宝） 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? Is_Push {get;set;}

        /// <summary>
        /// Desc:时效ID 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 timeBarID {get;set;}

        /// <summary>
        /// Desc:订单货物类型备注 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string OrderGoodsNotes {get;set;}

        /// <summary>
        /// Desc:收件人统编 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string RecipientCode {get;set;}

        /// <summary>
        /// Desc:是否已分配任务 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? is_task {get;set;}

        /// <summary>
        /// Desc:任务分配给的人 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string taskName {get;set;}

        /// <summary>
        /// Desc:快递单表商品名次集合 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string BillcodeGoods {get;set;}

        /// <summary>
        /// Desc:审单人 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string DoubleEmp {get;set;}

        /// <summary>
        /// Desc:审单时间 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? DoubleTime {get;set;}

        /// <summary>
        /// Desc:审单 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? DoubleCheck {get;set;}

        /// <summary>
        /// Desc:分包数量 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? subpackageNum {get;set;}

        /// <summary>
        /// Desc:分包 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public int? subpackage {get;set;}

        /// <summary>
        /// Desc:客户代码集合 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string customerCode {get;set;}

        /// <summary>
        /// Desc:收件人统编 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string unifiedCompile {get;set;}

        /// <summary>
        /// Desc:是否包税 
        /// Default:((0)) 
        /// Nullable:True 
        /// </summary>
        public int? is_tax {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Int64 shopid {get;set;}

        /// <summary>
        /// Desc:店铺 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Shop {get;set;}

        /// <summary>
        /// Desc:是否正在操作 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public Boolean? Is_Operator {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string Operator {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? OperatorTime {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string OperatorMac {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string LogMacIP {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string LogMacAddres {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string LogName {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public DateTime? LogTime {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:- 
        /// Nullable:True 
        /// </summary>
        public string goodsType {get;set;}

        /// <summary>
        /// Desc:- 
        /// Default:((0)) 
        /// Nullable:False 
        /// </summary>
        public Decimal Free_Weight {get;set;}

    }
}
