using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Medical.Synchronization
{
    public class TripleDes
    {
        /// <summary>
        /// Mã hóa ký tự với kiểu mã hõa TripleDes - MD5
        /// </summary>
        /// <param name="key"></param>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public static string Encode(string key, string toEncrypt)
        {
            byte[] preKeyArray = UTF8Encoding.UTF8.GetBytes("Medical.Synchronization");
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("Medical.Synchronization" + key));
            Array.Resize<byte>(ref preKeyArray, keyArray.Length);
            keyArray.CopyTo(preKeyArray, preKeyArray.Length - keyArray.Length);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = preKeyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        /// <summary>
        /// Giải mã dữ liệu đã mã hóa
        /// </summary>
        /// <param name="key"></param>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        public static string Decode(string key, string toDecrypt)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);
                byte[] preKeyArray = UTF8Encoding.UTF8.GetBytes("Medical.Synchronization");

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("Medical.Synchronization" + key));
                Array.Resize<byte>(ref preKeyArray, keyArray.Length);
                keyArray.CopyTo(preKeyArray, preKeyArray.Length - keyArray.Length);

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = preKeyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                if (toEncryptArray.Length == 0) return string.Empty;
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(
                toEncryptArray, 0, toEncryptArray.Length);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
