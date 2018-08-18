using System.Configuration;
using System.Web;
namespace Akic.Core.Config
{
    public class Configs
    {
        public static string getValue(string key)
        {
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load(HttpContext.Current.Server.MapPath("~/Config/system.config"));
            System.Xml.XmlNode xNode;
            System.Xml.XmlElement xElem1;
            xNode = xDoc.SelectSingleNode("//appSettings");
            xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + key + "']");
            string str = xElem1.Attributes["value"].InnerText;
            return str;

          
             
        }
    }
}
