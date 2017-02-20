using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISample
{
    public  class WebControl
    {
        private  IControl control;
       
        private IControl Control
        {
            get
            {
                if(null == control)
                {
                    control = new SeleniumWebControl();
                }
                return control;
            }
        }
        public  void Click()
        {
            Control.Click();
        }

        public  void Sendkeys()
        {
            control.SendKeys();
        }
    }
}
