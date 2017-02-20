using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLPractice
{

    class Program
    {
        private static IWebDriver browser;
        public static IWebDriver Browser
        {
            get
            {
                if(null == browser)
                {
                    browser = new FirefoxDriver();

                }
                return browser;

            }
        }

        private static TestSettings test;
        public static TestSettings TestPage
        {
            get
            {
                if(null == test)
                {
                    test = new TestSettings();
                }
                return test;
            }
        }

       static void Main(string[] args)
       {

           TestPage.driver.Manage().Window.Maximize();
           TestPage.driver.Navigate().GoToUrl(TestPage.URL);
       }
    }
}
