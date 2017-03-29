using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpathExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new RemoteWebDriver(DesiredCapabilities.HtmlUnitWithJavaScript());
            driver.Navigate().GoToUrl("http://www.google.com");
           
            string url = "https://www.w3schools.com/html/tryit.asp?filename=tryhtml_table_intro";
            //html/body/table/tbody/tr[2]/td[2]/preceding-sibling::td
            //html/body/table/tbody/tr[2]/td[2]/following-sibling::td
            //The ends-with function is part of XPath 2.0 but browsers generally only support 1.0

            //Css Selectors
            //linkedin
            //[id=login-email]
            //[id^=login-e]//Strats with
            //[id$=email]//ends-with
            //[id*=email]//contains
            //#layout-main/# represents id
            //.login-form/. represents class
            //form>input[id=login-email]
        }
    }
}
