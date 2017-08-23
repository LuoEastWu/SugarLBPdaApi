using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Mode;
using Model.LBTable;

namespace Common
{
    /// <summary>
    /// 保存数据类
    /// </summary>
    public class InsertData
    {
        /// <summary>
        /// 保存客户端请求记录并返回Key
        /// </summary>
        /// <param name="Ip"></param>
        /// <returns></returns>
        public static string SaveClientInfo(string Ip,string FunctionName,string CusID,string KeyMd5)
        {
            try
            {
                var _Object = ClientInfo.GetKey(CusID);
                Entity.ComeCount += 1;
                if (Ip.Length > 5)
                {
                    Common.Config.StartSqlSugar((db) => {
                        db.Insertable(new ApiLog()
                        {
                            CusID = CusID,
                            KeyMd5 = KeyMd5,
                            FunctionName = FunctionName,
                            PostTime = DateTime.Now,
                            Address = Ip
                        }).ExecuteCommand();
                    });
                    return _Object;
                }
                return _Object;
            }
            catch
            {
                return string.Empty;
            }

        }
    }
}
