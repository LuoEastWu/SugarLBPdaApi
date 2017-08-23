using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar
{
    public interface IInsertable<T>
    {
        /// <summary>
        /// 执行命令并返回影响行数
        /// </summary>
        /// <returns></returns>
        int ExecuteCommand();
        /// <summary>
        /// 执行命令并返回自增列
        /// </summary>
        /// <returns></returns>
        int ExecuteReutrnIdentity();
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        IInsertable<T> AS(string tableName);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lockString"></param>
        /// <returns></returns>
        IInsertable<T> With(string lockString);
        /// <summary>
        /// 插入列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IInsertable<T> InsertColumns(Expression<Func<T, object>> columns);
        /// <summary>
        /// 插入列
        /// </summary>
        /// <param name="insertColumMethod"></param>
        /// <returns></returns>
        IInsertable<T> InsertColumns(Func<string, bool> insertColumMethod);
        /// <summary>
        /// 过滤列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IInsertable<T> IgnoreColumns(Expression<Func<T, object>> columns);
        /// <summary>
        /// 过滤列
        /// </summary>
        /// <param name="ignoreColumMethod"></param>
        /// <returns></returns>
        IInsertable<T> IgnoreColumns(Func<string,bool> ignoreColumMethod);
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="isInsertNull"></param>
        /// <param name="isOffIdentity"></param>
        /// <returns></returns>
        IInsertable<T> Where(bool isInsertNull, bool isOffIdentity = false);
        /// <summary>
        /// 返回Orm生成的SQL语句
        /// </summary>
        /// <returns></returns>
        KeyValuePair<string, List<SugarParameter>> ToSql();
    }
}
