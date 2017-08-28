using Common;
using Model.LBTable;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_Print
    {

        public Model.GeneralReturns Print(Model.M_Print.Request S)
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();

            if (!string.IsNullOrEmpty(S.repair))
            {
                return SupplementPrint(genRet, S);
            }

            if (String.IsNullOrEmpty(S.operateMan) || String.IsNullOrEmpty(S.operateSite) || null == S.PackaginBillcode || S.PackaginBillcode.Count == 0)
            {
                genRet.MsgText = "参数不全，请核实";

            }
            else
            {
                List<Model.M_Print.Return> reqList = new List<Model.M_Print.Return>();
                pmw_order orderInfo = new DAL.Dal_Print().getOrderInfo(long.Parse(S.orderID));
                int subcontractCount = 0;
                if (orderInfo.subpackageNum == null || orderInfo.subpackageNum < 1)
                {
                    subcontractCount = 1;
                }
                else
                {
                    subcontractCount = int.Parse(orderInfo.subpackageNum.ToString());
                }


                for (int i = 1; i <= subcontractCount; i++)
                {

                    if (orderInfo == null)
                    {
                        genRet.MsgText = "无法获取订单信息";
                    }
                    else
                    {

                        List<string> billcodeList = new List<string>();
                        foreach (var billcode in S.PackaginBillcode)
                        {
                            billcodeList.Add(i == 1 ? billcode.billcode : billcode.billcode + "-" + i);
                        }

                        string message = string.Empty;//错误消息
                        StringBuilder strBuiGoodsCode = new StringBuilder();//货物类型代码
                        StringBuilder strBuiGoodsType = new StringBuilder();//货物类型
                        StringBuilder strBuiGoodsName = new StringBuilder();//货物名称
                        double billcodeWeight = 0;

                        if (!IsPackage(orderInfo.order_code, i, billcodeList, ref message, ref strBuiGoodsType, ref strBuiGoodsName, ref billcodeWeight))
                        {
                            genRet.MsgText = message;
                            return genRet;
                        }
                        #region 代收货款
                        var collectingMoney = orderInfo.pay_type == 1 ? (orderInfo.country_free + orderInfo.agencyFund) : orderInfo.agencyFund;
                        #endregion


                        GoodsCatalog goodsInfo = new DAL.Dal_Print().getGoodsTypeInfo(S.PackaginBillcode[0].billcode);
                        if (goodsInfo == null)
                        {
                            genRet.MsgText = "无法获取货物类型";
                            return genRet;
                        }

                        strBuiGoodsCode.Append(goodsInfo.briefCode);
                        pmw_member memberInfo = new DAL.Dal_Print().getMemberInfo(orderInfo.member_id);
                        if (memberInfo == null)
                        {
                            genRet.MsgText = "无法获取会员信息";
                            return genRet;
                        }

                        TaoBaoInfo shopInfo = new DAL.Dal_Print().getShopInfo(memberInfo.astro);
                        if (shopInfo == null)
                        {
                            genRet.MsgText = "无法获取店铺信息";
                            return genRet;
                        }

                        pmw_house houseInfo = new DAL.Dal_Print().getHouseInfo(long.Parse(S.operateSite));
                        if (houseInfo == null)
                        {
                            genRet.MsgText = "无法获取仓库信息";
                            return genRet;
                        }
                        pmw_timeBar flightInfo = new DAL.Dal_Print().getFlightTime(orderInfo.timeBarID);
                        if (flightInfo == null)
                        {
                            genRet.MsgText = "无法获取航班时效信息";
                            return genRet;
                        }
                        PrintConfig printConfigInfo = PrintConfigInfo(orderInfo, S.express);
                        if (printConfigInfo == null)
                        {
                            genRet.MsgText = "无法获取打印配置信息";
                            return genRet;
                        }

                        Forwarder forwarderInfo = new DAL.Dal_Print().getForwarderCode(printConfigInfo.pjCom, printConfigInfo.pjCode);
                        if (forwarderInfo == null)
                        {
                            genRet.MsgText = "无法获取派件公司信息";
                            return genRet;
                        }

                        Forwarder_number forwarderNoInfo = new DAL.Dal_Print().getPrintNo(forwarderInfo.id);
                        if (forwarderNoInfo == null || string.IsNullOrEmpty(forwarderNoInfo.num))
                        {
                            genRet.MsgText = "无法获取单号";
                            return genRet;
                        }
                        string printNo = forwarderNoInfo.num;
                        if (new DAL.Dal_Print().getForwardingAgentNoCount(forwarderInfo.id) < 2001)
                        {
                            try
                            {
                                var SentState1 = FastSocket.MaeesgeSend(new MassgeClass()
                                {
                                    IsSite = true,
                                    Mags = forwarderInfo.ForwarderName,
                                    MagsID = "0",
                                    Mags_Type = "HmOrderCount",
                                    SiteOrUser = new string[] { "客服" }
                                }, false);
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                        string recipients = new DAL.Dal_Print().getRecipientName(orderInfo.cname, orderInfo.id);
                        StringBuilder strBuiBill = new StringBuilder();

                        foreach (string strbill in billcodeList.ToArray())
                        {
                            strBuiBill.Append(strBuiBill.Length < 1 ? strbill : "," + strBuiBill);
                        }

                        bool dbPrint = new DAL.Dal_Print().Print(orderInfo, string.IsNullOrEmpty(orderInfo.sent_kd_billcode) ? printNo : orderInfo.sent_kd_billcode + "," + printNo, S.express.Contains("黑猫") ? "黑猫宅急便" : S.express, recipients, houseInfo, shopInfo, forwarderInfo, billcodeList.ToArray(), strBuiBill, billcodeList.Count, strBuiGoodsName.ToString(), S, printNo, billcodeWeight);
                        if (!dbPrint)
                        {
                            new DAL.Dal_Print().ReleaseForwarder_number(forwarderNoInfo);
                            genRet.MsgText = "无法生成运单";
                            return genRet;
                        }


                        if (printConfigInfo.pjCom.Contains("国阳"))
                        {
                            ApiHelp.GYHelper gyApi = new ApiHelp.GYHelper();
                            gyApi.AddData(new ApiHelp.GYHelper.Data()
                            {
                                SentType = S.express.Contains("取货") ? "A02" : "A01",
                                Signer = recipients,
                                SignAddress = orderInfo.address,
                                SignPhone = orderInfo.mobile,
                                SignEmail = memberInfo.email,
                                StoreName = S.express.Contains("取货") ? recipients : "",
                                StoreCode = S.express.Contains("取货") ? orderInfo.customerCode : "",
                                StoreAddress = S.express.Contains("取货") ? orderInfo.address : "",
                                StorePhone = S.express.Contains("取货") ? orderInfo.mobile : "",
                                OrderCode = printNo,
                                GoodsName = strBuiGoodsName.ToString(),
                                GoodsAccount = billcodeList.Count,
                                DsMoney = (int)collectingMoney,
                                Weight = (int)billcodeWeight,
                                SentFastType = GyTransferCompanyCode(S.express)
                            });
                            gyApi.ToCsv(Common.Entity.ftpPaht, true);
                        }


                        reqList.Add(new Model.M_Print.Return
                        {
                            WaybillNo = printNo,
                            billcode = string.Join(",", billcodeList.ToArray()),
                            employee = S.operateMan,
                            Js_number = billcodeList.Count,
                            briefCode = strBuiGoodsCode.ToString(),
                            goodsType = strBuiGoodsType.ToString(),
                            shopName = shopInfo.Name,
                            OrderGoodsNotes = orderInfo.OrderGoodsNotes,
                            CusCode = forwarderInfo.ForwarderCode,
                            timeBarName = flightInfo.timeBarName,
                            orderID = orderInfo.id.ToString(),
                            z_weight = billcodeWeight.ToString(),
                            address = orderInfo.address,
                            Phone = orderInfo.mobile,
                            recipients = recipients,
                            IdentificationGoods = strBuiGoodsType.ToString().Contains("特") ? "T" : "",
                            ds_mdgj_Free = orderInfo.pay_type == 1 ? Math.Round(Convert.ToDecimal(orderInfo.agencyFund + orderInfo.country_free), 2).ToString() : "0",
                            DFFeer = orderInfo.pay_type == 1 ? Math.Round(Convert.ToDecimal(orderInfo.agencyFund + orderInfo.country_free), 2).ToString() : orderInfo.agencyFund.ToString(),
                            addressCode = printNo.Substring(6),
                            goodsName = strBuiGoodsName.ToString(),
                            chargedWeight = orderInfo.Free_Weight.ToString()
                        });
                        genRet.State = true;
                        genRet.Mb = S.express;
                        genRet.ReturnJson = Common.DataHandling.ObjToJson(reqList);
                        genRet.MsgText = S.operateMan;
                    }

                }
            }

            return genRet;
        }



        /// <summary>
        /// 获取打印配置
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <param name="kdComanpy"></param>
        /// <returns></returns>
        public PrintConfig PrintConfigInfo(pmw_order orderInfo, string kdComanpy)
        {
            if (kdComanpy.Contains("黑猫"))
            {
                if (orderInfo.agencyFund <= 0 && orderInfo.pay_type != 1 && !kdComanpy.Contains("不代收"))
                {
                    kdComanpy = kdComanpy + "不代收";
                }
                else if (!kdComanpy.Contains("代收"))
                {
                    kdComanpy = kdComanpy + "代收";
                }
                return new DAL.Dal_Print()
            .getPrinConfig(kdComanpy);
            }
            else
            {
                return new DAL.Dal_Print()
            .getPrinConfig("国阳");
            }

        }

        /// <summary>
        /// 是否能打包
        /// </summary>
        /// <param name="order_code"></param>
        /// <param name="i"></param>
        /// <param name="ReqList"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool IsPackage(string order_code, int i, List<string> billCodeList, ref string message, ref StringBuilder strBuiGoodsType, ref StringBuilder strBuiGoodsName, ref double weight)
        {
            if (billCodeList.Count < 1)
            {
                message = "请输入单号";
                return false;
            }



            bool boo = false;

            List<pmw_billcode> billcodeInfo = new DAL.Dal_Print().getBillcodeInfo(billCodeList);
            foreach (var billcode in billcodeInfo)
            {
                if (billcodeInfo != null && order_code == billcode.order_code)
                {
                    if (billcode.is_packed == 1 || !string.IsNullOrEmpty(billcode.packed_billcode))
                    {
                        message = "快递单号【" + billcode.kd_billcode + "】已打包";
                        boo = false;
                        break;
                    }
                    else
                    {

                        strBuiGoodsName.Append(strBuiGoodsName.Length < 1 ? billcode.goods.Trim() : "," + billcode.goods.Trim());

                        strBuiGoodsType.Append(strBuiGoodsType.Length < 1 ? billcode.goodsTyep : strBuiGoodsType.ToString().Contains(billcode.goodsTyep) ? string.Empty : "," + billcode.goodsTyep);
                        weight += (double)billcode.dd_weight;
                        boo = true;
                    }

                }
                else
                {
                    message = "该快递单号不是该订单货物";
                    boo = false;
                    break;
                }
            }

            return boo;



        }


        /// <summary>
        /// 补打运单
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="S"></param>
        /// <returns></returns>
        private Model.GeneralReturns SupplementPrint(Model.GeneralReturns gr, Model.M_Print.Request S)
        {
            if (String.IsNullOrEmpty(S.operateMan) || String.IsNullOrEmpty(S.operateSite))
            {
                gr.MsgText = "缺少操作人或站点";
                gr.State = false;
                return gr;
            }

            pmw_billcode billcodeInfo = new DAL.Dal_Print().SupplementGetBillCodeInfo(S.repair);
            if (billcodeInfo == null || string.IsNullOrEmpty(billcodeInfo.packed_billcode))
            {
                gr.MsgText = "无法获取快递单信息";
                return gr;
            }
            List<Model.M_Print.Return> reqList = new List<Model.M_Print.Return>();
            pmw_order orderInfo = new DAL.Dal_Print().SupplementGetOrderInfo(billcodeInfo.order_code);
            if (orderInfo == null)
            {
                gr.MsgText = "无法获取订单信息";
                return gr;
            }
            CFHMPring pringInfo = new DAL.Dal_Print().SupplementGetPrintInfo(billcodeInfo.packed_billcode);
            if (pringInfo == null)
            {
                gr.MsgText = "无法获取打印信息";
                return gr;
            }
            pmw_timeBar flightInfo = new DAL.Dal_Print().getFlightTime(orderInfo.timeBarID);
            if (flightInfo == null)
            {
                gr.MsgText = "无法获取航班信息";
                return gr;
            }
            string SignerCode = string.Empty, VersionCode = string.Empty, addressCode = string.Empty;
            secondEJSPushData(pringInfo.deliveryCom, pringInfo.recipientsAdd, out SignerCode, out VersionCode, out addressCode);
            reqList.Add(new Model.M_Print.Return
            {
                WaybillNo = pringInfo.CForHM_number,
                billcode = pringInfo.KD_billcodeList,
                employee = S.operateMan,
                Js_number = (int)pringInfo.TurnNumber,
                briefCode = pringInfo.deliveryCode,
                goodsType = billcodeInfo.goodsTyep,
                goodsName = pringInfo.goods,
                shopName = pringInfo.consolidator,
                OrderGoodsNotes = orderInfo.OrderGoodsNotes,
                CusCode = pringInfo.deliveryCode,
                timeBarName = flightInfo.timeBarName,
                orderID = orderInfo.id.ToString(),
                z_weight = pringInfo.netWeight.ToString(),
                address = pringInfo.recipientsAdd,
                Phone = pringInfo.recipientsPhone,
                recipients = pringInfo.recipients,
                IdentificationGoods = billcodeInfo.goodsTyep.Contains("特") ? "T" : "",
                ds_mdgj_Free = orderInfo.pay_type == 1 ? Math.Round(Convert.ToDecimal(pringInfo.freightPayable + orderInfo.country_free), 2).ToString() : "0",
                DFFeer = orderInfo.pay_type == 1 ? Math.Round(Convert.ToDecimal(pringInfo.freightPayable + orderInfo.country_free), 2).ToString() : pringInfo.freightPayable.ToString(),
                addressCode = addressCode,
                SignerCode = SignerCode,
                VersionCode = VersionCode,
                chargedWeight = orderInfo.Free_Weight.ToString()
            });
            if (reqList.Count > 0)
            {
                gr.ReturnJson = DataHandling.ObjToJson(reqList);
                gr.State = true;
                gr.Mb = pringInfo.deliveryCom;
                gr.MsgText = S.operateMan;
            }
            else
            {
                gr.MsgText = "无法获取打印信息";
            }

            return gr;

        }





        /// <summary>
        /// 获取发货物流编号
        /// </summary>
        /// <param name="comPanyName"></param>
        /// <returns></returns>
        private int GyTransferCompanyCode(string comPanyName)
        {
            if (comPanyName.Contains("邮局"))
            {
                return 1;
            }
            else if (comPanyName.Contains("宅配通"))
            {
                return 2;
            }
            else if (comPanyName.Contains("黑猫"))
            {
                return 3;
            }
            else if (comPanyName.Contains("萊爾富"))
            {
                return 4;
            }
            else if (comPanyName.Contains("OK"))
            {
                return 5;
            }
            else if (comPanyName.Contains("7‐11"))
            {
                return 6;
            }
            else if (comPanyName.Contains("全家"))
            {
                return 7;
            }
            else if (comPanyName.Contains("立邦"))
            {
                return 8;
            }
            else if (comPanyName.Contains("新竹"))
            {
                return 9;
            }
            return 0;

        }

        /// <summary>
        /// 补打单EJS
        /// </summary>
        /// <param name="MDKDCOM"></param>
        /// <param name="address"></param>
        /// <param name="SignerCode"></param>
        /// <param name="VersionCode"></param>
        /// <param name="addressCode"></param>
        private void secondEJSPushData(String MDKDCOM, string address, out String SignerCode, out String VersionCode, out string addressCode)
        {

            if (MDKDCOM.Contains("黑猫"))
            {
                Common.Collections.HmHelper Hm = new Common.Collections.HmHelper();
                var bb = Common.Collections.HmHelper.query_suda7(address);
                SignerCode = bb.suda7_1 != null && bb.suda7_1.Replace("-", "").Length > 5 ? bb.suda7_1.Replace("-", "").Substring(bb.suda7_1.Replace("-", "").Length - 5) : "";
                VersionCode = Common.Collections.HmHelper.VisonNo.egs_version;
                addressCode = Common.Collections.HmHelper.query_suda7(address).suda7_1;

                try
                {
                    Hm.ToEOD(Common.Entity.ftpPaht, true);
                }
                catch (Exception ex)
                {

                    Common.SystemLog.WriteSystemLog(" 补打单EJS", "黑猫EJS推送错误：", ex.Message);
                }
            }
            else if (MDKDCOM.Contains("超峰"))
            {
                Common.Collections.CFHelper Cf = new Common.Collections.CFHelper();
                var zip = Common.Collections.CFHelper.HttpGet(Common.Collections.CFHelper.EdiUrl, address);
                SignerCode = zip.Jm;
                VersionCode = String.Empty;
                addressCode = String.Empty;
            }
            else
            {
                SignerCode = String.Empty;
                VersionCode = String.Empty;
                addressCode = String.Empty;
            }



        }
    }
}
