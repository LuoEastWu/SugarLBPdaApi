using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_wavehouseList
    {
        public Model.GeneralReturns wavehouseList() 
        {
            Model.GeneralReturns genRet = new Model.GeneralReturns();
            Model.M_wavehouse wav = new Model.M_wavehouse();
            wav.houseInfo = new DAL.Dal_wavehouseList().wavehouseList();
            if (wav.houseInfo.Count > 0)
            {
                genRet.State = true;
                genRet.ReturnJson = Common.DataHandling.ObjToJson(wav);
            }
            else 
            {
                genRet.MsgText = "获取失败";
            }
            

            return genRet;
        }
    }
}
