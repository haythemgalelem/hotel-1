using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;

namespace Common
{
    /// <summary>
    /// 模块:Common
    /// 作用:密码处理
    /// 作者:phq
    /// 日期:2011-12-28
    /// </summary>
    public class Cryptography
    {
        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        #region SHA1加盐加密
        /// <summary>
        /// 获取加盐的散列值
        /// </summary>
        /// <param name="paraTohash">要HASH的字符</param>
        /// <returns></returns>
        public static string GetSaltedHash(string paraTohash)
        {
            if (paraTohash == null || paraTohash == "")
            {
                throw new HotelException(@"GetSaltedHash的参数不能为NULL或""");
            }
            string salt = "kdfjelkreroogk;,1kdfj,wj,,,mk23j23kj23fgoihgfpslk;jf";
            string strToHash = salt + paraTohash;
            byte[] strBytes = Encoding.Default.GetBytes(strToHash);
         
            SHA1CryptoServiceProvider shaHash = new SHA1CryptoServiceProvider();
            byte[] hash = shaHash.ComputeHash(strBytes);
            return Convert.ToBase64String(hash);
        }

        #endregion

        #region Des加密、解密
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串 </returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));//转换为字节
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();//实例化数据加密标准
                MemoryStream mStream = new MemoryStream();//实例化内存流
                //将数据流链接到加密转换的流
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        #endregion
    }
}
