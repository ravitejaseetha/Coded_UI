using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration
{
    public class Guimap
    {

        private DateTime nowTimeStamp;

        private string id;
        private string marked;
        private string xpath;
        private string className;
        private string text;
        private string css;
        private string identificationType;
        private string button;
        private string atribute;
        private string logicalName;
        private string name;


        /// <summary>
        /// Initializes a new instance of the <see cref="Guimap"/> class.
        /// </summary>
        public Guimap()
        {

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
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string LogicalName
        {
            get { return logicalName; }
            set { logicalName = value; }
        }
        /// <summary>
        /// Gets or sets the name of the logical.
        /// </summary>
        /// <value>
        /// The name of the logical.
        /// </value>
        public string Button
        {
            get { return button; }
            set { button = value; }
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
        public string Marked
        {
            get { return marked; }
            set { marked = value; }
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

        public string Css
        {
            get { return css; }
            set { css = value; }
        }

        public string Atribute
        {
            get { return atribute; }
            set { atribute = value; }
        }
    }
}
