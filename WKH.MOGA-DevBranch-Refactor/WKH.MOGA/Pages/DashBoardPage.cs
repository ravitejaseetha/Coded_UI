using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKH.SeleniumFrameWork;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WKH.MOGA
{
    public class DashBoardPage : UIObjects
    {
        public static DashBoardPage dashBoardPage;

        public DashBoardPage()
        {
            PageFactory.InitElements(WebDriver, this);
            dashBoardPage = this;
        }

        #region Dash Board controls

        [FindsBy(How = How.CssSelector, Using = ".header>h3")]
        public IWebElement dashBdHeader;

        [FindsBy(How = How.CssSelector, Using = ".header>h4")]
        public IWebElement dashBdBody;
        
        #endregion

        //This method verifies Home page of Dash board
        public static void DashBoardHomepageVerification()
        {
            ResultReport.AddTestStepDetails("Verifying homepage of dashboard");

            dashBoardPage = new DashBoardPage();
            
            Assert.IsTrue(dashBoardPage.dashBdHeader.Text == "Experiments Dashboard", "Experiments Dashboard not displayed");
            Assert.IsTrue(dashBoardPage.dashBdBody.Text == "Make Ovid Great Again", "Experiments Dashboard body not displayed properly");

        }

    }
}
