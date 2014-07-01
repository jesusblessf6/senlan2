using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Utility.Misc
{
    public class Encrypt
    {
        public static string Encode(string input)
        {
            const string encryptkey = "SRMS"; //密钥
            var desc = new DESCryptoServiceProvider(); //des进行加密
            byte[] key = Encoding.Unicode.GetBytes(encryptkey);
            byte[] data = Encoding.Unicode.GetBytes(input);
            var ms = new MemoryStream(); //存储加密后的数据
            var cs = new CryptoStream(ms, desc.CreateEncryptor(key, key), CryptoStreamMode.Write);
            cs.Write(data, 0, data.Length); //进行加密
            cs.FlushFinalBlock();
            string strRtn = Convert.ToBase64String(ms.ToArray());
            return strRtn;
        }
    }
}