using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.LBTable;

namespace DAL
{
    public class Dal_Print
    {
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public pmw_order getOrderInfo(long id)
        {
            return Common.Config.StartSqlSugar<pmw_order>((db) =>
            {
                return db.Queryable<pmw_order>()
                         .Where(a => a.id == id)
                         .First();
            });


        }

        /// <summary>
        /// 获取快递表信息
        /// </summary>
        /// <param name="kd_billcode"></param>
        /// <returns></returns>
        public List<pmw_billcode> getBillcodeInfo(List<string> kd_billcode)
        {
            return Common.Config.StartSqlSugar<List<pmw_billcode>>((db) =>
            {
                return db.Queryable<pmw_billcode>()
                         .In(a => a.kd_billcode, kd_billcode)
                         .ToList();
            });
        }

        /// <summary>
        /// 获取会员信息
        /// </summary>
        /// <param name="member_id"></param>
        /// <returns></returns>
        public pmw_member getMemberInfo(long member_id)
        {
            return Common.Config.StartSqlSugar<pmw_member>((db) =>
            {
                return db.Queryable<pmw_member>()
                         .Where(a => a.id == member_id)
                         .First();
            });
        }
        /// <summary>
        /// 获取店铺信息
        /// </summary>
        /// <param name="shopId"></param>
        /// <returns></returns>
        public TaoBaoInfo getShopInfo(long shopId)
        {
            return Common.Config.StartSqlSugar<TaoBaoInfo>((db) =>
            {
                return db.Queryable<TaoBaoInfo>()
                         .Where(a => a.ID == shopId)
                         .First();
            });


        }
        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns></returns>
        public pmw_house getHouseInfo(long houseId)
        {
            return Common.Config.StartSqlSugar<pmw_house>((db) =>
                   {
                       return db.Queryable<pmw_house>()
                                .Where(a => a.id == houseId)
                                .First();
                   });
        }

        /// <summary>
        /// 获取航班时效
        /// </summary>
        /// <param name="FlightId"></param>
        /// <returns></returns>
        public pmw_timeBar getFlightTime(long FlightId)
        {
            return Common.Config.StartSqlSugar<pmw_timeBar>((db) =>
            {
                return db.Queryable<pmw_timeBar>()
                         .Where(a => a.id == FlightId)
                         .First();
            });

        }
        /// <summary>
        /// 获取货物类型信息
        /// </summary>
        /// <param name="goodsName"></param>
        /// <returns></returns>
        public GoodsCatalog getGoodsTypeInfo(string billcode)
        {
            return Common.Config.StartSqlSugar((db) =>
            {
                return db.Queryable<GoodsCatalog>()
                .Where((a) => a.goodsName == billcode)
                .First();
            });

        }


        /// <summary>
        /// 取余数客户名称
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string getRecipientName(String recipien, long orderID)
        {
            String recipienname = String.Empty;
            var countNum = Common.Config.StartSqlSugar<int>((db) =>
            {
                return db.Queryable<CFHMPring>()
                         .Where(x => x.OrderID == orderID)
                         .Count() + 1;
            });
            string[] sArray = recipien.Trim().Split(new string[] { ",", "，", " ", "，", "   " }, StringSplitOptions.RemoveEmptyEntries);
            int remainder = countNum % sArray.Count();
            recipienname = remainder == 0 ? sArray[sArray.Count() - 1] : sArray[remainder - 1];
            return recipienname;
        }

        /// <summary>
        /// 获取打印配置
        /// </summary>
        /// <param name="sentCompany"></param>
        /// <returns></returns>
        public PrintConfig getPrinConfig(string sentCompany)
        {
            return Common.Config.StartSqlSugar<PrintConfig>((db) =>
            {
                return db.Queryable<PrintConfig>()
                         .Where(a => a.pjCom == sentCompany)
                         .First();
            });


        }
        /// <summary>
        /// 获取派件公司信息
        /// </summary>
        /// <param name="sentCompany"></param>
        /// <param name="printConfigCode"></param>
        /// <returns></returns>
        public Forwarder getForwarderCode(string sentCompany, string printConfigCode)
        {
            return Common.Config.StartSqlSugar<Forwarder>((db) =>
            {
                return db.Queryable<Forwarder>()
                         .Where(a => a.ForwarderName == sentCompany && a.ForwarderCode == printConfigCode)
                         .First();
            });

        }

