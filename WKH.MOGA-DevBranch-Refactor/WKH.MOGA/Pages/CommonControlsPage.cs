using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WKH.SeleniumFrameWork;

namespace WKH.MOGA
{
    public class CommonControlsPage : UIObjects
    {
        public static CommonControlsPage commonControlsPage;


        public CommonControlsPage()
        {
            PageFactory.InitElements(WebDriver, this);
            commonControlsPage = this;
        }

        //creating object of this class. Call this before accessing anyother method of this class
        public static void NavigateHere()
        {
            commonControlsPage = new CommonControlsPage();
        }

        #region CommonControls

        [FindsBy(How = How.ClassName, Using = "results")]
        public IWebElement resultsDiv;

        //[FindsBy(How = How.ClassName, Using = "card-block")]
        //public IWebElement recordsDiv;

        [FindsBy(How = How.ClassName, Using = "card-block")]
        public IList<IWebElement> recordsCollection;



        public int AbstractElement(IWebElement ele)
        {
            return CommonFixtures.FindChildElementsbyCriteria(ele,"Id","divAbsrow").Count;

        }

        [FindsBy(How = How.ClassName, Using = "title")]
        public IWebElement titleField;

        [FindsBy(How = How.Id, Using = "divAbsrow")]
        public IList<IWebElement> Abstract;

        [FindsBy(How = How.ClassName, Using = "authors")]
        public IWebElement authorsField;

        [FindsBy(How = How.ClassName, Using = "journal")] //Parent one
        public IWebElement journalDiv;

        [FindsBy(How = How.ClassName, Using = "journalName")]
        public IWebElement journalNameField;

        [FindsBy(How = How.ClassName, Using = "volume")]
        public IWebElement volumeField;

        [FindsBy(How = How.ClassName, Using = "issue")]
        public IWebElement issueField;

        [FindsBy(How = How.ClassName, Using = "pages")]
        public IWebElement pagesField;

        [FindsBy(How = How.ClassName, Using = "publicationtype")]
        public IWebElement articleTypeField;

        [FindsBy(How = How.LinkText, Using = "Feedback »")]
        public IWebElement feedbackLink;

        //Pagination controls        
        [FindsBy(How = How.ClassName, Using = "wk-icon-arrow-right")]
        public IWebElement rightArrowLink;

        [FindsBy(How = How.ClassName, Using = "wk-icon-arrow-left")]
        public IWebElement leftArrowLink;

        [FindsBy(How = How.CssSelector, Using = "wk-layout-item")]
        public IList<IWebElement> linksLayoutsInResultsRecordDiv;

        [FindsBy(How = How.CssSelector, Using = ".title>a")]
        public IWebElement titleLinkOfTheRecord;

        [FindsBy(How = How.ClassName, Using = "panel panel-primary")]
        public IWebElement referencePageHeader;

        //[FindsBy(How = How.XPath, Using = "//*[@class='col-sm-2 gridheader']")]
        [FindsBy(How = How.TagName, Using = "dt")]
        public IList<IWebElement> referenceFields;

        [FindsBy(How = How.CssSelector, Using = ".dl-horizontal>dd")]
        public IList<IWebElement> refernceFieldValues;

        [FindsBy(How = How.ClassName, Using = "wk-layout-66-33")]
        public IList<IWebElement> fieldsLayoutInResultsRecordDiv;

        //[FindsBy(How = How.ClassName, Using = "dl-horizontal")]
        //public IWebElement refernceFieldValue;

        [FindsBy(How = How.LinkText, Using = "Search")]
        public IWebElement searchTab;

        [FindsBy(How = How.LinkText, Using = "Citation Search")]
        public IWebElement findCitationTab;

        //Help page controls

        [FindsBy(How = How.LinkText, Using = "Help")]
        public IWebElement helpLink;

        [FindsBy(How = How.ClassName, Using = "text-Default")]
        public IWebElement helpPageHeading;

        [FindsBy(How = How.LinkText, Using = "About Ovid Labs")]
        public IWebElement aboutOvidLabsLink;

        [FindsBy(How = How.LinkText, Using = "Citation Search")]
        public IWebElement citationSearchLink;

        [FindsBy(How = How.LinkText, Using = "Search")]
        public IWebElement searchLink;

        [FindsBy(How = How.Id, Using = "section1")]
        public IWebElement aboutOvidLabsHelp;

        [FindsBy(How = How.Id, Using = "section2")]
        public IWebElement citationSearchHelp;

        [FindsBy(How = How.Id, Using = "section1")]
        public IWebElement searchHelp;

        [FindsBy(How = How.Id, Using = "Input_SelectedResource")]
        public IWebElement resourcesComboBoxId;

        //Tool tip controls
        [FindsBy(How = How.LinkText, Using = "LEARN MORE ...")]
        public IWebElement learnMoreLink;

        //Invite User controls
        [FindsBy(How = How.LinkText, Using = "Invite User")]
        public IWebElement inviteUserLink;

        [FindsBy(How = How.Id, Using = "Input_Recipients")]
        public IWebElement inviteUsersEditBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='InviteUsrBox']/form/button")]
        public IWebElement inviteButton;

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success")]
        public IWebElement alertSuccess;

        [FindsBy(How = How.Id, Using = "MedlineWarning")]
        public IWebElement alertWarning;

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-info>p")]
        public IWebElement alertInfo;

        [FindsBy(How = How.LinkText, Using = "RCP")]
        public IWebElement rcp;

        //No Results on Search
        [FindsBy(How = How.XPath, Using = ".//*[@id='FieldedSearchResult']/h2")]
        public IWebElement noResultsFound;

        //teaser Text
        [FindsBy(How = How.CssSelector, Using = ".col-sm-12.teasertxt.rowPadding")]
        public IWebElement teaserText;

        //abstract Text
        [FindsBy(How = How.XPath, Using = "//*[@id=\"divAbsrow\"]/div/div/div/p")]
        public IWebElement abstractText;

        //abstract Text
        [FindsBy(How = How.CssSelector, Using = ".wk-icon-angle-down")]
        public IWebElement abstractArrow;

        //Commom constants for SBA
        public string rowClass;

