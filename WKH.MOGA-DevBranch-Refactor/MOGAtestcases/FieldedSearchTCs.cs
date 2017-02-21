using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.MOGA;
using System.Collections.Generic;
using WKH.SeleniumFrameWork;

namespace MOGAtestcases
{
    [TestClass]
    public class FieldedSearchTCs
    {


        # region constructor

       
        List<string> searchTerms = null;

        #endregion

        [WorkItem(101202), TestCategory("SanityTest"), TestMethod]
        public void SingleFieldSearchPartialSearchTerms_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                    FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                    LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                    FieldedSearchPage.NavigateHere();
                    FieldedSearchPage.SelectFieldedSearchTab();
                    CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                    Dictionary<string, string> fieldNames = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel("FieldName", "SearchTerm", "MedlineFields");
            
                    searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel("FieldName", "MedlineFields");
                /*modified for fix: This method is trying to get the error message without clicking the search button. So I have commennted the code and 
                 written two methods : 1 for clicking the search button and  the 2nd for the getting the error message*/
                
					//string result = CommonControlsPage.NoResultsFound();
                    
                    //Click the search button
                    FieldedSearchPage.ClickSearchButton();

                     //getting the error message for search without search term
                    string result = FieldedSearchPage.GetMessageForSearchWithoutSearchTerm();


					foreach (KeyValuePair<string, string> fieldNameAndValues in fieldNames)
                    {
                        FieldedSearchPage.NavigateHere();
                        FieldedSearchPage.SingleFieldSearch(fieldNameAndValues.Key, fieldNameAndValues.Value);
	                    if (result != null)
	                    {
                            Assert.AreEqual(result, "Please enter a search term");
						}
	                    else
	                    {
							FieldedSearchPage.VerifySinglefieldsResultsForPartialSearchTerm(fieldNameAndValues.Key, fieldNameAndValues.Value);
						}
                        
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
              
        [WorkItem(101203), TestCategory("SmokeTest"), TestMethod]
        public void SingleFieldSearchFullSearchTerm_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
            
                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.SelectFieldedSearchTab();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                Dictionary<string, string> fieldNames = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel("FieldName", "FullSearchTerm", "MedlineFields");

                foreach (KeyValuePair<string, string> fieldNameAndValues in fieldNames)
                {
                    FieldedSearchPage.NavigateHere();
                    FieldedSearchPage.SingleFieldSearch(fieldNameAndValues.Key, "\""+fieldNameAndValues.Value+"\"");
                    FieldedSearchPage.VerifySinglefieldsResultsForFullSearchTerm(fieldNameAndValues.Key, fieldNameAndValues.Value);
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

        [WorkItem(101204), TestCategory("SmokeTest"), TestMethod]
        public void MultiFieldSearchWithPartialTermsANDcase_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                
                Dictionary<string, string> field1Data = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel("FieldName1", "SearchTerm1", "MedlineFieldsANDcase");
                Dictionary<string, string> field2Data = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel("FieldName2", "SearchTerm2", "MedlineFieldsANDcase");

                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.MultiFieldSearchWithTheGivenOperators(field1Data, "AND");
                FieldedSearchPage.VerifyMultifieldResultsForPartialTermsWithANDoperator(field1Data);

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
        public void MultiFieldSearchWithTermWithColonANDcase_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                Dictionary<string, string> field1Data = new Dictionary<string, string> { { "Title ➰", "Transplantation: dramatic" }, { "Author(s) ➰", "Antoine" } };
               
                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.MultiFieldSearchWithTheGivenOperators(field1Data, "AND");
                FieldedSearchPage.VerifyMultifieldResultsForPartialTermsWithANDoperator(field1Data);

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(101205), TestCategory("SmokeTest"), TestMethod]
        public void MultiFieldSearchWithPartialTermsORcase_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                CommonControlsPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                Dictionary<string, string> field1Data = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel("FieldName1", "SearchTerm1", "MedlineFieldsANDcase");
                Dictionary<string, string> field2Data = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel("FieldName2", "SearchTerm2", "MedlineFieldsANDcase");

                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.MultiFieldSearchWithTheGivenOperators(field1Data,"OR");
                FieldedSearchPage.VerifyMultifieldResultsForPartialTermsWithORoperator(field1Data);

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(102693), TestCategory("SmokeTest"), TestMethod]
        public void MultiFieldSearchWithOperatorNOT_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                CommonControlsPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                Dictionary<string, string> fieldData = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel("FieldName3", "SearchTerm3", "MedlineFieldsANDcase");
               
                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.MultiFieldSearchWithTheGivenOperators(fieldData, "NOT");
                FieldedSearchPage.VerifyMultifieldResultsForNOToperator(fieldData);

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        [WorkItem(102616), TestCategory("SmokeTest"), TestMethod]
        public void MultiFieldSearchWithOperatorsANDandOR_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                CommonControlsPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                FieldedSearchPage dd = new FieldedSearchPage();

