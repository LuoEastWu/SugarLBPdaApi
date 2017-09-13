using Model.LBTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_CheckOrderInfo
    {
        public Model.GeneralReturns CheckOrderInfo(Model.M_CheckOrderInfo.Request S) 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            if (String.IsNullOrEmpty(S.billcode))
            {
                genRet.MsgText = "缺少参数";
                return genRet;
            }
            pmw_billcode billCodeInfo=new DAL.Dal_CheckOrderInfo().GetOrderIdentify(S.billcode);
            if (billCodeInfo != null && !string.IsNullOrEmpty(billCodeInfo.order_code))
            {
                Model.M_CheckOrderInfo che = new Model.M_CheckOrderInfo();
                che.coir = new DAL.Dal_CheckOrderInfo().CheckOrderInfo(billCodeInfo.order_code);
                if (che.coir.Count > 0)
                {
                    if (new DAL.Dal_CheckOrderInfo().GetOrderBillcodeCount(billCodeInfo.order_code)>=che.coir.Count)
                    {
                        che.cysList = new DAL.Dal_CheckOrderInfo().GetCysList(che.coir[0].country_id);
                        genRet.ReturnJson = Common.DataHandling.ObjToJson(che);
                        genRet.State = true;
                    }
                    else 
                    {
                        genRet.MsgText = "未捡完货，不能打包";
                    }
                    
                }
                else 
                {
                    if (new DAL.Dal_CheckOrderInfo().IsLockOrder(S.billcode))
                    {
                        genRet.MsgText = "快递单号已被锁";
                    }
                    else 
                    {
                        if (new DAL.Dal_CheckOrderInfo().IsOrderAudit(billCodeInfo.order_code))
                        {
                            genRet.MsgText = "未审单";
                        }
                        else 
                        {
                            if (new DAL.Dal_CheckOrderInfo().IsOutBillcodeCount(billCodeInfo.order_code))
                            {
                                genRet.MsgText = "无法获取快递单信息";
                            }
                            else 
                            {
                                genRet.MsgText = "没有需要打包的快递单号";
                            }
                        }
                    }
                }
            }
            else 
            {
                genRet.MsgText = "请输入正确的快递单号";
            }
            return genRet;
            

        }
    }
}
