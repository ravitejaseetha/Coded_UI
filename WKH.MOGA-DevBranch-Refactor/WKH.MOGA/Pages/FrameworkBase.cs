using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKH.SeleniumFrameWork;

namespace WKH.MOGA
{
    public class FrameworkBase 
    {
        public static void OpenBrowser(string browser, string url)
        {

            UIObjects.LaunchApplication(browser, url);
        }

        public static void CloseBrowser()
        {
            try
            {
                if ((MOGAConstants.browserType == "Chrome") || (MOGAConstants.browserType == "chrome"))
                {
                    CommonMethods.KillProcess("chromedriver");
                    CommonMethods.KillProcess("chrome");
                }
                else if ((MOGAConstants.browserType == "IE") || (MOGAConstants.browserType == "ie"))
                {
                    CommonMethods.KillProcess("IEDriverServer");
                    CommonMethods.KillProcess("iexplore");
                    //UIObjects.WebDriver.Quit();
                }
                else
                {
                    UIObjects.WebDriver.Close();
                }
            }
            catch (Exception ex)
            {
                //Doing R&D for Jenkins Issue
            }

        }

        public static void CatchBlockCodeForResults(string testcaseName, string user , string exceptionMsg)
        {
            MOGAConstants.logMessage = "Test case failed for User - " + user +": as Selenium - "+ exceptionMsg;
            ResultReport.AddTestStepDetails(MOGAConstants.logMessage, "Fail");
            ResultReport.AddTestCaseName(testcaseName, MOGAConstants.browserType, "Fail");
            ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName, "Fail");
            CloseBrowser();
            MOGAConstants.logMessage = string.Empty;
            Assert.Fail(exceptionMsg);
        }

         

    }
}
