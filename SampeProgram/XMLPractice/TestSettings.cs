using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLPractice
{
    public enum BrowserType
    {
        IE,

        GoogleChrome,

        Firefox
    }
   public class TestSettings : BaseSettings
    {

        string url = "";
        string _path;
        public IWebDriver driver;
        public IWebDriver GetBrowser()
        {
            if (Browser.Equals(BrowserType.GoogleChrome.ToString()))
            {
                driver = new ChromeDriver();
                return driver;
            }
            if (Browser.Equals(BrowserType.Firefox.ToString()))
            {
                driver = new FirefoxDriver();
                return driver;
            }
            if (Browser.Equals(BrowserType.IE.ToString()))
            {
                driver = new InternetExplorerDriver();
                return driver;
            }
            driver = new FirefoxDriver();
            return driver;

        }
        public TestSettings()
        {
            _path = Path.Combine(Directory.GetCurrentDirectory(),"TestSettings.xml");
            GetBrowser();
        }
        public string URL
        {
            get
            {
                string value = GetValue(_path, "AUMCPUrl");
                if(null != value)
                {
                    url = value;
                }
                return url;
            }
        }

       string browser = "Firefox";
        public string Browser
        {
            get
            {
                string value = GetValue(_path, "Browser");
                if(null != value)
                {
                    browser = value;
                }
                return browser;
            }
        }
    }
}
