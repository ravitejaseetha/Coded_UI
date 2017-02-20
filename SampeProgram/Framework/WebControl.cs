using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class WebControl
    {
        internal IControl Control;

        private ControlAccess myAccess;
        public WebControl(Browser aBrowser, LocatorType aLocatorType, ControlType aControl)
        {
            myAccess = new ControlAccess();
            myAccess.Browser = aBrowser;
            myAccess.LocatorType = aLocatorType;
            myAccess.ControlType = aControl;
            myAccess.IntializeControlAccess();
        }

        public void GetControl()
        {
            Control = myAccess.GetControl();
        }
        public void Click()
        {
            Control.Click();
        }

        public bool IsControlPresent()
        {
            return myAccess.IsElementPresent();
        }
    }
}
