using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;
using SqlSugar;

namespace DAL
{
    public class Dal_CheckBillcodeInfo
    {
        public List<Model.M_CheckBillcodeInfo.Return> CheckBillcodeInfo(string billcode)
        {
            return Common.Config.StartSqlSugar<List<Model.M_CheckBillcodeInfo.Return>>((db) =>
            {
                return db.Queryable<pmw_billcode>()
                         .Where(a => a.kd_billcode == billcode)
                         .Select<Model.M_CheckBillcodeInfo.Return>(a => new Model.M_CheckBillcodeInfo.Return
                         {
                             billcodeWeight = a.dd_weight.ToString(),
                             dd_size = a.dd_size,
                             goods = a.goods,
                             kd_com = a.kd_com,
                             username = a.username
                         }).ToList();
            });

        }
    }
}
