using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class CricHome : IContext
    {
        public IWebDriver driver;
        public static string name;
        public CricHome(IWebDriver Driver)
            :this(name,Driver)
        {
            driver = Driver;
        }
        public CricHome(string name,IWebDriver url)
        {

        }
        public void Start()
        {
            driver.Navigate().GoToUrl("http://www.cricinfo.com");
        }

        public void Execute()
        {
            Console.WriteLine("Execute Cricinfo");
        }

        public void End()
        {
            //driver;
        }
    }
}
