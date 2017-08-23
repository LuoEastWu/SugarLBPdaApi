using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Entity
    {
        /// <summary>
        /// 接口访问次数——重启刷新
        /// </summary>
        public static long ComeCount { get; set; }
        /// <summary>
        /// SqlSugar Orm 框架静态对象
        /// </summary>
        public static String Connectioning { get; set; }
        /// <summary>
        /// 网站目录路径
        /// </summary>
        public static string ftpPaht { get; set; }
    }
}
