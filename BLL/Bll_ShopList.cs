using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_ShopList
    {
        public Model.GeneralReturns ShopList() 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            Model.M_ShopList sho = new Model.M_ShopList();
            sho.tbiList = new DAL.Dal_ShopList().ShopList();
            if (sho.tbiList.Count > 0)
            {
                genRet.ReturnJson = Common.DataHandling.ObjToJson(sho);
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
