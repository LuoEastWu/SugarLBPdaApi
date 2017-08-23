using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.LBTable;

namespace DAL
{
    public class Dal_Login
    {
        public Model.LoginMode.LoginReturn Login(string userName, string password)
        {
            return Common.Config.StartSqlSugar<Model.LoginMode.LoginReturn>((db) =>
            {
                return db.Queryable<pmw_admin, pmw_house>((a, b) => new object[]
                       {
                           JoinType.Left,a.houseid==b.id
                       })
                      .Where((a, b) => a.username == userName && a.password == password)
                      .Select<Model.LoginMode.LoginReturn>((a, b) => new Model.LoginMode.LoginReturn()
                      {
                          username = a.username,
                          nickname = a.nickname,
                          permission = SqlFunc.IsNullToInt(a.permission),
                          areaCode = a.areaCode,
                          PDA_role = a.PDA_role,
                           house_name = b.house_name,
                          houseid = a.houseid.ToString(),
                          house_type = b.house_type
                      }).First();

            });
        }
    }
}
