using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleTest
{
    public class BaseSettings
    {
        protected static string GetValue(string xmlPath,string key)
        {
            XmlDocument xmlDoc = GetXmlDoc(xmlPath);
            XmlNodeList settingList = xmlDoc.SelectNodes("/TestSettings/TestSetting");
            foreach(XmlNode valueNode in settingList)
            {
                if(valueNode.FirstChild.Name.Equals(key))
                {
                    return valueNode.FirstChild.InnerText;
                }
            }
            return null;
        }

        protected static XmlDocument GetXmlDoc(string XMLPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(XMLPath);
            return xmlDoc;
        }
    }
}
