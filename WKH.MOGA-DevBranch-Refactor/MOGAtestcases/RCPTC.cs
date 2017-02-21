using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.MOGA;
using System.Collections.Generic;
using WKH.SeleniumFrameWork;

namespace MOGAtestcases
{
    [TestClass]
    public class RCPTC
    {
        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void DefaultBoost_Test()
        {


            FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
            LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
            RCPpage.NavigateHere();
            RCPpage.SelectRCPTab();

            RCPpage.rcpPage.GetBoostFieldElementValues();
            RCPpage.rcpPage.IsHeaderVisible();
            var defaultValues = RCPpage.rcpPage.GetToolTipValues();
            var afterSlide = RCPpage.rcpPage.DragSlider();
            int inc = 0;
            int incAfter = 0;
            foreach (var item in defaultValues)
            {
                if (item.Equals(afterSlide[inc]))
                {
                    ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName, "Fail");
                }

                inc++;
            }

            RCPpage.SelectRCPTab();
            var afterNavigationtValues = RCPpage.rcpPage.GetToolTipValues();

            foreach (var item in defaultValues)
            {
                if (item.Equals(afterNavigationtValues[incAfter]))
                {
                    ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName, "Pass");
                }

                incAfter++;
            }

            if (!RCPpage.rcpPage.IsHeaderVisible())
            {
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName, "Pass");
            }
            //            RCPpage.SelectRCPTab();



            //RCPpage.ClickCombo();
            LoginPage.LogoutFromMOGA();
            FrameworkBase.CloseBrowser();
            ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);

        }
    }
}
