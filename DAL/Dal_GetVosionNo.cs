using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.VosionNo;

namespace DAL
{
    public class Dal_GetVosionNo
    {
        public Model.M_GetVosionNo.Return getVosionNo()
        {

            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = @"user id=yxkd; password=yxkd; initial catalog=AutoUpdateDataBase;Server=120.31.136.99,1500",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });
            db.Ado.IsEnableLogEvent = true;
            db.Ado.LogEventStarting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.RewritableMethods.SerializeObject(pars));
                Console.WriteLine();
            };


         

          return  db.Queryable<Model.VosionNo.Version>()
                     .Where(a => a.soft == "EJE" && a.now == 1)
                     .Select(a => new Model.M_GetVosionNo.Return
                     {
                         geturl = "http://updata.rcominfo.com/EJE/EJEAndroidPDA.apk",
                         vosoin = a.name,
                         Rem = a.text
                     }).First();
            
           
        }
    }
}
