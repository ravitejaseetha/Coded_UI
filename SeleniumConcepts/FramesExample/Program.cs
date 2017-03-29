using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FramesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/iframe-practice-page/");
            driver.Manage().Window.Maximize();
            driver.SwitchTo().Frame("IF1");
            driver.FindElement(By.XPath(".//*[@name='firstname']")).SendKeys("Helloworld");
            driver.SwitchTo().DefaultContent();
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(0, -250);");
            driver.FindElement(By.XPath(".//*[text()='Home']")).Click();
        }
    }
}
