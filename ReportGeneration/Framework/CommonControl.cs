using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework
{
    public class CommonControl
    {
        private IWebDriver driver;

        public IWebDriver Driver
        {
            get
            {
                if (null == driver)
                {
                    driver = new ChromeDriver();
                }
                return driver;
            }
        }


        public void SendKeys(Dictionary<string, string> locator, string input)
        {
            Driver.FindElement(By.Id(locator.Values.First())).SendKeys(input);
        }


        public void NavigateToURL(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Maximize()
        {
            Driver.Manage().Window.Maximize();
        }

        public void Close()
        {
            Driver.Close();
        }
    }
}
