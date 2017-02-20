using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceLabRemoteExecution
{
    class PageBase
    {
        protected IWebDriver webDriver;

        public string title { get; protected set; }
    }
}
