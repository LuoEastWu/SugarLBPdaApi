using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 系统日志帮助类
    /// </summary>
    public static class SystemLog
    {
        /// <summary>
        /// 系统日志文件名
        /// </summary>
        public static String LogFileName { get; set; }
        /// <summary>
        /// WriteSystemLog
        /// </summary>
        /// <param name="LogType"></param>
        /// <param name="LogText"></param>
        /// <returns></returns>
        public static bool WriteSystemLog(String LogType, String LogText)
        {
            try
            {
                if (LogFileName == null || LogFileName == string.Empty) { return false; }
                if (!File.Exists(LogFileName))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(LogFileName));
                }
                StreamWriter sw = File.AppendText(LogFileName);
                string w = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + LogType + " " + LogText + "\r\n";
                sw.Write(w);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 系统日志文件名
        /// </summary>
        public static String LogFilePathName { get; set; }

        /// <summary>
        /// WriteSystemLog
        /// </summary>
        /// <param name="LogType"></param>
        /// <param name="LogText"></param>
        /// <returns></returns>
        public static bool WriteSystemLog(string FileStr, String LogTxtName, String LogText)
        {
            try
            {
                if (String.IsNullOrEmpty(FileStr) || String.IsNullOrEmpty(LogTxtName)) { return false; }
                string PathName = LogFilePathName + "记录日志/" + FileStr + "/" + DateTime.Today.ToString("yyyy-MM-dd") + LogTxtName + ".txt";
                if (!File.Exists(PathName))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(PathName));
                }
                StreamWriter sw = File.AppendText(PathName);
                string w = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + LogTxtName + " " + LogText + "\r\n";
                sw.Write(w);
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
