using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_PushMessage
    {
        public class Request 
        {
            /// <summary>
            /// 问题单号
            /// </summary>
           [Model.Mode.Mode(Rem = "问题单号", IsNull = false)]
            public string billcode { get; set; }
            /// <summary>
            /// 错误类型
            /// </summary>
           [Model.Mode.Mode(Rem = "错误类型", IsNull = false)]
            public string ErrorType { get; set; }
            /// <summary>
            /// 操作人
            /// </summary>
            [Model.Mode.Mode(Rem = "操作人", IsNull = false)]
            public string Operation_emp { get; set; }
        }
       
    }
}
