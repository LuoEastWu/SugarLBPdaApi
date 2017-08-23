using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.LBTable;

namespace DAL
{
    public class Dal_ZTPutaway
    {
        public bool Putaway(Model.M_ZTPutaway.Request S) 
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                db.Deleteable<pmw_ztd_track>(a => a.billcode == S.billcode);
                return db.Insertable<pmw_ztd_track>(new pmw_ztd_track
                  {
                      billcode = S.billcode,
                      scan_emp = S.emp,
                      scan_time = DateTime.Now,
                      scan_type = "自提点入库",
                      scan_memo = "货物到达【" + S.wavehouse_name + "】",
                      scan_site = S.wavehouse_name,
                      next_site = S.place_code
                  }).ExecuteCommand() > 0;
            });
           
        }
    }
}
