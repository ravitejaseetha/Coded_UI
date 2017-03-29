using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlertsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            //This step produce an alert on screen
            driver.FindElement(By.XPath("//*[@id='content']/p[4]/button")).Click();
            Thread.Sleep(2000);
            // Switch the control of 'driver' to the Alert from main Window
            IAlert simpleAlert = driver.SwitchTo().Alert();

            // '.Text' is used to get the text from the Alert
            string alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is " + alertText);

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            simpleAlert.Accept();




            //Dismiss Alert
            IWebElement element = driver.FindElement(By.XPath("//*[@id='content']/p[8]/button"));

            // 'IJavaScriptExecutor' is an interface which is used to run the 'JavaScript code' into the webdriver (Browser)
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            Thread.Sleep(1000);
            // Switch the control of 'driver' to the Alert from main window
            IAlert confirmationAlert = driver.SwitchTo().Alert();

            // Get the Text of Alert
            string alertText1 = confirmationAlert.Text;

            Console.WriteLine("Alert text is " + alertText);

            //'.Dismiss()' is used to cancel the alert '(click on the Cancel button)'
            confirmationAlert.Dismiss();



            //Prompt Alerts
            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Window.Maximize();

            //This step produce an alert on screen
            IWebElement element1 = driver.FindElement(By.XPath("//*[@id='content']/p[11]/button"));

            // 'IJavaScriptExecutor' is an 'interface' which is used to run the 'JavaScript code' into the webdriver (Browser)        
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element1);

            // Switch the control of 'driver' to the Alert from main window
            IAlert promptAlert = driver.SwitchTo().Alert();

            // Get the Text of Alert
            String alertText3 = promptAlert.Text;
            Console.WriteLine("Alert text is " + alertText3);

            //'.SendKeys()' to enter the text in to the textbox of alert 
            promptAlert.SendKeys("Accepting the alert");

            Thread.Sleep(4000); //This sleep is not necessary, just for demonstration

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            promptAlert.Accept();
        }
    }
}
