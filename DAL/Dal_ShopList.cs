using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.LBTable;

namespace DAL
{
    public class Dal_ShopList
    {
        public List<Model.M_ShopList.Return> ShopList()
        {
            return Common.Config.StartSqlSugar<List<Model.M_ShopList.Return>>((db) =>
            {
                return db.Queryable<TaoBaoInfo>()
                                .Select<Model.M_ShopList.Return>(a => new Model.M_ShopList.Return
                                {
                                    ID = a.ID,
                                    Name = a.Name
                                }).ToList();
            });

        }
    }
}
