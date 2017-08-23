using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar
{
    public interface IDeleteable<T> where T : class, new()
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
        IDeleteable<T> AS(string tableName);
        /// <summary>
        /// 附加条件
        /// </summary>
        /// <param name="lockString"></param>
        /// <returns></returns>
        IDeleteable<T> With(string lockString);
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="deleteObj"></param>
        /// <returns></returns>
        IDeleteable<T> Where(T deleteObj);
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IDeleteable<T> Where(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="deleteObjs"></param>
        /// <returns></returns>
        IDeleteable<T> Where(List<T> deleteObjs);
        /// <summary>
        /// 包含集合 In
        /// </summary>
        /// <typeparam name="PkType"></typeparam>
        /// <param name="primaryKeyValue"></param>
        /// <returns></returns>
        IDeleteable<T> In<PkType>(PkType primaryKeyValue);
        /// <summary>
        /// 包含集合 In
        /// </summary>
        /// <typeparam name="PkType"></typeparam>
        /// <param name="primaryKeyValues"></param>
        /// <returns></returns>
        IDeleteable<T> In<PkType>(PkType[] primaryKeyValues);
        /// <summary>
        /// 包含集合 In
        /// </summary>
        /// <typeparam name="PkType"></typeparam>
        /// <param name="primaryKeyValues"></param>
        /// <returns></returns>
        IDeleteable<T> In<PkType>(List<PkType> primaryKeyValues);
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="whereString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IDeleteable<T> Where(string whereString,object parameters=null);
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="whereString"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        IDeleteable<T> Where(string whereString, SugarParameter parameter);
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="whereString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IDeleteable<T> Where(string whereString, SugarParameter[] parameters);
        /// <summary>
        /// 条件
        /// </summary>
        /// <param name="whereString"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IDeleteable<T> Where(string whereString, List<SugarParameter> parameters);
        /// <summary>
        /// 返回ORM生成的SQL语句
        /// </summary>
        /// <returns></returns>
        KeyValuePair<string, List<SugarParameter>> ToSql();
    }
}
