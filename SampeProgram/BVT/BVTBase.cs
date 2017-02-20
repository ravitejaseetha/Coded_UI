using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVT
{
    public class BVTBase
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
    }
}
