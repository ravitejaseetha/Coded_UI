using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using WKH.SeleniumFrameWork;

namespace WKH.MOGA
{
    public class FindCitationPage : UIObjects
    {
        public static FindCitationPage findCitaionPage;

        public FindCitationPage()
        {
            PageFactory.InitElements(WebDriver, this);
            findCitaionPage = this;
        }

        //creating object of this class. Call this before accessing anyother method of this class
        public static void NavigateHere()
        {
            findCitaionPage = new FindCitationPage();
            CommonControlsPage.NavigateHere();
        }

        #region Find citation page controls

        [FindsBy(How = How.LinkText, Using = "Citation Search")]
        public IWebElement findCitationTab;

        [FindsBy(How = How.LinkText, Using = "Zoek citaat")]
        public IWebElement findCitationTabDutchURL;

        [FindsBy(How = How.Id, Using = "Input_Citation")]
        public IWebElement searchBox;

        [FindsBy(How = How.ClassName, Using = "wk-search-submit")]
        public IWebElement searchButton;
        
        //Citation styles controls
        [FindsBy(How = How.XPath, Using = "//input[@id='Input_CitationFormat' and @value='MLA']")]
        public IWebElement mlaCitation;

        [FindsBy(How = How.XPath, Using = "//input[@id='Input_CitationFormat' and @value='Chicago']")]
        public IWebElement chicagoCitation;

        [FindsBy(How = How.XPath, Using = "//input[@id='Input_CitationFormat' and @value='APA']")]
        public IWebElement apaCitation;

        [FindsBy(How = How.XPath, Using = "//input[@id='Input_CitationFormat' and @value='Default']")]
        public IWebElement defaultCitation;

        [FindsBy(How = How.Id, Using = "Input_CitationFormat")]
        public IWebElement citationFormatStyleComboBoxId;

        //Tool tip controls
        [FindsBy(How = How.CssSelector, Using = ".tooltip-inner")] 
        public IWebElement toolTipOfCitationTab;

        [FindsBy(How = How.CssSelector, Using = ".glyphicon.glyphicon-comment")]
        public IWebElement toolTipControlOfCitationBox;

        [FindsBy(How = How.CssSelector, Using = ".col-sm-12.text-left")]
        public IWebElement toolTipOfCitationBox;

        //Pagination controls
        [FindsBy(How = How.Id, Using = "divCitationSearchPagination")]
		public IWebElement paginationDivCitationPage;
        
        //Constants of Citation page
        public string citationSearchEditBoxId = "Input_Citation";
        public string citationSearchButtonClassName = "wk-search-submit";        
        public string strCitationFormatStyleComboBoxId = "Input_CitationFormat";

        #endregion

        #region Find citation page methods

        /// <summary>
        /// Click Find citation tab
        /// </summary>
        public static void SelectFindCitationTab()
        {
            ResultReport.AddTestStepDetails("Select Find citation Tab");
            //Selecting fielded search Tab
            findCitaionPage.findCitationTab.Click();

            CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.Id(findCitaionPage.citationSearchEditBoxId), 60);
        }

