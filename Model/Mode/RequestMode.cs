using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Mode
{
    /// <summary>
    /// 客户端请求模型类
    /// </summary>
    public class RequestMode
    {
        /// <summary>
        /// 客户相关接口
        /// </summary>
        public class Client
        {
            /// <summary>
            /// 登陆请求模型
            /// </summary>
            [ModeClassAttribute("客户登陆请求")]
            public class Login
            {
                /// <summary>
                /// 归属网点
                /// </summary>
                [ModeAttribute(Rem = "归属网点", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 登陆账号
                /// </summary>
                [ModeAttribute(Rem = "登陆账号", IsNull = false)]
                public String Uid { get; set; }
                /// <summary>
                /// 登陆密码
                /// </summary>
                [ModeAttribute(Rem = "登陆密码", IsNull = false)]
                public String Pwd { get; set; }
                /// <summary>
                /// 用户标识
                /// </summary>
                [ModeAttribute(Rem = "用户标识", IsNull = true)]
                public String Code { get; set; }
            }
            /// <summary>
            /// 注册请求模型
            /// </summary>
            [ModeClassAttribute("客户注册请求")]
            public class Register
            {
                /// <summary>
                /// 名称
                /// </summary>
                [ModeAttribute(Rem = "名称", IsNull = false)]
                public String Name { get; set; }
                /// <summary>
                /// 代码
                /// </summary>
                [ModeAttribute(Rem = "代码", IsNull = true)]
                public String Code { get; set; }
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 登陆账号
                /// </summary>
                [ModeAttribute(Rem = "登陆账号", IsNull = false)]
                public String Uid { get; set; }
                /// <summary>
                /// 登陆密码
                /// </summary>
                [ModeAttribute(Rem = "登陆密码", IsNull = false)]
                public String Pwd { get; set; }
                /// <summary>
                /// 手机
                /// </summary>
                [ModeAttribute(Rem = "手机", IsNull = false)]
                public String Phone { get; set; }
            }
            /// <summary>
            /// 修改密码接口模型
            /// </summary>
            [ModeClassAttribute("客户修改密码")]
            public class UpdataPwd
            {
                /// <summary>
                /// 网点编号
                /// </summary>
                [ModeAttribute(Rem = "网点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 用户编号 如 客户编号  业务员编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = false)]
                public int ID { get; set; }
                /// <summary>
                /// 原始密码
                /// </summary>
                [ModeAttribute(Rem = "原始密码", IsNull = false)]
                public String OldPassWord { get; set; }
                /// <summary>
                /// 新密码
                /// </summary>
                [ModeAttribute(Rem = "新密码", IsNull = false)]
                public String PassWord { get; set; }
            }
            /// <summary>
            /// 客户重置密码
            /// </summary>
            [ModeClassAttribute("客户重置密码")]
            public class ResettingPwd
            {
                /// <summary>
                /// 网点编号
                /// </summary>
                [ModeAttribute(Rem = "网点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 用户编号 如 客户编号  业务员编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = false)]
                public int ID { get; set; }
                /// <summary>
                /// 新密码
                /// </summary>
                [ModeAttribute(Rem = "新密码", IsNull = false)]
                public String PassWord { get; set; }
            }
            /// <summary>
            /// 修改客户资料
            /// </summary>
            [ModeClassAttribute("客户修改资料")]
            public class UpdateInfo
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 客户编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = false)]
                public int Client { get; set; }
                /// <summary>
                /// 客户名称
                /// </summary>
                [ModeAttribute(Rem = "客户名称", IsNull = false)]
                public String Name { get; set; }
                /// <summary>
                /// 客户手机
                /// </summary>
                [ModeAttribute(Rem = "客户手机", IsNull = false)]
                public String Phone { get; set; }
            }
            /// <summary>
            /// 会员查询接口情况模型
            /// </summary>
            [ModeClassAttribute("客户查询")]
            public class Query
            {
                /// <summary>
                /// 网点编号
                /// </summary>
                [ModeAttribute(Rem = "网点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 会员编号
                /// </summary>
                [ModeAttribute(Rem = "会员编号", IsNull = true)]
                public int Client { get; set; }
                /// <summary>
                /// 专属业务员
                /// </summary>
                [ModeAttribute(Rem = "专属业务员", IsNull = true)]
                public int Personnel { get; set; }
                /// <summary>
                /// 会员名称
                /// </summary>
                [ModeAttribute(Rem = "会员名称", IsNull = true)]
                public String Name { get; set; }
                /// <summary>
                /// 手机
                /// </summary>
                [ModeAttribute(Rem = "手机", IsNull = true)]
                public String Phone { get; set; }
                /// <summary>
                /// 登陆账号
                /// </summary>
                [ModeAttribute(Rem = "登陆账号", IsNull = true)]
                public String Uid { get; set; }
                /// <summary>
                /// 注册起始时间
                /// </summary>
                [ModeAttribute(Rem = "注册起始时间", IsNull = true)]
                public String StartTime { get; set; }
                /// <summary>
                /// 注册截止时间
                /// </summary>
                [ModeAttribute(Rem = "注册截止时间", IsNull = true)]
                public String EndTime { get; set; }
            }
            /// <summary>
            /// 查询客户地址接口请求模型
            /// </summary>
            [ModeClassAttribute("查询客户地址")]
            public class QueryAddress
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 客户编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = false)]
                public int Client { get; set; }
                /// <summary>
                /// 地址ID
                /// </summary>
                [ModeAttribute(Rem = "地址ID", IsNull = true)]
                public int ID { get; set; }
                /// <summary>
                /// 是否默认
                /// </summary>
                [ModeAttribute(Rem = "是否默认", IsNull = true)]
                public Boolean IsDef { get; set; }
                /// <summary>
                /// 地址类型 1 发货地址 2 收获地址 0 不限
                /// </summary>
                [ModeAttribute(Rem = "地址类型 1 发货地址 2 收获地址 0 不限", IsNull = true)]
                public int Type { get; set; }
            }
            /// <summary>
            /// 添加客户地址请求模型
            /// </summary>
            [ModeClassAttribute("添加客户地址")]
            public class AddAddress
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 客户编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = false)]
                public int Client { get; set; }
                /// <summary>
                /// 地址类型 1 发货地址 2 收获地址 0 不限
                /// </summary>
                [ModeAttribute(Rem = "地址类型 1 发货地址 2 收获地址", IsNull = false)]
                public int Type { get; set; }
                /// <summary>
                /// 联系人
                /// </summary>
                [ModeAttribute(Rem = "联系人", IsNull = false)]
                public String Person { get; set; }
                /// <summary>
                /// 电话
                /// </summary>
                [ModeAttribute(Rem = "电话", IsNull = false)]
                public String Phone { get; set; }
                /// <summary>
                /// 省
                /// </summary>
                [ModeAttribute(Rem = "省", IsNull = false)]
                public String Province { get; set; }
                /// <summary>
                /// 市
                /// </summary>
                [ModeAttribute(Rem = "市", IsNull = false)]
                public String City { get; set; }
                /// <summary>
                /// 区
                /// </summary>
                [ModeAttribute(Rem = "区", IsNull = false)]
                public String Area { get; set; }
                /// <summary>
                /// 详细地址
                /// </summary>
                [ModeAttribute(Rem = "详细地址", IsNull = false)]
                public String Address { get; set; }
                /// <summary>
                /// 设为默认地址
                /// </summary>
                [ModeAttribute(Rem = "设为默认地址", IsNull = true)]
                public Boolean IsDef { get; set; }
            }
            /// <summary>
            /// 修改客户地址
            /// </summary>
            [ModeClassAttribute("修改客户地址")]
            public class UpdateAddress:AddAddress
            {
                /// <summary>
                /// 地址ID
                /// </summary>
                [ModeAttribute(Rem = "地址编号", IsNull = false)]
                public Int64 ID { get; set;}
            }
            /// <summary>
            /// 删除客户地址请求模型
            /// </summary>
            [ModeClassAttribute("删除客户地址")]
            public class DelAddress
            {
                /// <summary>
                /// 地址编号
                /// </summary>
                [ModeAttribute(Rem = "地址编号", IsNull = false)]
                public int ID { get; set; }
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 客户编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = false)]
                public int Client { get; set; }
            }
            /// <summary>
            /// 删除客户
            /// </summary>
            [ModeClassAttribute("删除客户")]
            public class Del
            {
                /// <summary>
                /// 网点编号
                /// </summary>
                [ModeAttribute(Rem = "网点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 用户编号 如 客户编号  业务员编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = false)]
                public int ID { get; set; }
            }
            /// <summary>
            /// 设置默认地址
            /// </summary>
            [ModeClassAttribute("设置默认地址")]
            public class SetDefAddress : DelAddress
            {

            }
        }
        /// <summary>
        /// 业务员相关接口
        /// </summary>
        public class Personnel
        {
            /// <summary>
            /// 登陆请求模型
            /// </summary>
            [ModeClassAttribute("业务员登陆")]
            public class Login
            {
                /// <summary>
                /// 归属网点
                /// </summary>
                [ModeAttribute(Rem = "归属网点", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 登陆账号
                /// </summary>
                [ModeAttribute(Rem = "登陆账号", IsNull = false)]
                public String Uid { get; set; }
                /// <summary>
                /// 登陆密码
                /// </summary>
                [ModeAttribute(Rem = "登陆密码", IsNull = false)]
                public String Pwd { get; set; }
            }
            /// <summary>
            /// 添加业务员请求模型
            /// </summary>
            [ModeClassAttribute("添加业务员")]
            public class Add
            {
                /// <summary>
                /// 名称
                /// </summary>
                [ModeAttribute(Rem = "名称", IsNull = false)]
                public String Name { get; set; }
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 账号
                /// </summary>
                [ModeAttribute(Rem = "账号", IsNull = false)]
                public String Uid { get; set; }
                /// <summary>
                /// 密码
                /// </summary>
                [ModeAttribute(Rem = "密码", IsNull = false)]
                public String Pwd { get; set; }
                /// <summary>
                /// 电话
                /// </summary>
                [ModeAttribute(Rem = "电话", IsNull = false)]
                public String Phone { get; set; }
                /// <summary>
                /// 0 业务员  1 管理员
                /// </summary>
                [ModeAttribute(Rem = "0 业务员  1 管理员", IsNull = false)]
                public int Type { get; set; }
            }
            /// <summary>
            /// 修改密码接口模型
            /// </summary>
            [ModeClassAttribute("业务员修改密码")]
            public class UpdataPwd
            {
                /// <summary>
                /// 网点编号
                /// </summary>
                [ModeAttribute(Rem = "网点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 用户编号 如 客户编号  业务员编号
                /// </summary>
                [ModeAttribute(Rem = "业务员编号", IsNull = false)]
                public int ID { get; set; }
                /// <summary>
                /// 原始密码
                /// </summary>
                [ModeAttribute(Rem = "原始密码", IsNull = false)]
                public String OldPassWord { get; set; }
                /// <summary>
                /// 新密码
                /// </summary>
                [ModeAttribute(Rem = "新密码", IsNull = false)]
                public String PassWord { get; set; }
            }
            /// <summary>
            /// 业务员查询接口情况模型
            /// </summary>
            [ModeClassAttribute("业务员查询")]
            public class Query
            {
                /// <summary>
                /// 网点编号
                /// </summary>
                [ModeAttribute(Rem = "网点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 编号
                /// </summary>
                [ModeAttribute(Rem = "业务员编号", IsNull = true)]
                public int Personnel { get; set; }
                /// <summary>
                /// 名称
                /// </summary>
                [ModeAttribute(Rem = "名称", IsNull = true)]
                public String Name { get; set; }
                /// <summary>
                /// 手机
                /// </summary>
                [ModeAttribute(Rem = "手机", IsNull = true)]
                public String Phone { get; set; }
                /// <summary>
                /// 登陆账号
                /// </summary>
                [ModeAttribute(Rem = "登陆账号", IsNull = true)]
                public String Uid { get; set; }
            }
            /// <summary>
            /// 业务员删除
            /// </summary>
            [ModeClassAttribute("业务员删除")]
            public class Del
            {
                /// <summary>
                /// 网点编号
                /// </summary>
                [ModeAttribute(Rem = "网点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 用户编号 如 客户编号  业务员编号
                /// </summary>
                [ModeAttribute(Rem = "业务员编号", IsNull = false)]
                public int ID { get; set; }
            }
            /// <summary>
            /// 修改业务员资料
            /// </summary>
            [ModeClassAttribute("修改业务员资料")]
            public class UpdateInfo : Add
            {
                /// <summary>
                /// 用户编号 如 客户编号  业务员编号
                /// </summary>
                [ModeAttribute(Rem = "业务员编号", IsNull = false)]
                public int ID { get; set; }
            }
            /// <summary>
            /// 业务员重置密码
            /// </summary>
            [ModeClassAttribute("业务员重置密码")]
            public class ResettingPwd
            {
                /// <summary>
                /// 网点编号
                /// </summary>
                [ModeAttribute(Rem = "网点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 用户编号 如 客户编号  业务员编号
                /// </summary>
                [ModeAttribute(Rem = "业务员编号", IsNull = false)]
                public int ID { get; set; }
                /// <summary>
                /// 新密码
                /// </summary>
                [ModeAttribute(Rem = "新密码", IsNull = false)]
                public String PassWord { get; set; }
            }
        }
        /// <summary>
        /// 站点相关接口
        /// </summary>
        public class Site
        {
            /// <summary>
            /// 查询站点
            /// </summary>
            [ModeClassAttribute("查询站点")]
            public class Query
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
            }
            /// <summary>
            /// 添加站点请求模型
            /// </summary>
            [ModeClassAttribute("添加站点")]
            public class Add
            {
                /// <summary>
                /// 站点名称
                /// </summary>
                [ModeAttribute(Rem = "站点名称", IsNull = false)]
                public String Name { get; set; }
                /// <summary>
                /// 站点标识
                /// </summary>
                [ModeAttribute(Rem = "站点标识", IsNull = false)]
                public String Code { get; set; }
                /// <summary>
                /// 快递公司ID
                /// </summary>
                [ModeAttribute(Rem = "快递公司ID", IsNull = false)]
                public int Express { get; set; }
                /// <summary>
                /// 联系人
                /// </summary>
                [ModeAttribute(Rem = "联系人", IsNull = false)]
                public String Person { get; set; }
                /// <summary>
                /// 联系手机
                /// </summary>
                [ModeAttribute(Rem = "联系手机", IsNull = false)]
                public String Phone { get; set; }
                /// <summary>
                /// 联系电话
                /// </summary>
                [ModeAttribute(Rem = "联系电话", IsNull = false)]
                public String Tel { get; set; }
                /// <summary>
                /// 联系地址
                /// </summary>
                [ModeAttribute(Rem = "联系地址", IsNull = false)]
                public String Address { get; set; }
                /// <summary>
                /// 到期时间
                /// </summary>
                [ModeAttribute(Rem = "到期时间", IsNull = false)]
                public String EndTime { get; set; }
            }
            /// <summary>
            /// 修改站点资料接口请求模型
            /// </summary>
            [ModeClassAttribute("修改站点资料")]
            public class Update
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 站点名称
                /// </summary>
                [ModeAttribute(Rem = "站点名称", IsNull = false)]
                public String Name { get; set; }
                /// <summary>
                /// 站点标识
                /// </summary>
                [ModeAttribute(Rem = "站点标识", IsNull = false)]
                public String Code { get; set; }
                /// <summary>
                /// 快递公司ID
                /// </summary>
                [ModeAttribute(Rem = "快递公司ID", IsNull = false)]
                public int Express { get; set; }
                /// <summary>
                /// 联系人
                /// </summary>
                [ModeAttribute(Rem = "联系人", IsNull = false)]
                public String Person { get; set; }
                /// <summary>
                /// 联系手机
                /// </summary>
                [ModeAttribute(Rem = "联系手机", IsNull = false)]
                public String Phone { get; set; }
                /// <summary>
                /// 联系电话
                /// </summary>
                [ModeAttribute(Rem = "联系电话", IsNull = false)]
                public String Tel { get; set; }
                /// <summary>
                /// 联系地址
                /// </summary>
                [ModeAttribute(Rem = "联系地址", IsNull = false)]
                public String Address { get; set; }
            }
        }
        /// <summary>
        /// 订单相关接口
        /// </summary>
        public class Order
        {
            /// <summary>
            /// 新建订单接口模型
            /// </summary>
            [ModeClassAttribute("新建订单")]
            public class Add
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 会员编号
                /// </summary>
                [ModeAttribute(Rem = "会员编号", IsNull = false)]
                public int Client { get; set; }
                /// <summary>
                /// 寄件人
                /// </summary>
                [ModeAttribute(Rem = "寄件人", IsNull = false)]
                public String Senter { get; set; }
                /// <summary>
                /// 寄件手机
                /// </summary>
                [ModeAttribute(Rem = "寄件手机", IsNull = false)]
                public String SentPhone { get; set; }
                /// <summary>
                /// 寄件电话
                /// </summary>
                [ModeAttribute(Rem = "寄件电话", IsNull = false)]
                public String SentTel { get; set; }
                /// <summary>
                /// 寄件省
                /// </summary>
                [ModeAttribute(Rem = "寄件省", IsNull = false)]
                public String SentProvince { get; set; }
                /// <summary>
                /// 寄件市
                /// </summary>
                [ModeAttribute(Rem = "寄件市", IsNull = false)]
                public String SentCity { get; set; }
                /// <summary>
                /// 寄件区
                /// </summary>
                [ModeAttribute(Rem = "寄件区", IsNull = false)]
                public String SentArea { get; set; }
                /// <summary>
                /// 寄件地址
                /// </summary>
                [ModeAttribute(Rem = "寄件地址", IsNull = false)]
                public String SentAddress { get; set; }
                /// <summary>
                /// 收件人
                /// </summary>
                [ModeAttribute(Rem = "收件人", IsNull = false)]
                public String Signer { get; set; }
                /// <summary>
                /// 收件手机
                /// </summary>
                [ModeAttribute(Rem = "收件手机", IsNull = false)]
                public String SignPhone { get; set; }
                /// <summary>
                /// 收件电话
                /// </summary>
                [ModeAttribute(Rem = "收件电话", IsNull = false)]
                public String SignTel { get; set; }
                /// <summary>
                /// 收件省
                /// </summary>
                [ModeAttribute(Rem = "收件省", IsNull = false)]
                public String SignProvince { get; set; }
                /// <summary>
                /// 收件市
                /// </summary>
                [ModeAttribute(Rem = "收件市", IsNull = false)]
                public String SignCity { get; set; }
                /// <summary>
                /// 收件区域
                /// </summary>
                [ModeAttribute(Rem = "收件区域", IsNull = false)]
                public String SignArea { get; set; }
                /// <summary>
                /// 收件地址
                /// </summary>
                [ModeAttribute(Rem = "收件地址", IsNull = false)]
                public String SignAddress { get; set; }
                /// <summary>
                /// 商品名称
                /// </summary>
                [ModeAttribute(Rem = "商品名称", IsNull = true)]
                public String GoodsName { get; set; }
                /// <summary>
                /// 商品类型
                /// </summary>
                [ModeAttribute(Rem = "商品类型", IsNull = true)]
                public String GoodsType { get; set; }
                /// <summary>
                /// 货物金额
                /// </summary>
                [ModeAttribute(Rem = "货物金额", IsNull = true)]
                public Decimal GoodsMoney { get; set; }
                /// <summary>
                /// 快件类型
                /// </summary>
                [ModeAttribute(Rem = "快件类型", IsNull = true)]
                public String FastType { get; set; }
                /// <summary>
                /// 代收货款
                /// </summary>
                [ModeAttribute(Rem = "代收货款", IsNull = true)]
                public Decimal GetMoney { get; set; }
                /// <summary>
                /// 是否收件人付款
                /// </summary>
                [ModeAttribute(Rem = "是否收件人付款", IsNull = true)]
                public int IsSignPay { get; set; }
                /// <summary>
                /// 是否短信通知
                /// </summary>
                [ModeAttribute(Rem = "是否短信通知", IsNull = true)]
                public int IsSms { get; set; }
                /// <summary>
                /// 备注
                /// </summary>
                [ModeAttribute(Rem = "备注", IsNull = true)]
                public String Rem { get; set; }
            }
            /// <summary>
            /// 取消订单请求模型
            /// </summary>
            [ModeClassAttribute("取消订单")]
            public class Cancel
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 客户编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = false)]
                public int Client { get; set; }
                /// <summary>
                /// 订单编号
                /// </summary>
                [ModeAttribute(Rem = "订单编号", IsNull = false)]
                public int ID { get; set; }
            }
            /// <summary>
            /// 查询订单请求模型
            /// </summary>
            [ModeClassAttribute("查询订单")]
            public class Query
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 客户编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = true)]
                public int Client { get; set; }
                /// <summary>
                /// 订单编号
                /// </summary>
                [ModeAttribute(Rem = "订单编号", IsNull = true)]
                public int ID { get; set; }
                /// <summary>
                /// 业务员
                /// </summary>
                [ModeAttribute(Rem = "业务员", IsNull = true)]
                public int Personnel { get; set; }
                /// <summary>
                /// 快递单号
                /// </summary>
                [ModeAttribute(Rem = "快递单号", IsNull = true)]
                public String OrderCode { get; set; }
                /// <summary>
                /// 订单状态 0 查询所有
                /// </summary>
                [ModeAttribute(Rem = "订单状态 0 查询所有", IsNull = true)]
                public int State { get; set; }
                /// <summary>
                /// 起始时间
                /// </summary>
                [ModeAttribute(Rem = "起始时间", IsNull = true)]
                public String StartTime { get; set; }
                /// <summary>
                /// 结束时间
                /// </summary>
                [ModeAttribute(Rem = "结束时间", IsNull = true)]
                public String EndTime { get; set; }
            }
            /// <summary>
            /// 订单分配请求模型
            /// </summary>
            [ModeClassAttribute("订单分配")]
            public class ToPersonnel
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 客户编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = false)]
                public int Client { get; set; }
                /// <summary>
                /// 订单编号
                /// </summary>
                [ModeAttribute(Rem = "订单编号", IsNull = false)]
                public int ID { get; set; }
                /// <summary>
                /// 业务员编号
                /// </summary>
                [ModeAttribute(Rem = "业务员编号", IsNull = false)]
                public int Personnel { get; set; }
            }
            /// <summary>
            /// 订单绑定快递单号请求模型
            /// </summary>
            [ModeClassAttribute("订单绑定快递单号")]
            public class ToCode
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 客户编号
                /// </summary>
                [ModeAttribute(Rem = "客户编号", IsNull = false)]
                public int Client { get; set; }
                /// <summary>
                /// 订单编号
                /// </summary>
                [ModeAttribute(Rem = "订单编号", IsNull = false)]
                public int ID { get; set; }
                /// <summary>
                /// 快递单号
                /// </summary>
                [ModeAttribute(Rem = "快递单号", IsNull = false)]
                public String OrderCode { get; set; }
                /// <summary>
                /// 运费
                /// </summary>
                [ModeAttribute(Rem = "运费", IsNull = false)]
                public Decimal Free { get; set; }
            }
        }
        /// <summary>
        /// 基础信息相关接口
        /// </summary>
        public class BaseInfo
        {
            /// <summary>
            /// 获取菜单列表
            /// </summary>
            [ModeClassAttribute("获取菜单")]
            public class GetMeun
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 菜单编号
                /// </summary>
                [ModeAttribute(Rem = "菜单编号", IsNull =true)]
                public int ID { get; set; }
            }
            /// <summary>
            /// 删除菜单
            /// </summary>
            [ModeClassAttribute("删除菜单")]
            public class DelMeun
            {
                /// <summary>
                /// 菜单编号
                /// </summary>
                [ModeAttribute(Rem = "菜单编号", IsNull = false)]
                public int ID { get; set; }
            }
            /// <summary>
            /// 修改菜单
            /// </summary>
            [ModeClassAttribute("修改菜单")]
            public class UpdataMeun : PubMode.BaseInfo.RoleInfo
            {

            }
            /// <summary>
            /// 新增菜单
            /// </summary>
            [ModeClassAttribute("新增菜单")]
            public class AddMeun : PubMode.BaseInfo.RoleInfo
            {

            }
            /// <summary>
            /// 获取快递公司
            /// </summary>
            [ModeClassAttribute("获取快递公司")]
            public class GetExperss
            {
                /// <summary>
                /// 编号
                /// </summary>
                [ModeAttribute(Rem = "编号", IsNull = true)]
                public int ID { get; set; }
                /// <summary>
                /// 标识
                /// </summary>
                [ModeAttribute(Rem = "标识", IsNull = true)]
                public String Name { get; set; }
            }
        }
        /// <summary>
        /// 其他接口
        /// </summary>
        public class Entity
        {
            /// <summary>
            /// 通用请求模型
            /// </summary>
            [ModeClassAttribute("通用请求模型")]
            public class AllRequset
            {
                /// <summary>
                /// 站点
                /// </summary>
                [ModeAttribute(Rem = "站点", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 编号
                /// </summary>
                [ModeAttribute(Rem = "编号", IsNull = false)]
                public int ID { get; set; }
                /// <summary>
                /// 标识
                /// </summary>
                [ModeAttribute(Rem = "标识", IsNull = false)]
                public String Name { get; set; }
            }
            /// <summary>
            /// 短信发送请求模型
            /// </summary>
            [ModeClassAttribute("发送短信")]
            public class SentSms
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 手机号码
                /// </summary>
                [ModeAttribute(Rem = "手机号码", IsNull = false)]
                public String Phone { get; set; }
                /// <summary>
                /// 短信内容
                /// </summary>
                [ModeAttribute(Rem = "短信内容", IsNull = false)]
                public String Sms { get; set; }
            }
            /// <summary>
            /// 查询短信接口请求模型
            /// </summary>
            [ModeClassAttribute("查询短信")]
            public class Query_SmsLog
            {
                /// <summary>
                /// 站点ID
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 状态 --可空
                /// </summary>
                [ModeAttribute(Rem = "状态", IsNull = true)]
                public int State { get; set; }
                /// <summary>
                /// 电话号码 --可空
                /// </summary>
                [ModeAttribute(Rem = "电话号码", IsNull = true)]
                public String Phone { get; set; }
                /// <summary>
                /// 类型 --可空
                /// </summary>
                [ModeAttribute(Rem = "类型", IsNull = true)]
                public int Type { get; set; }
                /// <summary>
                /// 开始时间 --可空
                /// </summary>
                [ModeAttribute(Rem = "开始时间", IsNull = true)]
                public String StartTime { get; set; }
                /// <summary>
                /// 截止时间 --可空
                /// </summary>
                [ModeAttribute(Rem = "截止时间", IsNull = true)]
                public String EndTime { get; set; }
            }
            /// <summary>
            /// 极光推送
            /// </summary>
            [ModeClassAttribute("极光推送")]
            public class JPushSent
            {
                /// <summary>
                /// 消息类型
                /// </summary>
                [ModeAttribute(Rem = "消息类型", IsNull = false)]
                public int MsgType { get; set; }
                /// <summary>
                /// 手机类型
                /// </summary>
                [ModeAttribute(Rem = "手机类型", IsNull = false)]
                public int PhoneType { get; set; }
                /// <summary>
                /// 消息标题
                /// </summary>
                [ModeAttribute(Rem = "消息标题", IsNull = false)]
                public string MsgTitle { get; set; }
                /// <summary>
                /// 消息内容
                /// </summary>
                [ModeAttribute(Rem = "消息内容", IsNull = false)]
                public string MsgText { get; set; }
                /// <summary>
                /// 接收用户
                /// </summary>
                [ModeAttribute(Rem = "接收用户", IsNull = false)]
                public List<String> Uid { get; set; }
                /// <summary>
                /// 分组
                /// </summary>
                [ModeAttribute(Rem = "分组", IsNull = false)]
                public String TageType { get; set; }
            }
            /// <summary>
            /// GoEasy推送模型
            /// </summary>
            [ModeClassAttribute("GoEasy推送")]
            public class GoEasy
            {
                /// <summary>
                /// key
                /// </summary>
                [ModeAttribute(Rem = "key", IsNull = false)]
                public string Appkey { get; set; }
                /// <summary>
                /// 用户标识
                /// </summary>
                [ModeAttribute(Rem = "用户标识", IsNull = false)]
                public string channel { get; set; }
                /// <summary>
                /// 消息内容
                /// </summary>
                [ModeAttribute(Rem = "消息内容", IsNull = false)]
                public string content { get; set; }
            }
            /// <summary>
            /// 获取支付配置
            /// </summary>
            [ModeClassAttribute("获取支付配置")]
            public class GetPayConfig
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
            }
            /// <summary>
            /// 推送内置微信模板消息
            /// </summary>
            [ModeClassAttribute("推送内置微信模板消息")]
            public class PushWx
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 推送类型 MoneyChange(账户资金变动提醒) GoodsArrival(到货提醒) OrderSend(订单发货) AddMoney(充值通知) IntegralChange(积分变动通知) Sign(签收通知)
                /// </summary>
                [ModeAttribute(Rem = "推送类型 MoneyChange(账户资金变动提醒) GoodsArrival(到货提醒) OrderSend(订单发货) AddMoney(充值通知) IntegralChange(积分变动通知) Sign(签收通知)", IsNull =false)]
                public String PushType { get; set; }
                /// <summary>
                /// 会员OpenID
                /// </summary>
                [ModeAttribute(Rem = "微信OpenID", IsNull =true)]
                public String OpenID { get; set; }
                /// <summary>
                /// 会员ID
                /// </summary>
                [ModeAttribute(Rem = "会员ID", IsNull = true)]
                public Int64 MemberID { get; set; }
                /// <summary>
                /// 会员名称
                /// </summary>
                [ModeAttribute(Rem = "会员名称", IsNull = true)]
                public String MemberName { get; set; }
                /// <summary>
                /// 快递单号
                /// </summary>
                [ModeAttribute(Rem = "快递单号", IsNull = true)]
                public String BillCode { get; set; }
                /// <summary>
                /// 订单ID
                /// </summary>
                [ModeAttribute(Rem = "订单ID", IsNull = true)]
                public String OrderID { get; set; }
                /// <summary>
                /// 金额 积分
                /// </summary>
                [ModeAttribute(Rem = "金额 积分", IsNull = true)]
                public Decimal Money { get; set; }
                /// <summary>
                /// 当前金额 积分
                /// </summary>
                [ModeAttribute(Rem = "当前金额 积分", IsNull = true)]
                public Decimal NowMoney { get; set; }
                /// <summary>
                /// 金额 积分 类型说明
                /// </summary>
                [ModeAttribute(Rem = "金额 积分 类型说明", IsNull = true)]
                public String MoneyType { get; set; }
                /// <summary>
                /// 快递公司
                /// </summary>
                [ModeAttribute(Rem = "快递公司", IsNull = true)]
                public String Com { get; set; }
                /// <summary>
                /// 收件人 签收人
                /// </summary>
                [ModeAttribute(Rem = "收件人 签收人", IsNull = true)]
                public String Signer { get; set; }
                /// <summary>
                /// 收件电话 签收电话
                /// </summary>
                [ModeAttribute(Rem = "收件电话 签收电话", IsNull = true)]
                public String SignPhone { get; set; }
            }
            /// <summary>
            /// 推送自定义微信模板消息
            /// </summary>
            [ModeClassAttribute("推送自定义微信模板消息")]
            public class PushWxMbMessge
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// OpenID 用户ID
                /// </summary>
                [ModeAttribute(Rem = "微信OpenID", IsNull =false)]
                public string touser { get; set; }
                /// <summary>
                /// 消息模板ID
                /// </summary>
                [ModeAttribute(Rem = "消息模板ID", IsNull = false)]
                public string template_id { get; set; }
                /// <summary>
                /// 颜色
                /// </summary>
                [ModeAttribute(Rem = "颜色", IsNull = true)]
                public string topcolor { get; set; }
                /// <summary>
                /// 链接
                /// </summary>
                [ModeAttribute(Rem = "链接", IsNull = true)]
                public string url { get; set; }
                /// <summary>
                /// 模板数据
                /// </summary>
                [ModeAttribute(Rem = "模板数据 value color 模式数据", IsNull = false)]
                public Dictionary<String, PubMode.Entity.MbMsgObject> data { get; set; }
            }
            /// <summary>
            /// 支付申请模型
            /// </summary>
            [ModeClassAttribute("支付申请")]
            public class PayRequest
            {
                /// <summary>
                /// 站点编号
                /// </summary>
                [ModeAttribute(Rem = "站点编号", IsNull = false)]
                public int Site { get; set; }
                /// <summary>
                /// 【必填】支付方式 0 微信支付 1 支付宝支付 默认 0
                /// </summary>
                [ModeAttribute(Rem = "支付方式 0 微信支付 1 支付宝支付", IsNull = false)]
                public Int64 PayMode { get; set; }
                /// <summary>
                /// 【可空】支付宝是否二维码模式 0 默认跳转模式 微信该参数无效
                /// </summary>
                [ModeAttribute(Rem = "支付宝是否二维码模式 0 默认跳转模式 微信该参数无效", IsNull = true)]
                public Int64 IsQrCode { get; set; }
                /// <summary>
                /// 【必填】支付金额 单位 RMB/元
                /// </summary>
                [ModeAttribute(Rem = "支付金额 单位 RMB/元", IsNull = false)]
                public Decimal Money { get; set; }
                /// <summary>
                /// 【必填】订单编号
                /// </summary>
                [ModeAttribute(Rem = "订单编号", IsNull = false)]
                public String OrderCode { get; set; }
                /// <summary>
                /// 【可空】客户标识
                /// </summary>
                [ModeAttribute(Rem = "客户标识", IsNull = true)]
                public String ClientCode { get; set; }
                /// <summary>
                /// 【必填】商品名称
                /// </summary>
                [ModeAttribute(Rem = "商品名称", IsNull = false)]
                public String GoodsName { get; set; }
                /// <summary>
                /// 【可空】用户自定义的支付类型
                /// </summary>
                [ModeAttribute(Rem = "用户自定义的支付类型", IsNull = true)]
                public String PayType { get; set; }
                /// <summary>
                /// 【可空】其他备注信息
                /// </summary>
                [ModeAttribute(Rem = "其他备注信息", IsNull = true)]
                public String Rem { get; set; }
                /// <summary>
                /// 【可空】支付宝支付完毕跳转地址
                /// </summary>
                [ModeAttribute(Rem = "支付宝支付完毕跳转地址", IsNull = true)]
                public String ReturnUrl { get; set; }
            }
            /// <summary>
            /// 微信JsApi支付申请模型
            /// </summary>
            [ModeClassAttribute("微信JsApi支付申请")]
            public class WxJsApiPayRequest : PayRequest
            {
                /// <summary>
                /// 【必填】用户OpenID
                /// </summary>
                [ModeAttribute(Rem = "微信OpenID", IsNull = false)]
                public String OpenID { get; set; }
                /// <summary>
                /// IP
                /// </summary>
                [ModeAttribute(Rem = "IP", IsNull = false)]
                public String Ip { get; set; }
            }
        }
    }
}
