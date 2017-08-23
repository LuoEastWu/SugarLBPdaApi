using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Mode
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class ReturnClass: Attribute
    {
        /// <summary>
        /// 返回类型
        /// </summary>
        public Type Type { get; set;}
        /// <summary>
        /// 说明
        /// </summary>
        public String Rem { get; set; }
        public ReturnClass(Type Type,String Rem)
        {
            this.Type = Type;
            this.Rem = Rem;
        }
    }
    [AttributeUsage(AttributeTargets.Class,Inherited =true)]
    public class ModeClassAttribute:Attribute
    {
        /// <summary>
        /// 注释说明
        /// </summary>
        public String Rem { get; set; }
        public ModeClassAttribute(String Rem)
        {
            this.Rem = Rem;
        }
    }
    [AttributeUsage(AttributeTargets.Property,Inherited = true)]
    public class ModeAttribute :Attribute
    {
        /// <summary>
        /// 显示名称 可空
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 注释说明
        /// </summary>
        public String Rem { get; set; }
        /// <summary>
        /// 是否可空
        /// </summary>
        public Boolean IsNull { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public String Type { get; set; }
    }
}
