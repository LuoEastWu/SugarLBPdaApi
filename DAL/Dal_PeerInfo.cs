using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;
using SqlSugar;

namespace DAL
{
    public class Dal_PeerInfo
    {
        public List<Model.M_PeerInfo.Return> PeerInfo() 
        {
            return Common.Config.StartSqlSugar<List<Model.M_PeerInfo.Return>>((db)=>
            {
                return db.Queryable<pmw_CustomerData>()
                                .Select<Model.M_PeerInfo.Return>(a => new Model.M_PeerInfo.Return
                                {
                                    customerName = a.customerName
                                }).ToList();
            });
                                
        }
    }
}
