using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_PickingStop
    {
        public Model.GeneralReturns PickingStop(Model.M_PickingStop.Request S)
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            if (String.IsNullOrEmpty(S.out_billcode) || String.IsNullOrEmpty(S.oper))
            {
                genRet.MsgText = "运单号为空或操作员为空";
                return genRet;
            }
            bool dbRes = new DAL.Dal_PickingStop().StopPicking(S.out_billcode, S.oper);
            if (dbRes)
            {
                genRet.State = true;
            }
            else
            {
                genRet.MsgText = "终止拣货失败";
            }
            return genRet;
        }
    }
}
