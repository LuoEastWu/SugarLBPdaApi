using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.LBTable;

namespace DAL
{
    public class Dal_wavehouseList
    {
        public List<Model.M_wavehouse.Return> wavehouseList() 
        {
            return Common.Config.StartSqlSugar<List<Model.M_wavehouse.Return>>((db) => 
            {
                return db.Queryable<pmw_house>()
                         .Select<Model.M_wavehouse.Return>(a => new Model.M_wavehouse.Return
                         {
                             ID = a.id.ToString(),
                             house_name = a.house_name,
                             house_type = a.house_type
                         }).ToList();
            });
                         
        }
    }
}
