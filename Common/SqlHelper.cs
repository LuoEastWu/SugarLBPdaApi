using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SqlSugar;

namespace Common
{
    /// <summary>
    /// Sql连接帮助类
    /// </summary>
    public static class SqlHelper
    {
        /// <summary>
        /// 数据库地址
        /// </summary>
        public static string SqlAddress = "47.90.48.6";
        /// <summary>
        /// 数据库端口
        /// </summary>
        public static string SqlPort = "1433";
        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string DataName = "EJE";
        /// <summary>
        /// 数据库账号
        /// </summary>
        public static string UserName = "rcominfo";
        /// <summary>
        /// 数据库密码
        /// </summary>
        public static string PassWord = "rcominfo";
        /// <summary>
        /// SqlSugar Orm 框架静态对象
        /// </summary>
        public static String Connectioning = "server=" + SqlAddress + "," + SqlPort + ";Initial Catalog=" + DataName + ";Persist Security Info=True;User ID=" + UserName + ";Password=" + PassWord;
        /// <summary>
        /// Sql连接句柄
        /// </summary>
        public static SqlConnection SqlHand { get; set; }
        /// <summary>
        /// Sql错误信息
        /// </summary>
        public static String SqlErrorText { get; set; }
        /// <summary>
        /// SqlConnectText
        /// </summary>
        private static String SqlConnectText { get; set; }
        /// <summary>
        /// 当前执行行数
        /// </summary>
        public static int SqlNowCount { get; set; }
        /// <summary>
        /// Connect Sql DataBase
        /// </summary>
        /// <param name="ServerIP">SqlServerIP</param>
        /// <param name="Port">SqlPort</param>
        /// <param name="DataBaseName">DataBaseName</param>
        /// <param name="Uid">UserName</param>
        /// <param name="Pwd">PassWord</param>
        /// <returns>ConnectState</returns>
        public static bool ConnectSql(String ServerIP, String Port, String DataBaseName, String Uid, String Pwd)
        {
            if (SqlHand != null)
            {
                if (SqlHand.State == System.Data.ConnectionState.Open)
                {
                    SqlErrorText = string.Empty;
                    return true;
                }
            }
            SqlConnectText = @"user id=" + Uid + "; password=" + Pwd + "; initial catalog=" + DataBaseName + ";Server=" + ServerIP + "," + Port;
            SqlHand = new SqlConnection(SqlConnectText);
            try
            {
                SqlHand.Open();
                if (SqlHand.State == System.Data.ConnectionState.Open)
                {
                    SqlErrorText = string.Empty;
                    return true;
                }
                SqlErrorText = "StateError:" + SqlHand.State.ToString();
                return false;
            }
            catch (Exception ex)
            {
                SqlErrorText = ex.Message;
                return false;
            }
        }
        /// <summary>
        /// 检测Sql连接状态
        /// </summary>
        /// <returns></returns>
        public static bool ConnectSql()
        {
            if (SqlHand != null)
            {
                if (SqlHand.State == System.Data.ConnectionState.Open)
                {
                    SqlErrorText = string.Empty;
                    return true;
                }
            }
            SqlConnectText = SqlConnectText != null ? SqlConnectText : @"user id=" + UserName + "; password=" + PassWord + "; initial catalog=" + DataName + ";Server=" + SqlAddress + "," + SqlPort; ;
            SqlHand = new SqlConnection(SqlConnectText);
            try
            {
                SqlHand.Open();
                if (SqlHand.State == System.Data.ConnectionState.Open)
                {
                    SqlErrorText = string.Empty;
                    return true;
                }
                SqlErrorText = "StateError:" + SqlHand.State.ToString();
                return false;
            }
            catch (Exception ex)
            {
                SqlErrorText = ex.Message;
                return false;
            }
        }
        /// <summary>
        /// 关闭SqlConnect
        /// </summary>
        /// <returns></returns>
        public static bool StopSql()
        {
            if (SqlHand == null)
            {
                SqlErrorText = string.Empty;
                return true;
            }
            if (SqlHand.State != System.Data.ConnectionState.Open)
            {
                SqlErrorText = string.Empty;
                return true;
            }
            try
            {
                SqlHand.Close();
                SqlErrorText = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                SqlErrorText = ex.Message;
                return false;
            }
        }
        /// <summary>
        /// 定义多条执行命令 每次执行一条完毕后的事件委托
        /// </summary>
        public delegate void Executioned(ExecutionedReturn Exe);
        /// <summary>
        /// 查询Sql数据库并返回DataSet
        /// </summary>
        /// <param name="SqlStr">Sql命令字符串</param>
        /// <returns></returns>
        public static DataSet Query(String SqlStr)
        {
            bool ConnectState = false;
            ConnectState = ConnectSql();
            SqlErrorText = ConnectState ? string.Empty : "连接SqlServerError";
            if (!ConnectState) { return null; }
            try
            {
                SqlDataAdapter Orad = new SqlDataAdapter(SqlStr, SqlHand);
                DataSet Ds = new DataSet();
                Orad.Fill(Ds);
                return Ds;
            }
            catch (Exception ex)
            {
                SqlErrorText = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 执行Sql命令并返回影响行数
        /// </summary>
        /// <param name="SqlStr"></param>
        /// <returns></returns>
        public static int Execute(String SqlStr)
        {
            bool ConnectState = false;
            ConnectState = ConnectSql();
            SqlErrorText = ConnectState ? string.Empty : "连接SqlServerError";
            if (!ConnectState) { return 0; }
            try
            {
                SqlCommand OrCmd = new SqlCommand(SqlStr, SqlHand);
                int RowCount = OrCmd.ExecuteNonQuery();
                return RowCount;
            }
            catch (Exception ex)
            {
                SqlErrorText = ex.Message;
                return 0;
            }
        }
        /// <summary>
        /// 执行命令获取Sql数据库第一行第一列
        /// </summary>
        /// <param name="SqlStr"></param>
        /// <returns></returns>
        public static String Getsagin(String SqlStr)
        {
            bool ConnectState = false;
            ConnectState = ConnectSql();
            SqlErrorText = ConnectState ? string.Empty : "连接SqlServerError";
            if (!ConnectState) { return string.Empty; }
            try
            {
                SqlCommand OrCmd = new SqlCommand(SqlStr, SqlHand);
                String RowCount = OrCmd.ExecuteScalar().ToString();
                return RowCount;
            }
            catch (Exception ex)
            {
                SqlErrorText = ex.Message;
                return string.Empty;
            }
        }
        /// <summary>
        /// 执行Sql事物
        /// </summary>
        /// <param name="SqlList">sql集合</param>
        /// <param name="IsError">遇到错误是否继续执行</param>
        /// <param name="Exe">回掉函数</param>
        /// <returns>影响行数</returns>
        public static int Execute_Transaction(System.Collections.ArrayList SqlList, bool IsError, Executioned Exe)
        {
            bool ConnectState = false;
            ConnectState = ConnectSql();
            SqlErrorText =  ConnectState ? string.Empty:"连接SqlServerError";
            if (!ConnectState) { return 0; }
            SqlTransaction oraTact = SqlHand.BeginTransaction();
            SqlCommand oraCmd = new SqlCommand();
            oraCmd.Connection = SqlHand;
            oraCmd.Transaction = oraTact;
            oraCmd.CommandTimeout = 1000;
            SqlNowCount = 0;
            int OkCount = 0;
            foreach (string SqlStr in SqlList)
            {
                oraCmd.CommandText = SqlStr;
                bool State = true;
                try
                {
                    oraCmd.ExecuteNonQuery();
                    SqlErrorText = string.Empty;
                    OkCount += 1;
                }
                catch (Exception ex)
                {
                    State = false;
                    SqlErrorText = ex.Message;
                    if (!IsError) { oraTact.Rollback(); return 0; }
                }
                SqlNowCount += 1;
                if (Exe != null) { Exe(new ExecutionedReturn(State, SqlErrorText, SqlStr, SqlList.Count, SqlNowCount)); }
            }
            oraTact.Commit();
            return OkCount;
        }
        /// <summary>
        /// 利用BCP方法往数据库添加数据
        /// </summary>
        /// <param name="DT"></param>
        /// <param name="TableName"></param>
        /// <param name="TableCellName"></param>
        /// <param name="BcpCellName"></param>
        /// <returns></returns>
        public static bool Execute_Bcp(DataTable DT, String TableName, System.Collections.ArrayList TableCellName, System.Collections.ArrayList BcpCellName)
        {
            bool ConnectState = false;
            ConnectState = ConnectSql();
            SqlErrorText = ConnectState ? string.Empty : "连接SqlServerError";
            if (!ConnectState) { return ConnectState; }
            SqlNowCount = 0;
            using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(SqlHand))
            {
                bcp.SqlRowsCopied += new System.Data.SqlClient.SqlRowsCopiedEventHandler(bcp_SqlRowsCopied);
                bcp.BatchSize = 1000;// 1000;//每次传输的行数
                bcp.NotifyAfter = 100;//进度提示的行数
                bcp.DestinationTableName = TableName;//目标表
                for (int i = 0; i < TableCellName.Count; i++)
                {
                    bcp.ColumnMappings.Add(TableCellName[i].ToString(), BcpCellName[i].ToString());
                }
                try
                {
                    bcp.WriteToServer(DT);
                    return true;

                }
                catch (Exception Ex)
                {
                    SqlErrorText = Ex.Message;
                    return false;
                }
            }
        }
        /// <summary>
        /// 进度显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void bcp_SqlRowsCopied(object sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e)
        {
            SqlNowCount += (int)e.RowsCopied;
        }
    }
    /// <summary>
    /// 执行完毕事件返回类
    /// </summary>
    public class ExecutionedReturn
    {
        /// <summary>
        /// 初始化类
        /// </summary>
        /// <param name="State">状态</param>
        /// <param name="Error">错误</param>
        /// <param name="Sql">命令</param>
        /// <param name="count">总数</param>
        /// <param name="nowcount">当前数</param>
        public ExecutionedReturn(bool State, String Error, String Sql, int count, int nowcount)
        {
            ExecutState = State;
            ErrorText = Error;
            SqlStr = Sql;
            Count = count;
            NowSize = nowcount;
        }
        /// <summary>
        /// 执行结果
        /// </summary>
        public bool ExecutState { set; get; }
        /// <summary>
        /// 错误说明
        /// </summary>
        public String ErrorText { set; get; }
        /// <summary>
        /// 当前命令
        /// </summary>
        public String SqlStr { get; set; }
        /// <summary>
        /// 命令总数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 当前数量
        /// </summary>
        public int NowSize { get; set; }
    }
}
