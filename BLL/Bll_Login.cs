using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_Login
    {
        public Model.GeneralReturns Login(Model.LoginMode.LoginRequest S) 
        {
            Model.GeneralReturns gr = new Model.GeneralReturns();
            if (String.IsNullOrEmpty(S.Uid) || String.IsNullOrEmpty(S.Pwd))
            {
                gr.MsgText = "用户名或密码为空";
                return gr;
            }
           Model.LoginMode.LoginReturn loginRet= new DAL.Dal_Login().Login(S.Uid,Common.DataHandling.GetMD5Hash(Common.DataHandling.GetMD5Hash(S.Pwd)));
           if (loginRet == null)
           {
               gr.MsgText = "用户名或密码错误";
           }
           else if (string.IsNullOrEmpty(loginRet.username) || string.IsNullOrEmpty(loginRet.nickname))
           {
               gr.MsgText = "无法获取用户名";
           }
           else 
           {
               gr.ReturnJson = Common.DataHandling.ObjToJson(loginRet);
               gr.State = true;
           }
            return gr;
        }
    }
}
