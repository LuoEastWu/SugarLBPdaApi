using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugar
{
    public enum SqlDateType
    {
        /// <summary>
        /// 05 16 2006 10:57AM
        /// </summary>
        Date_0 = 0,
        /// <summary>
        /// 05/16/06
        /// </summary>
        Date_1 = 1,
        /// <summary>
        /// 06.05.16
        /// </summary>
        Date_2 = 2,
        /// <summary>
        /// 16/05/06
        /// </summary>
        Date_3 = 3,
        /// <summary>
        /// 16.05.06
        /// </summary>
        Date_4 = 4,
        /// <summary>
        /// 16-05-06
        /// </summary>
        Date_5 = 5,
        /// <summary>
        /// 16 05 06
        /// </summary>
        Date_6 = 6,
        /// <summary>
        /// 05 16, 06
        /// </summary>
        Date_7 = 7,
        /// <summary>
        /// 10:57:46
        /// </summary>
        Date_8 = 8,
        /// <summary>
        /// 05 16 2006 10:57:46:827AM
        /// </summary>
        Date_9 = 9,
        /// <summary>
        /// 05-16-06
        /// </summary>
        Date_10 = 10,
        /// <summary>
        /// 06/05/16
        /// </summary>
        Date_11 = 11,
        /// <summary>
        /// 060516
        /// </summary>
        Date_12 = 12,
        /// <summary>
        /// 16 05 2006 10:57:46:937
        /// </summary>
        Date_13 = 13,
        /// <summary>
        /// 10:57:46:967
        /// </summary>
        Date_14 = 14,
        /// <summary>
        /// 2006-05-16 10:57:47
        /// </summary>
        Date_20 = 20,
        /// <summary>
        /// 2006-05-16 10:57:47.157
        /// </summary>
        Date_21 = 21,
        /// <summary>
        /// 05/16/06 10:57:47 AM
        /// </summary>
        Date_22 = 22,
        /// <summary>
        /// 2006-05-16
        /// </summary>
        Date_23 = 23,
        /// <summary>
        /// 10:57:47
        /// </summary>
        Date_24 = 24,
        /// <summary>
        /// 2006-05-16 10:57:47.250
        /// </summary>
        Date_25 = 25,
        /// <summary>
        /// 05 16 2006 10:57AM
        /// </summary>
        Date_100 = 100,
        /// <summary>
        /// 05/16/2006
        /// </summary>
        Date_101 = 101,
        /// <summary>
        /// 2006.05.16
        /// </summary>
        Date_102 = 102,
        /// <summary>
        /// 16/05/2006
        /// </summary>
        Date_103 = 103,
        /// <summary>
        /// 16.05.2006
        /// </summary>
        Date_104 = 104,
        /// <summary>
        /// 16-05-2006
        /// </summary>
        Date_105 = 105,
        /// <summary>
        /// 16 05 2006
        /// </summary>
        Date_106 = 106,
        /// <summary>
        /// 05 16, 2006
        /// </summary>
        Date_107 = 107,
        /// <summary>
        /// 10:57:49
        /// </summary>
        Date_108 = 108,
        /// <summary>
        /// 05 16 2006 10:57:49:437AM
        /// </summary>
        Date_109 = 109,
        /// <summary>
        /// 05-16-2006
        /// </summary>
        Date_110 = 110,
        /// <summary>
        /// 2006/05/16
        /// </summary>
        Date_111 = 111,
        /// <summary>
        /// 20060516
        /// </summary>
        Date_112 = 112,
        /// <summary>
        /// 16 05 2006 10:57:49:513
        /// </summary>
        Date_113 = 113,
        /// <summary>
        /// 10:57:49:547
        /// </summary>
        Date_114 = 114,
        /// <summary>
        /// 2006-05-16 10:57:49
        /// </summary>
        Date_120 = 120,
        /// <summary>
        /// 2006-05-16 10:57:49.700
        /// </summary>
        Date_121 = 121,
        /// <summary>
        /// 2006-05-16T10:57:49.827
        /// </summary>
        Date_126 = 126,
        /// <summary>
        /// 18 ???? ?????? 1427 10:57:49:907AM
        /// </summary>
        Date_130 = 130,
        /// <summary>
        /// 18/04/1427 10:57:49:920AM
        /// </summary>
        Date_131 = 131
    }
}
