using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_AbnormalPicking
    {
        public Model.GeneralReturns AbnormalPicking(Model.M_AbnormalPicking.Request S)
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            if (String.IsNullOrEmpty(S.site))
            {
                genRet.MsgText = "操作员仓库不能为空";
                return genRet;
            }
            Model.M_AbnormalPicking abnPic = new Model.M_AbnormalPicking();
            abnPic.AbnormalPickingListReturn = new DAL.Dal_AbnormalPicking().AbnormalPickingList(S.site);
            if (abnPic.AbnormalPickingListReturn.Count > 0)
            {
                foreach (var A in abnPic.AbnormalPickingListReturn)
                {
                    A.site = S.site;
                    A.Operator = S.Operator;
                }
                genRet.ReturnJson = Common.DataHandling.ObjToJson(abnPic);
                genRet.State = true;
            }
            return genRet;
        }
    }
}
