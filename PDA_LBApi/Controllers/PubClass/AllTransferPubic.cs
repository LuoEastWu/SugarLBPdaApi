using System;
using System.Reflection;
using System.Web.Mvc;
using Model.Mode;
using System.Linq;
using Common;

namespace Controllers
{
    /// <summary>
    /// API 基类 请勿修改 新的控制器类请继承该类
    /// </summary>
    public class AllTransferPubic : Controller
    {
        /// <summary>
        /// 通用JsonP接口
        /// </summary>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AllTransfer_JsonP(String FunctionName, string JsonData, string CusID, string KeyMd5)
        {
            return new JSONPResult { Data = AllTransfer(FunctionName, JsonData, CusID, KeyMd5) };
        }

        /// <summary>
        /// 通用的Post接口
        /// </summary>
        /// <param name="FunctionName"></param>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [HttpPost]
        public string AllTransfer(String FunctionName, string JsonData, string CusID, string KeyMd5)
        {
            Model.GeneralReturns Now_RetObject = new Model.GeneralReturns();
            Now_RetObject.State = false;
            try
            {
                if (FunctionName == null || FunctionName == string.Empty)
                {
                    Now_RetObject.MsgText = "错误的FunctionName";
                }
                else
                {
                    MethodInfo Mt = this.GetType().GetMethod(FunctionName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    if (Mt == null || Mt.GetParameters().Count() != 1)
                    {
                        Now_RetObject.MsgText = "错误的FunctionName";
                    }
                    else
                    {
                        Type NowType = Mt.GetParameters()[0].ParameterType;
                        var Obj = EntityProcess.CheckPostData(Request, NowType, FunctionName, JsonData, CusID, KeyMd5);
                        Now_RetObject = Obj.ReturnMode;
                        if (Now_RetObject.State)
                        {
                            Now_RetObject = (Model.GeneralReturns)Mt.Invoke(System.Activator.CreateInstance(this.GetType()), new object[] { Obj.JsonObject });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Now_RetObject.MsgText = ex.Message;
            }
            return HttpHelper.ObjToJson(Now_RetObject);
        }

        /// <summary>
        /// 通用的GET接口
        /// </summary>
        /// <param name="FunctionName"></param>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [HttpGet]
        public string AllTransfer_Get(String FunctionName, string JsonData, string CusID, string KeyMd5)
        {
            return AllTransfer(FunctionName, JsonData, CusID, KeyMd5);
        }

        /// <summary>
        /// 通用Options接口
        /// </summary>
        /// <param name="FunctionName"></param>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [HttpOptions]
        public string AllTransfer_Options(String FunctionName, string JsonData, string CusID, string KeyMd5)
        {
            return AllTransfer(FunctionName, JsonData, CusID, KeyMd5);
        }

        /// <summary>
        /// 通用Patch接口
        /// </summary>
        /// <param name="FunctionName"></param>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [HttpPatch]
        public string AllTransfer_Patch(String FunctionName, string JsonData, string CusID, string KeyMd5)
        {
            return AllTransfer(FunctionName, JsonData, CusID, KeyMd5);
        }

        /// <summary>
        /// 通用Delete接口
        /// </summary>
        /// <param name="FunctionName"></param>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [HttpDelete]
        public string AllTransfer_Delete(String FunctionName, string JsonData, string CusID, string KeyMd5)
        {
            return AllTransfer(FunctionName, JsonData, CusID, KeyMd5);
        }

        /// <summary>
        /// 通用Put接口
        /// </summary>
        /// <param name="FunctionName"></param>
        /// <param name="JsonData"></param>
        /// <param name="CusID"></param>
        /// <param name="KeyMd5"></param>
        /// <returns></returns>
        [HttpPut]
        public string AllTransfer_Put(String FunctionName, string JsonData, string CusID, string KeyMd5)
        {
            return AllTransfer(FunctionName, JsonData, CusID, KeyMd5);
        }
    }
}