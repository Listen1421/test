using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2参数名ascii码从小到大排序_字典序_拼接
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("nonce_str", "nonce_str1111");
            dic.Add("mch_billno", "mch_billno1111");
            dic.Add("mch_id", "mch_id1111");
            dic.Add("wxappid", "wxappid1111");
            dic.Add("send_name", "send_name1111");
            dic.Add("re_openid", "re_openid1111");
            dic.Add("total_amount", "total_amount1111");
            dic.Add("total_num", "total_num1111");
            dic.Add("wishing", "wishing1111");
            dic.Add("client_ip", "client_ip1111");
            dic.Add("act_name", "act_name1111");
            dic.Add("remark", "remark1111");
            var str = AsciiDicToStr(dic);
            Console.WriteLine(str);
        }
        /// <summary>
        /// c# 参数名ascii码从小到大排序(字典序)拼接
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static string AsciiDicToStr(Dictionary<string, string> dir)
        {
            string[] arrKeys = dir.Keys.ToArray();
            Array.Sort(arrKeys, string.CompareOrdinal);
            var sb = new StringBuilder();
            foreach (var key in arrKeys)
            {
                string value = dir[key];
                sb.Append(key + "=" + value + "&");
            }
            return sb.ToString().Substring(0, sb.ToString().Length - 1);
        }
    }
}
