using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.SeleniumFrameWork;
using WKH.MOGA;
using System.Collections.Generic;

namespace MOGAtestcases
{
    [TestClass]
    public class LinksVerificationTCs
    {

        #region constructor
       
        #endregion

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void AbstractBasic_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                
                SearchPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);
                SearchPage.SimpleSearch("abstract:heart");
                CommonControlsPage.VerifyAbstractLinkAndTermInResults("heart");

                SearchPage.SimpleSearch("title:heart AND abstract:heart");
                CommonControlsPage.VerifyAbstractLinkAndTermInResults("heart");

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }

        }

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void TitleLinkNavigation_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
          
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);
                FindCitationPage.DoCitationSearch("Plastic Surgery");

                CommonControlsPage.VerifyTitleLinkNavigation();                
               
                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void ReferenceLinkVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                
                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                FindCitationPage.DoCitationSearch("Plastic Surgery");

                CommonControlsPage.VerifyAllRecordsForReferenceLink();
            
                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void ViewPubmedLinkVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                CommonControlsPage.SelectResource(MOGAConstants.strMedline);
                FindCitationPage.DoCitationSearch("heart attack");

                CommonControlsPage.VerifyAllRecordsForViewPubmedLink();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void ViewPubmedCentralLinkVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                CommonControlsPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strMedline);

                SearchPage.NavigateHere();
                //SearchPage.SelectShowJournalArticles(false);
                SearchPage.SimpleSearch("27058529");

                CommonControlsPage.VerifyAllRecordsForViewPubmedCentralLink();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void ViewOnOvidLinkVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                SearchPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strMedline);
                //SearchPage.SelectShowJournalArticles(false);
                SearchPage.SimpleSearch("26269014");

                CommonControlsPage.VerifyAllRecordsForViewOnOvidLink();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void JournalSiteLinkVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                CommonControlsPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strJournals);
                SearchPage.NavigateHere();
                SearchPage.SimpleSearch("heart NOT doi:*");
                CommonControlsPage.VerifyJournalSiteLinkForExistance();

                CommonControlsPage.SelectResource(MOGAConstants.strMedline);
                //SearchPage.SelectShowJournalArticles(false);
                SearchPage.SimpleSearch("heart NOT doi:*");
                CommonControlsPage.VerifyJournalSiteLinkForNonExistance();

                CommonControlsPage.SelectResource(MOGAConstants.strJournals);
                SearchPage.SimpleSearch("heart AND doi:*");
                CommonControlsPage.VerifyJournalSiteLinkForNonExistance();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }


        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void MedlineRecordsVerificationForTheAvailableLinks_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                SearchPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strMedline);
                //SearchPage.SelectShowJournalArticles(false);
                SearchPage.SimpleSearch("heart");
                CommonControlsPage.VerifyAvaialableLinksForMedlineRecords();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void JournalsVerificationForTheAvailableLinks_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                CommonControlsPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strJournals);
                SearchPage.NavigateHere();
                SearchPage.SimpleSearch("heart");
                CommonControlsPage.VerifyAvaialableLinksForJournals();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void DOILinkVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                
                SearchPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strMedline);
                //SearchPage.SelectShowJournalArticles(false);
                SearchPage.SimpleSearch("doi:*"); //http://dx.doi.org/10.1002/pbc.25544

                CommonControlsPage.DOILinkValidation();

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