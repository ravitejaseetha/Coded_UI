using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WKH.MOGA;
using WKH.SeleniumFrameWork;

namespace WKH.MOGA
{
    public class SearchPage : UIObjects
    {
        public static SearchPage searchPage;

        public SearchPage()
        {
            PageFactory.InitElements(WebDriver, this);
            searchPage = this;
        }

        //creating object of this class. Call this before accessing anyother method of this class
        public static void NavigateHere()
        {
            searchPage = new SearchPage();
            CommonControlsPage.NavigateHere();
        }

        #region Search page controls

        //[FindsBy(How = How.Id, Using = "Input_SearchTerm")]
        //public IWebElement searchEdit;
        [FindsBy(How = How.XPath, Using = ".//*[@id='SimpleSearchBox']//label[text()='Show Articles']")]
        public IWebElement searchEditLabel;

        [FindsBy(How = How.Id, Using = "Input_ShowArticles")]
        public IWebElement showArticlesCheckBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='Input_SearchTerm']")]
        public IWebElement searchEdit;

        [FindsBy(How = How.ClassName, Using = "wk-search-submit")]
        public IWebElement searchSubmitBtn;

        [FindsBy(How = How.LinkText, Using = "Search")]
        public IWebElement searchTab;


        [FindsBy(How = How.Id, Using = "Input_ShowMedia")]
        public IWebElement showMediaCheckBox;

        [FindsBy(How = How.CssSelector,Using = ".tooltip-inner")] //".tooltip-inner>table>tbody>tr>td"
        public IWebElement toolTipOfSearchTab;

        [FindsBy(How = How.CssSelector, Using = ".glyphicon.glyphicon-comment")]
        public IWebElement toolTipControlOfSearchBox;

