using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiMapExample
{
    public class Guimap
    {
        private DateTime nowTimeStamp;
        public string id;
        private string name;
        private string xpath;
        private string className;
        private string logicalName;
        private string tagname;
        private string identificationType;
        private string content;
        private string atribute;
        private string css;
        public Guimap()
        {
            //log4net.ThreadContext.Properties["myContext"] = "Logging from GuiMap Class";
            nowTimeStamp = DateTime.Now;
        }

        public DateTime LastUsedTime
        {
            get
            {
                return nowTimeStamp;
            }
            set
            {
                nowTimeStamp = value;
            }
        }
        /// <summary>
        /// Gets or sets the type of the identification.
        /// </summary>
        /// <value>
        /// The type of the identification.
        /// </value>
        public string IdentificationType
        {
            get { return identificationType; }
            set { identificationType = value; }
        }
        /// <summary>
        /// Gets or sets the tagname.
        /// </summary>
        /// <value>
        /// The tagname.
        /// </value>
        public string Tagname
        {
            get { return tagname; }
            set { tagname = value; }
        }

        public string Css
        {
            get { return css; }
            set { css = value; }
        }


        /// <summary>
        /// Gets or sets the name of the logical.
        /// </summary>
        /// <value>
        /// The name of the logical.
        /// </value>
        public string LogicalName
        {
            get { return logicalName; }
            set { logicalName = value; }
        }

        /// <summary>
        /// Gets or sets the name of the class.
        /// </summary>
        /// <value>
        /// The name of the class.
        /// </value>
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Gets or sets the xpath.
        /// </summary>
        /// <value>
        /// The xpath.
        /// </value>
        public string Xpath
        {
            get { return xpath; }
            set { xpath = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public string Atribute
        {
            get { return atribute; }
            set { atribute = value; }
        }
    }
}
