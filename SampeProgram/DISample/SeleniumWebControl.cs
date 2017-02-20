using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISample
{
    public class SeleniumWebControl : IControl
    {
        private IWebDriver driver;
        public IWebDriver Driver
        {
            get
            {
                if(null == driver)
                {
                    driver = new FirefoxDriver();
                }
                return driver;
            }
        }


        

        public IWebElement ele
        {
        get{
            return Driver.FindElement(By.XPath("ad"));
        }
            
        }
        public void Click()
        {

            Console.WriteLine("Final Wrapper Click");
            Console.ReadKey();
        }

        public void SendKeys()
        {
            Console.WriteLine("Final Wrapper Sendkeys");
        }
    }
}
