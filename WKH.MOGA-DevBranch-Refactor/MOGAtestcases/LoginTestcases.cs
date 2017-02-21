using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.SeleniumFrameWork;
using System.Collections.Generic;
using WKH.MOGA;


namespace MOGAtestcases
{
    [TestClass]
    public class LoginTestCases
    {
        # region constructor
       
        #endregion

        //Commented this test case as it is covered in other test cases
        //[WorkItem(1), TestMethod]
        public void LoginAuthenticationWithValidUser_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                LoginPage.LogoutFromMOGA();

                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch(Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }
        

        [WorkItem(98929), TestCategory("SmokeTest"), TestMethod]
        public void LoginAuthenticationWithInValidUser_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGAWithInvalidUserCredentials(MOGAConstants.inValidUserName1, MOGAConstants.passWord1);

                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.inValidUserName1, ex.Message);
            }
        }

        [WorkItem(98601), TestCategory("SanityTest"), TestMethod]
        public void WarningMessagesForLoginValidations_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.WarningMessagesVerificationForInvalidUsers(MOGAConstants.inValidUserName1, MOGAConstants.inValidPassWord1);
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
