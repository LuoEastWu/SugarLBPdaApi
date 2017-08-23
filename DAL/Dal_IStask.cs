using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.LBTable;

namespace DAL
{
    public class Dal_IStask
    {
        public bool IsTask(string order_code)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Updateable<pmw_order>(new pmw_order
                {
                    is_task = 0,
                    taskName = String.Empty
                })
                                  .Where(a => a.order_code == order_code).ExecuteCommand() > 0;
            });



        }
    }
}
