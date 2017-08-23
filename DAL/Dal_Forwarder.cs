using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using Model.LBTable;

namespace DAL
{
    public class Dal_Forwarder
    {
        public List<Model.M_Forwarder.Return> Forwarder()
        {
            return Common.Config.StartSqlSugar<List<Model.M_Forwarder.Return>>((db) =>
            {
                return db.Queryable<Forwarder>()
                                .Select<Model.M_Forwarder.Return>(a => new Model.M_Forwarder.Return
                                {
                                    ForwarderName = a.ForwarderName,
                                    id = a.id.ToString()
                                }).ToList();
            });

        }
    }
}
