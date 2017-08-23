using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_ZTPutaway
    {
        public Model.GeneralReturns ZTPutaway(Model.M_ZTPutaway.Request S) 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            if (string.IsNullOrEmpty(S.place_code) || string.IsNullOrEmpty(S.billcode) || string.IsNullOrEmpty(S.emp) || string.IsNullOrEmpty(S.wavehouse_name))
            {
                genRet.MsgText = "参数不全，请核实";
            }
            else 
            {
                genRet.State = new DAL.Dal_ZTPutaway().Putaway(S);
                genRet.MsgText = "上架失败";
            }
            return genRet;
        }
    }
}
