using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    [Export(typeof(IContainerPlugin))]
    public class WebControlUtility : IContainerPlugin
    {
        //public WebControlUtility()
        //{

        //}

        private Browser myBrowser;
        public Browser Browser
        {
            get
            {
                return myBrowser;
            }
            set
            {
                myBrowser = value;

            }
        }

        public void SetBrowser(BrowserType aBrowserType)
        {
            myBrowser = new Browser(aBrowserType);
        }

        public void SetBrowser(BrowserType aBrowserType, string binaryPath)
        {
            myBrowser = new Browser(aBrowserType);
        }

        public T GetControlFromLocator<T>() where T : WebControl
        {
            WebControl aWebControl = null;
            if (typeof(T) == typeof(WebButton))
            {
                aWebControl = new WebButton(myBrowser);
            }

            if (aWebControl.IsControlPresent())
            {
                aWebControl.GetControl();
            }
            return (T)aWebControl;
        }

        public string Description
        {
            get
            {
                return "WebDriver Plugin";
            }
            set
            {
                Description = value;
            }
        }
    }
}
