using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;

namespace Common
{
    /// <summary>
    /// 添加请求数据
    /// </summary>
    public class AddRequestData
    {
        /// <summary>
        /// 保存客户端请求记录并返回Key
        /// </summary>
        /// <param name="Ip"></param>
        /// <returns></returns>
        public static string SaveClientInfo(string Ip, string FunctionName, string CusID, string KeyMd5)
        {
            try
            {
                var _Object =Common.ClientInfo.GetKey(CusID);
                 Entity.ComeCount += 1;
                if (Ip.Length > 5)
                {
                    Common.Config.GetInstance().Insertable<ApiLog>(new ApiLog()
                    {
                        CusID = CusID,
                        KeyMd5 = KeyMd5,
                        FunctionName = FunctionName,
                        PostTime = DateTime.Now
                    });
                    
                    return _Object;
                }
                return _Object;
            }
            catch (Exception ex)
            {
                Common.SystemLog.WriteSystemLog(" 客户端请求记录并返回Key错误信息：", ex.Message);
                return string.Empty;
            }

        }

      
    }
}
