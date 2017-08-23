using System.Web.Mvc;
/// <summary>
/// JsonP对象
/// </summary>
public class JSONPResult : JsonResult
{
    /// <summary>
    /// 新的对象
    /// </summary>
    public JSONPResult()
    {
        JsonRequestBehavior = JsonRequestBehavior.AllowGet;
    }
    /// <summary>
    /// 回掉函数
    /// </summary>
    public string Callback { get; set; }
    ///<summary>
    ///对操作结果进行处理
    ///</summary>
    ///<paramname="context"></param>
    public override void ExecuteResult(ControllerContext context)
    {
        var httpContext = context.HttpContext;
        var callBack = Callback;
        if (string.IsNullOrWhiteSpace(callBack))
            callBack = httpContext.Request["callback"]; //获得客户端提交的回调函数名称
        // 返回客户端定义的回调函数
        httpContext.Response.Write(callBack + "(");
        httpContext.Response.Write(Data);          //Data 是服务器返回的数据        
        httpContext.Response.Write(");");            //将函数输出给客户端，由客户端执行
    }
}