using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class M_IStask
    {
        public class Request 
        {
            [Model.Mode.Mode(Rem = "订单识别号", IsNull = false)]
            public string order_code { get; set; }
        }
    }
}
