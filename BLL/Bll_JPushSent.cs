using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_JPushSent
    {
        public Model.GeneralReturns JPushSent(Model.JPushMode S)
        {
            Model.GeneralReturns gr = new Model.GeneralReturns();
            if (S.MsgType > 2)
            {
                gr.MsgText = "消息类型错误";
            }
            else
            {
                if (S.PhoneType > 2)
                {
                    gr.MsgText = "手机类型错误";
                }
                else
                {
                    gr.State = true;
                    if (S.Type <= 1)
                    {
                        gr.ReturnJson =SendPush(S.MsgType, S.MsgTitle, S.MsgText, S.Uid, S.TageType, S.PhoneType);
                    }
                    else
                    {
                        gr.ReturnJson = SendPushMsg(S.MsgType, S.MsgTitle, S.MsgText, S.Uid, S.TageType, S.PhoneType);
                    }
                }
            }

            return gr;
        }



        /// <summary>
        /// 极光推送消息
        /// </summary>
        /// <param name="type">0:发送给设备的所有用户 1: //发送给设备用户ID为888的用户（如果发给多个ID，可以用“,”号隔开，如“888,999,000”，限制在1000个以内. 2.发送给类别为Level8的用户  </param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="Uid">用户id 或类型</param>
        /// <param name="AndroidIso">0 所有类型 1 android 2 ios</param>
        /// <returns></returns>
        public static string SendPush(int type, String title, String content, List<String> Uid, String TageType, int AndroidIso)
        {
            string result = "";  //返回结果  
            string app_key = "3613c5922bd40904c3464b2b";
            string master_secret = "778551c5e604ca480a5da524";
            int time_to_live = 86400;   //生存周期，单位为秒  
            string os = "android|ios";
            switch (AndroidIso)
            {
                case 0:
                    os = "android|ios";
                    break;
                case 1:
                    os = "android";
                    break;
                case 2:
                    os = "ios";
                    break;
            }
            String Uids = string.Empty;
            foreach (var s in Uid)
            {
                Uids += Uids == string.Empty ? s : "," + s;
            }
            JPush.JPushClient client = new JPush.JPushClient(app_key, master_secret, time_to_live);

            switch (type)
            {
                case 0: //发送给设备的所有用户  
                    result = client.sendNotificationByAppkey(9, "des", title, content, os, "", "");
                    break;
                case 1: //发送给设备用户ID为888的用户（如果发给多个ID，可以用“,”号隔开，如“888,999,000”，限制在1000个以内，具体官方文档有说明）  
                    result = client.sendNotificationByAlias(Uids, 9, "des", title, content, os, "", "");
                    break;
                case 2: //发送给类别为Level8的用户  
                    result = client.sendNotificationByTag(TageType, 9, "des", title, content, os, "", "");
                    break;
            }

            return result;
        }


        /// <summary>
        /// 极光推送自定义消息
        /// </summary>
        /// <param name="type">0:发送给设备的所有用户 1: //发送给设备用户ID为888的用户（如果发给多个ID，可以用“,”号隔开，如“888,999,000”，限制在1000个以内. 2.发送给类别为Level8的用户  </param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="Uid">用户id 或类型</param>
        /// <param name="AndroidIso">0 所有类型 1 android 2 ios</param>
        /// <returns></returns>
        public static string SendPushMsg(int type, String title, String content, List<String> Uid, String TageType, int AndroidIso)
        {
            string result = "";  //返回结果  
            string app_key = "3613c5922bd40904c3464b2b";
            string master_secret = "778551c5e604ca480a5da524";
            int time_to_live = 86400;   //生存周期，单位为秒  
            string os = "android|ios";
            switch (AndroidIso)
            {
                case 0:
                    os = "android|ios";
                    break;
                case 1:
                    os = "android";
                    break;
                case 2:
                    os = "ios";
                    break;
            }
            String Uids = string.Empty;
            foreach (var s in Uid)
            {
                Uids += Uids == string.Empty ? s : "," + s;
            }
            JPush.JPushClient client = new JPush.JPushClient(app_key, master_secret, time_to_live);
            switch (type)
            {
                case 0:
                    result = client.sendCustomMesByAppkey(9, "des", title, content, os, "", "");
                    break;
                case 1:
                    result = client.sendCustomMesByAlias(Uids, 9, "des", title, content, os, "", "");
                    break;
                case 2:
                    result = client.sendCustomMesByTag(TageType, 9, "des", title, content, os, "", "");
                    break;

            }
            return result;
        }
    }
}
