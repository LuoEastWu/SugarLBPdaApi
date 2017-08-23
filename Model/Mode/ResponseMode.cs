using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Mode
{
    /// <summary>
    /// 服务器返回模型类
    /// </summary>
    public class ResponseMode
    {
        /// <summary>
        /// 客户相关接口
        /// </summary>
        public class Client
        {
            /// <summary>
            /// 登陆返回信息
            /// </summary>
            public class Login : PubMode.Client.ClientInfo
            {

            }
            /// <summary>
            /// 查询客户信息接口返回信息
            /// </summary>
            public class Query
            {
                /// <summary>
                /// 客户信息集合
                /// </summary>
                public List<PubMode.Client.ClientInfo> ClientInfo { get; set; }
            }
            /// <summary>
            /// 查询客户地址接口返回信息
            /// </summary>
            public class QueryAddress
            {
                /// <summary>
                /// 地址集合
                /// </summary>
                public List<PubMode.Client.AddressInfo> Client_AddressInfo { get; set; }
            }
        }
        /// <summary>
        /// 业务员相关接口
        /// </summary>
        public class Personnel
        {
            /// <summary>
            /// 登陆返回信息
            /// </summary>
            public class Login : PubMode.Personnel.PersonnelInfo
            {

            }
            /// <summary>
            /// 查询业务员信息接口返回信息
            /// </summary>
            public class Query
            {
                /// <summary>
                /// 业务员信息集合
                /// </summary>
                public List<PubMode.Personnel.PersonnelInfo> PersonnelInfo { get; set; }
            }
        }
        /// <summary>
        /// 站点相关接口
        /// </summary>
        public class Site
        {
            /// <summary>
            /// 查询站点信息
            /// </summary>
            public class Query : PubMode.Site.SiteInfo
            {

            }
        }
        /// <summary>
        /// 订单相关接口
        /// </summary>
        public class Order
        {
            /// <summary>
            /// 订单查询接口返回信息
            /// </summary>
            public class Query
            {
                /// <summary>
                /// 订单数据集合
                /// </summary>
                public List<PubMode.Order.OrderInfo> OrderInfo { get; set; }
            }
        }
        /// <summary>
        /// 基础信息相关接口
        /// </summary>
        public class BaseInfo
        {
            /// <summary>
            /// 获取快递公司接口返回信息
            /// </summary>
            public class GetExpress
            {
                /// <summary>
                /// 快递公司信息集合
                /// </summary>
                public List<PubMode.BaseInfo.ExpressInfo> ExpressInfo { get; set; }
            }
            /// <summary>
            /// 查询短信发送记录接口返回模型
            /// </summary>
            public class Query_SmsLog
            {
                /// <summary>
                /// 短信记录集合
                /// </summary>
                public List<PubMode.BaseInfo.SmsInfo> SmsInfo { get; set; }
            }
            /// <summary>
            /// 获取菜单接口
            /// </summary>
            public class GetMeun
            {
                /// <summary>
                /// 菜单信息
                /// </summary>
                public List<PubMode.BaseInfo.RoleInfo> RoleInfo { get; set; }
            }
        }
        /// <summary>
        /// 其他接口
        /// </summary>
        public class Entity
        {
            /// <summary>
            /// 获取支付配置
            /// </summary>
            [ModeClassAttribute("支付配置信息")]
            public class GetPayConfig
            {
                /// <summary>
                /// 商户支付密钥，参考开户邮件设置（必须配置）
                /// </summary>
                [ModeAttribute(Rem = "微信商户支付密钥", IsNull = false)]
                public String Wx_Key { get; set; }
                /// <summary>
                /// 绑定支付的APPID（必须配置）
                /// </summary>
                [ModeAttribute(Rem = "微信绑定支付的APPID", IsNull = false)]
                public String Wx_AppID { get; set; }
                /// <summary>
                /// 商户号（必须配置）
                /// </summary>
                [ModeAttribute(Rem = "微信商户号", IsNull = false)]
                public String Wx_MchID { get; set; }
                /// <summary>
                /// 公众帐号secert（仅JSAPI支付的时候需要配置）
                /// </summary>
                [ModeAttribute(Rem = "微信公众帐号secert", IsNull = false)]
                public String Wx_AppSecret { get; set; }
                /// <summary>
                /// 合作身份者ID，以2088开头由16位纯数字组成的字符串
                /// </summary>
                [ModeAttribute(Rem = "支付宝合作身份者ID", IsNull = false)]
                public String Ali_Partner { get; set; }
                /// <summary>
                /// 交易安全检验码，由数字和字母组成的32位字符串
                /// </summary>
                [ModeAttribute(Rem = "支付宝交易安全检验码", IsNull = false)]
                public String Ali_Key { get; set; }
                /// <summary>
                /// 卖家支付宝账号
                /// </summary>
                [ModeAttribute(Rem = "支付宝卖家支付宝账号", IsNull = false)]
                public String Ali_Selleer_Email { get; set; }
                /// <summary>
                /// 支付宝同步回调地址
                /// </summary>
                [ModeAttribute(Rem = "支付宝同步回调地址", IsNull = true)]
                public String Ali_RetrunUrl { get; set; }
            }
            /// <summary>
            /// 支付成功返回回掉模型
            /// </summary>
            [ModeClassAttribute("支付成功返回信息")]
            public class PayedResponse
            {
                /// <summary>
                /// 请求数据
                /// </summary>
                [ModeAttribute(Rem = "请求数据", IsNull = false)]
                public RequestMode.Entity.PayRequest PayRequest { get; set; }
                /// <summary>
                /// 支付编号
                /// </summary>
                [ModeAttribute(Rem = "支付编号", IsNull = false)]
                public String PayNo { get; set; }
                /// <summary>
                /// 支付金额
                /// </summary>
                [ModeAttribute(Rem = "支付金额", IsNull = false)]
                public Decimal PayMoney { get; set; }
                /// <summary>
                /// 通知类型 0 即时到账 1 退款
                /// </summary>
                [ModeAttribute(Rem = "通知类型 0 即时到账 1 退款", IsNull = false)]
                public Int64 IpnType { get; set; }
            }
            /// <summary>
            /// 微信JsApo支付申请返回模型
            /// </summary>
            [ModeClassAttribute("微信JsApo支付申请返回信息")]
            public class WxJsApiPayRetrun
            {
                /// <summary>
                /// 用户标识 OpenID
                /// </summary>
                [ModeAttribute(Rem = "用户标识 OpenID", IsNull = false)]
                public String OpenID { get; set; }
                /// <summary>
                /// 微信标识
                /// </summary>
                [ModeAttribute(Rem = "微信标识", IsNull = false)]
                public String AppID { get; set; }
                /// <summary>
                /// 生成签名的时间戳
                /// </summary>
                [ModeAttribute(Rem = "生成签名的时间戳", IsNull = false)]
                public String timeStamp { get; set; }
                /// <summary>
                /// 生成签名的随机串
                /// </summary>
                [ModeAttribute(Rem = "生成签名的随机串", IsNull = false)]
                public String nonceStr { get; set; }
                /// <summary>
                /// 统一支付接口返回的prepay_id参数值
                /// </summary>
                [ModeAttribute(Rem = "统一支付接口返回的prepay_id参数值", IsNull = false)]
                public String prepayId { get; set; }
                /// <summary>
                /// 支付签名
                /// </summary>
                [ModeAttribute(Rem = "支付签名", IsNull = false)]
                public String paySign { get; set; }
                /// <summary>
                /// 错误信息
                /// </summary>
                [ModeAttribute(Rem = "错误信息", IsNull = true)]
                public String Msg { get; set; }
            }
        }
    }
}
