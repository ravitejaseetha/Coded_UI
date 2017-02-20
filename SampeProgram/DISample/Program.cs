using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISample
{
    public class Program
    {
       public static void Main(string[] args)
        {
           //IWebDriver driver
            IWebDriver driver = new RemoteWebDriver(new Uri("http://172.16.107.112:8080/wd/hub"), DesiredCapabilities.Firefox());
            driver.Navigate().GoToUrl("http://www.google.com");
            WebControl wc = new WebControl();
            wc.Click();
        }
    }
}
