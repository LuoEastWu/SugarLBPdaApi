using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_Forwarder
    {
        public Model.GeneralReturns Forwarder()
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            Model.M_Forwarder der = new Model.M_Forwarder();
            der.ForwarderLiset = new DAL.Dal_Forwarder().Forwarder();
            if (der.ForwarderLiset.Count > 0)
            {
                genRet.ReturnJson = Common.DataHandling.ObjToJson(der);
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
