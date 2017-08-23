using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL
{
    public class Bll_PeerDeliverBill
    {
        public Model.GeneralReturns PeerDeliverBill(Model.M_PeerDeliverBill.Request S) 
        {
            Model.GeneralReturns gr = new Model.GeneralReturns();
            if (String.IsNullOrEmpty(S.billcode) || String.IsNullOrEmpty(S.KD_com) || String.IsNullOrEmpty(S.scan_emp) || String.IsNullOrEmpty(S.scan_site))
            {
                gr.MsgText = "缺少必要参数";
                return gr;
            }

            if (new Regex("^[0-9]*$").IsMatch(S.billcode))
            {
                if (new DAL.Dal_PeerDeliverBill().PeerHandIn(S))
                {
                    gr.State = true;
                }
                else
                {
                    gr.MsgText = "无法交单";
                }
            }
            else 
            {
                gr.MsgText = "请输入正确的单号";
            }
           
            return gr;
        }
    }
}
