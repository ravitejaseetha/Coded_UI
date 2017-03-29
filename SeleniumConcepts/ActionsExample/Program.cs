using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("http://www.toolsqa.com");
            //driver.Manage().Window.Maximize();
            //Actions act = new Actions(driver);
            //IWebElement element = driver.FindElement(By.LinkText("TUTORIAL"));
            //act.MoveToElement(element).Build().Perform();
            //Thread.Sleep(4000);
            //driver.FindElement(By.PartialLinkText("Jav")).Click();
            
            driver.Navigate().GoToUrl("http://www.linkedin.com");
            driver.Manage().Window.Maximize();
            Actions act = new Actions(driver);
            IWebElement element1 = driver.FindElement(By.XPath(".//*[@id='login-email']"));
            act.MoveToElement(element1).Click().KeyDown(element1, Keys.Shift)
                .SendKeys(element1, "hello")
                .KeyUp(element1, Keys.Shift)
                .DoubleClick(element1)
                .ContextClick()
                .Build()
                .Perform();
            driver.Close();
        }
    }
}
