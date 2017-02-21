using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.MOGA;
using System.Collections.Generic;
using WKH.SeleniumFrameWork;

namespace MOGAtestcases
{
    [TestClass]
    public class DashBoardTCs
    {
       

        //[WorkItem(99814), TestCategory("SmokeTest"), TestMethod] //Ignored the Test for change in URL.
        public void DashBoardAdmin_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appDashBoardAdminURL);
                LoginPage.LoginToMOGA(MOGAConstants.dashBoardAdminUid, MOGAConstants.dashBoardAdminPwd);

                DashBoardPage.DashBoardHomepageVerification();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        #region Initialize + Cleanup + Test Context
        [TestInitialize()]
        public void MyTestInitialize()
        {
            
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            MOGAConstants.logMessage = string.Empty;
          
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        #endregion
    }
}
