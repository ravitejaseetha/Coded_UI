using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace WKH.MOGA.UIAutomation.Browser
{
    /// <summary>
    /// This Class is dedicated to implement all Browser Related Activities like 
    /// Invoking the browser, Maximizing Windows, NavigateToURL, Switching To WIndows
    /// Swithcing To Frames etc
    /// </summary>
   public class Browser
    {
        public static IWebDriver driver = null;
        public static string baseUrl = ConfigurationManager.AppSettings.Get("baseurl");

        /// <summary>
        /// This method will read the browser value from configuration file and 
        /// invoke the same browser 
        /// </summary>
        /// <returns></returns>
        public static IWebDriver InvokeBrowser()
        {
           
                string driverToInvoke = ConfigurationManager.AppSettings.Get("browser");
                string driverPath = ConfigurationManager.AppSettings.Get("executionpath") + "Support\\";
                switch(driverToInvoke.ToLower())
                {
                    case "firefox":
                        driver = new FirefoxDriver();
                        return driver;

                    case "chrome":
                        driver = new ChromeDriver(driverPath);
                        return driver;

                    case "ie":
                        driver = new InternetExplorerDriver(driverPath);
                        return driver;

                    default:
                        throw new Exception("Please provide a valid browser name in config file");
                          
            }

        }

        /// <summary>
        /// This method will navigate the browser to the given URL
        /// </summary>
        /// <param name="url"> Default value is null and this method will navigate the browser to the baseURL when it is null. So calling this method without any parameter will navigate the browser to the base URL or it will navigate the browser to the passed url
        /// </param>
        public static void NavigateToUrl(string url = null)
        {
            if (url == null)
                driver.Navigate().GoToUrl(baseUrl);
            else
                driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// This method will maximize the current window
        /// </summary>
        public static void MaximizeWindow()
        {
            driver.Manage().Window.Maximize();
        }


        /// <summary>
        /// This method quits the instance of the driver
        /// </summary>
        public static void Quit()
        {
            driver.Quit();
        }      
    }
}
