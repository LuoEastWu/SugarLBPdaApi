using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace PDA_EJEAPI.Controllers
{
    public class CallTestController : Controller
    {
        /// <summary>
        /// 打开初始模板页面
        /// </summary>
        /// <param name="FunctionName"></param>
        /// <returns></returns>
        public ActionResult CallTest(String ControllerName, string FunctionName,String Rem)
        {
            return View("CallTest", new Model.Mode.DataMode.PostMode() { ControllerName = ControllerName, FunctionName = FunctionName,Rem = Rem, CusID = "", JsonData = "", Key = "" });
        }
        /// <summary>
        /// 页面输入参数验证回调
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult CallTest(Model.Mode.DataMode.PostMode model)
        {
            var _object = model;
            if (String.IsNullOrEmpty(model.FunctionName) || String.IsNullOrEmpty(model.ControllerName))
            {
                ModelState.AddModelError("", "未知的函数名称，请返回主页后重新测试！");
                return View(_object);
            }
            if (String.IsNullOrEmpty(model.JsonData))
            {
                ModelState.AddModelError("", "JsonData不能为空");
                return View(_object);
            }
            if (String.IsNullOrEmpty(model.CusID))
            {
                ModelState.AddModelError("", "CusID不能为空");
                return View(_object);
            }
            if (String.IsNullOrEmpty(model.Key))
            {
                ModelState.AddModelError("", "Key不能为空");
                return View(_object);
            }
            if (ModelState.IsValid)
            {
                var _Object = Common.ApiMode.GetNameValueCollection(model);
                _object.KeyMd5 = _Object.GetValues("KeyMd5")[0];
                string Url = string.Empty;
                Url = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/" + model.ControllerName + "/AllTransfer";
                ViewBag.ReturnText = Common.HttpHelper.Send(Url, System.Text.Encoding.UTF8, _Object);
                return View(_object);
            }
            else
            {
                return View(_object);
            }
        }
    }
}
