using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_KD_comInfo
    {
        public Model.GeneralReturns KD_comInfo() 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            Model.M_KD_comInfo kdCom = new Model.M_KD_comInfo();
            kdCom.Kd_comInfo = new DAL.Dal_KD_comInfo().KD_comInfo();
            if (kdCom.Kd_comInfo.Count > 0) 
            {
                genRet.ReturnJson = Common.DataHandling.ObjToJson(kdCom);
                genRet.State = true;
            }
            else 
            {
                genRet.MsgText = "获取失败";
            }
            return genRet;
        }
    }
}
