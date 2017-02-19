using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParser
{
    class Program
    {
        static void Main(string[] args)
        {

            var directory = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\TestResults\\");
            var myFile = (from f in directory.GetFiles()
                          orderby f.LastWriteTime descending
                          select f).First();
            XmlDocument xml = new XmlDocument();
            var filename = Directory.GetCurrentDirectory() + "\\TestResults\\" + myFile.Name;
            xml.Load(filename); //myXmlString is the xml file in string //copying xml to string: string myXmlString = xmldoc.OuterXml.ToString();
            XmlNodeList elemList = xml.GetElementsByTagName("TestMethod");
            for (int i = 0; i < elemList.Count; i++)
            {
                if (!elemList[i].Attributes["className"].Value.Contains(','))
                {
                    elemList[i].Attributes["className"].Value = elemList[i].Attributes["className"].Value + ",";
                }

            }
            xml.Save(filename);
        }
    }

}
