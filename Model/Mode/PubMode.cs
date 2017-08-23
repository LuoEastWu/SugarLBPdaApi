using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Mode
{
    /// <summary>
    /// 公开模型
    /// </summary>
    public class PubMode
    {
        /// <summary>
        /// 客户相关接口
        /// </summary>
        public class Client
        {
            /// <summary>
            /// 客户信息
            /// </summary>
            public class ClientInfo
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID { get; set; }
                /// <summary>
                /// 名称
                /// </summary>
                public String Name { get; set; }
                /// <summary>
                /// 代码
                /// </summary>
                public String Code { get; set; }
                /// <summary>
                /// 站点编号
                /// </summary>
                public int Site { get; set; }
                /// <summary>
                /// 站点名称
                /// </summary>
                public String SiteName { get; set; }
                /// <summary>
                /// 业务员编号
                /// </summary>
                public int Presonnel { get; set; }
                /// <summary>
                /// 业务员名称
                /// </summary>
                public String PresonnelName { get; set; }
                /// <summary>
                /// 登陆账号
                /// </summary>
                public String Uid { get; set; }
                /// <summary>
                /// 登陆密码
                /// </summary>
                public String Pwd { get; set; }
                /// <summary>
                /// 手机
                /// </summary>
                public String Phone { get; set; }
                /// <summary>
                /// 创建时间
                /// </summary>
                public DateTime CreateTime { get; set; }
                /// <summary>
                /// 是否有效用户
                /// </summary>
                public int Valid { get; set; }
            }
            /// <summary>
            /// 客户地址信息
            /// </summary>
            public class AddressInfo
            {
                /// <summary>
                /// 地址编号
                /// </summary>
                public int ID { get; set; }
                /// <summary>
                /// 站点编号
                /// </summary>
                public int Site { get; set; }
                /// <summary>
                /// 站点名称
                /// </summary>
                public String SiteName { get; set; }
                /// <summary>
                /// 客户编号
                /// </summary>
                public int Client { get; set; }
                /// <summary>
                /// 客户名称
                /// </summary>
                public String ClientName { get; set; }
                /// <summary>
                /// 地址类型 1 发货地址 2 收获地址 0 不限
                /// </summary>
                public int Type { get; set; }
                /// <summary>
                /// 联系人
                /// </summary>
                public String Person { get; set; }
                /// <summary>
                /// 电话
                /// </summary>
                public String Phone { get; set; }
                /// <summary>
                /// 省
                /// </summary>
                public String Province { get; set; }
                /// <summary>
                /// 市
                /// </summary>
                public String City { get; set; }
                /// <summary>
                /// 区
                /// </summary>
                public String Area { get; set; }
                /// <summary>
                /// 详细地址
                /// </summary>
                public String Address { get; set; }
                /// <summary>
                /// 默认地址ID
                /// </summary>
                public int DefID { get; set; }
            }
        }
        /// <summary>
        /// 业务员相关接口
        /// </summary>
        public class Personnel
        {
            /// <summary>
            /// 业务员信息
            /// </summary>
            public class PersonnelInfo
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID { get; set; }
                /// <summary>
                /// 名称
                /// </summary>
                public String Name { get; set; }
                /// <summary>
                /// 站点编号
                /// </summary>
                public int Site { get; set; }
                /// <summary>
                /// 站点名称
                /// </summary>
                public String SiteName { get; set; }
                /// <summary>
                /// 账号
                /// </summary>
                public String Uid { get; set; }
                /// <summary>
                /// 密码
                /// </summary>
                public String Pwd { get; set; }
                /// <summary>
                /// 电话
                /// </summary>
                public String Phone { get; set; }
                /// <summary>
                /// 0 业务员  1 管理员
                /// </summary>
                public int Type { get; set; }
                /// <summary>
                /// 是否有效
                /// </summary>
                public int Valid { get; set; }
            }
        }
        /// <summary>
        /// 站点相关接口
        /// </summary>
        public class Site
        {
            /// <summary>
            /// 站点信息
            /// </summary>
            public class SiteInfo
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID { get; set; }
                /// <summary>
                /// 站点名称
                /// </summary>
                public String Name { get; set; }
                /// <summary>
                /// 站点标识
                /// </summary>
                public String Code { get; set; }
                /// <summary>
                /// 快递公司ID
                /// </summary>
                public int Express { get; set; }
                /// <summary>
                /// 快递公司名称
                /// </summary>
                public String ExpressName { get; set; }
                /// <summary>
                /// 联系人
                /// </summary>
                public String Person { get; set; }
                /// <summary>
                /// 联系手机
                /// </summary>
                public String Phone { get; set; }
                /// <summary>
                /// 联系电话
                /// </summary>
                public String Tel { get; set; }
                /// <summary>
                /// 联系地址
                /// </summary>
                public String Address { get; set; }
                /// <summary>
                /// 短信数量
                /// </summary>
                public int SmsCount { get; set; }
                /// <summary>
                /// 到期时间
                /// </summary>
                public String EndTime { get; set; }
            }
        }
        /// <summary>
        /// 订单相关接口
        /// </summary>
        public class Order
        {
            /// <summary>
            /// 订单明细
            /// </summary>
            public class OrderInfo
            {
                /// <summary>
                /// 订单ID
                /// </summary>
                public int ID { get; set; }
                /// <summary>
                /// 快递单号
                /// </summary>
                public String OrderCode { get; set; }
                /// <summary>
                /// 订单时间
                /// </summary>
                public DateTime OrderTime { get; set; }
                /// <summary>
                /// 站点编号
                /// </summary>
                public int Site { get; set; }
                /// <summary>
                /// 站点名称
                /// </summary>
                public String SiteName { get; set; }
                /// <summary>
                /// 会员编号
                /// </summary>
                public int Client { get; set; }
                /// <summary>
                /// 会员名称
                /// </summary>
                public String ClientName { get; set; }
                /// <summary>
                /// 寄件人
                /// </summary>
                public String Senter { get; set; }
                /// <summary>
                /// 寄件手机
                /// </summary>
                public String SentPhone { get; set; }
                /// <summary>
                /// 寄件电话
                /// </summary>
                public String SentTel { get; set; }
                /// <summary>
                /// 寄件省
                /// </summary>
                public String SentProvince { get; set; }
                /// <summary>
                /// 寄件市
                /// </summary>
                public String SentCity { get; set; }
                /// <summary>
                /// 寄件区
                /// </summary>
                public String SentArea { get; set; }
                /// <summary>
                /// 寄件地址
                /// </summary>
                public String SentAddress { get; set; }
                /// <summary>
                /// 收件人
                /// </summary>
                public String Signer { get; set; }
                /// <summary>
                /// 收件手机
                /// </summary>
                public String SignPhone { get; set; }
                /// <summary>
                /// 收件电话
                /// </summary>
                public String SignTel { get; set; }
                /// <summary>
                /// 收件省
                /// </summary>
                public String SignProvince { get; set; }
                /// <summary>
                /// 收件市
                /// </summary>
                public String SignCity { get; set; }
                /// <summary>
                /// 收件区域
                /// </summary>
                public String SignArea { get; set; }
                /// <summary>
                /// 收件地址
                /// </summary>
                public String SignAddress { get; set; }
                /// <summary>
                /// 商品名称
                /// </summary>
                public String GoodsName { get; set; }
                /// <summary>
                /// 商品类型
                /// </summary>
                public String GoodsType { get; set; }
                /// <summary>
                /// 货物金额
                /// </summary>
                public Decimal GoodsMoney { get; set; }
                /// <summary>
                /// 快件类型
                /// </summary>
                public String FastType { get; set; }
                /// <summary>
                /// 支付状态 0 未支付  1 已支付
                /// </summary>
                public int PayState { get; set; }
                /// <summary>
                /// 支付方式 0 现金 1 支付宝 2 微信 3 刷卡 4 积分 5 其他
                /// </summary>
                public int PayType { get; set; }
                /// <summary>
                /// 运费
                /// </summary>
                public Decimal Free { get; set; }
                /// <summary>
                /// 业务员ID
                /// </summary>
                public int Personnel { get; set; }
                /// <summary>
                /// 业务员名称
                /// </summary>
                public String PersonnelName { get; set; }
                /// <summary>
                /// 代收货款
                /// </summary>
                public Decimal GetMoney { get; set; }
                /// <summary>
                /// 是否收件人付款 0 寄付 1 到付
                /// </summary>
                public int IsSignPay { get; set; }
                /// <summary>
                /// 是否短信通知 0 不通知 1 通知
                /// </summary>
                public int IsSms { get; set; }
                /// <summary>
                /// 备注
                /// </summary>
                public String Rem { get; set; }
                /// <summary>
                /// 订单状态 0 待处理 1 已分配 2 已收件 3 已签收 4 异常  5 其他
                /// </summary>
                public int State { get; set; }
            }
        }
        /// <summary>
        /// 基础信息相关接口
        /// </summary>
        public class BaseInfo
        {
            /// <summary>
            /// 菜单信息
            /// </summary>
            public class RoleInfo
            {
                /// <summary>
                /// 菜单编号
                /// </summary>
                [ModeAttribute(Rem = "菜单编号", IsNull = false)]
                public int ID { get; set; }
                /// <summary>
                /// 菜单名称
                /// </summary>
                [ModeAttribute(Rem = "菜单名称", IsNull = false)]
                public String Name { get; set; }
                /// <summary>
                /// 菜单父菜单
                /// </summary>
                [ModeAttribute(Rem = "菜单父菜单", IsNull = false)]
                public int Tid { get; set; }
                /// <summary>
                /// 菜单排序
                /// </summary>
                [ModeAttribute(Rem = "菜单排序", IsNull = false)]
                public int Sort { get; set; }
                /// <summary>
                /// 菜单链接
                /// </summary>
                [ModeAttribute(Rem = "菜单链接", IsNull = false)]
                public String Link { get; set; }
                /// <summary>
                /// 是否可见
                /// </summary>
                [ModeAttribute(Rem = "是否可见", IsNull = false)]
                public int Valid { get; set; }
            }
            /// <summary>
            /// 快递公司信息
            /// </summary>
            public class ExpressInfo
            {
                /// <summary>
                /// ID
                /// </summary>
                public int ID { get; set; }
                /// <summary>
                /// 名称
                /// </summary>
                public String Name { get; set; }
                /// <summary>
                /// 标识
                /// </summary>
                public String Code { get; set; }
            }
            /// <summary>
            /// 短信信息
            /// </summary>
            public class SmsInfo
            {
                /// <summary>
                /// 编号
                /// </summary>
                public int ID { get; set; }
                /// <summary>
                /// 手机
                /// </summary>
                public String Phone { get; set; }
                /// <summary>
                /// 类型
                /// </summary>
                public int Type { get; set; }
                /// <summary>
                /// 内容
                /// </summary>
                public String Sms { get; set; }
                /// <summary>
                /// 状态
                /// </summary>
                public int State { get; set; }
                /// <summary>
                /// 发送时间
                /// </summary>
                public String SendTime { get; set; }
                /// <summary>
                /// 创建时间
                /// </summary>
                public String CreateTime { get; set; }
                /// <summary>
                /// 发送编号
                /// </summary>
                public String SendNo { get; set; }
            }
        }
        /// <summary>
        /// 其他接口
        /// </summary>
        public class Entity
        {
            /// <summary>
            /// 微信消息格式
            /// </summary>
            public class MbMsgObject
            {
                /// <summary>
                /// 内容
                /// </summary>
                public String value { get; set; }
                /// <summary>
                /// 颜色
                /// </summary>
                public String color { get; set; }
            }
        }
    }
}