        private object lockQueryNo = new object();
        /// <summary>
        /// 获取打印号信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Forwarder_number getPrintNo(long id)
        {
            lock (lockQueryNo)
            {
                return Common.Config.StartSqlSugar<Forwarder_number>((db) =>
                {
                    return db.Ado.UseTran<Forwarder_number>(() =>
                    {
                        var forderInfo = db.Queryable<Forwarder_number>()
                                           .Where(a => a.ForwarderID == id && SqlFunc.IsNullToInt(a.is_Use) == 0)
                                           .OrderBy(a => a.num)
                                           .First();
                        db.Updateable<Forwarder_number>(new
                        {
                            is_Use = 1
                        })
                        .Where(a => a.ForwarderID == id && a.num == forderInfo.num)
                        .ExecuteCommand();
                        return forderInfo;
                    }).Data;
                });
            }
        }

        /// <summary>
        /// 释放承运商单号
        /// </summary>
        /// <param name="id"></param>
        public void ReleaseForwarder_number(Forwarder_number forNumInfo) 
        {
            Common.Config.StartSqlSugar((db) => 
            {
                db.Updateable<Forwarder_number>(new
                {
                    is_Use = 1
                })
                .Where(a => a.ForwarderID == forNumInfo.id && a.num == forNumInfo.num)
                .ExecuteCommand();
            });
          
        }

        /// <summary>
        /// 返回剩余单号数量
        /// </summary>
        /// <param name="ForwardingID"></param>
        /// <returns></returns>
        public int getForwardingAgentNoCount(long ForwardingID)
        {
            return Common.Config.StartSqlSugar<int>((db) =>
             {
                 return db.Queryable<Forwarder_number>()
                          .Where(a => SqlFunc.IsNullToInt(a.is_Use) == 0 && a.ForwarderID == ForwardingID)
                          .Count();
             });
        }

