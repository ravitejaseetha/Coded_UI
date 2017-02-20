using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Flipkart : IContext
    {
        public IWebDriver driver;
        
        public Flipkart(IWebDriver Driver)
        {
            driver = Driver;
        }

        public Flipkart()
        {
            
        }
        public void Start()
        {
            driver.Navigate().GoToUrl("http://www.flipkart.com");
        }

        public void Execute()
        {
            Console.WriteLine("Execute Flipkart");
        }

        public void End()
        {
            driver.Quit();
        }
    }
}
