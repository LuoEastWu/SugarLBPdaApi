using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.LBTable;

namespace Common
{
    /// <summary>
    /// API客户授权类
    /// </summary>
    public class ClientInfo
    {
        /// <summary>
        /// 内部客户集合
        /// </summary>
        private static List<Model.CusInfo> _client = new List<Model.CusInfo>();
        /// <summary>
        /// 客户集合
        /// </summary>
        public static List<Model.CusInfo> client
        {
            set { _client = value; }
            get
            {
                try
                {
                    if (_client == null || _client.Count == 0)
                    {
                        Common.Config.StartSqlSugar((db) =>
                       {
                           _client = db.Queryable<CusInfo>()
                                      .Where(s1 => s1.State == 0)
                                      .Select<Model.CusInfo>(s1 => new Model.CusInfo()
                                      {
                                          CusID = s1.CusID.ToString(),
                                          CusName = s1.CusName,
                                          KeyText = s1.KeyText,
                                          Count = s1.Count.ToString()
                                      }).ToList();
                       });
                    }
                }
                catch
                {
                    _client = new List<Model.CusInfo>();
                }
                return _client;
            }
        }
        /// <summary>
        /// 根据客户ID获取Key
        /// </summary>
        /// <param name="CusID"></param>
        /// <returns></returns>
        public static string GetKey(string CusID)
        {
            var _Object = new Model.CusInfo();
            try
            {
                if (client.Any(x => x.CusID == CusID))
                {
                    _Object = client.Last(x => x.CusID == CusID);
                }
                else
                {
                    Common.EntityProcess.StartSqlSugar(db =>
                    {
                        _Object = db.Queryable<CusInfo>()
                                .Where(x => x.CusID == SqlFunc.ToInt32(CusID))
                                .Select(x => new Model.CusInfo()
                                {
                                    CusID = x.CusID.ToString(),
                                    CusName = x.CusName,
                                    Count = x.Count.ToString(),
                                    KeyText = x.KeyText
                                }).First();
                        if (_Object != null) { client.Add(_Object); } else { _Object = new Model.CusInfo(); }
                    });
                }
            }
            catch
            {
                return string.Empty;
            }

            return _Object.KeyText;
        }
    }
}
