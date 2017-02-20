using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampeProgram
{
    class Program
    {
       public static IWebDriver driver;
        public static  IWebDriver Driver
        {
            get
            {
                if (null == driver)
                {
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Navigate().GoToUrl("Http://google.com");
                }
                return driver;
            }
        }

        protected IWebElement FindByXpath(string xpath)
        {
            return Driver.FindElement(By.XPath(xpath));
        }

          static void Main(string[] args)
        {

            Driver.FindElement(By.Id("lst-ib")).SendKeys("gmail");
    
        }
       


       
    }
}
