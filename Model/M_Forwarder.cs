using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_Forwarder
    {
        public class Request 
        {

        }
        [Model.Mode.Mode(Rem = "承运商LIst", IsNull = false)]
        public List<Return> ForwarderLiset { get; set; }
        public class Return 
        {
            /// <summary>
            /// 承运商ID
            /// </summary>
           [Model.Mode.Mode(Rem = "承运商ID", IsNull = false)]
            public string id { get; set; }
            /// <summary>
            ///承运商名称
            /// </summary>
           [Model.Mode.Mode(Rem = "承运商名称", IsNull = false)]
            public string ForwarderName { get; set; }
        }
    }
}
