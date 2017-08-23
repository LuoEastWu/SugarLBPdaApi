using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_KD_comInfo
    {
        public class Request 
        {

        }
        public List<Return> Kd_comInfo { get; set; }
        public class Return 
        {
            /// <summary>
            /// 快递公司ID
            /// </summary>
           [Model.Mode.Mode(Rem = "快递公司ID", IsNull = false)]
            public int id { get; set; }
            /// <summary>
            /// 快递公司名称
            /// </summary>
           [Model.Mode.Mode(Rem = "快递公司名称", IsNull = false)]
            public string Kd_com { get; set; }
            /// <summary>
            /// 国家ID
            /// </summary>
            [Model.Mode.Mode(Rem = "国家ID", IsNull = false)]
            public string country_id { get; set; }
            /// <summary>
            /// 简码
            /// </summary>
           [Model.Mode.Mode(Rem = "快递简码", IsNull = false)]
            public string jym { get; set; }
        }
    }
}
