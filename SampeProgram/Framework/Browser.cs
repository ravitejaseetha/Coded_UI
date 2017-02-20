using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public enum BrowserType
    {
        Firefox,
        IE,
        Chrome
    }
    public class Browser
    {
        private IWebDriver FirefoxDriver
        {
            get
            {
                return new FirefoxDriver();
            }
        }
        internal BrowserType BrowserType;
        internal IWebDriver BrowserHandle;
        public void GetBrowser(BrowserType aBrowserType)
        {

            BrowserType = aBrowserType;

            if (aBrowserType == BrowserType.Firefox)
            {
                BrowserHandle = FirefoxDriver;
            }

            //if (aBrowserType == BrowserType.IE)
            //{
            //    BrowserHandle = IEDriver;
            //}

            //if (aBrowserType == BrowserType.Chrome)
            //{
            //    BrowserHandle = ChromeDriver;
            //}

            //if (aBrowserType == BrowserType.HTMLUnit)
            //{
            //    BrowserHandle = HTMLUnit;
            //}
        }

        public Browser(BrowserType aBrowserType)
        {

            GetBrowser(aBrowserType);

        }

        public void Navigate(string Url)
        {
            BrowserHandle.Navigate().GoToUrl(Url);
        }

        public void Maximize()
        {
            BrowserHandle.Manage().Window.Maximize();
        }
    }
}
