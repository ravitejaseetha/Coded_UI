using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelExecution
{
    public enum Browsers
    {
        Firefox,
        Chrome
    }
    public class TestBase
    {
        
        public IWebDriver driver;

        public void SetupBrowser(string browserName)
        {
            if (browserName.Equals("Firefox"))
                driver = new FirefoxDriver();
            else if(browserName.Equals("Chrome"))
                driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
        }


        public static IEnumerable<string> Browser()
        {
            string[] browser = BrowserResource.BrowserNames.Split(',');
            foreach (var item in browser)
            {
                yield return item;
            }
        }
    }
}
