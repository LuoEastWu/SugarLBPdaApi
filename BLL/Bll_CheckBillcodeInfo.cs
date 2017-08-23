using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_CheckBillcodeInfo
    {
        public Model.GeneralReturns CheckBillcodeInfo(Model.M_CheckBillcodeInfo.Request S) 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            if (String.IsNullOrEmpty(S.billcode))
            {
                genRet.MsgText = "未获取到快递单号";
                return genRet;
            }
            Model.M_CheckBillcodeInfo che = new Model.M_CheckBillcodeInfo();
            che.cbr = new DAL.Dal_CheckBillcodeInfo().CheckBillcodeInfo(S.billcode);
            if (che.cbr.Count > 0)
            {
                genRet.ReturnJson = Common.DataHandling.ObjToJson(che);
                genRet.State = true;
            }
            else 
            {
                genRet.MsgText = "无法获取";
            }
            return genRet;
        }
    }
}
