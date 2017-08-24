using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Config
    {
        public static string ConnectionString { get; set; }

        /// <summary>
        /// SqlSugar静态执行方法
        /// </summary>
        public static T StartSqlSugar<T>(Func<SqlSugar.SqlSugarClient,T> func)
        {
            using (SqlSugar.SqlSugarClient db = new SqlSugar.SqlSugarClient(new ConnectionConfig 
            {
                ConnectionString = Config.ConnectionString, //必填
                DbType = DbType.SqlServer, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType=InitKeyType.SystemTable
            }))
            {
                return func(db);
            }
        }
        /// <summary>
        /// SqlSugar静态执行方法
        /// </summary>
        public static void StartSqlSugar(Action<SqlSugar.SqlSugarClient> func)
        {
            using (SqlSugar.SqlSugarClient db = new SqlSugar.SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = Config.ConnectionString, //必填
                DbType = DbType.SqlServer, //必填
                IsAutoCloseConnection = true, //默认false
                InitKeyType = InitKeyType.Attribute
            }))
            {
                try
                {
                    func(db);
                }
                catch(Exception ex)
                {
                    Common.SystemLog.WriteSystemLog("SqlSugar", ex.Message);
                }
            }
        }
        public static SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = Config.ConnectionString,
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });
            db.Ado.IsEnableLogEvent = true;
            db.Ado.LogEventStarting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.RewritableMethods.SerializeObject(pars));
                Console.WriteLine();
            };
            return db;
        }
    }
}
