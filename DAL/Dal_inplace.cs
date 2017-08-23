using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;
using SqlSugar;

namespace DAL
{
    public class Dal_inplace
    {
        /// <summary>
        /// 没有有入库记录
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public bool inplaceRecord(Model.M_inplaceRequest S)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
             {
                 return db.Queryable<pmw_billcode, tab_filter>((a, b) => new object[]
                                {
                                    JoinType.Left,
                                    a.kd_billcode==b.kd_billcode
                                })
                     .Where((a, b) => SqlFunc.IsNullToInt(a.is_dd) == 1 && a.kd_billcode == S.billcode && SqlFunc.IsNullOrEmpty(b.kd_billcode))
                     .Any();
             });

        }
        /// <summary>
        /// 单号已发货
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public bool inplaceSendOut(Model.M_inplaceRequest S)
        {

            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Queryable<pmw_billcode>()
                                              .Where(a => a.kd_billcode == S.billcode && SqlFunc.IsNullToInt(a.is_senttohk) == 1)
                                              .Any();
            });

        }
        /// <summary>
        /// 已上架
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public bool Putaway(Model.M_inplaceRequest S)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Queryable<tab_inplace>()
                                              .Where(a => a.billcode == S.billcode)
                                              .Any();

            });
        }
        /// <summary>
        /// 库位存在
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public bool WarehouseLocation(Model.M_inplaceRequest S)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Queryable<pmw_wavehouse>()
                                              .Where(a => a.wavehouse_place_name == S.place_code)
                                              .Any();
            });
        }
        /// <summary>
        /// 上架/盘点
        /// 执行事务更新
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public bool ExecuteInplace(Model.M_inplaceRequest S)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Ado.UseTran(() =>
                {

                    db.Insertable<tab_inplace>(new tab_inplace
                    {
                        wavehouse = S.wavehouse_name,
                        billcode = S.billcode,
                        place_code = S.place_code.ToUpper(),
                        emp = S.emp,
                        create_type = S.in_type,
                        create_time = DateTime.Now
                    })
                    .ExecuteCommand();
                    db.Updateable<pmw_billcode>(new
                    {
                        stock_area = S.place_code.ToUpper(),
                        is_inplace = 1,
                        inplace_time = DateTime.Now,
                        inplace_emp = S.emp
                    })
                    .Where(a => a.kd_billcode == S.billcode && SqlFunc.IsNullToInt(a.is_dd) == 1)
                    .ExecuteCommand();
                }).IsSuccess;
            });


        }


    }
}
