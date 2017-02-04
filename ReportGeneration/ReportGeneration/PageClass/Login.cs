using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneration.PageClass
{
    public class Login : PageBase
    {
        public Login()
            : base("CreateProject.xml")
        {

        }


        public Dictionary<string, string> Username
        {
            get
            {
                return GetLocatorValue("Username");
            }
        }


        public Dictionary<string, string> Password
        {
            get
            {
                return GetLocatorValue("Password");
            }
        }
    }
}
