using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.LBTable;
using SqlSugar;

namespace DAL
{
    public class Dal_CheckOrderInfo
    {
        /// <summary>
        /// 获取订单标识
        /// </summary>
        /// <param name="billCode"></param>
        /// <returns></returns>
        public pmw_billcode GetOrderIdentify(string billCode)
        {
            return Common.Config.StartSqlSugar<pmw_billcode>((db) =>
            {
                return db.Queryable<pmw_billcode>()
                         .Where(a => a.kd_billcode == billCode)
                         .First();
            });

        }


        /// <summary>
        /// 获取订单总快递数
        /// </summary>
        /// <param name="order_code"></param>
        /// <returns></returns>
        public int GetOrderBillcodeCount(string order_code)
        {
            return Common.Config.StartSqlSugar<int>((db) =>
            {
                return db.Queryable<pmw_billcode>()
                          .Where(a => a.order_code == order_code)
                          .Count();
            });

        }

        /// <summary>
        /// 快递单号被锁单
        /// </summary>
        /// <param name="billCode"></param>
        /// <returns></returns>
        public bool IsLockOrder(string billCode)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Queryable<pmw_billcode>()
                                .Any(a => a.kd_billcode == billCode && SqlFunc.IsNullToInt(a.is_lock) == 1);
            });


        }
        /// <summary>
        /// 订单未审单
        /// </summary>
        /// <param name="order_code"></param>
        /// <returns></returns>
        public bool IsOrderAudit(string order_code)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Queryable<pmw_order>()
                         .Any(a => a.order_code == order_code && SqlFunc.IsNullToInt(a.DoubleCheck) == 0);
            });

        }
        /// <summary>
        /// 是否存在没有打包的
        /// </summary>
        /// <param name="order_code"></param>
        /// <returns></returns>
        public bool IsOutBillcodeCount(string order_code)
        {
            return Common.Config.StartSqlSugar<bool>((db) =>
            {
                return db.Queryable<pmw_billcode>()
                                .Any(a => SqlFunc.IsNullToInt(a.is_packed) == 0 && SqlFunc.IsNullOrEmpty(a.packed_billcode));
            });

        }

        /// <summary>
        /// 获取核单列表
        /// </summary>
        /// <param name="order_code"></param>
        /// <returns></returns>
        public List<Model.M_CheckOrderInfo.Return> CheckOrderInfo(string order_code)
        {
            return Common.Config.StartSqlSugar<List<Model.M_CheckOrderInfo.Return>>((db) =>
            {
                return db.Queryable<pmw_billcode, pmw_order>((a, b) => new object[]
                         {
                             JoinType.Left,
                             a.order_code==b.order_code
                         })
                           .Where(a => a.order_code == order_code && SqlFunc.IsNullToInt(a.is_packed) == 0 && (SqlFunc.IsNullToInt(a.is_lock) == 0 || SqlFunc.IsNullToInt(a.is_lock) == 2) && SqlFunc.IsNullToInt(a.is_apply) == 1 && SqlFunc.IsNullToInt(a.lost_flag) == 0 && SqlFunc.IsNullToInt(a.confirm_order) == 1 && SqlFunc.IsNullToInt(a.is_outplace) == 1)
                           .Select<Model.M_CheckOrderInfo.Return>((a, b) => new Model.M_CheckOrderInfo.Return
                           {
                               kd_billcode = a.kd_billcode,
                               goods = a.goods,
                               kd_com = a.kd_com,
                               username = a.username,
                               OrderWeight = a.dd_weight.ToString(),
                               dd_size = a.dd_size,
                               isSensitive = a.goodsTyep,
                               is_lock = SqlFunc.ToInt32(a.is_lock),
                               stockArea = a.stock_area,
                               OrderId = b.id,
                               cforhm = b.cforhmType,
                               CForHMCusCode = b.CForHMCusCode,
                               country_id = SqlFunc.ToInt32(b.country_id)
                           }).ToList();
            });


        }

        /// <summary>
        /// 获取承运商
        /// </summary>
        /// <param name="country_id"></param>
        /// <returns></returns>
        public List<Model.M_CheckOrderInfo.ReturnCys> GetCysList(int country_id)
        {
            return Common.Config.StartSqlSugar<List<Model.M_CheckOrderInfo.ReturnCys>>((db) =>
            {
                return db.Queryable<Forwarder>()
                          .Where(a => a.country_id == country_id)
                          .Select<Model.M_CheckOrderInfo.ReturnCys>(a => new Model.M_CheckOrderInfo.ReturnCys
                          {
                              country_id = SqlFunc.ToInt32(a.country_id),
                              ForwarderCode = a.ForwarderCode,
                              ForwarderName = a.ForwarderName,
                              id = a.id
                          }).ToList();
            });

        }
    }
}
