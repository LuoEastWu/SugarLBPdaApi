using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.LBTable;

namespace DAL
{
    public class Dal_NumberOffShelf
    {
        /// <summary>
        /// 判断扫描的快递单号是否存在指定任务里
        /// </summary>
        /// <param name="kd_billcode"></param>
        /// <param name="out_barcode"></param>
        /// <returns></returns>
        public bool IsThereTask(string kd_billcode, string out_barcode)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                var outba = db.Queryable<pmw_billcode>()
                             .Any(a => a.kd_billcode == kd_billcode && a.order_code == out_barcode);
                if (!outba)
                {
                    var orderInfo = db.Queryable<pmw_order>()
                                      .Where(a => a.id == SqlFunc.IsNullToInt64(out_barcode))
                                      .First();
                    outba= db.Queryable<pmw_billcode>()
                             .Any(a => a.kd_billcode == kd_billcode && a.order_code == orderInfo.order_code);

                }
                return outba;
            });

        }
        /// <summary>
        /// 快递单号已下架
        /// </summary>
        /// <param name="kd_billcode"></param>
        /// <returns></returns>
        public bool IsBillcodeOut(string kd_billcode)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Queryable<pmw_billcode>()
                         .Any(a => a.kd_billcode == kd_billcode && SqlFunc.IsNullToInt(a.is_outplace) == 1);

            });

        }
        /// <summary>
        /// 执行下架
        /// </summary>
        /// <param name="kd_billcode"></param>
        /// <param name="scan_emp"></param>
        /// <returns></returns>
        public bool ExecuteBillCodeOut(String kd_billcode, string scan_emp)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Updateable<pmw_billcode>()
                         .UpdateColumns(a => new pmw_billcode()
                         {
                             is_outplace = 1,
                             outplace_time = DateTime.Now,
                             outplace_emp = scan_emp,
                             is_lock = 0
                         })
                         .Where(a => a.kd_billcode == kd_billcode && SqlFunc.IsNullToInt(a.is_inplace) == 1)
                         .ExecuteCommand() > 0;
            });

        }

    }
}
