using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locators
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/Automation-practice-form/");

            // Type Name in the FirstName text box      
            driver.FindElement(By.Name("firstname")).SendKeys("Lakshay");

            //Type LastName in the LastName text box
            driver.FindElement(By.Name("lastname")).SendKeys("Sharma");

            // Click on the Submit button
            driver.FindElement(By.Id("submit")).Click();


            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/Automation-practice-form/");
 
		// Click on "Partial Link Text" link
		driver.FindElement(By.PartialLinkText("Partial")).Click();
		
 
		// Convert element in to a string 
		string sClass = driver.FindElements(By.TagName("button")).ToString();
		
 
		// Click on "Link Text" link
		driver.FindElement(By.LinkText("Link Test")).Click();
		
        }
    }
}
