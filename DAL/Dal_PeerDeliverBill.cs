using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;

namespace DAL
{
    public class Dal_PeerDeliverBill
    {
        public bool PeerHandIn(Model.M_PeerDeliverBill.Request S)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
             {
                 return db.Insertable<pmw_PeerDeliverBill>(new pmw_PeerDeliverBill
                        {
                            billcode = S.billcode,
                            CusName = S.KD_com,
                            createTime = DateTime.Now,
                            scan_emp = S.scan_emp,
                            scan_site = S.scan_site
                        }).ExecuteCommand() > 0;
             });

        }
    }
}
