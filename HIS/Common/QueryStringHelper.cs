using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Text;
namespace HIS.UI.Common
{
    public class QueryStringHelper
    {
        #region "-- Local Variables / Objects --"
        //'A string of 16 numbers.  {n1, .. , n16} // = 1111111111111111
        private static Byte[] sharedkey = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private static Byte[] sharedvector = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        #endregion

        #region "-- Exposed Methods --"

        /// <summary>
        /// Encrypt Query String
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string EncryptQueryString(Dictionary<string, string> target)
        {
            //Create a List of string type
            List<string> keyValue = new List<string>();

            // Loop through the hash table and populate the keyValue List variable with
            // the key string and value string concatenated
            foreach (string key in target.Keys)
                keyValue.Add(String.Concat(key + "~", target[key]));

            //Convert the keyValues List to Array
            string[] keyValues = keyValue.ToArray();

            //Combine all the items in the array into a single long string concatenated with the "|" character
            string combinedKeyValues = String.Join("|", keyValues);

            //Now Encrypt the string
            string encryptCombinedKeyValues = Encrypt(combinedKeyValues);

            //Return the string
            return encryptCombinedKeyValues;

        }

        public static string GetEncriptedURL(Dictionary<string, string> param, string url)
        {
            return string.Format("{0}?param={1}", url, EncryptQueryString(param));
        }

        /// <summary>
        /// Decrypt Query String
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Dictionary<string, string> DecryptQueryString(string target)
        {
            target = target.Replace(" ", "+");
            //Decrypt the String
            string decryptString = Decrypt(target);

            //Split the string based on the delimiter and convert to array.
            string[] deQueryStringLimiter = { "|" };
            string[] arrayValues = decryptString.Split(deQueryStringLimiter, StringSplitOptions.None);


            //Now populate all items in the array to a Dictionary object after splitting to key value pairs.
            Dictionary<string, string> queryString = new Dictionary<string, string>();

            string[] keyValueLimiter = { "~" };

            //Loop through the arrayValues, split and assign in the Dictionary object.
            foreach (string val in arrayValues)
            {
                string[] keyValues = val.Split(keyValueLimiter, StringSplitOptions.None);
                queryString.Add(keyValues[0], keyValues[1]);
            }

            return queryString;
        }

        /// <summary>
        /// Encrypt Method
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string Encrypt(string val)
        {
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            Byte[] toEncrypt = Encoding.UTF8.GetBytes(val);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, tdes.CreateEncryptor(sharedkey, sharedvector), CryptoStreamMode.Write);

            cs.Write(toEncrypt, 0, toEncrypt.Length);
            cs.FlushFinalBlock();

            return Convert.ToBase64String(ms.ToArray());
        }

        /// <summary>
        /// Decrypt Method
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string Decrypt(string val)
        {
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            Byte[] toDecrypt = Convert.FromBase64String(val);

            MemoryStream ms = new MemoryStream();

            CryptoStream cs = new CryptoStream(ms, tdes.CreateDecryptor(sharedkey, sharedvector), CryptoStreamMode.Write);

            cs.Write(toDecrypt, 0, toDecrypt.Length);
            cs.FlushFinalBlock();

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        #endregion
    }
}