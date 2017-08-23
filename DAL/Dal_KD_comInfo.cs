using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;
using SqlSugar;
namespace DAL
{
    public class Dal_KD_comInfo
    {
        public List<Model.M_KD_comInfo.Return> KD_comInfo() 
        {
            return Common.Config.StartSqlSugar<List<Model.M_KD_comInfo.Return>>((db)=>
            {
                return  db.Queryable<pmw_kd_com>()
                                .Select<Model.M_KD_comInfo.Return>(a => new Model.M_KD_comInfo.Return
                                {
                                    country_id =a.country_id.ToString(),
                                    id =SqlFunc.ToInt32(a.id),
                                    jym = a.jym,
                                    Kd_com = a.kd_com
                                }).ToList();
            });
                               
        }
    }
}
