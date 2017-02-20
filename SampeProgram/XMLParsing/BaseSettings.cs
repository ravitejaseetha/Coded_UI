using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParsing
{
    class BaseSettings
    {
        protected static string GetValue(string path,string key)
        {
            XmlDocument xml = GetXmlDoc(path);
            XmlNodeList listEle = xml.SelectNodes("/TestSettings/TestSetting");
            foreach(XmlNode ele in listEle)
            {
                if(ele.FirstChild.Name.Equals(key))
                {
                    return ele.FirstChild.InnerText;
                }
            }
            return null;
        }

        protected static XmlDocument GetXmlDoc(string path)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            return xml;
        }
    }
}