        //Control properties of search results of the records
        public static string titleLinkClassname = "title";
        public static string authorsSpanClassName = "authors";
        public static string journalSpanClassName = "blackTitle";
        public static string journalSpanId = "JournalName";
        public static string volumeSpanClassName = "volume";
        public static string issueSpanClassName = "issue";
        public static string pagesSpanClassName = "pages";
        public static string articleTypeSpanClassName = "publicationtype";
        public static string dateSpanClassName = "date";
        public static string abstractLinkDivId = "divAbsrow";
        public static string abstractLinkText = "Abstract";
        public static string strResourceComboBoxId = "Input_SelectedResource"; //Input_ContentSelected


        #endregion

        #region CommonMehodsOfSBA

        /// <summary>
        /// Click Search/Simple search tab
        /// </summary>
        public static void SelectSearchTab()
        {
            ResultReport.AddTestStepDetails("Select Search Tab");
            //Selecting fielded search Tab
            commonControlsPage.searchTab.Click();
           Assert.IsTrue(CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.ClassName("wk-search-input")));
            //WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));
            //waitForObject.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.ClassName("wk-search-input")));
        }





        /// <summary>
        /// Teaser Text
        /// </summary>
        public static void AbstractArrowClick()
        {
            ResultReport.AddTestStepDetails("Abstract Arrow Click");
            //Retriving No Results Found Message
            commonControlsPage.abstractArrow.Click();

        }

        /// <summary>
        /// Teaser Text
        /// </summary>
        public static string AbstractText()
        {
            ResultReport.AddTestStepDetails("Abstract Text");
            //Retriving No Results Found Message
            return commonControlsPage.abstractText.Text;

        }

        /// <summary>
        /// Teaser Text
        /// </summary>
        public static string TeaserText()
        {
            ResultReport.AddTestStepDetails("Teaser Text");
            //Retriving No Results Found Message
            return commonControlsPage.teaserText.Text;

        }

        /// <summary>
        /// No Results Found
        /// </summary>
        public static string NoResultsFound()
        {
            ResultReport.AddTestStepDetails("No Results Found");
            //Retriving No Results Found Message
            return commonControlsPage.noResultsFound.Text;

        }

        /// <summary>b
        /// Select Resource
        /// </summary>
        public static void SelectResource(string resourceName)
        {
            ResultReport.AddTestStepDetails("Select required resource");

            Assert.IsTrue(CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.Id(strResourceComboBoxId)));

            //WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
            //waitForObject.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id(strResourceComboBoxId)));

            CommonMethods.SelectDropdownListByText(WebDriver ,By.Id(strResourceComboBoxId), resourceName);
        }

        /// <summary>
        /// Verify Resource selection preference
        /// </summary>
        public static void VerifySelectedResourcePreference(string expResourceName)
        {
            ResultReport.AddTestStepDetails("Verify selected resource preference");

            Assert.IsTrue(CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.Id(strResourceComboBoxId)));

            //WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
            //waitForObject.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id(strResourceComboBoxId)));

            //Get Selected resource option from Dropdown
            SelectElement selectElement = new SelectElement(commonControlsPage.resourcesComboBoxId);
            string actResourceName = selectElement.SelectedOption.Text;

            Assert.IsTrue(expResourceName.Trim() == actResourceName.Trim(), "Resource preference not saved, please select");
        }

        /// <summary>
        /// Verifying the fields of Reference
        /// </summary>     
        public static void VerifyCompleteReferenceFieldsForTheExistence()
        {
            ResultReport.AddTestStepDetails("Verifying complete reference page for the fields existence");

            Assert.IsTrue(CommonFixtures.WaitTillElementwithTextDisappeared(WebDriver, By.TagName("a"), "Back to Results"));

            //WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));
            //waitForObject.Until(ExpectedConditions.InvisibilityOfElementWithText(By.TagName("a"), "Back to Results"));
            //waitForObject.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("dl-horizontal"))); //Classname of the grid

            Thread.Sleep(3000);

            string[] fieldNames = { "Title", "PMID", "Ovid Accession Number", "Owner", "Authors", "Institutions", "MeSH", "Country of Publication", "Status", "Creation Date", "Entry Date", "Update Date", "DOI", "Abstract", "Issn", "ISSN Linking", "Grants", "NLM Journal Code", "NLM Journal Name", "Language", "Journal Subset", "Other IDs", "Keyword Headings", "Publication Type" };

            bool flag = false;

            foreach (string field in fieldNames)
            {
                foreach (IWebElement element in commonControlsPage.referenceFields)
                {
                    if (element.Text.Replace(":", "").Trim() == field)
                    {
                        flag = true;
                        break;
                    }
                }
                Assert.IsTrue(flag, "Field: " + field + " not found in reference page");
                flag = false;
            }

        }

        public static void VerifyCompleteReferenceFieldsFromExcel(string[] displayResult)
        {

            ResultReport.AddTestStepDetails("Verifying complete reference page for the fields existence");

            Assert.IsTrue(CommonFixtures.WaitTillElementwithTextDisappeared(WebDriver, By.TagName("a"), "Back to Results"));


            //WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));
            //waitForObject.Until(ExpectedConditions.InvisibilityOfElementWithText(By.TagName("a"), "Back to Results"));

            Dictionary<string, string> resultDictionary = new Dictionary<string, string>();

            List<string> splitDisplayTerm = new List<string>();
            foreach (var displayTerm in displayResult)
            {
                var split = displayTerm.Split('|');
                splitDisplayTerm.Add(split[0]);
                if (split.Length > 1)
                {
                    for (int i = 1; i < split.Length; i++)
                    {
                        splitDisplayTerm.Add(split[i]);

                    }

                }

            }
            if (splitDisplayTerm != null)
            {
                foreach (var splitTerm in splitDisplayTerm)
                {
                    var finalSplit = splitTerm.Split('#');
                    resultDictionary.Add(finalSplit[0], finalSplit[1]);
                }
            }
            Dictionary<string, string> actualResult = new Dictionary<string, string>();
            int inc = 0;
            foreach (IWebElement element in commonControlsPage.referenceFields)
            {
                actualResult.Add(element.Text.Replace(":", "").Trim(), commonControlsPage.refernceFieldValues[inc].Text);

                inc++;
            }

            foreach (KeyValuePair<string, string> result in resultDictionary)
            {
                if (actualResult.ContainsKey(result.Key.Replace("\n", String.Empty).Trim()))
                {

                    if (actualResult[result.Key.Replace("\n", string.Empty).Trim()].Equals(result.Value))
                    {

                    }


                }
            }
        }

        // Checks whether the terms present in the fields passed, if *, then all fields needs to be checked
        // if operation and rightTerm are empty, then it will check the leftTerm alone
        public static bool CheckSearchTermWithOperatorInCompleteReference(string[] fieldNames, string leftTerm, string operation, string rightTerm, ref bool leftFlag, ref bool rightFlag)
        {
            ResultReport.AddTestStepDetails("Verifying complete reference page for terms in the fields");

          //  Thread.Sleep(2000); // Added temprarily to stop Jenkins build failure.

            //WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));
            //waitForObject.Until(ExpectedConditions.TextToBePresentInElement(WebDriver.FindElement(By.ClassName("dl-horizontal")).FindElement(By.TagName("dt")), "Title :")); //Class name of the reference grid

            IWebElement webElement = WebElement("ClassName=dl-horizontal");

            IList<IWebElement> refFieldNameCollection = CommonFixtures.FindChildElementsbyCriteria(webElement,"TagName","dt");
            IList<IWebElement> refFieldValueCollection = CommonFixtures.FindChildElementsbyCriteria(webElement, "TagName", "dd");

            bool flag = false;
            bool bCompareAll = fieldNames[0].Equals("*");

            for (int fieldIndex = 0; fieldIndex < refFieldNameCollection.Count; fieldIndex++)
            {
                bool bCompare = false;
                // if not all fields
                if (!bCompareAll)
                {
                    string fieldName = refFieldNameCollection[fieldIndex].Text.ToLower();
                    foreach (string fName in fieldNames)
                    {
                        if (fName.ToLower().Equals(fieldName))
                        {
                            bCompare = true;
                            break;
                        }
                    }
                }
                // if either compare all or if the field is the field to compare
                if (bCompareAll || bCompare)
                {
                    if (refFieldValueCollection[fieldIndex].Text.Length <= 0)
                        continue;
                    MOGAConstants.mogaFunctions.CheckBothTermInField(refFieldValueCollection[fieldIndex].Text.ToLower(), leftTerm, operation, rightTerm, ref leftFlag, ref rightFlag);

                    // both term should present
                    if (operation.Equals("and"))
                    {
                        flag = leftFlag && rightFlag;
                    }
                    // either one of them should present
                    else if (operation.Equals("or"))
                    {
                        flag = leftFlag || rightFlag;
                    }
                    // the left should present & the right shouldn't
                    else if (operation.Equals("not"))
                    {
                        flag = leftFlag && rightFlag;
                    }
                    // Validation for no operator
                    else
                    {
                        Assert.Fail("Operator not given in Test data, please check");
                    }

                    // if matched break and return
                    if (flag)
                    {
                        break;
                    }
                }
            }
            return flag;
        }


        // Checks whether the terms present in the fields passed, if *, then all fields needs to be checked
        // if operation and rightTerm are empty, then it will check the leftTerm alone
        public static bool CheckSearchTermWithoutOperatorInCompleteReference(string[] fieldNames, string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying complete reference page for search terms in the fields");

            IWebElement webElement = UIObjects.WebElement("class=dl-horizontal");

            IList<IWebElement> refFieldNameCollection = CommonFixtures.FindChildElementsbyCriteria(webElement, "TagName", "dt");
            IList<IWebElement> refFieldValueCollection = CommonFixtures.FindChildElementsbyCriteria(webElement, "TagName", "dd");

           //IList<IWebElement> refFieldNameCollection = WebDriver.FindElement(By.ClassName("dl-horizontal")).FindElements(By.TagName("dt"));
            //IList<IWebElement> refFieldValueCollection = WebDriver.FindElement(By.ClassName("dl-horizontal")).FindElements(By.TagName("dd"));

            bool flag = false;
            bool bCompareAll = fieldNames[0].Equals("*");
            string[] searchTermArray = searchTerm.Split(' ');
            for (int fieldIndex = 0; fieldIndex < refFieldNameCollection.Count; fieldIndex++)
            {
                bool bCompare = false;
                // if not all fields
                if (!bCompareAll)
                {
                    string fieldName = refFieldNameCollection[fieldIndex].Text.ToLower();
                    foreach (string fName in fieldNames)
                    {
                        if (fName.ToLower().Equals(fieldName))
                        {
                            bCompare = true;
                            break;
                        }
                    }
                }
                // if either compare all or if the field is the field to compare
                if (bCompareAll || bCompare)
                {
                    if (refFieldValueCollection[fieldIndex].Text.Length <= 0)
                        continue;
                    flag = MOGAConstants.mogaFunctions.VerifySearchTermInArray(refFieldValueCollection[fieldIndex].Text.ToLower(), searchTermArray);

                    // if matched break and return
                    if (flag)
                    {
                        break;
                    }
                }
            }
            return flag;
        }


        /// <summary>
        /// Click Title link of the record
        /// </summary>     
        public static void ClickTitleLink()
        {
            ResultReport.AddTestStepDetails("Click Title link of first record");
            //Click on Title of first record
            CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[0],"css",".title>a").Click();

        }

        /// <summary>
        /// Verify Abstract link of each record for existence
        /// </summary>     
        public static void VerifyAbstractLinkAndTermInResults(string abstractTerm)
        {
            ResultReport.AddTestStepDetails("Verify Abstract link of each record");
			if (commonControlsPage.recordsCollection.Count != 0)
            {
                for (int i = 0; i < commonControlsPage.recordsCollection.Count; i++)
                {
                    IWebElement record = CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i], "LinkText", abstractLinkText);
                    Assert.IsTrue(record.Displayed);

                    CommonMethods.ClickElementUsingJavaScript(record);

                    bool abstractflag = false;
                    //Capturing all sections of Abstract and verifying each section for the search term
                    ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria( CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i],"Id","divAbsrow"),"TagName","P");
                    for (int fieldCount = 0; fieldCount < list.Count; fieldCount++)
                    {
                        string abstractValue = list[fieldCount].Text.ToLower();
                        if (abstractValue.Contains(abstractTerm.ToLower()))
                        {
                            abstractflag = true;
                            break;
                        }
                    }
                    Assert.IsTrue(abstractflag, "Unable to find search term " + abstractTerm + "in the Abstract field of the record" + i);
                }
            }
            else
            {
                Assert.IsTrue(false, "No records for the search term: " + abstractTerm);
            }

        }


        // This method verifies the References link functionality for all the records on the first page
        public static void VerifyAllRecordsForReferenceLink(params string[] displayResults)
        {
            ResultReport.AddTestStepDetails("Verifying reference link functionality");

            if (commonControlsPage.recordsCollection.Count != 0)
            {
                for (int j = 0; j < commonControlsPage.recordsCollection.Count; j++)
                {
                    ReadOnlyCollection<IWebElement> list =CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[j],"TagName","a");
                    bool referenceLinkFlag = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        commonControlsPage.rowClass = list[i].Text;

                        if (commonControlsPage.rowClass == "View Reference")
                        {
                            referenceLinkFlag = true;

                            CommonMethods.ClickElementUsingJavaScript(list[i]);
                            //list[i].Click();
                            if (displayResults.Length > 0)
                            {
                                VerifyCompleteReferenceFieldsFromExcel(displayResults);
                            }
                            else
                            {
                                VerifyCompleteReferenceFieldsForTheExistence();
                            }

                            WebDriver.Navigate().Back();
                            break;
                        }
                    }
                    Assert.IsTrue(referenceLinkFlag, "Reference link not found in the Links layout of the record number:" + j);
                }

            }
            else
                Assert.IsTrue(false, "No results found");

        }

        // This method verifies the References link functionality for all the records on the first page
        public static void VerifyAllRecordsForViewReferenceLink(string displayResults)
        {
            ResultReport.AddTestStepDetails("Verifying view reference link functionality");
            Thread.Sleep(2000);
            //Getting all the result blocks. Iterating all blocks and clicking the view reference link
            //checking if the opened page content's title coontains any substring of the search item
            int recordCount = commonControlsPage.recordsCollection.Count;
            if (recordCount != 0)
            {
                for (int j = 0; j < recordCount; j++)
                {
                    //getting list of search result block
                    IList<IWebElement> lstSearchResultBlock = commonControlsPage.recordsCollection;
                    //getting the view refrence link of the respective block
                    IWebElement viewReferenceLink = CommonFixtures.FindChildElementsbyCriteria(lstSearchResultBlock[j], "XPath", "//div/a[text()='View Reference']")[j];
                    viewReferenceLink.Click();
                    Thread.Sleep(3000);
                    VerifyReferencePageHasProperTitle(displayResults);
                    WebDriver.Navigate().Back();
                }

            }
            else
                Assert.IsTrue(false, "No results found");
        }

        private static void VerifyReferencePageHasProperTitle(string displayResults)
        {
            Dictionary<string, string> resultRecord = new Dictionary<string, string>();
            Dictionary<string, string> expectedResults = new Dictionary<string, string>();
            List<IWebElement> titles = WebElements("XPath=//dl[@class = 'dl-horizontal']/dt").ToList(); 
            List <IWebElement> values = WebElements("XPath=//dl[@class = 'dl-horizontal']/dd").ToList();
            int titlesCount = titles.Count();
            for (int i = 0; i < titlesCount; i++)
            {
                resultRecord.Add(titles[i].Text.Substring(0, titles[i].Text.Length - 2).Trim(), values[i].Text);
            }
            List<string> SearchTerms = displayResults.Split('|').ToList();
            List<string> expec;
            for (int i = 0; i < SearchTerms.Count; i++)
            {
                expec = SearchTerms[i].Split('#').ToList();
                expectedResults.Add(expec[0].Trim(), expec[1].Trim());
            }
            bool flag = false;
            foreach (KeyValuePair<string, string> entry in expectedResults)
            {
                List<string> ExpectedSubStrings = new List<string>();
                ExpectedSubStrings = entry.Value.Split(' ').Select(innerItem => innerItem.Trim()).ToList();
                //if (resultRecord[entry.Key] == entry.Value)
                if (ExpectedSubStrings.Any(resultRecord[entry.Key].Contains))
                {
                    flag = true;
                }
            }
            Assert.IsTrue(flag, "Reference Page Content does not contain matching search Term");
        }

        // This method verifies the PubMed link functionality for all the records on the first page
        public static void VerifyAllRecordsForViewPubmedLink()
        {
            ResultReport.AddTestStepDetails("Validating records for PubMed link");
            FindCitationPage.NavigateHere();
            if (commonControlsPage.recordsCollection.Count != 0)
            {
                for (int j = 0; j < commonControlsPage.recordsCollection.Count; j++)
                {

                    //Capture Title of the record
                    string titleOfTheRecordInSBA = CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[j],"ClassName",titleLinkClassname).Text;

                    ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[j],"TagName","a");
                    bool pubmedFlag = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        commonControlsPage.rowClass = list[i].Text;

                        if (commonControlsPage.rowClass == "View PubMed")
                        {
                            pubmedFlag = true;
                            string winHandleBefore = WebDriver.CurrentWindowHandle;

                            CommonMethods.ClickElementUsingJavaScript(list[i]);
                            //list[i].Click();

                            //Identifying new browser page of PubMed website
                            List<string> handles = WebDriver.WindowHandles.ToList<string>();
                            WebDriver.SwitchTo().Window(handles.Last());

                            string tilteInPubMedSite = UIObjects.WebElement("CssSelector=.rprt.abstract>h1").Text;

                           // string tilteInPubMedSite = WebDriver.FindElement(By.CssSelector(".rprt.abstract>h1")).Text;

                            Assert.IsTrue(titleOfTheRecordInSBA == tilteInPubMedSite, "Title of the record does not match with Pubmed");

                            WebDriver.Close();

                            WebDriver.SwitchTo().Window(handles.First());

                            break;
                        }

                    }
                    Assert.IsTrue(pubmedFlag, "Pubmed link not found in the Links layout of the record number:" + j);
                }

            }
            else
                Assert.IsTrue(false, "No results found");

        }

        // This method verifies the PubMedCentral link functionality for all the records on the first page
        public static void VerifyAllRecordsForViewPubmedCentralLink()
        {
            ResultReport.AddTestStepDetails("Validating records in PubMed Central");
            FindCitationPage.NavigateHere();
            if (commonControlsPage.recordsCollection.Count != 0)
            {
                for (int j = 0; j < commonControlsPage.recordsCollection.Count; j++)
                {

                    //Capture Title of the record
                    string titleOfTheRecordInSBA = CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[j],"ClassName",titleLinkClassname).Text;

                    ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[j],"TagName","a");
                    bool pubMedCentFlag = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        commonControlsPage.rowClass = list[i].Text;

                        if (commonControlsPage.rowClass == "View PubMed Central")
                        {
                            pubMedCentFlag = true;
                            string winHandleBefore = WebDriver.CurrentWindowHandle;

                            CommonMethods.ClickElementUsingJavaScript(list[i]);
                            //list[i].Click();

                            //Identifying new browser page of PubMed website
                            List<string> handles = WebDriver.WindowHandles.ToList<string>();

                            WebDriver.SwitchTo().Window(handles.Last());

                            string tilteInPubMedCentralSite = UIObjects.WebElement("CssSelector=.content-title").Text;

                           // string tilteInPubMedCentralSite = WebDriver.FindElement(By.CssSelector(".content-title")).Text;

                            Assert.IsTrue(titleOfTheRecordInSBA == tilteInPubMedCentralSite + ".", "Title of the record does not match with Pubmed Central");

                            CommonFixtures.CloseCurrentWindow(WebDriver);
                            UIObjects.SwitchToPreviousWindow(WebDriver, handles.First());

                            break;
                        }
                    }
                    Assert.IsTrue(pubMedCentFlag, "Pub med central link not found in the Links layout in search results of the record number:" + j);
                }

            }
            else
                Assert.IsTrue(false, "No results found");

        }

        // This method verifies the ViewOnOvid link functionality for all the records on the first page
        public static void VerifyAllRecordsForViewOnOvidLink()
        {
            ResultReport.AddTestStepDetails("Verifying search results for View on Ovid link");

            if (commonControlsPage.recordsCollection.Count != 0)
            {
                for (int j = 0; j < commonControlsPage.recordsCollection.Count; j++)
                {
                    //Capture Title of the record
                    string titleOfTheRecordInSBA = CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[j], "ClassName", titleLinkClassname).Text;

                    ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[j], "TagName", "a");

                     bool ovidLinkFlag = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        commonControlsPage.rowClass = list[i].Text;

                        if (commonControlsPage.rowClass == "View on Ovid")
                        {
                            ovidLinkFlag = true;
                            string winHandleBefore = WebDriver.CurrentWindowHandle;

                            CommonMethods.ClickElementUsingJavaScript(list[i]);
                            //list[i].Click();

                            //Identifying new browser page of Ovid website
                            List<string> handles = WebDriver.WindowHandles.ToList<string>();
                            WebDriver.SwitchTo().Window(handles.Last());

                            if (UIObjects.WebElements("Id=ID").Count > 0)
                            {
                                UIObjects.WebElement("Id=ID").SendKeys("automate");

                                UIObjects.WebElement("Id=password").SendKeys("autotest");

                                UIObjects.WebElement("ClassName=standard-button-login").Click();
                            }
                            //modified for fix of test case name 'ViewOnOvidLinkVerification_Test'
                            //the title link element identification is corrected. Hence commenting the wrong identification.
                            //string tilteInOvidWebSite = WebDriver.FindElement(By.ClassName("fulltext-TITLE")).Text;

                            //Writing correct identification of title element
                            string tilteInOvidWebSite = UIObjects.WebElement("TagName=title_link_here").Text;

                            /*
                             *modified for fix of test case name 'ViewOnOvidLinkVerification_Test'
                             * Changing the Assert of title match from equals to contains as The title is also having the language name.
                             */
                            // Assert.IsTrue(titleOfTheRecordInSBA == tilteInOvidWebSite + ".", "Title of the record does not match with Ovid");

                            Assert.IsTrue(tilteInOvidWebSite.Contains(titleOfTheRecordInSBA), "Ovid does not contain the Title of the record");

                            CommonFixtures.CloseCurrentWindow(WebDriver);
                            UIObjects.SwitchToPreviousWindow(WebDriver, handles.First());
                            break;
                        }

                    }
                    Assert.IsTrue(ovidLinkFlag, "View on Ovid link not found in the Links layout of the record number:" + j);
                }

            }
            else
                Assert.IsTrue(false, "No results found");

        }

        // This method verifies the DOI link functionality for all the records on the first page
        public static void DOILinkValidation()
        {
            ResultReport.AddTestStepDetails("Verifying search results for DOI link");
            FindCitationPage.NavigateHere();

            int RecordCollectionCount = commonControlsPage.recordsCollection.Count;
            if (RecordCollectionCount != 0)
            {
                for (int j = 0; j < RecordCollectionCount; j++)
                {
                    //Capture Title of the record
                    string titleOfTheRecordInSBA =CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[j],"ClassName",titleLinkClassname).Text;

                    CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver, By.LinkText("View DOI Site"), 60);
                   
                    CommonMethods.ClickElementUsingJavaScript(CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[j],"LinkText","View DOI Site"));
                    //commonControlsPage.recordsCollection[j].FindElement(By.LinkText("View DOI Site")).Click();

                    //Identifying new browser page of DOI website
                    List<string> handles = WebDriver.WindowHandles.ToList<string>();
                    //Waiters.WaitSwitchToWindowByTitle(WebDriver,handles.Last());
                    WebDriver.SwitchTo().Window(handles.Last());

                    //As we have multiple DOI third party websites using following code to handle
                    string tilteInDOISite = string.Empty;
                    if (UIObjects.WebElements("ClassName=svTitle").Count > 0)
                    {
                        tilteInDOISite = UIObjects.WebElement("ClassName=svTitle").Text;
                    }
					else if (UIObjects.WebElements("ClassName=aTitle").Count > 0)
					{
						tilteInDOISite = UIObjects.WebElement("ClassName=aTitle").Text;
					}
                    else if (UIObjects.WebElements("CssSelector=.mainTitle").Count > 0)
                    {
                        tilteInDOISite = UIObjects.WebElement("CssSelector=.mainTitle").Text;
                    }
                    else if (UIObjects.WebElements("Id=article-title-1").Count > 0)
                    {
                        tilteInDOISite = UIObjects.WebElement("Id=article-title-1").Text;
                    }
                    else if (UIObjects.WebElements("ClassName=ArticleTitle").Count > 0)
                    {
                        tilteInDOISite = UIObjects.WebElement("ClassName=ArticleTitle").Text;
                    }
                    else if (UIObjects.WebElements("CssSelector=.description>span>h1").Count > 0)
                    {
                        CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver, By.CssSelector(".description>span>h1"), 120);

                        tilteInDOISite = UIObjects.WebElement("CssSelector=.description>span>h1").Text;
                    }
                    else if (UIObjects.WebElements("XPath=.//*[@id='articleTitle']/h3").Count > 0)
                    {
                        tilteInDOISite = UIObjects.WebElement("XPath=.//*[@id='articleTitle']/h3").Text;
                    }
                    else if (UIObjects.WebElements("XPath=.//*[@id='eidarticle']/h1").Count > 0)
                    {
                        tilteInDOISite = UIObjects.WebElement("XPath=//*[@id='eidarticle']/h1").Text;
                    }
                    
                    //Removing Special characters from the 'Original' and 'Compare' texts
                    string strActual = Regex.Replace(titleOfTheRecordInSBA, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                    string strCompare = Regex.Replace(tilteInDOISite, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);

                    Assert.IsTrue(tilteInDOISite != string.Empty, "Title not captured from DOI site,please check the script");

                    //Assert.IsTrue(titleOfTheRecordInSBA.ToLower().Trim().Contains(tilteInDOISite.ToLower().Replace("(", "").Replace(")", "").Replace("☆", "").Replace("-", "—").Replace("’", "'").Trim()), "Title of the record does not match with DOI site");
                    Assert.IsTrue(strActual.Contains(strCompare), "Title of the record does not match with DOI site");
                    CommonFixtures.CloseCurrentWindow(WebDriver);
                    UIObjects.SwitchToPreviousWindow(WebDriver, handles.First());
                }
            }
            else
                Assert.IsTrue(false, "No results found");

        }

        // This method verifies the Journal site link functionality for all the records on the first page
        public static void VerifyJournalSiteLinkForExistance()
        {
            ResultReport.AddTestStepDetails("Verifying Journal site link functionality");

            int RecordCollectionCount = commonControlsPage.recordsCollection.Count;
            if (RecordCollectionCount != 0)
            {
                for (int j = 0; j < RecordCollectionCount; j++)
                {
                    ReadOnlyCollection<IWebElement> list =CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[j],"TagName","a");
                    bool journalSiteLinkFlag = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        commonControlsPage.rowClass = list[i].Text;

                        if (commonControlsPage.rowClass == "View Journal Site")
                        {
                            journalSiteLinkFlag = true;
                            CommonMethods.ClickElementUsingJavaScript(list[i]);

                            //Identifying new browser page of Journals website
                            List<string> handles = WebDriver.WindowHandles.ToList<string>();
                            WebDriver.SwitchTo().Window(handles.Last());

                            string journalSiteURL = WebDriver.Url;

                            Assert.IsTrue(journalSiteURL.Contains("http://journals.lww.com/pages/default.aspx"), "Journals website journals.lww.com site not opened");

                            CommonFixtures.CloseCurrentWindow(WebDriver);
                            UIObjects.SwitchToPreviousWindow(WebDriver, handles.First());
                            break;
                        }
                    }
                    Assert.IsTrue(journalSiteLinkFlag, "Journal site link not found in the Links layout of the record number:" + j);
                }

            }
            else
                Assert.IsTrue(false, "No results found");

        }

        // This method verifies the Journal site link for non-existance of all the records on the first page
        public static void VerifyJournalSiteLinkForNonExistance()
        {
            ResultReport.AddTestStepDetails("Verifying Journal site link functionality");

            if (commonControlsPage.recordsCollection.Count != 0)
            {
                for (int j = 0; j < commonControlsPage.recordsCollection.Count; j++)
                {
                    ReadOnlyCollection<IWebElement> list =CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[j],"TagName","a");
                    bool journalSiteLinkFlag = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        commonControlsPage.rowClass = list[i].Text;

                        if (commonControlsPage.rowClass == "View Journal Site")
                        {
                            journalSiteLinkFlag = true;
                            break;
                        }
                    }
                    Assert.IsFalse(journalSiteLinkFlag, "Journal site link found for Medline record number:" + j);
                }

            }
            else
                Assert.IsTrue(false, "No results found");

        }

        // This method verifies the the links should be available for Medline records
        public static void VerifyAvaialableLinksForMedlineRecords()
        {
            ResultReport.AddTestStepDetails("Verifying Medline records for available links");

            if (commonControlsPage.recordsCollection.Count != 0)
            {
                for (int j = 0; j < commonControlsPage.recordsCollection.Count; j++)
                {
                    //Capture Title of the record
                    string titleOfTheRecordInSBA =CommonFixtures.FindChildElementbyCriteria( commonControlsPage.recordsCollection[j],"ClassName",titleLinkClassname).Text;

                    ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[j],"TagName","a");

                    bool viewReferenceFlag = false;
                    bool viewOnOvidLinkFlag = false;
                    bool viewJournalSiteFlag = false;

                    for (int i = 0; i < list.Count; i++)
                    {
                        commonControlsPage.rowClass = list[i].Text;

                        if (commonControlsPage.rowClass == "View Reference")
                        {
                            viewReferenceFlag = true;
                        }

                        if (commonControlsPage.rowClass == "View on Ovid")
                        {
                            viewOnOvidLinkFlag = true;
                        }

                        if (commonControlsPage.rowClass == "View Journal Site")
                        {
                            viewJournalSiteFlag = true;
                        }

                    }
                    Assert.IsTrue(viewReferenceFlag, "View Reference link not found in the Links layout of the record number:" + j);
                    Assert.IsTrue(viewOnOvidLinkFlag, "View on Ovid link not found in the Links layout of the record number:" + j);
                    Assert.IsFalse(viewJournalSiteFlag, "View Journal Site link found for Medline record record number:" + j);
                }

            }
            else
                Assert.IsTrue(false, "No results found");

        }

        // This method verifies the the links should be available for Journals
        public static void VerifyAvaialableLinksForJournals()
        {
            ResultReport.AddTestStepDetails("Verifying Journals for available links");

            if (commonControlsPage.recordsCollection.Count != 0)
            {
                for (int j = 0; j < commonControlsPage.recordsCollection.Count; j++)
                {
                    //Capture Title of the record
                    string titleOfTheRecordInSBA = CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[j], "ClassName", titleLinkClassname).Text;

                    ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[j], "TagName", "a");

                    bool viewReferenceFlag = false;
                    bool viewOnOvidLinkFlag = false;
                    bool viewJournalOrDOISiteFlag = false;

                    for (int i = 0; i < list.Count; i++)
                    {
                        commonControlsPage.rowClass = list[i].Text;

                        if (commonControlsPage.rowClass == "View Reference")
                        {
                            viewReferenceFlag = true;
                        }

                        if (commonControlsPage.rowClass == "View on Ovid")
                        {
                            viewOnOvidLinkFlag = true;
                        }

                        if ((commonControlsPage.rowClass == "View Journal Site") || (commonControlsPage.rowClass == "View DOI Site"))
                        {
                            viewJournalOrDOISiteFlag = true;
                        }

                    }
                    Assert.IsTrue(viewReferenceFlag, "View Reference link not found in the Links layout of the record number:" + j);
                    Assert.IsFalse(viewOnOvidLinkFlag, "View on Ovid link found for Journal record number:" + j);
                    Assert.IsTrue(viewJournalOrDOISiteFlag, "Journal or DOI link not found for Journal number:" + j);
                }

            }
            else
                Assert.IsTrue(false, "No results found");

        }

        /// <summary>
        /// Verifying complete reference Navigating from Title link
        /// </summary>     
        public static void VerifyTitleLinkNavigation()
        {
            ResultReport.AddTestStepDetails("Verifying complete reference for Title");

            if (commonControlsPage.recordsCollection.Count != 0)
            {
                for (int i = 0; i < commonControlsPage.recordsCollection.Count; i++)
                {
                    CommonMethods.ClickElementUsingJavaScript( CommonFixtures.FindChildElementbyCriteria( commonControlsPage.recordsCollection[i],"CssSelector",".title>a"));
                    //commonControlsPage.recordsCollection[i].FindElement(By.CssSelector(".title>a")).Click();
                    VerifyCompleteReferenceFieldsForTheExistence();
                    WebDriver.Navigate().Back();
                    CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver, By.Id("Input_Citation"), 60);

                }
            }
            else
            {
                Assert.IsTrue(false, "No records found for the given search term");
            }
        }

        /// <summary>
        /// This method verifies Help link
        /// </summary>
        public static void VerifyHelpPage()
        {
            ResultReport.AddTestStepDetails("Verifying Help Page for existence");

            commonControlsPage.helpLink.Click();
            CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver, By.Id("section1"), 60);

            Assert.IsTrue(commonControlsPage.aboutOvidLabsHelp.Text.Contains("About Ovid Labs"), "About Ovid Labs help text not found");
            Assert.IsTrue(commonControlsPage.aboutOvidLabsHelp.Text.Contains("Citation Search"), "Citation Search help text not found");
            Assert.IsTrue(commonControlsPage.aboutOvidLabsHelp.Text.Contains("Search"), "Search help text not found");

            Assert.IsTrue(commonControlsPage.aboutOvidLabsLink.Displayed, "About Ovid Labs scrollSpy link not found");
            Assert.IsTrue(commonControlsPage.citationSearchLink.Displayed, "Citation Search scrollSpy link not found");
            Assert.IsTrue(commonControlsPage.searchLink.Displayed, "Search scrollSpy link not found");

        }

        /// <summary>
        /// This method verifies Invite user error messages validation
        /// </summary>
        public static void VerifyInviteUserErrorMessages()
        {
            ResultReport.AddTestStepDetails("Verifying Help Page for existence");

            commonControlsPage.inviteUserLink.Click();
            CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver, By.Id("Input_Recipients"), 60);

            commonControlsPage.inviteUsersEditBox.SendKeys("test@wolterskluwer.com");
            commonControlsPage.inviteButton.Click();
            Assert.IsTrue(commonControlsPage.alertSuccess.Text == "Your Invitation has been sent Successfully.\r\nTEST@WOLTERSKLUWER.COM", "Expected validation message is not getting displayed");

            commonControlsPage.inviteUsersEditBox.Clear();
            commonControlsPage.inviteUsersEditBox.SendKeys("mogasearch@wolterskluwer.com,ovidqa.automation@wolterskluwer.com");
            commonControlsPage.inviteButton.Click();
            Assert.IsTrue(commonControlsPage.alertInfo.Text == "MOGASEARCH@WOLTERSKLUWER.COM,OVIDQA.AUTOMATION@WOLTERSKLUWER.COM are already invited or a members of Ovid Labs. Invitations not sent.", "Expected validation message is not getting displayed");

            commonControlsPage.inviteUsersEditBox.Clear();
            commonControlsPage.inviteUsersEditBox.SendKeys("mogasearch@wolterskluwer.com,ovidqa.automation@wolterskluwer.com,test@wolterskluwer.com");
            commonControlsPage.inviteButton.Click();
            Assert.IsTrue(commonControlsPage.alertInfo.Text == "MOGASEARCH@WOLTERSKLUWER.COM,OVIDQA.AUTOMATION@WOLTERSKLUWER.COM are already invited or a members of Ovid Labs. Invitations not sent.", "Expected validation message is not getting displayed");

            Assert.IsTrue(commonControlsPage.alertSuccess.Text == "Your Invitation has been sent Successfully.\r\nTEST@WOLTERSKLUWER.COM", "Expected validation message is not getting displayed");

        }

        /// <summary>
        /// This method verifies Medline Records Information message validation
        /// </summary>
        public static void VerifyMedlineRecordsInfoMessage()
        {
            ResultReport.AddTestStepDetails("Verifying Medline Records information Message");
            string InfoMsg = commonControlsPage.alertWarning.Text;
            Assert.IsTrue(commonControlsPage.alertWarning.Text == "ATTENTION MEDLINE SEARCHERS: As part of a set of ongoing experiments, Ovid Labs is only indexing about 1 Million records. We apologize for any inconvenience this may cause.", "Expected validation message is not getting displayed");
        }

        /// <summary>
        /// This method verifies Invite user link for existence for Normal users
        /// </summary>
        public static void VerifyInviteUserLinkForExistence()
        {
            ResultReport.AddTestStepDetails("Invite user link for existence");

            Assert.IsTrue(CommonFixtures.CheckPropertyValue(UIObjects.WebElement("LinkText='Invite User'"),"Count","0","="), "Invite user link displayed for normal user also,Please check the permission");

        }

        //This method verifies relevancy of the results displayed on First page
        public static void VerifyRelevancyOfResults(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying Relevancy of the results");

            string[] searchTermArray = searchTerm.Split(' ');

            bool flag = false;

            if (commonControlsPage.recordsCollection.Count != 0)
            {
                for (int i = 0; i < commonControlsPage.recordsCollection.Count; i++)
                {
                    flag = false;

                    //Title field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[i],"ClassName",titleLinkClassname).Count > 0)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", titleLinkClassname).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue;
                        }
                    }

                    //Author field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", authorsSpanClassName).Count > 0)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", authorsSpanClassName).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue;
                        }
                    }

                        //Journal field verification
                        if (CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", journalSpanClassName).Count > 0)
                        {
                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", journalSpanClassName).Text.ToLower(), searchTermArray))
                           {
                            flag = true;
                            continue;
                        }
                    }

                            //Pages field verification
                            if (CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", pagesSpanClassName).Count > 0)
                            {
                                if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", pagesSpanClassName).Text.ToLower(), searchTermArray))
                                  {
                            flag = true;
                            continue;
                        }
                    }

                                //Issue field verification
                                if (CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", issueSpanClassName).Count > 0)
                                {
                                    if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", issueSpanClassName).Text.ToLower(), searchTermArray))
                         {
                            flag = true;
                            continue;
                        }
                    }

                                    //Volume field verification
                                    if (CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", volumeSpanClassName).Count > 0)
                                    {
                                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", volumeSpanClassName).Text.ToLower(), searchTermArray))
                                         {
                            flag = true;
                            continue;
                        }
                    }

                                        //Date field verification
                                        if (CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", dateSpanClassName).Count > 0)
                                        {
                                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i], "ClassName", dateSpanClassName).Text.ToLower(), searchTermArray))
                                      {
                            flag = true;
                            continue;
                        }
                    }

                                            //Abstract field verification
                                            if (CommonFixtures.FindChildElementsbyCriteria(commonControlsPage.recordsCollection[i], "Id", "divAbsrow").Count > 0)
                                            {
                          CommonMethods.ClickElementUsingJavaScript(CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i],"LinkText","abstractLinkText"));

                        ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(CommonFixtures.FindChildElementbyCriteria(commonControlsPage.recordsCollection[i],"Id","divAbsrow"),"TagName","P");

                        for (int fieldCount = 0; fieldCount < list.Count; fieldCount++)
                        {
                            string abstractValue = list[fieldCount].Text.ToLower();

                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(abstractValue, searchTermArray))
                            {
                                flag = true;
                                continue;
                            }
                        }
                    }

                    // If Search term didn't got on the page, check the complete reference
                    if (!flag)
                    {
                        CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver, By.Id("View Reference"), 60);

                        CommonMethods.ClickElementUsingJavaScript((CommonFixtures.FindChildElementbyCriteria( commonControlsPage.recordsCollection[i],"LinkText","View Reference")));
                        //CommonControlsPage.commonControlsPage.recordsCollection[i].FindElement(By.LinkText("View Reference")).Click();

                        CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver, By.Id("dl-horizontal"), 120);

                        string[] fieldNames = { "*" }; // * => all fields
                        flag = CheckSearchTermWithoutOperatorInCompleteReference(fieldNames, searchTerm);
                        WebDriver.Navigate().Back();
                    }

                    if (flag)
                    {
                        Assert.IsTrue(true);
                    }
                    else
                    {
                        Assert.IsTrue(false, "Unable to find " + searchTerm + "in the record number:" + i);
                    }

                }
            }
            else
            {
                Assert.IsTrue(false, "No records for the search term: " + searchTerm);
            }
        }

        // This method verifies the segment name in the Ovid for 'View On Ovid link' navigation
        public static void VerifyDatabaseSegmentNameInOvid()
        {
            ResultReport.AddTestStepDetails("Verifying View on Ovid link navigation to MESD seggment in Ovid");

            int recordCollectionCount = commonControlsPage.recordsCollection.Count;
            if (recordCollectionCount != 0)
            {
                for (int j = 0; j < recordCollectionCount; j++)
                {
                    ReadOnlyCollection<IWebElement> list =CommonFixtures.FindChildElementsbyCriteria( commonControlsPage.recordsCollection[j],"TagName","a");
                    bool ovidLinkFlag = false;
                    for (int i = 0; i < list.Count; i++)
                    {
                        commonControlsPage.rowClass = list[i].Text;

                        if (commonControlsPage.rowClass == "View on Ovid")
                        {
                            ovidLinkFlag = true;
                            string winHandleBefore = WebDriver.CurrentWindowHandle;

                            CommonMethods.ClickElementUsingJavaScript(list[i]);
                            //list[i].Click();

                            //Identifying new browser page of Ovid website
                            List<string> handles = WebDriver.WindowHandles.ToList<string>();
                            WebDriver.SwitchTo().Window(handles.Last());

                            if (UIObjects.WebElements("Id=ID").Count > 0)
                            {
                                UIObjects.WebElement("Id=ID").SendKeys("automate");

                                UIObjects.WebElement("Id=password").SendKeys("autotest");

                                UIObjects.WebElement("ClassName=standard-button-login").Click();
                            }
                            if (UIObjects.WebElements("PartialLinkText=< Back to Search Results").Count > 0)
                                UIObjects.WebElement("PartialLinkText=< Back to Search Results").Click();
                           // string segmentNameInOvidWebSite = WebDriver.FindElement(By.XPath(".//*[@id='ovid-resources-link-block']/div")).Text;
                            string segmentNameInOvidWebSite = UIObjects.WebElement("XPath=.//*[@id='ovid-resources-link-block']/div").Text;

                            Assert.IsTrue(segmentNameInOvidWebSite == "Ovid MEDLINE(R) 1946 to Present with Daily Update", "View on Ovid link not navigating to MESD segment");
                            UIObjects.WebElement("PartialLinkText=Logoff").Click();
                            
                            //UIObjects.SwitchToWindowByTitle(handles.First());
                            CommonFixtures.CloseCurrentWindow(WebDriver);
                            UIObjects.SwitchToPreviousWindow(WebDriver, handles.First());
                            break;
                        }

                    }
                    Assert.IsTrue(ovidLinkFlag, "View on Ovid link not found in the Links layout of the record number:" + j);
                }

            }
            else
                Assert.IsTrue(false, "No results found");

        }

        //This method verifies whether System returns search reults
        public static void VerifySystemReturnsSearchResults()
        {
            ResultReport.AddTestStepDetails("Verifying search Results are getting or not");
            Assert.IsTrue(commonControlsPage.recordsCollection.Count > 0, "Search results not found for the given search term");
        }

        #endregion


      
    }
}
