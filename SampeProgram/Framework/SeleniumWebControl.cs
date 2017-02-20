using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class SeleniumWebControl : IControl
    {
        internal IWebElement aWebElement;

        public SeleniumWebControl(IWebElement webElement)
        {
            this.aWebElement = webElement;
        }
        public void Click()
        {
            aWebElement.Click();
        }
    }
}