        [FindsBy(How = How.CssSelector, Using = ".tooltip-inner")]
        public IWebElement toolTipOfSearchBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='SimpleSearchBox']/form/div[3]/div/a/span")]
        public IWebElement toolTipControlOfSynonymsCheckBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='SimpleSearchBox']/form/div[3]/div[1]/div[1]/div[2]/div[1]/div[1]/div")]
        public IWebElement toolTipOfSynonymsCheckBox;

        //Pagination controls
        [FindsBy(How = How.XPath, Using = "(//*[@class = 'wk-pagination'])[1]")]
        public IWebElement paginationDivSearchPage;
        #endregion

        #region Search page methods
        public static void SelectSearchTab()
        {
            ResultReport.AddTestStepDetails("Select search tab");

            searchPage.searchTab.Click();
            CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver, By.Id("Input_SearchTerm"), 60);

        }

        /// <summary>
        /// Enters query or search term and perform simple search
        /// </summary>
        /// <param name="searchTerm"></param>
        public static void SimpleSearch(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Do simple search");
            MOGAConstants.log.DebugFormat("Entered SimpleSearch {0}", searchTerm);

            //WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));
            //waitForObject.Until(ExpectedConditions.ElementToBeClickable(By.Id("Input_SearchTerm")));
            Thread.Sleep(5000);
			//modified for unchecking the 'show articles' checkbox. 
			//searchPage.searchEdit.Clear(); 

			//if (searchPage.showArticlesCheckBox.Selected)
			//    searchPage.showArticlesCheckBox.Click();



			//IJavaScriptExecutor js = WebDriver as IJavaScriptExecutor;
			//js.ExecuteScript("document.getElementById('Input_SearchTerm').setAttribute('value', '" + searchTerm + "')");
			searchPage.searchEdit.Clear();
			searchPage.searchEdit.SendKeys(searchTerm);
            searchPage.searchSubmitBtn.Click();

        }

        // This method verifies the search term for existence in any field for all the records 
        public static void VerifySearchTermsWithOutOperatorForAllFieldSearch(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given partial Search term");

            string[] searchTermArray = searchTerm.Split(' ');

            bool flag = false;

            if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
            {
                for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
                {
                    flag = false;

                    //Title field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname)!=null)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue; 
                        }
                    }

                    //Author field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.authorsSpanClassName) != null)
                     {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.authorsSpanClassName).Text.ToLower(), searchTermArray))
                         {
                            flag = true;
                            continue;
                        }
                    }

                    //Journal field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.journalSpanClassName) != null)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.journalSpanId).Text.ToLower(), searchTermArray))
                           {
                            flag = true;
                            continue;
                        }
                    }

                    //Pages field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.pagesSpanClassName) != null)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.pagesSpanClassName).Text.ToLower(), searchTermArray))
                       {
                            flag = true;
                            continue;
                        }
                    }

                    //Issue field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.issueSpanClassName) != null)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.issueSpanClassName).Text.ToLower(), searchTermArray))
                         {
                            flag = true;
                            continue;
                        }
                    }

                        //Volume field verification
                        if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.volumeSpanClassName) != null)
                        {
                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.volumeSpanClassName).Text.ToLower(), searchTermArray))
                         {
                            flag = true;
                            continue;
                        }
                    }

                            //Date field verification
                            if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.dateSpanClassName) != null)
                            {
                                if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.dateSpanClassName).Text.ToLower(), searchTermArray))
                                 {
                            flag = true;
                            continue;
                        }
                    }

                                //Abstract field verification
                      if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "Id", "divAbsrow") != null)
                            {
                        CommonMethods.ClickElementUsingJavaScript(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText", CommonControlsPage.abstractLinkText));
                        var listitem = CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "Id", "divAbsrow");
                        ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(listitem, "TagName", "P");

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
                        CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.LinkText("View Reference"), 60);

                        CommonMethods.ClickElementUsingJavaScript(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText","View Reference"));

                        CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.ClassName("dl-horizontal"), 120);

                        string[] fieldNames = { "*" }; // * => all fields
                        flag = CommonControlsPage.CheckSearchTermWithoutOperatorInCompleteReference(fieldNames, searchTerm);
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

        //Need to implement
        public static void VerifyRelevancyOfResults()
        {
            throw new NotImplementedException();
        }


        //This method verifies search term with combination of operators in all the avaialble fields of the search results
        public static void VerifySearchTermsWithOperatorForAllFieldSearch(string[] searchTermArray)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given Search terms");

            int nQueryTerms = searchTermArray.Length;
            if (nQueryTerms != 3)
            {
                Assert.IsTrue(false, "Mismatch of number of terms");
            }

            string leftTerm = searchTermArray[0]; // search term before operator
            string operation = searchTermArray[1]; // To handles operations like AND,OR & NOT
            string rightTerm = searchTermArray[2]; // search term after operator

            bool flag = false;
            bool leftFlag = false;
            bool rightFlag = false;
            int recordCount = CommonControlsPage.commonControlsPage.recordsCollection.Count;
            if (recordCount != 0)
            {
                // iterate record
                for (int i = 0; i < recordCount; i++)
                {
                    flag = false;
                    leftFlag = false;
                    rightFlag = false;

                    //Title field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Count > 0)
                    {
                        MOGAConstants.mogaFunctions.CheckBothTermInField(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Text.ToLower(), leftTerm, operation, rightTerm, ref leftFlag, ref rightFlag);
                    }

                    //Author field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.authorsSpanClassName).Count > 0)
                    {
                        MOGAConstants.mogaFunctions.CheckBothTermInField(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.authorsSpanClassName).Text.ToLower(), leftTerm, operation, rightTerm, ref leftFlag, ref rightFlag);
                    }

                    //Journal field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.journalSpanClassName).Count > 0)
                    {
                        MOGAConstants.mogaFunctions.CheckBothTermInField(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id",CommonControlsPage.journalSpanId).Text.ToLower(), leftTerm, operation, rightTerm, ref leftFlag, ref rightFlag);
                    }

                    //Pages field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.pagesSpanClassName).Count > 0)
                    {
                        MOGAConstants.mogaFunctions.CheckBothTermInField(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.pagesSpanClassName).Text.ToLower(), leftTerm, operation, rightTerm, ref leftFlag, ref rightFlag);
                    }

                    //Issue field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.issueSpanClassName).Count > 0)
                    {
                        MOGAConstants.mogaFunctions.CheckBothTermInField(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.issueSpanClassName).Text.ToLower(), leftTerm, operation, rightTerm, ref leftFlag, ref rightFlag);
                    }

                    //Volume field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.volumeSpanClassName).Count > 0)
                    {
                        MOGAConstants.mogaFunctions.CheckBothTermInField(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.volumeSpanClassName).Text.ToLower(), leftTerm, operation, rightTerm, ref leftFlag, ref rightFlag);
                    }

                    //Date field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.dateSpanClassName).Count > 0)
                    {
                        MOGAConstants.mogaFunctions.CheckBothTermInField(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.dateSpanClassName).Text.ToLower(), leftTerm, operation, rightTerm, ref leftFlag, ref rightFlag);
                    }

                    //Abstract field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id","divAbsrow").Count > 0)
                    {
                        CommonMethods.ClickElementUsingJavaScript(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText",CommonControlsPage.abstractLinkText));
                        //CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText","Abstract")).Click();

                        ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id","divAbsrow"),"TagName","P");

                        for (int fieldCount = 0; fieldCount < list.Count; fieldCount++)
                        {
                            string abstractValue = list[fieldCount].Text.ToLower();
                            MOGAConstants.mogaFunctions.CheckBothTermInField(abstractValue, leftTerm, operation, rightTerm, ref leftFlag, ref rightFlag);
                        }
                    }  

                    // For operation AND (both terms should present)
                    if (operation.Equals("and"))
                    {
                        flag = leftFlag && rightFlag;
                    }
                    //For operation OR (either one of them should present)
                    else if (operation.Equals("or"))
                    {
                        flag = leftFlag || rightFlag;
                    }
                    //For operation NOT (the left should present & the right shouldn't)
                    else if (operation.Equals("not"))
                    {
                        flag = leftFlag && rightFlag;
                        Assert.IsTrue(rightFlag, "NOT term present in the record number: "+ i);
                    }
                    // Validation for no operator
                    else
                    {
                        Assert.Fail("Operator not given in Test data, please check");
                    }

                    // If Search term didn't got on the page, check the complete reference
                    if (!flag || (operation.Equals("not")))
                    {
                        ReadOnlyCollection<IWebElement> linkElements = CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"TagName","a");
                        for (int fieldCount = 0; fieldCount < linkElements.Count; fieldCount++)
                        {
                            if (linkElements[fieldCount].Text.ToLower().Equals("view reference"))
                            {
                                CommonMethods.ClickElementUsingJavaScript(linkElements[fieldCount]);
                                //linkElements[fieldCount].Click();
                                CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.ClassName("dl-horizontal"), 60);

                                string[] fieldNames = { "*" }; // * => all fields
                                flag = CommonControlsPage.CheckSearchTermWithOperatorInCompleteReference(fieldNames, leftTerm, operation, rightTerm, ref leftFlag, ref rightFlag);
                                break;
                            }
                        }
                        WebDriver.Navigate().Back();
                    }

                    if (flag)
                    {
                        Assert.IsTrue(true);
                    }
                    else
                    {
                        Assert.IsTrue(false, "Unable to find term in the record number:" + i);
                    }
                }
            }
            else
            {
                Assert.IsTrue(false, "No records for the search term " );
            }

        }

        // This method is used to validate the movement between pages
        public static void VerifyPageDisplayOnSearchPage()
        {
            ResultReport.AddTestStepDetails("Verifying how pages are displaying upon Selecting last page");
            SimpleSearch("heart");

            //Verifying for First page is active by default
            string firstPageStatus = CommonFixtures.FindChildElementbyCriteria(CommonFixtures.FindChildElementbyCriteria(searchPage.paginationDivSearchPage, "ClassName", "wk-active"),"TagName","a").Text;
            Assert.IsTrue(firstPageStatus == "1", "First page link is not active by dafault");

            CommonFixtures.FindChildElementbyCriteria(searchPage.paginationDivSearchPage,"LinkText","10").Click();

            //Verifying for 10th page is active after click on 10
            string tenthPageStatus = CommonFixtures.FindChildElementbyCriteria(CommonFixtures.FindChildElementbyCriteria(searchPage.paginationDivSearchPage,"ClassName","active"),"TagName","a").Text;
            Assert.IsTrue(tenthPageStatus == "10", "10th page link is not active after selecting");

            Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(searchPage.paginationDivSearchPage,"LinkText","14").Displayed);
            Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(searchPage.paginationDivSearchPage,"LinkText","5").Displayed);
            Assert.IsFalse(CommonFixtures.FindChildElementsbyCriteria(searchPage.paginationDivSearchPage,"LinkText","15").Count > 0);

            CommonFixtures.FindChildElementbyCriteria(searchPage.paginationDivSearchPage,"LinkText","9").Click();
            Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(searchPage.paginationDivSearchPage,"LinkText","13").Displayed);
            Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(searchPage.paginationDivSearchPage,"LinkText","4").Displayed);
            Assert.IsFalse(CommonFixtures.FindChildElementsbyCriteria(searchPage.paginationDivSearchPage,"LinkText","14").Count > 0);

        }

        //This method verifies Auto focus of the cursor in the search page
        public static void VerifyAutoFocusOfSearchPage()
        {
            ResultReport.AddTestStepDetails("Verifying AutoFocus of the cursor in Search page");

            Assert.IsTrue(searchPage.searchEdit.Equals(WebDriver.SwitchTo().ActiveElement()),"Auto Focus is not in Search input box");
        }

        //This method tests tooltip messages of Search page
        public static void SearchTabTooltipVerification()
        {
            ResultReport.AddTestStepDetails("Verifying tooltip text of Search Tab");

            Actions action = new Actions(WebDriver);
            action.ClickAndHold(searchPage.searchTab).Build().Perform();
           
            //Get the tool tip of Search Tab
            string searchTabToolTipText = searchPage.toolTipOfSearchTab.Text;
            Assert.AreEqual("Combine powerful full text search capabilities with precision fielded search.", searchTabToolTipText);
            action.MoveToElement(searchPage.searchTab).Release(searchPage.searchTab).Perform();

            Thread.Sleep(5000); //will remove once I get the time to work on --Vijay
            ResultReport.AddTestStepDetails("Verifying tooltip text of Search box");

            //Get the tooltip of search box
            action = new Actions(WebDriver);
            action.ClickAndHold(searchPage.toolTipControlOfSearchBox).Build().Perform();

            string searchBoxTooltipText = searchPage.toolTipOfSearchBox.Text;
            Assert.IsTrue(searchBoxTooltipText.Contains("Search includes the complete Ovid MEDLINE database and a growing collection of full text journal articles from Ovid. It combines the ease of use of web search with the precision of fielded search. Here are a few examples to get you started:"),"SearchBox tooltip not displayed as expected");
            action.MoveToElement(searchPage.toolTipControlOfSearchBox).Release(searchPage.toolTipControlOfSearchBox).Perform();

            Thread.Sleep(5000); //will remove once I get the time to work on --Vijay

            //Get the tooltip of use synonyms check box
            action = new Actions(WebDriver);
            action.ClickAndHold(searchPage.toolTipControlOfSynonymsCheckBox).Build().Perform();
            
            string useSynonymsCheckBoxTooltip = searchPage.toolTipOfSynonymsCheckBox.Text;
            Assert.IsTrue(useSynonymsCheckBoxTooltip.Contains("Apply synonyms to Title and Abstract fields if selected"), "Unified search use synonyms tooltip not displayed as expected");
            action.MoveToElement(searchPage.toolTipControlOfSynonymsCheckBox).Release(searchPage.toolTipControlOfSynonymsCheckBox).Perform();
        }

        //This method Select / unSelect the Show articles option
        public static void SelectShowJournalArticles(bool select)
        {
            ResultReport.AddTestStepDetails("Select/Unselect Show articles option");
            if (select == true)
            {
                if (searchPage.showArticlesCheckBox.Selected == false)
                {
                    searchPage.showArticlesCheckBox.Click();
                }
            }
            else
            {
                if (searchPage.showArticlesCheckBox.Selected == true)
                {
                    searchPage.showArticlesCheckBox.Click();
                }
            }
            
        }

        #endregion

    }
}
