using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;
using SqlSugar;

namespace DAL
{
    public class Dal_KD_jd
    {

        public pmw_bill_tips billTips(string billcode)
        {
            return Common.Config.StartSqlSugar<pmw_bill_tips>((db) =>
            {
                return db.Queryable<pmw_bill_tips>()
                                .Where(a => a.billcode == billcode)
                                .First();
            });

        }
        /// <summary>
        /// 已交单
        /// </summary>
        /// <param name="billcode"></param>
        /// <returns></returns>
        public bool IsHandBill(string billcode)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Queryable<tab_kd_jd>()
                         .Any(a => a.billcode == billcode);
            });


        }

        /// <summary>
        /// 交单
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public bool DeliveryBillCode(Model.M_KD_jd.Request S)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Insertable<tab_kd_jd>(new tab_kd_jd
                {
                    kd_com = S.KD_com,
                    billcode = S.billcode,
                    emp = S.scan_emp,
                    createtime = DateTime.Now,
                    wavehouse = S.scan_site
                }).ExecuteCommand() > 0;
            });

        }
    }
}
