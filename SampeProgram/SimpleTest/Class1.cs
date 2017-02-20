using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class Class1
    {
        public static IWebDriver driver;
        public IWebDriver WebDriver
        {
            get
            {
                if(null == driver)
                {
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl(TestSettings.Default.URL);
                }
                return driver;
            }
        }

        public IWebElement FindByxpath(string xpath)
        {
            return WebDriver.FindElement(By.XPath(xpath));
        }

        public IWebElement FindById(string id)
        {
            return WebDriver.FindElement(By.Id(id));
        }
    }

    public class Home : Class1
    {
        public IWebElement Edit
        {
            get
            {
                return FindById("lst-ib");
            }
        }
       
    }



}
