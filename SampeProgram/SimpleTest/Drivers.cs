using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public enum BrowserType
    {
        Firefox,

        IE,

        Chrome,
    }
    public class Drivers
    {
        internal IWebDriver BrowserHandle;
        internal BrowserType BrowserType;

        public Drivers(BrowserType aBrowserType)
        {
            GetBrowser(aBrowserType);
        }
        private IWebDriver FirefoxDriver
        {
            get
            {
                return new FirefoxDriver();
            }
        }

        private IWebDriver IEDriver
        {
            get
            {
                return new InternetExplorerDriver(Config.DriverServerPath);
            }
        }

        private IWebDriver ChromeDriver
        {
            get
            {
                return new ChromeDriver(Config.DriverServerPath);
            }
        }

        public void GetBrowser(BrowserType aBrowserType)
        {
            if(aBrowserType == BrowserType.Firefox)
            {
                BrowserHandle = FirefoxDriver;
            }
            if(aBrowserType == BrowserType.Chrome)
            {
                BrowserHandle = ChromeDriver;
            }
            if(aBrowserType == BrowserType.IE)
            {
                BrowserHandle = IEDriver;
            }
        }
    }
}
