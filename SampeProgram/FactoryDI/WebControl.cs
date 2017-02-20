using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{
    public class WebControl
    {
        public ControlType bControlType;
        public ControlAccess myAccess;
        public WebControl(ControlType ctype)
        {
            myAccess = new ControlAccess();
            myAccess.ControlType = ctype;
        }
        internal IControl Control;

        public void GetControl()
        {
            Control = myAccess.GetControll();
        }



        public void Click()
        {
            Control.Click();
        }

        public void Senkeys()
        {
            Control.SendKeys();
        }
    }
}
