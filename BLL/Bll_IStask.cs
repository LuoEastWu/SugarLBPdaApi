using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_IStask
    {
        public Model.GeneralReturns IStask(Model.M_IStask.Request S) 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            if (string.IsNullOrEmpty(S.order_code))
            {
                genRet.MsgText = "缺少参数";
            }
            else 
            {
                if (new DAL.Dal_IStask().IsTask(S.order_code))
                {
                    genRet.State = true;
                }
                else 
                {
                    genRet.MsgText = "释放任务失败";
                }
            }
            return genRet;

        }
    }
}
