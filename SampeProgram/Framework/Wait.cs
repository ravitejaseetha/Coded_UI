using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Wait
    {
        public WebControlUtility thisWebDriver;
        public Wait(WebControlUtility webDriver)
        {
            thisWebDriver = webDriver;
        }

         WebControlUtility wb = new WebControlUtility();
        public T GetHtmlControl<T>() where T : WebControl
        {
            T Ctrl = null;

            Ctrl = thisWebDriver.GetControlFromLocator<T>();
            if (Ctrl == null)
            {
                //throw new GUIException(LogicalName, "Element not found on the Screen");
            }
            return Ctrl;
        }
    }
}
