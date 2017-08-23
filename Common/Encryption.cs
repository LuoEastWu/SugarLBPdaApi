using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    /// <summary>
    /// 加密类
    /// </summary>
   public class Encryption
    {
        /// <summary>
        /// 获取字符串MD5值
        /// </summary>
        /// <param name="input">要转换的文本</param>
        /// <returns>Md5值</returns>
        public static string GetMD5Hash(String input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }
            return sBuilder.ToString().ToLower();
        }
    }
}
