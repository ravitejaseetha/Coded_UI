using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.MOGA;
using System.Collections.Generic;
using WKH.SeleniumFrameWork;

namespace MOGAtestcases
{
    [TestClass]
    public class MiscellaneousTCs
    {
        # region constructor
       
        #endregion

        //Following test verifies FullText search option from UI but not for the content as we do not have FullText available at present as on 11/02/2016
        [WorkItem(101203), TestCategory("SmokeTest"), TestMethod]
        public void FullTextSearch_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.SelectFieldedSearchTab();
                CommonControlsPage.SelectResource(MOGAConstants.strJournals);

                string[] searchTerms = new string[3] { "plastic", "plastic and reconstructive surgery", "\"plastic and reconstructive surgery\"" };

                foreach (string searchTerm in searchTerms)
                {
                    FieldedSearchPage.NavigateHere();
                    FieldedSearchPage.SingleFieldSearch("FullText", searchTerm);
                    CommonControlsPage.VerifySystemReturnsSearchResults();
                }

                SearchPage.NavigateHere();
                SearchPage.SelectSearchTab();
                foreach (string searchTerm in searchTerms)
                {
                    SearchPage.SimpleSearch("fullText" + ":" + searchTerm);
                    CommonControlsPage.VerifySystemReturnsSearchResults();
                }

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
        public void RetractedArticles_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.SelectFieldedSearchTab();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                //modified for fix of test case 'RetractedArticles_Test'
                /*
                 * Changing the input of search term as the search term is having double quote("")
                 * which is resulting in 'No Result Found'.
                 * Removing the double quotes
                 */

                //FieldedSearchPage.SingleFieldSearch("PublicationType", "\"" + "Retracted Publication" + "\"");
                FieldedSearchPage.SingleFieldSearch("PublicationType","Retracted Publication");
                FieldedSearchPage.VerifyTitleOfTheRetractedArticlesStartsWithRetract("Retracted:");

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName, MOGAConstants.dataBaseName);

                int i = 0;
                foreach (string searchTerm in searchTerms)
                {
                    FindCitationPage.DoCitationSearch(searchTerm);
                    FieldedSearchPage.VerifyTitleOfTheRetractedArticles(searchTerm);
                    i = i + 1;
                }

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SanityTest"), TestMethod]
        public void AutoFocusOfTheSearchPages_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                SearchPage.NavigateHere();
                SearchPage.VerifyAutoFocusOfSearchPage();

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                FindCitationPage.VerifyAutoFocusOfCitationPage();

                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.SelectFieldedSearchTab();
                FieldedSearchPage.VerifyAutoFocusOfFieldedSearchPage();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        //[WorkItem(1),TestCategory("SmokeTest"), TestMethod]
        public void RelevancyOfSearchResults_Test()
        {
            //try
            //{
            ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
            FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
            LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

            SearchPage.NavigateHere();
            CommonControlsPage.SelectResource(MOGAConstants.strAllResources);
            SearchPage.SimpleSearch("heart");
            SearchPage.VerifyRelevancyOfResults();

            LoginPage.LogoutFromMOGA();
            FrameworkBase.CloseBrowser();
            ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            //}
            //catch (Exception ex)
            //{
            //    FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            //}
        }

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void HelpPageVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                CommonControlsPage.NavigateHere();
                CommonControlsPage.VerifyHelpPage();

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
        public void InviteUserErrorMessages_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.mogaAdminUserid, MOGAConstants.mogaAdminPwd);

                CommonControlsPage.NavigateHere();
                CommonControlsPage.VerifyInviteUserErrorMessages();

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
        public void MedlineRecordsInfoMessage_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.mogaAdminUserid, MOGAConstants.mogaAdminPwd);

                CommonControlsPage.NavigateHere();
                CommonControlsPage.VerifyMedlineRecordsInfoMessage();

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                CommonControlsPage.VerifyMedlineRecordsInfoMessage();

                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.SelectFieldedSearchTab();
                CommonControlsPage.VerifyMedlineRecordsInfoMessage();

                RCPpage.NavigateHere();
                RCPpage.SelectRCPTab();
                CommonControlsPage.VerifyMedlineRecordsInfoMessage();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [Ignore]
        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void InviteUserLinkDisplayForNormalUser_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                CommonControlsPage.NavigateHere();
                CommonControlsPage.VerifyInviteUserLinkForExistence();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SanityTest"), TestMethod]
        public void RCPpageToolTipVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                RCPpage.NavigateHere();
                RCPpage.RCPTabTooltipVerification();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SanityTest"), TestMethod]
        public void ResourceSelectionOptionPreference_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                SearchPage.NavigateHere();
                //Selecting Medline resource with user1
                CommonControlsPage.SelectResource(MOGAConstants.strMedline);
                SearchPage.SimpleSearch("heart");
                LoginPage.LogoutFromMOGA();

                //Verify Medline resource preference with user1
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                CommonControlsPage.VerifySelectedResourcePreference(MOGAConstants.strMedline);
                LoginPage.LogoutFromMOGA();

                //Selecting Journals resource with user1
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                CommonControlsPage.SelectResource(MOGAConstants.strJournals);
                SearchPage.SimpleSearch("heart");
                LoginPage.LogoutFromMOGA();

                //Verify Journals resource preference with user1
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                CommonControlsPage.VerifySelectedResourcePreference(MOGAConstants.strJournals);
                LoginPage.LogoutFromMOGA();

                //Select Medline with User2
                LoginPage.LoginToMOGA(MOGAConstants.userName2, MOGAConstants.passWord2);
                CommonControlsPage.SelectResource(MOGAConstants.strMedline);
                SearchPage.SimpleSearch("heart");
                LoginPage.LogoutFromMOGA();

                //Verify resource selection option of Journals for User1 in all the search pages
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                CommonControlsPage.VerifySelectedResourcePreference(MOGAConstants.strJournals);
                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                CommonControlsPage.VerifySelectedResourcePreference(MOGAConstants.strJournals);
                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.SelectFieldedSearchTab();
                CommonControlsPage.VerifySelectedResourcePreference(MOGAConstants.strJournals);
                LoginPage.LogoutFromMOGA();

                //Verify Medline resource preference with user2 in Search, CItation and Fielded search pages
                LoginPage.LoginToMOGA(MOGAConstants.userName2, MOGAConstants.passWord2);
                CommonControlsPage.VerifySelectedResourcePreference(MOGAConstants.strMedline);
                FindCitationPage.SelectFindCitationTab();
                CommonControlsPage.VerifySelectedResourcePreference(MOGAConstants.strMedline);
                FieldedSearchPage.SelectFieldedSearchTab();
                CommonControlsPage.VerifySelectedResourcePreference(MOGAConstants.strMedline);

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
        public void ViewOnOvidLinkNavigationToMESDsegment_Test()
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

                CommonControlsPage.VerifyDatabaseSegmentNameInOvid();

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
        private List<string> searchTerms;

        #endregion
    }
}
