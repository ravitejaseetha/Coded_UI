using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    class Program : TestBase
    {
        static void Main(string[] args)
        {
            //PageClass p = new PageClass();
            // TestBase tc = new TestBase();
            TestBase.WebDriver.Browser.Navigate("http://www.google.com");
            TestBase.WebDriver.Browser.Maximize();
            TestBase.PageClassBase.PageLogin.Button.Click();
        }

        private static TestBase testBase;
        public static TestBase TestBase
        {
            get
            {
                if (null == testBase)
                {
                    testBase = new TestBase();
                }
                return testBase;
            }
        }
    }
}
