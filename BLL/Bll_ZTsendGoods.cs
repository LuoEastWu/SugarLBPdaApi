using Model.LBTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_ZTsendGoods
    {
        public Model.GeneralReturns ZTsendGoods(Model.M_ZTsendGoods.Request S)
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            if (string.IsNullOrEmpty(S.out_barcode) || string.IsNullOrEmpty(S.scan_site) || string.IsNullOrEmpty(S.scan_emp) || string.IsNullOrEmpty(S.next_site) || string.IsNullOrEmpty(S.packno))
            {
                genRet.MsgText = "参数不全，请核实";
                return genRet;
            }
            if (new DAL.Dal_ZTsendGoods().IsSendGoods(S.out_barcode))
            {
                genRet.MsgText = "发货单号已经发件不能重复扫描";
            }
            else
            {
                if (S.out_barcode.IndexOf("-") > 0)
                {
                    S.out_barcode = S.out_barcode.Substring(0, S.out_barcode.IndexOf("-"));
                }
                pmw_order orderInfo = new DAL.Dal_ZTsendGoods().SendCompany(S.out_barcode);
                if (orderInfo != null)
                {
                    if (orderInfo.sent_kd_com == S.next_site)
                    {
                        genRet.MsgText = "不是往该自提点";
                    }
                    else
                    {
                        genRet.State = new DAL.Dal_ZTsendGoods().SendWareHouse(S);
                        genRet.MsgText = genRet.State?"":"发货出库失败";
                    }
                }
                else
                {
                    genRet.MsgText = "获取数据失败";
                }
            }
            return genRet;
        }
    }
}
