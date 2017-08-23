using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_AbnormalPickingList
    {
        public Model.GeneralReturns AbnormalPickingList(Model.M_AbnormalPickingList.Request S) 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            if (string.IsNullOrEmpty(S.out_barcode)) 
            {
                genRet.MsgText = "缺少参数";
                return genRet;
            }
            Model.M_AbnormalPickingList abnPic = new Model.M_AbnormalPickingList();
            abnPic.OffShelfRuturn = new DAL.Dal_AbnormalPickingList().AbnormalPickingList(S.out_barcode);
            if (abnPic.OffShelfRuturn.Count > 0)
            {
                genRet.ReturnJson = Common.DataHandling.ObjToJson(abnPic);
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
