using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar
{
    public class SqlFunc
    {
        /// <summary>
        /// 大于0并且不等于NULL
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool HasNumber(object thisValue)
        {
            return thisValue.ObjToInt() > 0;
        }
        /// <summary>
        /// 不是NULL并且不是空
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool HasValue(object thisValue)
        {
            return thisValue.IsValuable();
        }
        /// <summary>
        /// 是NULL或者空
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(object thisValue)
        {
            return thisValue.IsNullOrEmpty();
        }
        /// <summary>
        /// 将Null值转换为空文本 注:自己扩展的只适用于SqlServer
        /// </summary>
        /// <param name="thisValud"></param>
        /// <returns></returns>
        public static string IsNullToEmpty(object thisValud)
        {
            return thisValud.IsNullEmpty();
        }
        /// <summary>
        /// 将Null值转换为0  注:自己扩展的只适用于SqlServer
        /// </summary>
        /// <param name="thisValud"></param>
        /// <returns></returns>
        public static Int64 IsNullToInt64(object thisValud)
        {
            return thisValud.IsNullInt64();
        }
        /// <summary>
        /// 将Null值转换为0  注:自己扩展的只适用于SqlServer
        /// </summary>
        /// <param name="thisValud"></param>
        /// <returns></returns>
        public static int IsNullToInt(object thisValud)
        {
            return thisValud.IsNullInt();
        }
        /// <summary>
        /// 将时间字段转换为指定的文本格式  注:自己扩展的只适用于SqlServer
        /// </summary>
        /// <param name="thisValud">要转换的字段</param>
        /// <param name="parameterValue">转换格式</param>
        /// <returns></returns>
        public static string ToDateTime(object thisValud, SqlDateType parameterValue)
        {
            return thisValud.ToDateTime(parameterValue);
        }
        /// <summary>
        /// 转换成小写
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static string ToLower(object thisValue)
        {
            return thisValue == null ? null : thisValue.ToString().ToLower();
        }
        /// <summary>
        /// 转换成大写
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static string ToUpper(object thisValue)
        {
            return thisValue == null ? null : thisValue.ToString().ToUpper();
        }
        /// <summary>
        /// 去除前后空格
        /// </summary>
        /// <param name="thisValue"></param>
        /// <returns></returns>
        public static string Trim(object thisValue)
        {
            return thisValue == null ? null : thisValue.ToString().Trim();
        }
        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static bool Contains(string thisValue, string parameterValue)
        {
            return thisValue.Contains(parameterValue);
        }
        /// <summary>
        /// 包含列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="thisValue"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static bool ContainsArray<T>(T[] thisValue, object parameterValue)
        {
            return thisValue.Contains((T)parameterValue);
        }
        /// <summary>
        /// 模糊查询 like @p%
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static bool StartsWith(string thisValue, string parameterValue)
        {
            return thisValue.StartsWith(parameterValue);
        }
        /// <summary>
        /// 模糊查询 like %@p
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public static bool EndsWith(string thisValue, string parameterValue)
        {
            return thisValue.EndsWith(parameterValue);
        }
        /// <summary>
        /// 等于
        /// </summary>
        /// <param name="thisValue"></param>
        /// <param name="parameterValue"></param>
        /// <returns></returns>
        public new static bool Equals(object thisValue, object parameterValue)
        {
            return thisValue.Equals(parameterValue);
        }
        /// <summary>
        /// 是否是同一天
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static bool DateIsSame(DateTime date1, DateTime date2)
        {
            return date1.ToString("yyyy-MM-dd") == date2.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 是否是同一时间 （dataType 可以是年、月、天、小时、分钟、秒和毫秒）
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static bool DateIsSame(DateTime? date1, DateTime? date2)
        {
            return ((DateTime)date1).ToString("yyyy-MM-dd") == ((DateTime)date2).ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 是否是同一时间 （dataType 可以是年、月、天、小时、分钟、秒和毫秒）
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static bool DateIsSame(DateTime date1, DateTime date2, DateType dataType) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        /// <summary>
        /// 在当前时间加一定时间（dataType 可以是年、月、天、小时、分钟、秒和毫秒）
        /// </summary>
        /// <param name="date"></param>
        /// <param name="addValue"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static DateTime DateAdd(DateTime date, int addValue, DateType dataType) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        /// <summary>
        /// 在当前时间加N天
        /// </summary>
        /// <param name="date"></param>
        /// <param name="addValue"></param>
        /// <returns></returns>
        public static DateTime DateAdd(DateTime date, int addValue) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        /// <summary>
        /// 获取当前时间的年、月、天、小时、分钟、秒或者毫秒
        /// </summary>
        /// <param name="date"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public static int DateValue(DateTime date, DateType dataType) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        /// <summary>
        /// 范围判段
        /// </summary>
        /// <param name="value"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static bool Between(object value, object start, object end) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        /// <summary>
        /// 三元判段 ，相当于 it.id==1?1:2
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="Expression"></param>
        /// <param name="thenValue"></param>
        /// <param name="elseValue"></param>
        /// <returns></returns>
        public static TResult IIF<TResult>(bool Expression, TResult thenValue, TResult elseValue) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        /// <summary>
        /// 转换成int32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt32(object value) { return value.ObjToInt(); }
        /// <summary>
        /// 转换成int64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToInt64(object value) { return Convert.ToInt64(value); }
        /// <summary>
        /// yyyy-MM-dd HH:mm:ss.fff
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDate(object value) { return value.ObjToDate(); }
        /// <summary>
        ///HH:mm:ss 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TimeSpan ToTime(object value) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        /// <summary>
        /// 转换为文本格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(object value) { return value.ObjToString(); }
        /// <summary>
        /// 转换为Decimal格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object value) { return value.ObjToDecimal(); }
        /// <summary>
        /// 转换为Guid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(object value) { return Guid.Parse(value.ObjToString()); }
        /// <summary>
        /// 转换为Double格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(object value) { return value.ObjToMoney(); }
        /// <summary>
        /// 转换为Boolen格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(object value) { return value.ObjToBool(); }
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Substring(object value, int index, int length) { return value.ObjToString().Substring(index, length); }
        /// <summary>
        /// 替换指定字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldChar"></param>
        /// <param name="newChar"></param>
        /// <returns></returns>
        public static string Replace(object value, string oldChar, string newChar) { return value.ObjToString().Replace(oldChar, newChar); }
        /// <summary>
        /// 取长度
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Length(object value) { return value.ObjToString().Length; }
        public static TResult AggregateSum<TResult>(TResult thisValue) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        public static TResult AggregateAvg<TResult>(TResult thisValue) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        public static TResult AggregateMin<TResult>(TResult thisValue) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        public static TResult AggregateMax<TResult>(TResult thisValue) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        public static TResult AggregateCount<TResult>(TResult thisValue) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        public static TResult MappingColumn<TResult>(TResult oldColumnName, string newColumnName) { throw new NotSupportedException("This method is not supported by the current parameter"); }
        /// <summary>
        ///Example: new NewT(){name=SqlFunc.GetSelfAndAutoFill(it)}  Generated SQL   it.*
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TResult GetSelfAndAutoFill<TResult>(TResult value) { throw new NotSupportedException("This method is not supported by the current parameter"); }
    }
}
