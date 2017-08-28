using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PDA_LBApi
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
            Common.Entity.ftpPaht = Server.MapPath("~/");
            Common.Entity.SocketPaht = Server.MapPath("~/") + @"Config.ini";
            Common.SystemLog.LogFileName = Common.Entity.ftpPaht + @"ApiLog.txt";
            Common.Config.ConnectionString = string.Format("server={0},{1};Initial Catalog={2};Persist Security Info=True;User ID={3};Password={4}",
                                                       ConfigurationManager.AppSettings["SqlAddress"],
                                                       ConfigurationManager.AppSettings["SqlPort"],
                                                       ConfigurationManager.AppSettings["DataName"],
                                                       ConfigurationManager.AppSettings["UserName"],
                                                       ConfigurationManager.AppSettings["PassWord"]);
        }
    }
}