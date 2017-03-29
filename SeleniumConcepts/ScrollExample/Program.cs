using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrollExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.paytm.com/");
            driver.Manage().Window.Maximize();

            // scrollingToBottomofAPage

            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(3000);
            ////((IJavaScriptExecutor)driver).ExecuteScript("history.go(0)");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(document.body.scrollHeight,0)");
            Thread.Sleep(2000);
            //Scroll to particular element
            IWebElement element = driver.FindElement(By.XPath("//*[text()='About Us']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            Thread.Sleep(5000);

        


            //Scroll by coordinates of page
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(document.body.scrollHeight,0)");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,1500)");
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,-1500)");
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
