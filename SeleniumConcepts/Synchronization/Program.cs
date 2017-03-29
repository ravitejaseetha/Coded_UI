using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronization
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("http://www.google.com");
           // driver.FindElement(By.XPath("gg")).SendKeys("dd");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("lst-ib")));
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("lst-ib")).SendKeys("Hello");

            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-switch-windows/");
            IWebElement element = driver.FindElement(By.XPath("//*[@id='clock']"));
            DefaultWait<IWebElement> wait1 = new DefaultWait<IWebElement>(element);
            wait1.Timeout = TimeSpan.FromMinutes(2);
            wait1.PollingInterval = TimeSpan.FromMilliseconds(5000);
            wait1.IgnoreExceptionTypes();
            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                String styleAttrib = element.Text;
                if (styleAttrib.Contains("Buzz"))
                {
                    return true;
                }
                Console.WriteLine("Current time is " + styleAttrib);
                return false;
            });
            wait1.Until(waiter);
            driver.Quit();
        }
    }
}
