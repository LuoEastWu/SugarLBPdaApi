using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.LBTable;
namespace DAL
{
    public class Dal_ZTsendGoods
    {
        /// <summary>
        /// 已发货
        /// </summary>
        /// <param name="out_barCode"></param>
        /// <returns></returns>
        public bool IsSendGoods(string out_barCode)
        {
           return Common.Config.StartSqlSugar<bool>((db)=>
           {
               return db.Queryable<pmw_track_fj>()
                         .Any(a => a.billcode == out_barCode);
           });
                         
        }
        /// <summary>
        /// 获取发货公司
        /// </summary>
        /// <param name="out_barCode"></param>
        /// <returns></returns>
        public pmw_order SendCompany(string out_barCode) 
        {
            return Common.Config.StartSqlSugar<pmw_order>((db)=>
            {
                return db.Queryable<pmw_order>()
                                .Where(a => a.sent_kd_billcode == out_barCode)
                                .First();
            });
                                
        }

        /// <summary>
        /// 发货出库
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public bool SendWareHouse(Model.M_ZTsendGoods.Request S) 
        {
            return Common.Config.StartSqlSugar<bool>((db) => 
            {
                return db.Ado.UseTran(() =>
                {

                    db.Insertable<pmw_track_fj>(new pmw_track_fj
                    {
                        billcode = S.out_barcode,
                        scan_time = DateTime.Now,
                        scan_type = "发件",
                        scan_emp = S.scan_emp,
                        next_site = S.next_site,
                        scan_site = S.scan_site,
                        packno = S.packno
                    })
                    .ExecuteCommand();
                    db.Updateable<pmw_billcode>(new 
                    {
                        is_senttohk = 1,
                        senttohk_time = DateTime.Now,
                        senttohk_emp = S.scan_emp
                    })
                    .Where(a => a.packed_billcode == S.out_barcode)
                    .ExecuteCommand();
                    db.Updateable<pmw_order>(new 
                    {

                        is_senttohk = 1,
                        senttohk_time = DateTime.Now,
                        senttohk_emp = S.scan_emp
                    })
                    .Where(a => a.sent_kd_billcode == S.out_barcode)
                    .ExecuteCommand();
                }).IsSuccess;
            });
         
        }
    }
}
