using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.MOGA;
using System.Collections.Generic;
using WKH.SeleniumFrameWork;

namespace MOGAtestcases
{
    [TestClass]
    public class AutoCompleteTCs
    {
        #region constructor

        #endregion
        [Ignore]
        [WorkItem(1), TestMethod]
        public void AutoCompleteFieldedSearch_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.SelectFieldedSearchTab();
                FieldedSearchPage.SingleFieldSearchAC("Title ➰", "wat");

                AutoCompleteFeature.NavigateHere();
                AutoCompleteFeature.VerifyListOfAutoCompleteTerms("wat");
            
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