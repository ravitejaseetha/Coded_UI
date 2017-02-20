using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLPractice
{
    public class BaseSettings
    {
           protected static string GetValue(string path,string key)
            {
                XmlDocument xmlfile = GetXml(path);
                XmlNodeList eleList = xmlfile.SelectNodes("/TestSettings/TestSetting");
                foreach(XmlNode ele in eleList)
                {
                    if(ele.FirstChild.Name.Equals(key))
                    {
                        return ele.FirstChild.InnerText;
                    }
                }
               return null;

            }

            protected static XmlDocument GetXml(string path)
           {
               XmlDocument xml = new XmlDocument();
               xml.Load(path);
               return xml;
           }
        }
}
