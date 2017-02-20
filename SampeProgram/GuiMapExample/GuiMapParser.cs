using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GuiMapExample
{
    class GuiMapParser
    {
        public const string id = "id";
        public const string name = "name";
        public const string xpath = "xpath";
        public const string classname = "class";
        public const string tagname = "tagname";
        public const string xmlNodePath = "/ObjectRepository/FeatureSet";
        public const string content = "content";
        public const string atribute = "atribute";
        public const string css = "css";

        public Dictionary<string,Guimap> LoadGuimap(string file)
        {
            XmlDocument xml = new XmlDocument();
            Guimap guimap = null;
            Dictionary<string, Guimap> guiObjCollection = null;
            guiObjCollection = new Dictionary<string, Guimap>();
            xml.Load(file);
            XmlNodeList rootNode = xml.DocumentElement.SelectNodes(xmlNodePath);
            foreach(XmlNode node in rootNode)
            {
                XmlNodeList list = node.ChildNodes;
                foreach(XmlNode child in list)
                {
                    guimap = new Guimap();
                    string logicalName = child.Attributes["name"].InnerText;
                    string identificationType = child.FirstChild.Name;
                    string elementValue = child.FirstChild.InnerText;
                    guimap.LogicalName = logicalName;
                    switch(identificationType.ToLower())
                    {
                        case id: guimap.IdentificationType = identificationType;
                            guimap.id = elementValue;
                            if(!guiObjCollection.ContainsKey(guimap.LogicalName))
                            {
                                guiObjCollection.Add(guimap.LogicalName, guimap);
                            }
                            continue;

                            case name:
                                    guimap.IdentificationType = identificationType;
                                    guimap.Name = elementValue;
                                    //Add the logical name and GUIMap to the Object Collection
                                    if (!guiObjCollection.ContainsKey(guimap.LogicalName))
                                    {
                                        guiObjCollection.Add(guimap.LogicalName, guimap);
                                    }
                                    continue;
                                case xpath:
                                    guimap.IdentificationType = identificationType;
                                    guimap.Xpath = elementValue;
                                    //Add the logical name and GUIMap to the Object Collection
                                    if (!guiObjCollection.ContainsKey(guimap.LogicalName))
                                    {
                                        guiObjCollection.Add(guimap.LogicalName, guimap);
                                       // guiObjCollection1.Add(filename, guiObjCollection);
                                    }
                                    continue;
                                case classname:
                                    guimap.IdentificationType = identificationType;
                                    guimap.ClassName = elementValue;
                                    //Add the logical name and GUIMap to the Object Collection
                                    if (!guiObjCollection.ContainsKey(guimap.LogicalName))
                                    {
                                        guiObjCollection.Add(guimap.LogicalName, guimap);
                                    }
                                    continue;
                                case tagname:
                                    guimap.IdentificationType = identificationType;
                                    guimap.Tagname = elementValue;
                                    //Add the logical name and GUIMap to the Object Collection
                                    if (!guiObjCollection.ContainsKey(guimap.LogicalName))
                                    {
                                        guiObjCollection.Add(guimap.LogicalName, guimap);
                                    } continue;
                                case content:
                                    guimap.IdentificationType = identificationType;
                                    guimap.Content = elementValue;
                                    //Add the logical name and GUIMap to the Object Collection
                                    if (!guiObjCollection.ContainsKey(guimap.LogicalName))
                                    {
                                        guiObjCollection.Add( guimap.LogicalName, guimap);
                                    }
                                    continue;
                                case atribute:
                                    guimap.IdentificationType = identificationType;
                                    guimap.Atribute = elementValue;
                                    //Add the logical name and GUIMap to the Object Collection
                                    if (!guiObjCollection.ContainsKey(guimap.LogicalName))
                                    {
                                        guiObjCollection.Add( guimap.LogicalName, guimap);
                                    }
                                    continue;
                                case css:
                                    guimap.IdentificationType = identificationType;
                                    guimap.Css = elementValue;
                                    //Add the logical name and GUIMap to the Object Collection
                                    if (!guiObjCollection.ContainsKey(guimap.LogicalName))
                                    {
                                        guiObjCollection.Add(guimap.LogicalName, guimap);
                                    }
                                    continue;
                    }

                }
            }
            return guiObjCollection;
        }

    }
}
