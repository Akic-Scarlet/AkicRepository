using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Akic.Core.ResultHelper
{
    public class ResultHelper
    {

        /// <summary>
        /// 创建一个全球唯一的32位ID
        /// </summary>
        /// <returns>ID串</returns>
        public static string NewId
        {
            get
            {
                string id = DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                string guid = Guid.NewGuid().ToString().Replace("-", "");
                id += guid.Substring(0, 10);
                return id;
            }
        }
        public static DateTime NowTime
        {
            get
            {
                return DateTime.Now;
            }
        }
        public static string NewTimeId
        {
            get
            {
                string id = DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
                return id;
            }
        }
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="length">剩下长度</param>
        /// <returns>指定字符串并加...</returns>
        public static string SubValue(string value, int length)
        {
            if (value.Length > length)
            {
                value = value.Substring(0, length); value = value + "..."; return NoHtml(value);
            }
            else { return NoHtml(value); }
        }
        //还原的时候
        public static string InputText(string inputString)
        {

            if ((inputString != null) && (inputString != String.Empty))
            {
                inputString = inputString.Trim();
                //if (inputString.Length > maxLength) 
                //inputString = inputString.Substring(0, maxLength); 
                inputString = inputString.Replace("<br>", "\n");
                inputString = inputString.Replace("&", "&amp");
                inputString = inputString.Replace("'", "''");
                inputString = inputString.Replace("<", "&lt");
                inputString = inputString.Replace(">", "&gt");
                inputString = inputString.Replace("chr(60)", "&lt");
                inputString = inputString.Replace("chr(37)", "&gt");
                inputString = inputString.Replace("\"", "&quot");
                inputString = inputString.Replace(";", ";");

                return inputString;
            }
            else
            {
                return "";
            }

        }
        //添加的时候
        public static string OutputText(string outputString)
        {

            if ((outputString != null) && (outputString != String.Empty))
            {
                outputString = outputString.Trim();
                outputString = outputString.Replace("&amp", "&");
                outputString = outputString.Replace("''", "'");
                outputString = outputString.Replace("&lt", "<");
                outputString = outputString.Replace("&gt", ">");
                outputString = outputString.Replace("&lt", "chr(60)");
                outputString = outputString.Replace("&gt", "chr(37)");
                outputString = outputString.Replace("&quot", "\"");
                outputString = outputString.Replace(";", ";");
                outputString = outputString.Replace("\n", "<br>");
                return outputString;
            }
            else
            {
                return "";
            }
        }
        #region 去除HTML标记
        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="NoHTML">包括HTML的源码 </param>
        /// <returns>已经去除后的文字</returns>
        public static string NoHtml(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&hellip;", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&mdash;", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&ldquo;", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring = Regex.Replace(Htmlstring, @"&rdquo;", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;

        }
        #endregion
        public static string ChangeDateFormat(DateTime dt)
        { 
            StringBuilder sb=new StringBuilder();
            sb.AppendFormat("{0}/{1}/{2} ", dt.Day.ToString(), dt.Month.ToString(), dt.Year.ToString());

            return sb.ToString();
        }
        #region 格式化文本（防止SQL注入）
        /// <summary>
        /// 格式化文本（防止SQL注入）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Formatstr(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex10 = new System.Text.RegularExpressions.Regex(@"select", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex11 = new System.Text.RegularExpressions.Regex(@"update", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex12 = new System.Text.RegularExpressions.Regex(@"delete", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
            html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
            html = regex4.Replace(html, ""); //过滤iframe
            html = regex10.Replace(html, "s_elect");
            html = regex11.Replace(html, "u_pudate");
            html = regex12.Replace(html, "d_elete");
            html = html.Replace("'", "’");
            html = html.Replace("&nbsp;", " ");
            return html;
        }
        #endregion
    }
}
