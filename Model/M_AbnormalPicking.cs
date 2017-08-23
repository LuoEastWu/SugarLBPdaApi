using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_AbnormalPicking
    {
        public List<Return> AbnormalPickingListReturn { get; set; }
        public class Return
        {
            /// <summary>
            /// 订单运单号
            /// </summary>
            [Model.Mode.Mode(Rem = "订单识别号", IsNull = false)]
            public string billcode { get; set; }
            /// <summary>
            /// 异常提交员
            /// </summary>
            [Model.Mode.Mode(Rem = "异常提交员", IsNull = false)]
            public string AbnormalEmp { get; set; }
            /// <summary>
            /// 操作人
            /// </summary>
            [Model.Mode.Mode(Rem = "操做员工", IsNull = false)]
            public string Operator { get; set; }
            /// <summary>
            /// 仓库
            /// </summary>
           [Model.Mode.Mode(Rem = "仓库", IsNull = false)]
            public string site { get; set; }
        }

       

        public class Request 
        {
           
            /// <summary>
            /// 操作人
            /// </summary>
           [Model.Mode.Mode(Rem = "操作人", IsNull = false)]
            public string Operator { get; set; }
            /// <summary>
            /// 仓库
            /// </summary>
           [Model.Mode.Mode(Rem = "仓库", IsNull = false)]
            public string site { get; set; }
        }
    }
}