                List<FSTestData> testdata = null;
                testdata = dd.ReturnTestDataFromExcel("FieldName1", "SearchTerm1", "Opration1", "MedlineFieldsAND&OR");
               
                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.MultiFieldSearchWithAND_OR(testdata);
                FieldedSearchPage.VerifyMultifieldResultsForPartialTermsWithAND_ORoperator(testdata);

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

        //[WorkItem(101203), TestCategory("SmokeTest"), TestMethod]
        public void FieldedSearchWithSynonyms_Test()
        {
            //try
            //{
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.SelectFieldedSearchTab();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                Dictionary<string, string> fieldNames = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel("FieldName", "SearchTerm", "MedlineFields");

                searchTerms = MOGAConstants.mogaFunctions.ReadTestDatafromExcel("FieldName", "MedlineFields");

                foreach (KeyValuePair<string, string> fieldNameAndValues in fieldNames)
                {
                    FieldedSearchPage.NavigateHere();
                    FieldedSearchPage.SingleFieldSearch(fieldNameAndValues.Key, fieldNameAndValues.Value);
                    FieldedSearchPage.VerifySinglefieldsResultsForPartialSearchTerm(fieldNameAndValues.Key, fieldNameAndValues.Value);
                }

                LoginPage.LogoutFromMOGA();

                FrameworkBase.CloseBrowser();

                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            //}
            //catch (Exception ex)
            //{
            //    FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            //}
        }

        [WorkItem(102615), TestCategory("SanityTest"), TestMethod]
        public void MultiFieldSearchRetainFieldValues_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);
                CommonControlsPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                Dictionary<string, string> field1Data = MOGAConstants.mogaFunctions.ReturnTestDataOfTwoColumnsFromExcel("FieldName1", "SearchTerm1", "MedlineFieldsANDcase");
              
                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.MultiFieldSearchWithTheGivenOperators(field1Data,"AND");

                FieldedSearchPage.VerifyFieldsForRetainedValues(field1Data);

                LoginPage.LogoutFromMOGA();
                FrameworkBase.CloseBrowser();
                ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName);
            }
            catch (Exception ex)
            {
                FrameworkBase.CatchBlockCodeForResults(TestContext.TestName, MOGAConstants.userName1, ex.Message);
            }
        }

		[WorkItem(115474), TestCategory("SanityTest"), TestMethod]
		public void SingleFieldSearchforTeaserText_Test()
		{
			try
			{
				ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
				FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);

				LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

				FieldedSearchPage.NavigateHere();
				FieldedSearchPage.SelectFieldedSearchTab();
				CommonControlsPage.SelectResource(MOGAConstants.strAllResources);
				List<string> fieldlstList = MOGAConstants.mogaFunctions.ReadTestDatafromExcel("FieldName","TeaserText");
				Dictionary<string,string> fieldTeasers = new Dictionary<string, string>();
				foreach (var field in fieldlstList)
				{
					var val = field.Split('|');
					fieldTeasers.Add(val[0],val[1]);
				}
				foreach (KeyValuePair<string, string> fieldNameAndValues in fieldTeasers)
				{
					FieldedSearchPage.NavigateHere();
					FieldedSearchPage.SingleFieldSearch(fieldNameAndValues.Key, "\"" + fieldNameAndValues.Value + "\"");
					FieldedSearchPage.VerifySinglefieldsResultsForTeaserTextSearchTerm(fieldNameAndValues.Key, fieldNameAndValues.Value);
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
        public void FieldedSearchPaginationValidaion_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                CommonControlsPage.NavigateHere();
                CommonControlsPage.SelectResource(MOGAConstants.strAllResources);

                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.SelectFieldedSearchTab();
                FieldedSearchPage.VerifyPageDisplayOnFieldedSearch();

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
        public void FieldedSearchToolTipVerification_Test()
        {
            try
            {
                ResultReport.AddTestCaseName(TestContext.TestName, MOGAConstants.browserType);
                FrameworkBase.OpenBrowser(MOGAConstants.browserType, MOGAConstants.appURL);
                LoginPage.LoginToMOGA(MOGAConstants.userName1, MOGAConstants.passWord1);

                FieldedSearchPage.NavigateHere();
                FieldedSearchPage.FieldedSearchTabTooltipVerification();

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