        /// <summary>
        /// 记录打单数据
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <param name="orderSentBillCode"></param>
        /// <param name="orderSentCompany"></param>
        /// <param name="recipients"></param>
        /// <param name="houserInfo"></param>
        /// <param name="tbInfo"></param>
        /// <param name="forwarderInfo"></param>
        /// <param name="billCoderList"></param>
        /// <param name="goodsName"></param>
        /// <param name="S"></param>
        /// <param name="printNo"></param>
        /// <returns></returns>
        public bool Print(pmw_order orderInfo, string orderSentBillCode, string orderSentCompany, string recipients, pmw_house houserInfo, TaoBaoInfo tbInfo, Forwarder forwarderInfo, string[] billCoderList, string goodsName, Model.M_Print.Request S, string printNo, double weightBillcode)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Ado.UseTran(() =>
                {
                    db.Insertable<pmw_Print>(new pmw_Print
                    {
                        address = orderInfo.address,
                        orderID = orderInfo.id,
                        operateMan = S.operateMan,
                        operateSiteID = SqlFunc.ToInt32(S.operateSite),
                        operateTime = DateTime.Now,
                        WaybillNo = printNo,
                        z_weight = SqlFunc.ToDecimal(weightBillcode)
                    }).ExecuteCommand();
                    db.Insertable<pmw_track>(new pmw_track
                    {
                        billcode = printNo,
                        scan_time = DateTime.Now,
                        scan_type = "拣货完成",
                        scan_memo = "拣货完毕,快件已拣货完毕,正在打包",
                        scan_site = houserInfo.house_name,
                        scan_emp = S.operateMan
                    }).ExecuteCommand();

                    db.Updateable<pmw_billcode>(new
                    {
                        is_packed = 1,
                        packed_time = DateTime.Now,
                        packed_emp = S.operateMan,
                        packed_billcode = printNo,
                        packed_code = forwarderInfo.ForwarderCode,
                        packed_kd_com = forwarderInfo.ForwarderName,
                        printID = forwarderInfo.id,
                        is_Big = S.is_Big
                    })
                    .Where(a => SqlFunc.ContainsArray(billCoderList, a.kd_billcode) && a.order_code == orderInfo.order_code && (SqlFunc.IsNullToInt(a.is_lock) == 0 || SqlFunc.IsNullToInt(a.is_lock) == 2))
                    .ExecuteCommand();

                    db.Updateable<pmw_order>(new
                    {
                        is_sented = 1,
                        sent_emp = S.operateMan,
                        sent_time = DateTime.Now,
                        sent_kd_billcode = orderSentBillCode,
                        sent_kd_com = orderSentCompany
                    })
                    .Where(a => a.id == orderInfo.id)
                    .ExecuteCommand();

                    db.Insertable<CFHMPring>(new CFHMPring
                    {
                        CForHM_number = printNo,
                        OrderID = orderInfo.id,
                        freightPayable = SqlFunc.ToDecimal(orderInfo.agencyFund),
                        goods = goodsName.ToString(),
                        recipients = recipients,
                        consignee = recipients,
                        recipientsAdd = orderInfo.address,
                        recipientsPhone = orderInfo.mobile,
                        recipientsIDCard = orderInfo.RecipientCode,
                        TurnNumber = billCoderList.Length,
                        Order_Notes = orderInfo.order_memo,
                        consolidator = tbInfo.Name,
                        deliveryCom = forwarderInfo.ForwarderName,
                        deliveryCode = forwarderInfo.ForwarderCode,
                        billNumType = "PDA",
                        CFpacked_time = DateTime.Now,
                        CFpacked_billcode = printNo,
                        CFpacked_code = forwarderInfo.ForwarderCode,
                        CFpacked_emp = S.operateMan,
                        CFpacked_kd_com = forwarderInfo.ForwarderName,
                        KD_billcodeList = string.Join(",", billCoderList),
                        houseID = houserInfo.id,
                        houseName = houserInfo.house_name,
                        netWeight = SqlFunc.ToDecimal(weightBillcode)
                    }).ExecuteCommand();
                }).IsSuccess;
            });



        }

        /// <summary>
        /// 转仓
        /// </summary>
        /// <param name="shopName">店铺名称</param>
        /// <param name="transfe_house">转仓仓库</param>
        /// <param name="printNo">打印单号</param>
        /// <param name="transfe_emp">转仓操作人</param>
        /// <param name="house_name">转出仓</param>
        /// <param name="weight">打印快递单重量和</param>
        public void transfer(string shopName, string transfe_house, string printNo, string transfe_emp, string house_name, double weight)
        {

            Common.Config.StartSqlSugar((db) =>
            {
                db.Insertable<pmw_transfer>(new pmw_transfer
                  {
                      store = shopName,
                      billcode = printNo,
                      storehouse = transfe_house,
                      CreationTime = DateTime.Now,
                      Airlines_emp = transfe_emp,
                      RollOutHouse = house_name,
                      transferType = "黑猫或超峰",
                      PutStorage_weight = SqlFunc.ToDecimal(weight)
                  });
            });


        }


        /// <summary>
        /// 补单获取快递单信息
        /// </summary>
        /// <param name="kd_billcode"></param>
        /// <returns></returns>
        public pmw_billcode SupplementGetBillCodeInfo(string kd_billcode)
        {

            return Common.Config.StartSqlSugar<pmw_billcode>((db) =>
           {
               return db.Queryable<pmw_billcode>()
                        .Where(a => a.kd_billcode == kd_billcode)
                        .First();
           });


        }

        /// <summary>
        /// 补单获取快递单信息
        /// </summary>
        /// <param name="kd_billcode"></param>
        /// <returns></returns>
        public List<pmw_billcode> SupplementGetBillCodeListInfo(string packed_billcode)
        {
            return Common.Config.StartSqlSugar<List<pmw_billcode>>((db) =>
            {
                return db.Queryable<pmw_billcode>()
                         .Where(a => a.packed_billcode == packed_billcode)
                         .ToList();
            });

        }

        /// <summary>
        /// 补单获取订单信息
        /// </summary>
        /// <param name="order_code"></param>
        /// <returns></returns>
        public pmw_order SupplementGetOrderInfo(string order_code)
        {
            return Common.Config.StartSqlSugar<pmw_order>((db) =>
            {
                return db.Queryable<pmw_order>()
                         .Where(a => a.order_code == order_code)
                         .First();
            });

        }
        /// <summary>
        /// 获取打单信息
        /// </summary>
        /// <param name="packed_billcode"></param>
        /// <returns></returns>
        public CFHMPring SupplementGetPrintInfo(string packed_billcode)
        {
            return Common.Config.StartSqlSugar<CFHMPring>((db) =>
            {
                return db.Queryable<CFHMPring>()
                         .Where(a => a.CForHM_number == packed_billcode)
                         .First();
            });

        }
    }
}
