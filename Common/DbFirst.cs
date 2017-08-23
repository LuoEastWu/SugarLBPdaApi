using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class DbFirst : Base
    {
        /// <summary>
        /// 将库里面所有表都生成实体类文件
        /// </summary>
        /// <param name="MapPath"></param>
        public static void Init(string MapPath)
        {
            var db = Common.Config.GetInstance();
            //Create all class
            db.DbFirst.CreateClassFile(MapPath, "Model.LBTable");
        }
        /// <summary>
        /// 指定名表生成 ，可以传数组
        /// </summary>
        /// <param name="MapPath"></param>
        /// <param name="TableName"></param>
        public static void Init(string MapPath,string TableName)
        {
            var db = Common.Config.GetInstance();
            //Create all class
          
            db.DbFirst.Where(TableName).CreateClassFile(MapPath);
        }
    }
}
