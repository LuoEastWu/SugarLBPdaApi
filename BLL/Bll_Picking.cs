using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_Picking
    {
        public Model.GeneralReturns Picking(Model.M_Picking.Request S) 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            if (string.IsNullOrEmpty(S.out_barcode) || string.IsNullOrEmpty(S.scan_site) || string.IsNullOrEmpty(S.scan_emp))
            {
                genRet.MsgText = "参数不全";
                return genRet;
            }
            if (!new DAL.Dal_Picking().AlreadyOutOrder(S.out_barcode))
            {
                if (!new DAL.Dal_Picking().OrderNotOutBillcode(S.out_barcode))
                {
                    if (new DAL.Dal_Picking().OutOrder(S.out_barcode, S.scan_emp))
                    {
                        genRet.State = true;
                    }
                    else 
                    {
                        new DAL.Dal_Picking().OutOrderLoser(S.out_barcode);
                        genRet.MsgText = "下架失败";
                    }
                }
                else 
                {
                    genRet.MsgText = "快递单未完全下架";
                }
            }
            else 
            {
                genRet.MsgText = "订单已下架";
            }

            return genRet;
        }
    }
}
