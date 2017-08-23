using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class Bll_GetVosionNo
    {
        public Model.M_GetVosionNo.Return GetVosionNo() 
        {
            return new DAL.Dal_GetVosionNo().getVosionNo();
        }
    }
}
