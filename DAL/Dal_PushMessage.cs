using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;
using SqlSugar;

namespace DAL
{
    public class Dal_PushMessage
    {
        /// <summary>
        /// 推送锁定快递
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public bool ProblemInset(Model.M_PushMessage.Request S)
        {
            return Common.Config.StartSqlSugar<bool>((db) => 
            {
                return db.Ado.UseTran(() =>
                {
                    db.Insertable<PushMessage>(new PushMessage
                    {
                        billcode = S.billcode,
                        CreationTime = DateTime.Now,
                        Inspection = 0,
                        ErrorType = S.ErrorType,
                        Operation_emp = S.Operation_emp
                    })
                    .ExecuteCommand();
                    db.Updateable<pmw_billcode>(new 
                    {
                        is_lock = 1
                    })
                    .Where(a => a.kd_billcode == S.billcode)
                    .ExecuteCommand();
                }).IsSuccess;
            });
          
        }
    }
}
