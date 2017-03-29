using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefoxPreferences
{
    class Program
    {
        public static String downloadPath = "E:\\";
        static void Main(string[] args)
        {

            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("browser.download.folderList", 2);
            //profile.SetPreference("browser.download.manager.showWhenStarting", 2);
            profile.SetPreference("browser.download.dir", downloadPath);
            profile.SetPreference("browser.startup.homepage", "http://www.google.com");//about:cofig
            // profile.SetPreference("browser.helperApps.neverAsk.openFile", "text/csv,application/x-msexcel,application/excel,application/x-excel,application/vnd.ms-excel,image/png,image/jpeg,text/html,text/plain,application/msword,application/xml");///Save and open file

            //MIME (Multipurpose internet mail extensions).Its a way of identifying files on the internet according to their nature and format.
            profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "text/csv,application/vnd.ms-excel,application/pdf,image/png");//Only save file
            // profile.SetPreference("browser.helperApps.alwaysAsk.force", false);
            // profile.SetPreference("browser.download.manager.alertOnEXEOpen", true);
            // profile.SetPreference("browser.download.manager.focusWhenStarting", true);
            //profile.SetPreference("browser.download.manager.useWindow", false);
            //profile.SetPreference("browser.download.manager.showAlertOnComplete", false);
            //profile.SetPreference("browser.download.manager.closeWhenDone", true);
            IWebDriver driver = new FirefoxDriver(profile);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://spreadsheetpage.com/index.php/file/C35/P10/");
            driver.FindElement(By.LinkText("smilechart.xls")).Click();
        }
    }
}
