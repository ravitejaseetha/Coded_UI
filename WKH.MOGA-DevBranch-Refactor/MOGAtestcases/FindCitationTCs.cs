using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.MOGA;
using System.Collections.Generic;
using WKH.SeleniumFrameWork;

namespace MOGAtestcases
{
    [TestClass]
    public class FindCitationTCs
    {
        # region constructor

       
        List<string> searchTerms = null;

        #endregion

        [WorkItem(98246), TestCategory("SmokeTest"), TestMethod]
        public void FindCitationWithFullTitle_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName, MOGAConstants.dataBaseName);
                List<string> expSearchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName + "ExpectedTerms", MOGAConstants.dataBaseName);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                int i = 0;
                foreach (string searchTerm in searchTerms)
                {                    
                    FindCitationPage.DoCitationSearch(searchTerm);
                    FindCitationPage.VerifyAllRecordsForFullSearchTerm(expSearchTerms[i]);
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

        [WorkItem(98247), TestCategory("SanityTest"), TestMethod]
        public void FindCitationWithPartialSearchTerm_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName, MOGAConstants.dataBaseName);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                foreach (string searchTerm in searchTerms)
                {                   
                    FindCitationPage.DoCitationSearch(searchTerm);
                    FindCitationPage.VerifyAllRecordsForPartialSearchTerm(searchTerm);
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

        [WorkItem(102594), TestCategory("SmokeTest"), TestMethod]
        public void FindCitationPMID_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                Dictionary<string, string> searchData = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel(TestContext.TestName, TestContext.TestName + "ExpectedTerms", MOGAConstants.dataBaseName);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                CommonControlsPage.SelectResource(MOGAConstants.strMedline);

                //Entering search term with quotes and verifying for single PMID record
                foreach (KeyValuePair<string, string> fieldNameAndValues in searchData)
                {               
                    FindCitationPage.DoCitationSearch("\"" + fieldNameAndValues.Key + "\"");
                    FindCitationPage.VerifyResultsForDOIandPMID(fieldNameAndValues.Value);
                }

                //Entering search term without quotes and verifying for single PMID record
                foreach (KeyValuePair<string, string> fieldNameAndValues in searchData)
                {
                    FindCitationPage.DoCitationSearch(fieldNameAndValues.Key);
                    FindCitationPage.VerifyResultsForDOIandPMID(fieldNameAndValues.Value);
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

        [WorkItem(102595), TestCategory("SanityTest"), TestMethod]
        public void FindCitationPMIDWithPhrases_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                Dictionary<string, string> searchData = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel(TestContext.TestName, TestContext.TestName + "ExpectedTerms", MOGAConstants.dataBaseName);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                CommonControlsPage.SelectResource(MOGAConstants.strMedline);

                foreach (KeyValuePair<string, string> fieldNameAndValues in searchData)
                {
                    FindCitationPage.DoCitationSearch(fieldNameAndValues.Key);
                    FindCitationPage.VerifyPMIDwithPhrases(fieldNameAndValues.Value);
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

        //Commenting the method FindCitationForISSN_Test as temporarily out of scope as it has issues in implementing
        //[WorkItem(1),TestCategory("SmokeTest"), TestMethod]
        public void FindCitationForISSN_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                Dictionary<string, string> searchData = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel(TestContext.TestName, TestContext.TestName + "ExpectedTerms", MOGAConstants.dataBaseName);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();

                foreach (KeyValuePair<string, string> fieldNameAndValues in searchData)
                {
                    FindCitationPage.DoCitationSearch("\""+fieldNameAndValues.Key+"\"");
                    FindCitationPage.VerifyCitationResultsForISSN(fieldNameAndValues.Value);
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

        [WorkItem(103664), TestCategory("SanityTest"), TestMethod]
        public void RetainCitationStyleSelection_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                FindCitationPage.DoCitationSearch("fever");
                FindCitationPage.SelectCitationStyle("APA");           
                LoginPage.LogoutFromMOGA();

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);                
                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                FindCitationPage.DoCitationSearch("fever");
                FindCitationPage.VerifyCitationStyle("APA");
                FindCitationPage.SelectCitationStyle("Default"); // Setting to default citation style

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
        public void MLACitationStyle_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName, MOGAConstants.dataBaseName);
                List<string> expSearchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName + "ExpectedTerms", MOGAConstants.dataBaseName);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();

                int i = 0;
                foreach (string searchTerm in searchTerms)
                {
                    FindCitationPage.DoCitationSearch("\""+searchTerm +"\"");
                    FindCitationPage.VerifyCitationStyles("MLA",expSearchTerms[i]);
                    i = i + 1;
                }

                
                FindCitationPage.SelectCitationStyle("Default"); // Setting to default citation style

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
        public void APACitationStyle_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName, MOGAConstants.dataBaseName);
                List<string> expSearchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName + "ExpectedTerms", MOGAConstants.dataBaseName);
                int i = 0;

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();

                foreach (string searchTerm in searchTerms)
                {                    
                    FindCitationPage.DoCitationSearch("\"" + searchTerm + "\"");
                    FindCitationPage.VerifyCitationStyles("APA", expSearchTerms[i]);
                    i = i + 1;
                }

                FindCitationPage.SelectCitationStyle("Default"); // Setting to default citation style

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
        public void ChicagoCitationStyle_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName, MOGAConstants.dataBaseName);
                List<string> expSearchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName + "ExpectedTerms", MOGAConstants.dataBaseName);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                int i = 0;
                foreach (string searchTerm in searchTerms)
                {
                    
                    FindCitationPage.DoCitationSearch("\"" + searchTerm + "\"");
                    FindCitationPage.VerifyCitationStyles("Chicago", expSearchTerms[i]);
                    i = i + 1;
                }

                FindCitationPage.SelectCitationStyle("Default"); // Setting to default citation style

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();

                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(98248), TestCategory("SanityTest"), TestMethod]
        public void FindCitationWitBlankSearchTerm_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                FindCitationPage.DoCitationSearch("");
                FindCitationPage.VerifyErrorMessageForBlankCitation();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(98247), TestCategory("SmokeTest"), TestMethod]
        public void FindCitationResultsReliability_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();

                searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName, MOGAConstants.dataBaseName);
                foreach (string searchTerm in searchTerms)
                {                    
                    FindCitationPage.DoCitationSearch(searchTerm);
                    FindCitationPage.VerifyResultsForReliability(searchTerm);
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

        [WorkItem(98250), TestCategory("SanityTest"), TestMethod]
        public void FindCitationValidationForMaximumAllowedSearchChars_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                FindCitationPage.VerifyFindCitationSearchForMaxChars();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(98600), TestCategory("SanityTest"), TestMethod]
        public void FindCitationValidationForMoreThanMaximumAllowedSearchChars_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                FindCitationPage.VerifyFindCitationSearchForMoreThanMaxChars();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(98249), TestCategory("SanityTest"), TestMethod]
        public void FindCitationWithFeedbackFunctionality_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.VerifyFeedbackLinkFunctionality();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(99683), TestCategory("SmokeTest"), TestMethod]
        public void FindCitationDefaultPagination_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();             
                FindCitationPage.DefaultPaginationVerification();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(99684), TestCategory("SanityTest"), TestMethod]
        public void FindCitationPaginationResults_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                FindCitationPage.VerifyPaginationForPreviousAndNextLinks();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(100135), TestCategory("SanityTest"), TestMethod]
        public void FindCitationValidaionPageMovement_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                FindCitationPage.VerifyPageDisplayOnCitation();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }
        
        [WorkItem(98251), TestCategory("SanityTest"), TestMethod]
        public void FindCitationResultsCount_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTab();
                FindCitationPage.DoCitationSearch("heart attack");
                FindCitationPage.VerifyResultCountPerPage();

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(99145), TestCategory("SanityTest"), TestMethod]
        public void FindCitationWithPartialSearchTermInDutchURL_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appDutchURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel(TestContext.TestName, MOGAConstants.dataBaseName);

                FindCitationPage.NavigateHere();
                FindCitationPage.SelectFindCitationTabDutchURL();
                foreach (string searchTerm in searchTerms)
                {                    
                    FindCitationPage.FindCitationSearchForDutchURL(searchTerm);
                    FindCitationPage.VerifyAllRecordsForPartialSearchTermDutch(searchTerm);
                }

                LoginPage.LogoutFromMOGADutch();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appDutchURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(1), TestCategory("SanityTest"), TestMethod]
        public void CitationSearchToolTipVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FindCitationPage.NavigateHere();
                FindCitationPage.CitationTabTooltipVerification();

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
