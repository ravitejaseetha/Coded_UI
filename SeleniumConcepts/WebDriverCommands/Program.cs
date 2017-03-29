using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverCommands
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Manage().Window.Maximize();
            string title = driver.Title;
            string pageSource = driver.PageSource;
            driver.Close();

            //Browser Commands
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();

            //WebElement Commands
            driver.FindElement(By.XPath("")).Click();


        }
    }
}
