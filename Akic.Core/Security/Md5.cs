using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Akic.Core.Security
{
    public static partial  class Md5
    {
       /// <summary>
        /// Make MD5 encrypt string
        /// </summary>
        /// <param name="str">will encrypt string</param>
        /// <returns></returns>
        /// USE MD5 METHOD WILL HELP YOU ENCRYPT YOUR STRING
        public static string MD5(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] arr = UTF8Encoding.Default.GetBytes(str);
            byte[] bytes = md5.ComputeHash(arr);
            str = BitConverter.ToString(bytes);
            str = str.Replace("-", "");
            str = str.ToLower();
            return str;
        }
        /// <summary>
        /// replace the last string path 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Path(this string str, string path)
        {
            int index = str.LastIndexOf('\\');
            int indexDian = str.LastIndexOf('.');
            return str.Substring(0, index + 1) + path + str.Substring(indexDian);
        }
        public static List<string> ToList(this string ids)
        {
            List<string> listId = new List<string>();
            if (!string.IsNullOrEmpty(ids))
            {
                var sort = new SortedSet<string>(ids.Split(','));
                foreach (var item in sort)
                {
                    listId.Add(item);

                }
            }
            return listId;
        }
        /// <summary>
        /// Get many id from split "^",first split "^",then   split "&"
        /// </summary>
        /// <param name="ids">first split "^",then   split "&"</param>
        /// <returns></returns>
        public static List<string> GetIdSort(this string ids)
        {

            List<string> listId = new List<string>();
            if (!string.IsNullOrEmpty(ids))
            {
                var sort = new SortedSet<string>(ids.Split('^')
                    .Where(w => !string.IsNullOrWhiteSpace(w) && w.Contains('&'))
                    .Select(s => s.Substring(0, s.IndexOf('&'))));
                foreach (var item in sort)
                {
                    listId.Add(item);
                }
            }
            
            return listId;
        }
        /// <summary>
        /// get a id from split string
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static string GetId(this string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var sort = new SortedSet<string>(ids.Split('^')
                    .Where(w => !string.IsNullOrWhiteSpace(w) && w.Contains('&'))
                    .Select(s => s.Substring(0, s.IndexOf('&'))));
                foreach (var item in sort)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// chance string to dictionaty,than filter null of value,split 6 then 7 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<string, string> StringToDictionary(string value)
        {
            Dictionary<string, string> queryDictionary = new Dictionary<string, string>();
            string[] s = value.Split('^');
            for (int i = 0; i < s.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(s[i]) && !s[i].Contains("undefined"))
                {
                    var ss = s[i].Split('&');
                    if ((!string.IsNullOrEmpty(ss[0])) && (!string.IsNullOrEmpty(ss[1])))
                    {
                        queryDictionary.Add(ss[0], ss[1]);
                    }
                }

            }
            return queryDictionary;
        }
        /// <summary>
        /// get value of tpye of int,defult 0 
        /// </summary>
        /// <param name="Value">Will change value</param>
        /// <returns>if the value can return,true will return object value,otherwise defult 0 </returns>
        public static int GetInt(this object Value)
        {
            return GetInt(Value, 0);
        }
        /// <summary>
        /// get value of tpye of int,defult 0 
        /// </summary>
        /// <param name="Value">Will change value</param>
        /// <returns>if the value can return,true will return object value,otherwise defult 0 </returns>
        public static int GetInt(this object Value, int defaultValue)
        {

            if (Value == null) return defaultValue;
            if (Value is string && Value.GetString().HasValue() == false) return defaultValue;

            if (Value is DBNull) return defaultValue;

            if ((Value is string) == false && (Value is IConvertible) == true)
            {
                return (Value as IConvertible).ToInt32(CultureInfo.CurrentCulture);
            }

            int retVal = defaultValue;
            if (int.TryParse(Value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out retVal))
            {
                return retVal;
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// get value of tpye of int,defult 0 
        /// </summary>
        /// <param name="Value">Will change value</param>
        /// <returns>if the value can return,true will return object value,otherwise defult 0 </returns>
        public static string GetString(this object Value)
        {
            return GetString(Value, string.Empty);
        }
        /// <summary>
        /// Get bool from object,default string.empty
        /// </summary>
        /// <param name="Value">will transfer value</param>
        /// <param name="defaultValue">if failed,return default </param>
        /// <returns>if true ,return object value,otherwise return false</returns>
        public static string GetString(this object Value, string defaultValue)
        {
            if (Value == null) return defaultValue;
            string retVal = defaultValue;
            try
            {
                var strValue = Value as string;
                if (strValue != null)
                {
                    return strValue;
                }

                char[] chrs = Value as char[];
                if (chrs != null)
                {
                    return new string(chrs);
                }

                retVal = Value.ToString();
            }
            catch
            {
                return defaultValue;
            }
            return retVal;
        }
        /// <summary>
        ///  Get DateTime from object,default DateTime.MinValue
        /// </summary>
        /// <param name="Value">will transfer value</param>
        /// <param name="defaultValue">if failed,return default </param>
        /// <returns>if true ,return object value,otherwise return false</returns>
        public static DateTime GetDateTime(this object Value)
        {
            return GetDateTime(Value, DateTime.MinValue);
        }

        /// <summary>
        ///  Get DateTime from object,default DateTime.MinValue
        /// </summary>
        /// <param name="Value">will transfer value</param>
        /// <param name="defaultValue">if failed,return default </param>
        /// <returns>if true ,return object value,otherwise return false</returns>
        public static DateTime GetDateTime(this object Value, DateTime defaultValue)
        {
            if (Value == null) return defaultValue;

            if (Value is DBNull) return defaultValue;

            string strValue = Value as string;
            if (strValue == null && (Value is IConvertible))
            {
                return (Value as IConvertible).ToDateTime(CultureInfo.CurrentCulture);
            }
            if (strValue != null)
            {
                strValue = strValue
                    .Replace("年", "-")
                    .Replace("月", "-")
                    .Replace("日", "-")
                    .Replace("点", ":")
                    .Replace("时", ":")
                    .Replace("分", ":")
                    .Replace("秒", ":")
                      ;
            }
            DateTime dt = defaultValue;
            if (DateTime.TryParse(Value.GetString(), out dt))
            {
                return dt;
            }

            return defaultValue;
        }
        /// <summary>
        /// Get bool from object,default 0
        /// </summary>
        /// <param name="Value">will transfer value</param>
        /// <param name="defaultValue">if failed,return default </param>
        /// <returns>if true ,return object value,otherwise return false</returns>
        public static bool GetBool(this object Value)
        {
            return GetBool(Value, false);
        }

        /// <summary>
        /// Get bool from object,default 0
        /// </summary>
        /// <param name="Value">要转换的值</param>
        /// <param name="defaultValue">if failed,return default </param>
        /// <returns>if true ,return object value,otherwise return false</returns>
        public static bool GetBool(this object Value, bool defaultValue)
        {
            if (Value == null) return defaultValue;
            if (Value is string && Value.GetString().HasValue() == false) return defaultValue;

            if ((Value is string) == false && (Value is IConvertible) == true)
            {
                if (Value is DBNull) return defaultValue;

                try
                {
                    return (Value as IConvertible).ToBoolean(CultureInfo.CurrentCulture);
                }
                catch { }
            }

            if (Value is string)
            {
                if (Value.GetString() == "0") return false;
                if (Value.GetString() == "1") return true;
                if (Value.GetString().ToLower() == "yes") return true;
                if (Value.GetString().ToLower() == "no") return false;
            }
            ///  if (Value.GetInt(0) != 0) return true;
            bool retVal = defaultValue;
            if (bool.TryParse(Value.GetString(), out retVal))
            {
                return retVal;
            }
            else return defaultValue;
        }
        /// <summary>
        /// Check GuidValue whether contain valid value ,defult Guid.Empty 
        /// </summary>
        /// <param name="GuidValue">Will change</param>
        /// <returns>if return ,true return transfervalue ,oherwise return Guid.Empty</returns>
        public static Guid GetGuid(string GuidValue)
        {
            try
            {
                return new Guid(GuidValue);
            }
            catch { return Guid.Empty; }
        }
        /// <summary>
        /// Check GuidValue whether contain valid value ,defult 0
        /// </summary>
        /// <param name="Value"> 传入的值</param>
        /// <returns> whether contain，yes true，otherwise，return false</returns>
        public static bool HasValue(this string Value)
        {
            if (Value != null)
            {
                return !string.IsNullOrEmpty(Value.ToString());
            }
            else return false;
        }

    }

}
