using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_ztPriceList
    {
        public Model.GeneralReturns ztPriceList() 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            Model.M_ztPriceList ztPri=new Model.M_ztPriceList();
            ztPri.ztPrice=new DAL.Dal_ztPriceList().ztPriceList();
            if (ztPri.ztPrice.Count > 0)
            {
                genRet.ReturnJson = Common.DataHandling.ObjToJson(ztPri);
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
