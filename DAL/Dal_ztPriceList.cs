using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;
using SqlSugar;

namespace DAL
{
    public class Dal_ztPriceList
    {
        public List<Model.M_ztPriceList.Return> ztPriceList() 
        {
            return Common.Config.StartSqlSugar<List<Model.M_ztPriceList.Return>>((db)=>
            {
                return db.Queryable<pmw_type_price>()
                                .Select<Model.M_ztPriceList.Return>(a => new Model.M_ztPriceList.Return
                                {
                                    type_name = a.type_name
                                }).ToList();
            });
                                
        }
    }
}
