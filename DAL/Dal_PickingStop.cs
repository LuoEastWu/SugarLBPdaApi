using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;
using SqlSugar;
namespace DAL
{
    public class Dal_PickingStop
    {
        /// <summary>
        /// 终止拣货
        /// </summary>
        /// <param name="out_barCode"></param>
        /// <param name="scam_emp"></param>
        /// <returns></returns>
        public bool StopPicking(string out_barCode, string scam_emp) 
        {
           return Common.Config.StartSqlSugar<bool>((db) => 
            {
                return db.Ado.UseTran(() =>
                {
                    db.Updateable<pmw_order>(new 
                    {
                        Is_Operator = true,
                        Operator = scam_emp,
                        OperatorTime = DateTime.Now,
                        Abnormal = true,
                        is_task = 0,
                        taskName = string.Empty
                    })
                    .Where(a => a.order_code == out_barCode)
                    .ExecuteCommand();
                    db.Updateable<pmw_billcode>(new 
                    {
                        is_outplace = 0,
                        outplace_emp = string.Empty,
                        outplace_time = ""
                    })
                    .Where(a => a.order_code == out_barCode)
                    .ExecuteCommand();
                }).IsSuccess;
            });
         
        }
    }
}
