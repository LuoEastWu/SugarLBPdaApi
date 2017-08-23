using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_PeerInfo
    {
        public Model.GeneralReturns PeerInfo() 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            Model.M_PeerInfo pee = new Model.M_PeerInfo();
            pee.PD = new DAL.Dal_PeerInfo().PeerInfo();
            if(pee.PD.Count>0)
            {
                genRet.ReturnJson=Common.DataHandling.ObjToJson(pee);
                genRet.State=true;
            }
            else
            {
                genRet.MsgText="获取失败";
            }
            return genRet;
        }
    }
}
