using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;

namespace BLL
{
    public class BllGet_order_detail
    {
        public Model.GeneralReturns GetOrderDetail(Model.M_OffShelf.OffShelfRequest S)
        {

            Model.GeneralReturns genRet = new Model.GeneralReturns();
            if (string.IsNullOrEmpty(S.areaCode) || String.IsNullOrEmpty(S.Operator) || String.IsNullOrEmpty(S.site))
            {
                genRet.MsgText = "拣货员工信息不完整，无法拣货";
                return genRet;
            }
            pmw_order orderInfo = new pmw_order();
            if (String.IsNullOrEmpty(S.OrderID))
            {
                orderInfo = new DAL.DalGet_order_detail().IsPicking(S);
                if (orderInfo == null)
                {
                    pmw_admin adminInfo = new DAL.DalGet_order_detail().GetShopNameIDArray(S.Operator);
                    if (adminInfo == null || String.IsNullOrEmpty(adminInfo.shop_name))
                    {
                        genRet.MsgText = "无法获取员工管理店铺";
                        return genRet;
                    }
                    orderInfo = RegionalPicking(adminInfo.shop_name.Split(','), S.site, S.areaCode);
                    if (orderInfo == null || string.IsNullOrEmpty(orderInfo.order_code))
                    {
                        genRet.MsgText = "没有拣货任务了";
                        return genRet;
                    }
                }

            }
            else
            {
                if (new DAL.DalGet_order_detail().OrderOutBillCodeNotOut(int.Parse(S.OrderID)))
                {
                    new DAL.DalGet_order_detail().UpdateOrderNotOut(int.Parse(S.OrderID), 0);

                }
                orderInfo = new DAL.DalGet_order_detail().OrderIDGetTask(int.Parse(S.OrderID), S.site);
                if ((orderInfo == null || string.IsNullOrEmpty(orderInfo.order_code)) && !new DAL.DalGet_order_detail().IsOutBillCode(int.Parse(S.OrderID)))
                {
                    new DAL.DalGet_order_detail().UpdateOrderNotOut(int.Parse(S.OrderID), 1);
                    genRet.MsgText = "该订单已经下架";
                }
            }

            if (orderInfo != null && !string.IsNullOrEmpty(orderInfo.order_code))
            {
                new DAL.DalGet_order_detail().Release_task(orderInfo.id, S.Operator, 1);
                genRet = GetOrderDetailTask(orderInfo, S.Operator, S.site);
            }
            else
            {
                genRet.MsgText = "无法获取改单号信息";
            }

            return genRet;
        }


        /// <summary>
        /// 按区域拣货
        /// </summary>
        /// <param name="country_id"></param>
        /// <param name="site"></param>
        /// <param name="areaCodeArr"></param>
        /// <returns></returns>
        public pmw_order RegionalPicking(string[] shopNameArray, string site, string areaCodeArr)
        {
            pmw_order orderInfo = new pmw_order();
            foreach (var areaCode in areaCodeArr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                orderInfo = new DAL.DalGet_order_detail().RegionalPicking(shopNameArray, site, areaCode);
                if (orderInfo != null && !string.IsNullOrEmpty(orderInfo.order_code))
                {
                    break;
                }
            }
            return orderInfo;
        }


        /// <summary>
        /// 返回拣货任务
        /// </summary>
        /// <param name="orderInfo"></param>
        /// <returns></returns>
        private Model.GeneralReturns GetOrderDetailTask(pmw_order orderInfo, string operatorName, string site)
        {
            Model.GeneralReturns gr = new Model.GeneralReturns();
            Model.M_OffShelf.OffShelfListRuturn offSheListRet = new Model.M_OffShelf.OffShelfListRuturn();
            offSheListRet.OffShelfRuturn = new DAL.DalGet_order_detail().PickingTask(operatorName, site, orderInfo);

            if (offSheListRet.OffShelfRuturn.Count > 0)
            {
                gr.ReturnJson = Common.DataHandling.ObjToJson(offSheListRet);
                gr.State = true;
            }
            else
            {
                new DAL.DalGet_order_detail().Release_task(orderInfo.id, string.Empty, 0);
                gr.MsgText = "无法获取" + orderInfo.id + "！请重试";
            }
            return gr;


        }
    }
}
