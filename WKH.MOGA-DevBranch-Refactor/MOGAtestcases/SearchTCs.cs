using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.MOGA;
using WKH.SeleniumFrameWork;
using System.Collections.Generic;

namespace MOGAtestcases
{
    [TestClass]
    public class SearchTCs
    {
        #region constructor

        #endregion

        [WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void SearchWithSolrSyntaxForSingleField_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                Dictionary<string, string> queryAndTermsCollection = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel("SolrFieldName", "SearchTermSlr", "Search");

                SearchPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);
                //SearchPage.SelectShowJournalArticles(false);
                foreach (KeyValuePair<string, string> queryAndterm in queryAndTermsCollection)
                {
                    SearchPage.SimpleSearch(queryAndterm.Key + ":" + queryAndterm.Value);
                    FieldedSearchPage.NavigateHere();
                    FieldedSearchPage.VerifySinglefieldsResultsForPartialSearchTerm(queryAndterm.Key, queryAndterm.Value);
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
        public void SearchWithSolrSyntaxForMultipleFields_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                SearchPage.NavigateHere();
                //SearchPage.SelectSearchTab();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);
                SearchPage.SimpleSearch("title_Search:blood AND publicationDate_Year:2015");
                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.VerifySinglefieldsResultsForPartialSearchTerm("title", "blood");
                FieldedSearchPage.VerifySinglefieldsResultsForPartialSearchTerm("publicationDate_Year", "2015");

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
        public void SearchWithSingleSearchTerms_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                List<string> searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName, MOGAConstants.dataBaseName);

                SearchPage.NavigateHere();
                //SearchPage.SelectShowJournalArticles(false);

                for (int j = 0; j < searchTerms.Count; j++)
                {
                    SearchPage.SimpleSearch(searchTerms[j]);
                    SearchPage.VerifySearchTermsWithOutOperatorForAllFieldSearch(searchTerms[j]);
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
        public void UnifiedSearchWithFieldNames_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);
                SearchPage.NavigateHere();
                List<string> searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(MOGAConstants.searchItem, "Journal");
                Dictionary<string, string> searchDictionary = new Dictionary<string, string>();

                foreach (var srchTerm in searchTerms)
                {
                    var splitTerms = srchTerm.Split('|');
                    searchDictionary.Add(splitTerms[0], splitTerms[1]);
                }

                List<string> displayResults = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(MOGAConstants.expectedResult, "Journal");


                int inc = 0;
                foreach (KeyValuePair<string, string> searchTerm in searchDictionary)
                {
                    SearchPage.NavigateHere();
                    //SearchPage.SimpleSearch(searchTerm.Value);
                    FieldedSearchPage.NavigateHere();
                    FieldedSearchPage.SelectFieldedSearchTab();
                    FieldedSearchPage.SingleFieldSearch(searchTerm.Key, searchTerm.Value);
                    //CommonControlsPage.VerifyAllRecordsForReferenceLink(displayResults[inc]);
                    CommonControlsPage.VerifyAllRecordsForViewReferenceLink(displayResults[inc]);
                    inc++;
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
        public void SearchWithGeneralSearchTermsWithOperators_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                SearchPage.NavigateHere();
                //SearchPage.SelectSearchTab();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);
                //SearchPage.SelectShowJournalArticles(false);
                List<string> FieldList = new List<string>();
                FieldList.Insert(0, "SearchTerm1");
                FieldList.Insert(1, "Operation1");
                FieldList.Insert(2, "SearchTerm2");

                List<string>[] searchTerms = MOGAConstants.mogaFunctions.GetColumnsFromExcel(FieldList, "Search");

                int rows = searchTerms[0].Count;
                string[] allQueryTerms = new string[3];

                string searchQuery = "";
                int ix = 0;
                for (int i = 0; i < rows - 1; i++)
                {
                    searchQuery = "";
                    ix = 0;

                    for (int j = 0; j < FieldList.Count; j++)
                    {
                        searchQuery += searchTerms[i][j];
                        allQueryTerms[ix++] = searchTerms[i][j].ToLower();

                        searchQuery += " ";
                    }
                    SearchPage.SimpleSearch(searchQuery);
                    SearchPage.VerifySearchTermsWithOperatorForAllFieldSearch(allQueryTerms);
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


        //Commenting the following test case as regular search time might be any of the field in the record and as we are not displaying all fields script is getting failed
        //For some of the terms this might be failed till the time we implement all fields on UI
        //[WorkItem(1), TestCategory("SmokeTest"), TestMethod]
        public void SearchWithCombinationOfSolrSyntaxAndRegualrSearchTerm_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                SearchPage.NavigateHere();
                //SearchPage.SelectSearchTab();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                string[] QueryTerms1 = { "heart", "and", "2010" };
                string[] QueryTerms2 = { "heart", "not", "2010" };

                SearchPage.SimpleSearch("title_Search:(heart) AND (2010)");
                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.VerifySinglefieldsResultsForPartialSearchTerm("title", "heart");
                SearchPage.VerifySearchTermsWithOperatorForAllFieldSearch(QueryTerms1);

                SearchPage.SimpleSearch("title_Search:(heart) NOT (2010)");
                FieldedSearchPage.VerifySinglefieldsResultsForPartialSearchTerm("title", "heart");
                SearchPage.VerifySearchTermsWithOperatorForAllFieldSearch(QueryTerms2);

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
        public void SearchPaginationValidaion_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                SearchPage.NavigateHere();
                SearchPage.SelectSearchTab();
                SearchPage.VerifyPageDisplayOnSearchPage();

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
        public void SearchPageToolTipVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                SearchPage.NavigateHere();
                //SearchPage.SelectSearchTab();
                SearchPage.SearchTabTooltipVerification();

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