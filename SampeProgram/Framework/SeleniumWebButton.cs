using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class SeleniumWebButton : SeleniumWebControl, IButton
    {
        internal SeleniumWebButton(IWebElement webElement)
            : base(webElement)
        {

        }
    }
}
