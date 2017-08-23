using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar
{
    public interface IUpdateable<T>
    {
        /// <summary>
        /// 执行命令并返回影响行数
        /// </summary>
        /// <returns></returns>
        int ExecuteCommand();
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        IUpdateable<T> AS(string tableName);
        /// <summary>
        /// 附加条件
        /// </summary>
        /// <param name="lockString"></param>
        /// <returns></returns>
        IUpdateable<T> With(string lockString);
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="isNoUpdateNull"></param>
        /// <param name="IsOffIdentity"></param>
        /// <returns></returns>
        IUpdateable<T> Where(bool isNoUpdateNull,bool IsOffIdentity = false);
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IUpdateable<T> Where(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 更新指定列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IUpdateable<T> UpdateColumns(Expression<Func<T, object>> columns);
        /// <summary>
        /// 更新指定列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IUpdateable<T> UpdateColumns(Func<string, bool> updateColumMethod);
        /// <summary>
        /// 更新指定列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IUpdateable<T> UpdateColumns(Expression<Func<T, T>> columns);
        /// <summary>
        /// 忽略指定列
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        IUpdateable<T> IgnoreColumns(Expression<Func<T, object>> columns);
        /// <summary>
        /// 忽略指定列
        /// </summary>
        /// <param name="ignoreColumMethod"></param>
        /// <returns></returns>
        IUpdateable<T> IgnoreColumns(Func<string, bool> ignoreColumMethod);
        /// <summary>
        /// 设置更新列的值
        /// </summary>
        /// <param name="setValueExpression"></param>
        /// <returns></returns>
        IUpdateable<T> ReSetValue(Expression<Func<T, bool>> setValueExpression);
        /// <summary>
        /// 返回ORM生成的SQL语句
        /// </summary>
        /// <returns></returns>
        KeyValuePair<string,List<SugarParameter>> ToSql();
    }
}