        /// <summary>
        /// Click Find citation tab in Dutch URL
        /// </summary>
        public static void SelectFindCitationTabDutchURL()
        {
            ResultReport.AddTestStepDetails("Select Find citation Tab");
            //Selecting fielded search Tab
            findCitaionPage.findCitationTabDutchURL.Click();
            CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.Id(findCitaionPage.citationSearchEditBoxId), 60);
 }

        //This method is used to find citation search with the given term
        public static void DoCitationSearch( string searchTerm)
        {
            ResultReport.AddTestStepDetails("Doing find citaion search");            
            findCitaionPage.searchBox.Clear();
            CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.Id(findCitaionPage.citationSearchEditBoxId), 60);
             findCitaionPage.searchBox.SendKeys(searchTerm);
            findCitaionPage.searchButton.Click();            
        }

        //This method is used to find citation search with the lenthy search term
        public static void FindCitationSearchLengthySearcTerms(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Doing find citaion search");
          
            findCitaionPage.searchBox.Clear();

            try
            {
                findCitaionPage.searchBox.SendKeys(searchTerm);
            }
            catch (Exception ex)
            {
                
            }
            CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.ClassName(findCitaionPage.citationSearchButtonClassName), 60);

            findCitaionPage.searchButton.Click();

            CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.Id(findCitaionPage.citationSearchEditBoxId), 60);
        }

        //This method is used to find citation search with the given term
        public static void FindCitationSearchForDutchURL(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Doing find citaion search");
            findCitaionPage.searchBox.Clear();
            findCitaionPage.searchBox.SendKeys(searchTerm);
            findCitaionPage.searchButton.Click();
        }

        //This method is used to Select citation type
        public static void SelectCitationStyle(string citationType)
        {
            ResultReport.AddTestStepDetails("Select Citation type");

            switch (citationType.ToLower())
            {
                case "mla":
                    CommonMethods.SelectDropdownListByText(WebDriver,By.Id(findCitaionPage.strCitationFormatStyleComboBoxId), "MLA");
                    break;
                case "apa":
                    CommonMethods.SelectDropdownListByText(WebDriver, By.Id(findCitaionPage.strCitationFormatStyleComboBoxId), "APA");
                    break;
                case "chicago":
                    CommonMethods.SelectDropdownListByText(WebDriver, By.Id(findCitaionPage.strCitationFormatStyleComboBoxId), "Chicago");
                    break;
                case "default":
                    CommonMethods.SelectDropdownListByText(WebDriver, By.Id(findCitaionPage.strCitationFormatStyleComboBoxId), "Default View");
                    break;
                default:
                    {
                        Assert.Fail("Citation type you are looking is not yet implemented");
                        break;
                    }
            }
        }

        //This method verifies citation type selection
        public static void VerifyCitationStyle(string citationType)
        {
            ResultReport.AddTestStepDetails("Verify Citation style");

            switch (citationType.ToLower())
            {
                case "mla":
                    Assert.IsTrue(findCitaionPage.citationFormatStyleComboBoxId.GetAttribute("value") == "1", "Given citation style: "+ citationType  + " not selected by default for the user");
                    break;
                case "apa":
                    Assert.IsTrue(findCitaionPage.citationFormatStyleComboBoxId.GetAttribute("value") == "2", "Given citation style: " + citationType + " not selected by default for the user");
                    break;
                case "chicago":
                    Assert.IsTrue(findCitaionPage.citationFormatStyleComboBoxId.GetAttribute("value") == "3", "Given citation style: " + citationType + " not selected by default for the user");
                    break;
                case "default":
                    Assert.IsTrue(findCitaionPage.citationFormatStyleComboBoxId.GetAttribute("value") == "0", "Given citation style: " + citationType + " not selected by default for the user");
                    break;
                default:
                    {
                        Assert.Fail("Citation type you are looking is not yet implemented");
                        break;
                    }
            }

            //Setting dafault style
            //findCitaionPage.defaultCitation.Click();
            CommonMethods.SelectDropdownListByText(WebDriver, By.Id(findCitaionPage.strCitationFormatStyleComboBoxId), "Default View");

        }

        // This method verifies the full search term for existence in any field for all the records 
        public static void VerifyAllRecordsForFullSearchTerm(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given Search term");
            
            string getCellText = string.Empty;
            bool flag = false;
            if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
            {
                for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
                {

                    flag = false;

                    //Title field verification
                    if ( CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Count > 0)
                    {
                    if (CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname),"Text", searchTerm,"Contains"))
                        {
                            flag = true;
                            break;
                        }
                    }

                    //Author field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.authorsSpanClassName).Count > 0)
                    {
                        if (CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.authorsSpanClassName),"Text", searchTerm,"Contains"))
                        {
                            flag = true;
                            break;
                        }
                    }

                    //Journal field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.journalSpanClassName).Count > 0)
                    {
                        if (CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.journalSpanClassName),"Text", searchTerm,"Contains"))
                        {
                            flag = true;
                            break;
                        }
                    }

                    //pages field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.pagesSpanClassName).Count > 0)
                    {
                        if (CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.pagesSpanClassName), "Text", searchTerm, "Contains"))
                        {
                            flag = true;
                            break;
                        }
                    }

                    //issue field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.issueSpanClassName).Count > 0)
                    {
                        if (CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.issueSpanClassName), "Text", searchTerm, "Contains"))
                        {
                            flag = true;
                            break;
                        }
                    }

                    //volume field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.volumeSpanClassName).Count > 0)
                    {
                        if (CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.volumeSpanClassName), "Text", searchTerm, "Contains"))
                        {
                            flag = true;
                            break;
                        }
                    }

                    //date field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.dateSpanClassName).Count > 0)
                    {
                        if (CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.dateSpanClassName), "Text", searchTerm, "Contains"))
                        {
                            flag = true;
                            break;
                        }
                    }

                    //Article type verififcation
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.articleTypeSpanClassName).Count > 0)
                    {
                        if (CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.articleTypeSpanClassName), "Text", searchTerm, "Contains"))
                        {
                            flag = true;
                            break;
                        }
                    }

                    //abstract field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id","divAbsrow").Count > 0)
                    {
                        CommonMethods.ClickElementUsingJavaScript(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText","Abstract"));

                        ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id","divAbsrow"),"TagName","P");

                        for (int fieldCount = 0; fieldCount < list.Count; fieldCount++)
                        {
                            string abstractValue = list[fieldCount].Text.ToLower();

                            if (abstractValue.Contains(searchTerm.ToLower()))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }                    
                }
                //As we are giving the part of original title , original record should display as first record/somewhere in first page
                Assert.IsTrue(flag, "Unable to find full search term:" + searchTerm + "in any of the record on first pageof the results");
              }
              else
                Assert.IsTrue(false, "No results found for the search term:" + searchTerm);

        }
        
        // This method verifies the search term for existence in any field for all the records 
        public static void VerifyAllRecordsForPartialSearchTerm(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given partial Search term");
            
            string[] searchTermArray = searchTerm.Split(' ');
                      
            bool flag = false;

                if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
                {
                    for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
                    {
                        //To handle empty records
                        if (CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Text == "")
                        {
                            flag = true;
                            continue;
                        }

                        flag = false;

                        //Title field verification
                        if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Count > 0)
                        {
                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Text.ToLower(), searchTermArray))
                            {
                                flag = true;
                                continue;
                            }
                        }

                        //Author field verification
                        if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.authorsSpanClassName).Count > 0)
                        {
                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.authorsSpanClassName).Text.ToLower(), searchTermArray))
                            {
                                flag = true;
                                continue;
                            }
                        }

                        //journal field verification
                        if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.journalSpanClassName).Count > 0)
                        {
                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.journalSpanClassName).Text.ToLower(), searchTermArray))
                            {
                                flag = true;
                                continue;
                            }
                        }

                        //pages field verification
                        if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.pagesSpanClassName).Count > 0)
                        {
                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.pagesSpanClassName).Text.ToLower(), searchTermArray))
                            {
                                flag = true;
                                continue;
                            }
                        }

                        //issue field verification
                        if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.issueSpanClassName).Count > 0)
                        {
                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.issueSpanClassName).Text.ToLower(), searchTermArray))
                            {
                                flag = true;
                                continue;
                            }
                        }

                        //volume field verification
                        if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.volumeSpanClassName).Count > 0)
                        {
                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.volumeSpanClassName).Text.ToLower(), searchTermArray))
                            {
                                flag = true;
                                continue;
                            }
                        }

                        //Date field verification
                        if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.dateSpanClassName).Count > 0)
                        {
                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.dateSpanClassName).Text.ToLower(), searchTermArray))
                            {
                                flag = true;
                                continue;
                            }
                        }

                        //Abstract field verification
                        if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id","divAbsrow").Count > 0)
                        {
                            CommonMethods.ClickElementUsingJavaScript(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText","Abstract"));

                            ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id","divAbsrow"),"TagName","P");

                            for (int fieldCount = 0; fieldCount < list.Count; fieldCount++)
                            {
                                string abstractValue = list[fieldCount].Text.ToLower();
                            
                                if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(abstractValue, searchTermArray))
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }

                        Assert.IsTrue(flag, "Unable to find " + searchTerm + "in the record number:"+ i);
                    }
                }
                else
                {
                    Assert.IsTrue(false, "No records for the search term: " + searchTerm);                   
                }            

        }

        // This method verifies the results for Unique data, where it will bring back only 1 record 
        public static void VerifyResultsForDOIandPMID(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given PMID/DOI");
     
            Assert.IsTrue(CommonControlsPage.commonControlsPage.recordsCollection.Count == 1, "Given PMID/DOI: " + searchTerm + " - gives more than 1 record");

            string title = CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[0],"ClassName","title").Text;

            Assert.IsTrue(title.Trim().ToLower() == searchTerm.Trim().ToLower(), "Relevant DOI/PMID record is not displayed");

        }

        // This method verifies the results for the given PMID we are getting first record and relevane records are with the other phrases in the search term 
        public static void VerifyPMIDwithPhrases(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given PMID");
            
            Assert.IsTrue(CommonControlsPage.commonControlsPage.recordsCollection.Count > 1, "Given PMID/DOI: " + searchTerm + " - gives only 1 record");

            string titleOfFirstRecord = CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[0],"ClassName","title").Text;

            Assert.IsTrue(titleOfFirstRecord.Trim().ToLower() == searchTerm.Trim().ToLower(), "Relevant PMID record is not displayed");

        }

        // This method verifies the results for JournalName relevant to ISSN number 
        public static void VerifyCitationResultsForISSN(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given ISSN number");
            
            string journalName = CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[0],"ClassName","journalName").Text;

            Assert.IsTrue(journalName.Trim().ToLower() == searchTerm.Trim().ToLower(), "Relevant journal name is not displayed for the given ISSN");

        }

        // This method verifies the full search term for existence in any field for all the records 
        public static bool VerifyDataAfterContentUploadFromSSR(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given Search term");
            
            string getCellText = string.Empty;
            bool flag = false;
            if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
            {
                for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
                {
                    //Title field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Count > 0)
                    {
                        if (CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname),"Text",searchTerm,"Contains"))
                        {
                            flag = true;
                            continue;
                        }
                    }
                    
                    //Journal field verificaion
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.journalSpanClassName).Count > 0)
                    {
                        if (CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.journalSpanClassName),"Text",searchTerm,"Contains"))
                        {
                            flag = true;
                            continue;
                        }
                    }
                }
            }            
            return flag;
        }

        // This method verifies the Citation styles in Citation results 
        public static void VerifyCitationStyles(string citationType, string citation)
        {
            ResultReport.AddTestStepDetails("Verifying the the records to display in the specified Citation style");

            //Select Citation type
            SelectCitationStyle(citationType);

            //Verify relevant citation from the results                       
                string getCellText = string.Empty;           
                //Verifying citation of the record
                string citationOfTheRecord = CommonControlsPage.commonControlsPage.recordsCollection[0].Text;
            //Assert.IsTrue(citationOfTheRecord.Trim().ToLower().Contains(citation.ToLower()), "Relavant citation not found for: "+citationType.ToUpper());
			Assert.IsTrue(citationOfTheRecord.Trim().ToLower().Contains(citation.ToLower()), "Relavant citation not found for: " + citationType.ToUpper());
		}

        // This method verifies results on the same page upon  multiple clicks of search button
        public static void VerifyResultsForReliability(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given partial Search term");
            
            string[] searchTermArray = searchTerm.Split(' ');
            
            if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
            {
                string[] resultsArray1 = new string[CommonControlsPage.commonControlsPage.recordsCollection.Count];

                for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
                {                   
                    resultsArray1[i] = CommonControlsPage.commonControlsPage.titleField.Text;                   
                }

                findCitaionPage.searchButton.Click();

                string[] resultsArray2 = new string[CommonControlsPage.commonControlsPage.recordsCollection.Count];

                for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
                {
                    resultsArray2[i] = CommonControlsPage.commonControlsPage.titleField.Text;
                }

                Assert.IsTrue(resultsArray1.SequenceEqual(resultsArray2), "Not showing the same Results upon click on search button again");

            }
            else
            {
                Assert.IsTrue(false, "No records for the search term: " + searchTerm);
            }

        }

        /// <summary>
        /// This method verifies Abstract link for all the records.Outdated functionality.Will remove after sometime.
        /// </summary>
        /// <param name="searchTerm"></param>
        public static void VerifyAbstractLinkInCitationResults(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying search results for Abstract link");
            
            if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
            {
                for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
                {                    
                    Assert.IsTrue (CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText",CommonControlsPage.abstractLinkText).Displayed);
                    CommonMethods.ClickElementUsingJavaScript(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText",CommonControlsPage.abstractLinkText));
                }
            }
            else
            {
                Assert.IsTrue(false, "No records for the search term: " + searchTerm);
            }
        }
        
        // This method verifies the error messages for blank citation search 
        public static void VerifyErrorMessageForBlankCitation()
        {
            ResultReport.AddTestStepDetails("Verifying the expected message for Blank citation search");

            Assert.IsTrue(UIObjects.WebElement("ClassName=field-validation-error").Text.Contains("Please enter a complete or partial citation"));
           
        }

        //This method verifies the error messages for More than Allowed Characters
        public static void VerifyWarningMessageForMorethanAllowedCharacters()
        {
            ResultReport.AddTestStepDetails("Verifying the expected message for more than allowed limit");

            Assert.IsTrue(UIObjects.WebElement("ClassName=field-validation-error").Text.Contains("Citation cannot be more than 10,000 characters. Please try again with a shorter citation"));

        }

        //This method verifies the messages for NO records
        public static void VerifyNoRecordsMessageForFindCitation()
        {
            ResultReport.AddTestStepDetails("Verifying no records find message for the serch term which does not exist");

            if (UIObjects.WebElement("TagName=h2").Text.Contains("No Results found"))
            {
                ResultReport.AddTestStepDetails("No Results message found");
            }
            else
            {
                //ResultReport.AddTestStepDetails("No Results message not found,Application might have crashed!!Pls check", "Fail");
                Assert.IsTrue(false, "No Results message not found for the given large search term,Application might have crashed!!");
            }
        }
        
        //this method validates find citation for 10000 and less characters
        public static void VerifyFindCitationSearchForMaxChars()
        {
            ResultReport.AddTestStepDetails("Verifying find citation allows 10240 characters search term");

			string testDataPath = Environment.CurrentDirectory;

			testDataPath = testDataPath.Substring(0, testDataPath.IndexOf("bin")) + "TestData\\findCitationWith10000Chars.txt";
			string searchTerm1 = CommonMethods.GetTextFromTextFile(testDataPath);
			FindCitationSearchLengthySearcTerms(searchTerm1);
            VerifyNoRecordsMessageForFindCitation();

            ResultReport.AddTestStepDetails("Verifying find citation allows 10239 characters search term");
			testDataPath = Environment.CurrentDirectory;

			testDataPath = testDataPath.Substring(0, testDataPath.IndexOf("bin")) + "TestData\\findCitationWith9999Chars.txt";
			//Citation test data file path is hardcoded
			string searchTerm2 = CommonMethods.GetTextFromTextFile(testDataPath);
			FindCitationSearchLengthySearcTerms(searchTerm2);
            VerifyNoRecordsMessageForFindCitation();
                      
        }

        //To verify the search term which has more than the expected limit
        public static void VerifyFindCitationSearchForMoreThanMaxChars()
        {
            ResultReport.AddTestStepDetails("Verifying find citation for more than 10000 characters search term");
			string testDataPath = Environment.CurrentDirectory;

			testDataPath = testDataPath.Substring(0, testDataPath.IndexOf("bin")) + "TestData\\findCitationWith10001Chars.txt";
			//Citation test data file path is hardcoded
			string searchTerm3 = CommonMethods.GetTextFromTextFile(testDataPath);
            FindCitationSearchLengthySearcTerms(searchTerm3);
            VerifyWarningMessageForMorethanAllowedCharacters();
        }

        //This method tests feedback link functionality.
        public static void VerifyFeedbackLinkFunctionality()
        {
            ResultReport.AddTestStepDetails("Verifying feedback link on find citation page");

            CommonControlsPage.commonControlsPage.feedbackLink.Click();
         
            //Identifying new browser page of Survey monkey website
            List<string> handles = WebDriver.WindowHandles.ToList<string>();
            WebDriver.SwitchTo().Window(handles.Last());

            //Entering information on surveymonkey feedback page
            WebDriver.FindElement(By.Id("946716802")).SendKeys("This is MOGA QA testing");

            //Subimitting feedback by clicking on done button
            string surveyMonkeyLink = WebDriver.Url;
            Assert.IsTrue(surveyMonkeyLink.Contains("surveymonkey"), "Survey monkey feedback link not opened");
            //WebDriver.FindElement(By.CssSelector(".btn.small.done-button.survey-page-button.user-generated.notranslate")).Click();
            CommonMethods.ClickElementUsingJavaScript(WebDriver.FindElement(By.CssSelector(".btn.small.done-button.survey-page-button.user-generated.notranslate")));

            string successfulMsg = WebDriver.FindElement(By.CssSelector(".thanks-message.question-body-font-theme.user-generated.clearfix")).Text;
            Assert.IsTrue(successfulMsg.ToLower().Contains("thank you for your time and feedback"), "feedback not getting submitted, please check");
            CommonFixtures.CloseCurrentWindow(WebDriver);
            UIObjects.SwitchToPreviousWindow(WebDriver, handles.First());

        }

        //This method verifies result count per page
        public static void VerifyResultCountPerPage()
        {
            ResultReport.AddTestStepDetails("Verifying Result count per page");
            Assert.IsTrue(CommonControlsPage.commonControlsPage.recordsCollection.Count == 10, "10 records are not getting displayed");
        }

        // This method verifies the search term for existence in any field for all the records 
        public static void VerifyAllRecordsForPartialSearchTermDutch(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given partial Search term in DUtch URL");
            
            string[] searchTermArray = searchTerm.Split(' ');
                      
            bool flag = false;

            if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
            {
                for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
                {
                    //To handle empty records
                    if (CommonFixtures.FindChildElementbyCriteria( CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Text == "")
                    {
                        flag = true;
                        continue;
                    }

                    flag = false;

                    //Title field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Count > 0)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue;
                        }
                    }

                    //Author field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.authorsSpanClassName).Count > 0)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.authorsSpanClassName).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue;
                        }
                    }

                    //Journal field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.journalSpanClassName).Count > 0)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.journalSpanClassName).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue;
                        }
                    }

                    //Page field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.pagesSpanClassName).Count > 0)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.pagesSpanClassName).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue;
                        }
                    }

                    //Issue field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.issueSpanClassName).Count > 0)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.issueSpanClassName).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue;
                        }
                    }

                    //Volume field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.volumeSpanClassName).Count > 0)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.volumeSpanClassName).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue;
                        }
                    }

                    //Date field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.dateSpanClassName).Count > 0)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.dateSpanClassName).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue;
                        }
                    }

                    //Article type field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.articleTypeSpanClassName).Count > 0)
                    {
                        if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.articleTypeSpanClassName).Text.ToLower(), searchTermArray))
                        {
                            flag = true;
                            continue;
                        }
                    }

                    //Abstract field verification
                    if (CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id","divAbsrow").Count > 0)
                    {
                    CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText","Uittreksel").Click();

                        ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id","divAbsrow"),"TagName","P");

                        for (int fieldCount = 0; fieldCount < list.Count; fieldCount++)
                        {
                            string abstractValue = list[fieldCount].Text.ToLower();

                            if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(abstractValue, searchTermArray))
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    Assert.IsTrue(flag, "Unable to find " + searchTerm + "in the records");
                }
            }
            else
            {
                Assert.IsTrue(false, "No records for the search term: " + searchTerm);
            }

        }

        // This method is used to validate pagination functionality
        public static void VerifyPaginationForPreviousAndNextLinks()
        {
            ResultReport.AddTestStepDetails("Verifying pagination functionality");
            DoCitationSearch("\"heart attack\"");
           
            bool getRightArrowStatus = true;

            //Verifying for Right arrow link is disabled when we do not have more results
            ReadOnlyCollection<IWebElement> disabledLinks = CommonFixtures.FindChildElementsbyCriteria(findCitaionPage.paginationDivCitationPage,"ClassName","wk-disabled");
            if (disabledLinks.Count > 0)
            {
                string rightLinkStatus = disabledLinks[0].FindElement(By.TagName("a")).Text;
                if (rightLinkStatus == "")
                {
                    getRightArrowStatus = false;
                }
            }

            List<string> recordTitle = new List<string>();
            int i = 0;

            int gg = CommonControlsPage.commonControlsPage.recordsCollection.Count();

            string gfg = CommonControlsPage.commonControlsPage.recordsCollection[0].Text;

            recordTitle.Add(CommonControlsPage.commonControlsPage.recordsCollection[0].Text);

            while (getRightArrowStatus)
            {
                i = i + 1;

                CommonControlsPage.commonControlsPage.rightArrowLink.Click();
                Thread.Sleep(5000);
                recordTitle.Add(CommonControlsPage.commonControlsPage.recordsCollection[0].Text);

                Assert.IsTrue(recordTitle[i] != recordTitle[i-1], "same records exists on both the pages");
                
                disabledLinks = CommonFixtures.FindChildElementsbyCriteria(findCitaionPage.paginationDivCitationPage,"ClassName","wk-disabled");
                if (disabledLinks.Count > 0)
                {
                    string rightLinkStatus = CommonFixtures.FindChildElementbyCriteria(disabledLinks[0],"TagName","a").Text;
                    if (rightLinkStatus == "")
                    {
                        getRightArrowStatus = false;
                    }
                }
            }

            bool getLeftArrowStatus = true;
            disabledLinks = CommonFixtures.FindChildElementsbyCriteria(findCitaionPage.paginationDivCitationPage,"ClassName","wk-disabled");
            if (disabledLinks.Count > 0)
            {
                string leftLinkStatus = CommonFixtures.FindChildElementbyCriteria(disabledLinks[0],"TagName","a").Text;
                if (leftLinkStatus == "")
                {
                    getLeftArrowStatus = false;
                }
            }

            List<string> recordTitleBackWord = new List<string>();
            int j = 0;

            while (getLeftArrowStatus)
            {
                j = j + 1;
                CommonControlsPage.commonControlsPage.leftArrowLink.Click();
                Thread.Sleep(5000);

                recordTitleBackWord.Add(CommonControlsPage.commonControlsPage.recordsCollection[0].Text);

                Assert.IsTrue(recordTitle[recordTitle.Count() - j] != recordTitleBackWord[j-1], "same records exists on both the pages");
               
                disabledLinks = CommonFixtures.FindChildElementsbyCriteria(findCitaionPage.paginationDivCitationPage,"ClassName","wk-disabled");
                if (disabledLinks.Count > 0)
                {
                    string leftLinkStatus = disabledLinks[0].FindElement(By.TagName("a")).Text;
                    if (leftLinkStatus == "")
                    {
                        getLeftArrowStatus = false;
                    }
                }
            }

        }

        // This method is used to validate the movement between pages
        public static void VerifyPageDisplayOnCitation()
        {
            ResultReport.AddTestStepDetails("Verifying how pages are displaying upon Selecting last page");
            DoCitationSearch("heart");
            
            //Verifying for First page is active by default
            string firstPageStatus = CommonFixtures.FindChildElementbyCriteria(CommonFixtures.FindChildElementbyCriteria(findCitaionPage.paginationDivCitationPage,"ClassName","wk-active"),"TagName","a").Text;
            Assert.IsTrue(firstPageStatus == "1", "First page link is not active by dafault");

            CommonFixtures.FindChildElementbyCriteria(findCitaionPage.paginationDivCitationPage,"LinkText","10").Click();

            //Verifying for 10th page is active after click on 10
            string tenthPageStatus = CommonFixtures.FindChildElementbyCriteria(CommonFixtures.FindChildElementbyCriteria(findCitaionPage.paginationDivCitationPage,"ClassName","wk-active"),"TagName","a").Text;
            Assert.IsTrue(tenthPageStatus == "10", "10th page link is not active after selecting");

            Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(findCitaionPage.paginationDivCitationPage, "LinkText", "14").Displayed);
            Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(findCitaionPage.paginationDivCitationPage, "LinkText", "5").Displayed);
            Assert.IsFalse(CommonFixtures.FindChildElementsbyCriteria(findCitaionPage.paginationDivCitationPage, "LinkText", "15").Count > 0);

            CommonFixtures.FindChildElementbyCriteria(findCitaionPage.paginationDivCitationPage, "LinkText", "9").Click();
            Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(findCitaionPage.paginationDivCitationPage,"LinkText", "13").Displayed);
            Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(findCitaionPage.paginationDivCitationPage, "LinkText", "4").Displayed);
            Assert.IsFalse(CommonFixtures.FindChildElementsbyCriteria(findCitaionPage.paginationDivCitationPage, "LinkText", "14").Count > 0);

        }

        //This method verifies dafault pagination settings
        public static void DefaultPaginationVerification()
        {
           ResultReport.AddTestStepDetails("Verifying Dafault pagination");

           DoCitationSearch("blood cancer");

            //Verifying the left arrow link is disabled by default
           string disabledLinksName = CommonFixtures.FindChildElementbyCriteria(CommonFixtures.FindChildElementbyCriteria(findCitaionPage.paginationDivCitationPage,"ClassName","wk-disabled"),"TagName","a").Text;
           Assert.IsTrue(disabledLinksName == "", "Left arrow link is not disabled by dafault");
            
            //Verifying for FIrst page is active by default
           string firstPageStatus = CommonFixtures.FindChildElementbyCriteria(CommonFixtures.FindChildElementbyCriteria(findCitaionPage.paginationDivCitationPage,"ClassName","wk-active"),"TagName","a").Text;
           Assert.IsTrue(firstPageStatus == "1", "First page link is not active by dafault");

            //Verifying for 1 page of results
           DoCitationSearch("\"LOP36: EVALUATION OF THE USE OF CYANOACRYLATE GLUE IN MICROVASCULAR ANASTOMOSIS \"");

           ReadOnlyCollection<IWebElement> disabledLinks = CommonFixtures.FindChildElementsbyCriteria(findCitaionPage.paginationDivCitationPage,"ClassName","wk-disabled");

           disabledLinksName = CommonFixtures.FindChildElementbyCriteria(disabledLinks[0],"TagName","a").Text;
           Assert.IsTrue(disabledLinksName == "", "Left arrow link is not disabled for 1 page of results");

           string rightLinkStatus = disabledLinks[1].FindElement(By.TagName("a")).Text;
           Assert.IsTrue(rightLinkStatus == "", "Right arrow link is not disabled for 1 page of results");

        }

        //This method verifies Auto focus of the cursor in the Citation search page
        public static void VerifyAutoFocusOfCitationPage()
        {
            ResultReport.AddTestStepDetails("Verifying AutoFocus of the cursor in Citation page");

            Assert.IsTrue(findCitaionPage.searchBox.Equals(WebDriver.SwitchTo().ActiveElement()), "Auto Focus is not in Citation input box");
        }

        //This method tests tooltip messages of Citation page
        public static void CitationTabTooltipVerification()
        {
            ResultReport.AddTestStepDetails("Verifying tooltip text of Citation Tab");
            
            Actions action = new Actions(WebDriver);
            action.ClickAndHold(findCitaionPage.findCitationTab).Build().Perform();

            //Get the tool tip text of the Citation tab
            string citationTabToolTipText = findCitaionPage.toolTipOfCitationTab.Text;
            Assert.AreEqual("The quickest way find articles even if you don’t have a complete citation!", citationTabToolTipText);
            action.MoveToElement(findCitaionPage.findCitationTab).Release(findCitaionPage.findCitationTab).Perform();

            ResultReport.AddTestStepDetails("Verifying tooltip text of Citation search edit box");
            findCitaionPage.findCitationTab.Click();

            CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver,By.Id("Input_Citation"));

            //Get the tool tip text of the Citation searchbox
            action = new Actions(WebDriver);
            action.ClickAndHold(findCitaionPage.toolTipControlOfCitationBox).Build().Perform();

            string citationBoxTooltipText = findCitaionPage.toolTipOfCitationBox.Text;
            Assert.IsTrue(citationBoxTooltipText.Contains("You need to find an article, but don’t always have a complete citation. We get it. This will help."), "Citation tooltip not displayed as expected");
            //Assert.IsTrue(CommonControlsPage.commonControlsPage.learnMoreLink.Displayed, "Learn more link not displayed on Citation tooltip");
            action.MoveToElement(findCitaionPage.toolTipControlOfCitationBox).Release(findCitaionPage.toolTipControlOfCitationBox).Perform();
            
        }

        #endregion

    }
}
