using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WKH.SeleniumFrameWork;

namespace WKH.MOGA
{
	public class FieldedSearchPage : UIObjects
	{
		public static FieldedSearchPage fieldedSearchPage;

		public FieldedSearchPage()
		{
			PageFactory.InitElements(WebDriver, this);
			fieldedSearchPage = this;
		}

		//creating object of this class. Call this before accessing anyother method of this class
		public static void NavigateHere()
		{
			fieldedSearchPage = new FieldedSearchPage();
			CommonControlsPage.NavigateHere();
		}

		#region Find citation page controls

		[FindsBy(How = How.LinkText, Using = "Fielded Search")]
		public IWebElement fieldedSearchTab;

		[FindsBy(How = How.ClassName, Using = "wk-select-field")]
		public IWebElement solarSyntaxDropdown;

		[FindsBy(How = How.ClassName, Using = "wk-search-input")]
		public IWebElement solarSearchInput;

		[FindsBy(How = How.ClassName, Using = "wk-search-button-text")]
		public IWebElement searchButton;

		[FindsBy(How = How.Id, Using = "Input_Rows_0__SearchText")]
		public IWebElement fsTextArea;

		[FindsBy(How = How.Id, Using = "selectBoolean")]
		public IWebElement selectBooleanField;

		[FindsBy(How = How.ClassName, Using = "wk-search-input")]
		public IWebElement searchBox;

		//[FindsBy(How = How.ClassName, Using = "title")]
		//public IWebElement titleField;

		//[FindsBy(How = How.ClassName, Using = "authors")]
		//public IWebElement authorsField;

		//[FindsBy(How = How.ClassName, Using = "journal")] //Parent one
		//public IWebElement journalDiv;

		//[FindsBy(How = How.ClassName, Using = "journalName")]
		//public IWebElement journalNameField;

		//[FindsBy(How = How.ClassName, Using = "volume")]
		//public IWebElement volumeField;

		//[FindsBy(How = How.ClassName, Using = "issue")]
		//public IWebElement issueField;

		//[FindsBy(How = How.ClassName, Using = "pages")]
		//public IWebElement pagesField;

		//[FindsBy(How = How.LinkText, Using = "Abstract")]
		//public IWebElement abstractLink;

		[FindsBy(How = How.CssSelector, Using = ".tooltip-inner")]
		public IWebElement toolTipOfFieldedSearchTab;
        //Modified the locator to fix tool tip for Fielded search box
		[FindsBy(How = How.CssSelector, Using = ".glyphicon.glyphicon-comment")]
		public IWebElement toolTipControlOfFieldedSearchBox;

		[FindsBy(How = How.CssSelector, Using = ".col-sm-12.text-left")]
		public IWebElement toolTipOfFieldedSearchBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='FieldedSearchBox']/form/div[3]/div[1]/a/span")]
        public IWebElement toolTipControlOfSynonymsCheckBox;
        
        [FindsBy(How = How.XPath, Using = ".//*[@id='FieldedSearchBox']/form/div[3]/div[1]/div[1]/div[2]/div[1]/div[1]/div")]
        public IWebElement toolTipOfSynonymsCheckBox;

		//Pagination controls
		[FindsBy(How = How.ClassName, Using = "wk-icon-arrow-right")]
		public IWebElement rightArrowLink;

		[FindsBy(How = How.ClassName, Using = "wk-icon-arrow-left")]
		public IWebElement leftArrowLink;

		[FindsBy(How = How.ClassName, Using = "wk-pagination")]
		public IWebElement paginationDiv;

        [FindsBy(How = How.XPath, Using = "//span[@class='field-validation-error']")]
        public IWebElement ErrorMessageForSearchWithoutSearchTerm;

        //Pagination controls
        [FindsBy(How = How.XPath, Using = "//*[@id = 'divFieldedSearchPagination']//ul[@class='wk-pagination']")]
        public IWebElement paginationDivFieldedSearchPage;

        public string rowClass;

		public static string fsDefaultFieldNameCB_ID = "Input_Rows_0__FieldName";
		public static string fsDeafaultBooleanCB_ID = "Input_Rows_0__Operator";


		//Enter search term edit box  properties
		public static string fsSeacrhTermEditBoxNameFirstPart = "Input.Rows[";
		public static string fsSeacrhTermEditBoxNameSecondPart = "].SearchText";

		//Select field name Dropdown properties
		public static string fsFieldNameComboIdFirstPart = "Input_Rows_";
		public static string fsFieldNameComboIdSecondPart = "__FieldName";
		public static string fsFieldNameComboNameFirstPart = "Input.Rows[";
		public static string fsFieldNameComboNameSecondPart = "].FieldName";

		//Boolean operator Dropdown properties
		public static string fsBooleanComboIdFirstpart = "Input_Rows_";
		public static string fsBooleanComboIdSecondpart = "__Operator";
		public static string fsBooleanComboNameFirstpart = "Input.Rows[";
		public static string fsBooleanComboNameSecondpart = "].Operator";
		#endregion

		#region Fielded search Methods

		//Select Fielded search Tab
		public static void SelectFieldedSearchTab()
		{
			ResultReport.AddTestStepDetails("Select FieldedSearch Tab");
			//Selecting fielded search Tab
			fieldedSearchPage.fieldedSearchTab.Click();
            CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver, By.Id("Input_Rows_0__FieldName"), 60);

		}

		//Do fielded search by entering the search term against the given field
		public static void SingleFieldSearch(string filedName, string searchTerm)
		{
			ResultReport.AddTestStepDetails("Verifying available individual fields for the search");

            //Select field name
            CommonMethods.SelectDropdownListByText(WebDriver, By.Id(fsDefaultFieldNameCB_ID), filedName);

			//Enter search term
			fieldedSearchPage.fsTextArea.Clear();
			fieldedSearchPage.fsTextArea.SendKeys(searchTerm);

			fieldedSearchPage.fsTextArea.SendKeys(Keys.Escape);

			//Click search button
			fieldedSearchPage.searchButton.Click();
		}

		//Fielded search for the Auto cmplete fields
		public static void SingleFieldSearchAC(string filedName, string searchTerm)
		{
			ResultReport.AddTestStepDetails("Verifying available individual fields for the search");

            //Select field name
            CommonMethods.SelectDropdownListByText(WebDriver, By.Id(fsDefaultFieldNameCB_ID), filedName);

			//Enter search term
			fieldedSearchPage.fsTextArea.Clear();
			fieldedSearchPage.fsTextArea.SendKeys(searchTerm);
		}

        // This method verifies the search term for existence in specified field of all the records 
        public static void VerifySinglefieldsResultsForPartialSearchTerm(string fieldName, string fieldValue)
        {
            ResultReport.AddTestStepDetails("Verifying search results for given partial Search term");
            
            string[] searchTermArray = fieldValue.Replace("(","").Replace(")","").Replace("-", " ").Split(' ');

			if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
			{
				for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
				{
					switch (fieldName.Replace("➰", "").ToLower().Trim())
					{
						case "title":
						case "title_search": //Solr field name
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.titleLinkClassname).Text, searchTermArray), "Unable to find search term " + fieldValue + "for the field" + fieldName + " in the record" + i);
							break;
						case "author(s)":
						case "author":
						case "authors": //Solr field name
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"ClassName",CommonControlsPage.authorsSpanClassName).Text, searchTermArray), "Unable to find search term " + fieldValue + "for the field" + fieldName + " in the record" + i);
							break;
						case "journal name":
						case "journalname":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id",CommonControlsPage.journalSpanId).Text.ToLower(), searchTermArray), "Unable to find search term " + fieldValue + "for the field" + fieldName + " in the record" + i);
							break;
						case "page range":
						case "pagerange_search":  //Solr field name                                 
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.pagesSpanClassName).Text.ToLower(), searchTermArray), "Unable to find search term " + fieldValue + "for the field" + fieldName + " in the record" + i);
							break;
						case "issue":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.issueSpanClassName).Text.ToLower(), searchTermArray), "Unable to find search term " + fieldValue + "for the field" + fieldName + " in the record" + i);
							break;
						case "volume":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.volumeSpanClassName).Text.ToLower(), searchTermArray), "Unable to find search term " + fieldValue + "for the field" + fieldName + " in the record" + i);
							break;
						case "publication year":
						case "publicationdate_year": //Solr field name
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.dateSpanClassName).Text.ToLower(), searchTermArray), "Unable to find search term " + fieldValue + "for the field" + fieldName + " in the record" + i);
							break;
						case "publicationtype":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.articleTypeSpanClassName).Text.ToLower(), searchTermArray), "Unable to find search term " + fieldValue + "for the field" + fieldName + " in the record" + i);
							break;
						case "abstract_search": //Solr field name
							CommonMethods.ClickElementUsingJavaScript(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText",CommonControlsPage.abstractLinkText));
							//CommonControlsPage.commonControlsPage.recordsCollection[i],"LinkText","Abstract")).Click();
							bool abstractflag = false;
							ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"Id","divAbsrow"),"TagName","P");
							for (int fieldCount = 0; fieldCount < list.Count; fieldCount++)
							{
								string abstractValue = list[fieldCount].Text.ToLower();

								if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(abstractValue, searchTermArray))
								{
									abstractflag = true;
									break;
								}
							}
							Assert.IsTrue(abstractflag, "Unable to find search term " + fieldValue + "for the field" + fieldName + " in the record" + i);
							break;
						case "":
						case null:
							break;
						default:
							Assert.Fail("Not given proper field name.Please check!!");
							break;
					}

				}
			}
			else
			{
				Assert.IsTrue(false, "No records for the search term: " + fieldValue);
			}

		}

		// This method verifies the search term for existence in any field for all the records -- not yet fully implemented 
		public static void VerifyResultsOfFieldedSearchFieldsWhichDataNotDisplayeOnUI(string fieldName, string fieldValue)
		{
			ResultReport.AddTestStepDetails("Verifying search results for given partial Search term");

			string[] searchTermArray = fieldValue.Split(' ');

			if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
			{
				for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
				{
					ReadOnlyCollection<IWebElement> list = CommonFixtures.FindChildElementsbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i],"TagName","P");

					switch (fieldName.Replace("➰", "").ToLower().Trim())
					{
						case "title":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(list[0].Text, searchTermArray), "Unable to find " + fieldValue + "in the records");
							break;
						case "author(s)":
						case "author":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(list[1].Text, searchTermArray), "Unable to find " + fieldValue + "in the records");
							break;
						case "journal name":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(list[2],"Id",CommonControlsPage.journalSpanId).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
							break;
						case "page range":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(list[2],"ClassName",CommonControlsPage.pagesSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
							break;
						case "issue":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(list[2], "ClassName", CommonControlsPage.issueSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
							break;
						case "volume":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(list[2], "ClassName", CommonControlsPage.volumeSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
							break;
						case "publication year":
							Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(list[2], "ClassName", CommonControlsPage.dateSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
							break;
						default:
							Assert.Fail("Not given proper field name.Please check!!");
							break;
					}

				}
			}
			else
			{
				Assert.IsTrue(false, "No records for the search term: " + fieldValue);
			}

		}

		// This method verifies the complete search term for existence in the given field of all the records on first page
		public static void VerifySinglefieldsResultsForFullSearchTerm(string fieldName, string fieldValue)
		{
			ResultReport.AddTestStepDetails("Verifying search results for given partial Search term");

            int RecordCollectionCount = CommonControlsPage.commonControlsPage.recordsCollection.Count;

            if (RecordCollectionCount != 0)
			{
				for (int i = 0; i < RecordCollectionCount; i++)
				{
					switch (fieldName.Replace("➰", "").ToLower().Trim())
					{
						case "title":
							Assert.IsTrue(CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.titleLinkClassname),"Text", fieldValue.ToLower(),"Contains"), "Unable to find " + fieldValue + "in the records");
							break;
						case "author(s)":
						case "author":
							Assert.IsTrue(CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.authorsSpanClassName), "Text", fieldValue.ToLower(), "Contains"), "Unable to find " + fieldValue + "in the records");
							break;
						case "journal name":
							Assert.IsTrue(CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "Id",CommonControlsPage.journalSpanId), "Text", fieldValue.ToLower(), "Contains"), "Unable to find " + fieldValue + "in the records");
							break;
						case "page range":
							Assert.IsTrue(CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.pagesSpanClassName), "Text", fieldValue.ToLower(), "Contains"), "Unable to find " + fieldValue + "in the records");
							break;
						case "issue":
							Assert.IsTrue(CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.issueSpanClassName), "Text", fieldValue.ToLower(), "Contains"), "Unable to find " + fieldValue + "in the records");
							break;
						case "volume":
							Assert.IsTrue(CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.volumeSpanClassName),"Text", fieldValue.ToLower(),"Contains"), "Unable to find " + fieldValue + "in the records");
							break;
						case "publication year":
							Assert.IsTrue(CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.dateSpanClassName), "Text", fieldValue.ToLower(), "Contains"), "Unable to find " + fieldValue + "in the records");
							break;
						case "publicationtype":
							Assert.IsTrue(CommonFixtures.CheckPropertyValue(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.articleTypeSpanClassName), "Text", fieldValue.ToLower(), "Contains"), "Unable to find " + fieldValue + "in the records");
							break;
						case "":
						case null:
							break;
						default:
							Assert.Fail("Not given proper field name.Please check!!");
							break;
					}

				}

			}
			else if (CommonControlsPage.NoResultsFound() == "No Results found")
			{
				Assert.IsTrue(true, "No records for the search term: " + fieldValue);
			}
			else
			{
				Assert.IsTrue(false, "No records for the search term: " + fieldValue);
			}

		}

		public static void VerifySinglefieldsResultsForTeaserTextSearchTerm(string fieldName, string fieldValue)
		{
			ResultReport.AddTestStepDetails("Verifying search results for given partial Search term");

			foreach (IWebElement ele in CommonControlsPage.commonControlsPage.recordsCollection)
			{
				

				if (CommonControlsPage.commonControlsPage.AbstractElement(ele) > 0)
				{

					if (CommonControlsPage.abstractLinkText != "" && CommonControlsPage.TeaserText() != "")
					{
						
						if (! CommonControlsPage.TeaserText().ToLower().Contains(fieldValue.ToLower()))
						{
							ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName, "Unable to find " + fieldValue + "in the records");
						}
						CommonControlsPage.AbstractArrowClick();
						if (!CommonControlsPage.AbstractText().ToLower().Contains(CommonControlsPage.TeaserText().ToLower()))
						{
							ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName, "Unable to find " + CommonControlsPage.TeaserText().ToLower() + "in the records");
						}
						
					}

				}
				//else if (CommonControlsPage.abstractLinkText == "" || CommonControlsPage.TeaserText() == "")
				else
				{
					ResultReport.WriteResults(MOGAConstants.appURL, MOGAConstants.productName, "No Abstract and Teaser Text Found for this record");

				}

			}

		}

		//This method is used to select Multiple fields with AND/OR operators
		public static void MultiFieldSearchWithTheGivenOperators(Dictionary<string, string> field1Data, string Operator)
		{
			ResultReport.AddTestStepDetails("Selecting Multiple fields with the option :  " + Operator);

			SelectFieldedSearchTab();
			CommonControlsPage.SelectResource(MOGAConstants.strMedline);
			int rowNo = 0;

			foreach (KeyValuePair<string, string> fieldNameAndValues in field1Data)
			{
                //Selecting field name
                CommonMethods.SelectDropdownListByValue(WebDriver, By.Name(fsFieldNameComboNameFirstPart + rowNo + fsFieldNameComboNameSecondPart), fieldNameAndValues.Key);

				//Enter search term
				UIObjects.WebElement("Name="+fsSeacrhTermEditBoxNameFirstPart + rowNo + fsSeacrhTermEditBoxNameSecondPart).Clear();
                UIObjects.WebElement("Name=" + fsSeacrhTermEditBoxNameFirstPart + rowNo + fsSeacrhTermEditBoxNameSecondPart).SendKeys(fieldNameAndValues.Value);

				Thread.Sleep(500);

				Actions action = new Actions(WebDriver);
				action.SendKeys(Keys.Escape).Build().Perform();

				// WebDriver, "ClassName","lbltxt")).Click();
				//Select boolean operator from dropdown
				if (field1Data.Count != rowNo + 1)
                    CommonMethods.SelectDropdownListByValue(WebDriver, By.Name(fsBooleanComboNameFirstpart + rowNo + fsBooleanComboNameSecondpart), Operator);

				rowNo = rowNo + 1;
			}
			fieldedSearchPage.searchButton.Click();
		}

		//This method is used to select Multiple fields with AND & OR operators
		public static void MultiFieldSearchWithAND_OR(List<FSTestData> field1Data)
		{
			ResultReport.AddTestStepDetails("Doing Multiple fields search with AND_OR option");

			SelectFieldedSearchTab();

			int rowNo = 0;
			List<FSTestData> data = field1Data;

			for (int m = 0; m < data.Count; m++)
			{
                //Selecting field name
                CommonMethods.SelectDropdownListByValue(WebDriver, By.Name(fsFieldNameComboNameFirstPart + rowNo + fsFieldNameComboNameSecondPart), data[m].fieldName);

                //Enter search term
                UIObjects.WebElement("Name=" + fsSeacrhTermEditBoxNameFirstPart + rowNo + fsSeacrhTermEditBoxNameSecondPart).Clear();
            UIObjects.WebElement("Name=" + fsSeacrhTermEditBoxNameFirstPart + rowNo + fsSeacrhTermEditBoxNameSecondPart).SendKeys(data[m].searchTerm);
				int ss = data.Count();
				//Select boolean operator from dropdown
				if (ss != rowNo)
				{
					if (rowNo == field1Data.Count - 1)
						break;
					//CommonMethods.SeletDropdownlistByValue(fsBooleanComboNameFirstpart + rowNo + fsBooleanComboNameSecondpart, "Select");
					else
                        CommonMethods.SelectDropdownListByValue(WebDriver, By.Name(fsBooleanComboNameFirstpart + rowNo + fsBooleanComboNameSecondpart), data[m].operatorVal);
				}

				rowNo = rowNo + 1;
			}
			fieldedSearchPage.searchButton.Click();
		}

		// This method verifies the search terms for all the selected fields for existence in all the records 
		public static void VerifyMultifieldResultsForPartialTermsWithANDoperator(Dictionary<string, string> fieldData)
		{
			ResultReport.AddTestStepDetails("Verifying search results for given partial Search term with AND operator");

			if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
			{
				for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
				{
					foreach (KeyValuePair<string, string> fieldNameAndValues in fieldData)
					{
						string[] searchTermArray = fieldNameAndValues.Value.Split(':');
						for(int j=0;j < searchTermArray.Count();j++)
						{
							searchTermArray[j] = searchTermArray[j].Trim();
						}

						switch (fieldNameAndValues.Key.Replace("➰", "").ToLower().Trim())
						{
							case "title":
								Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.titleLinkClassname).Text.ToLower(), searchTermArray), "Unable to find " + fieldNameAndValues.Value + "in the records");
								break;
							case "author(s)":
							case "author":
								Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.authorsSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldNameAndValues.Value + "in the records");
								break;
							case "journal name":
								Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "Id",CommonControlsPage.journalSpanId).Text.ToLower(), searchTermArray), "Unable to find " + fieldNameAndValues.Value + "in the records");
								break;
							case "page range":
								Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.pagesSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldNameAndValues.Value + "in the records");
								break;
							case "issue":
								Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.issueSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldNameAndValues.Value + "in the records");
								break;
							case "volume":
								Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.volumeSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldNameAndValues.Value + "in the records");
								break;
							case "publication year":
								Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.dateSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldNameAndValues.Value + "in the records");
								break;
							case "publicationtype":
								Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.articleTypeSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldNameAndValues.Value + "in the records");
								break;
							default:
								Assert.Fail("Not given proper field name.Please check!!");
								break;
						}

					}
				}
			}
			else
			{
				Assert.IsTrue(false, "No records found for the given field values");
			}

		}

		// This method verifies the search terms for all the selected fields for existence in any of the the record
		public static void VerifyMultifieldResultsForPartialTermsWithORoperator(Dictionary<string, string> fieldData)
		{
			ResultReport.AddTestStepDetails("Verifying search results for given partial Search term with OR operator");

			Boolean flag = false;

			if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
			{
				for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
				{

					foreach (KeyValuePair<string, string> fieldNameAndValues in fieldData)
					{
						string[] searchTermArray = fieldNameAndValues.Value.Split(' ');

						switch (fieldNameAndValues.Key.Replace("➰", "").ToLower().Trim())
						{
							case "title":
								if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.titleLinkClassname).Text.ToLower(), searchTermArray)) flag = true;
								break;
							case "author(s)":
							case "author":
								if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.authorsSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
								break;
							case "journal name":
								if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "Id",CommonControlsPage.journalSpanId).Text.ToLower(), searchTermArray)) flag = true;
								break;
							case "page range":
								if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.pagesSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
								break;
							case "issue":
								if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.issueSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
								break;
							case "volume":
								if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.volumeSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
								break;
							case "publication year":
								if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.dateSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
								break;
							case "publicationtype":
								if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.articleTypeSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
								break;
							default:
								Assert.Fail("Not given proper field name.Please check!!");
								break;
						}

					}
					Assert.IsTrue(flag, "Given search terms are not available in any of the filed of the record number" + i);
					flag = false;
				}
			}
			else
			{
				Assert.IsTrue(false, "No records found for the given field values");
			}

		}

		// This method verifies the search terms for all the selected fields for not existence in all the records 
		public static void VerifyMultifieldResultsForNOToperator(Dictionary<string, string> fieldData)
		{
			ResultReport.AddTestStepDetails("Verifying search results for given Search term with NOT operator");

			if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
			{
				for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
				{
					int fieldNameInit = 0;
					foreach (KeyValuePair<string, string> fieldNameAndValues in fieldData)
					{
						if (fieldNameInit != 0)
						{
							string[] searchTermArray = fieldNameAndValues.Value.Split(' ');

							switch (fieldNameAndValues.Key.Replace("➰", "").ToLower().Trim())
							{
								case "title":
									Assert.IsFalse(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.titleLinkClassname).Text, searchTermArray), fieldNameAndValues.Value + ": Does existin the records");
									break;
								case "author(s)":
								case "author":
									Assert.IsFalse(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.authorsSpanClassName).Text, searchTermArray), fieldNameAndValues.Value + ": Does existin the records");
									break;
								case "journal name":
									Assert.IsFalse(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "Id",CommonControlsPage.journalSpanId).Text.ToLower(), searchTermArray), fieldNameAndValues.Value + ": Does existin the records");
									break;
								case "page range":
									Assert.IsFalse(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.pagesSpanClassName).Text.ToLower(), searchTermArray), fieldNameAndValues.Value + ": Does existin the records");
									break;
								case "issue":
									Assert.IsFalse(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.issueSpanClassName).Text.ToLower(), searchTermArray), fieldNameAndValues.Value + ": Does existin the records");
									break;
								case "volume":
									Assert.IsFalse(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.volumeSpanClassName).Text.ToLower(), searchTermArray), fieldNameAndValues.Value + ": Does existin the records");
									break;
								case "publication year":
									Assert.IsFalse(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.dateSpanClassName).Text.ToLower(), searchTermArray), fieldNameAndValues.Value + ": Does existin the records");
									break;
								case "publicationtype":
									Assert.IsFalse(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.articleTypeSpanClassName).Text.ToLower(), searchTermArray), fieldNameAndValues.Value + ": Does existin the records");
									break;
								default:
									Assert.Fail("Not given proper field name.Please check!!");
									break;
							}
							fieldNameInit = fieldNameInit + 1;
						}

					}
				}
			}
			else
			{
				Assert.IsTrue(false, "No records found for the given field values");
			}

		}

		// This method verifies the search terms for all the selected fields for existence in any of the the record
		public static void VerifyMultifieldResultsForPartialTermsWithAND_ORoperator(List<FSTestData> field1Data)
		{
			ResultReport.AddTestStepDetails("Verifying search results for given partial Search term with OR operator");

			bool flag = false;
			List<FSTestData> data = field1Data;

			//Validating for OR condition
			for (int m = 0; m < field1Data.Count; m++)
			{
				string fieldName = data[m].fieldName;
				string fieldValue = data[m].searchTerm;
				string operatorVal = "";

				if (m == 0)
				{
					operatorVal = "and";
				}
				else
				{
					operatorVal = data[m - 1].operatorVal;
				}


				if (operatorVal.Equals("OR"))
				{
					#region
					if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
					{
						for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
						{
							string[] searchTermArray = fieldValue.Split(' ');

							switch (fieldName.Replace("➰", "").ToLower().Trim())
							{
								case "title":
									if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.titleLinkClassname).Text, searchTermArray)) flag = true;
									break;
								case "author(s)":
								case "author":
									if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.authorsSpanClassName).Text, searchTermArray)) flag = true;
									break;
								case "journal name":
									if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.journalSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
									break;
								case "page range":
									if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.pagesSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
									break;
								case "issue":
									if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.issueSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
									break;
								case "volume":
									if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.volumeSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
									break;
								case "publication year":
									if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.dateSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
									break;
								case "publicationtype":
									if (MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.articleTypeSpanClassName).Text.ToLower(), searchTermArray)) flag = true;
									break;
								default:
									Assert.Fail("Not given proper field name.Please check!!");
									break;
							}
						}
					}
					else
					{
						Assert.IsTrue(false, "No records found for the given field values");
					}
					#endregion
				}
			}

			//Validating for AND condition if OR does not satisfy
			if (flag != true)
			{
				for (int m = 0; m < field1Data.Count; m++)
				{
					string fieldName = data[m].fieldName;
					string fieldValue = data[m].searchTerm;
					string operatorVal = data[m].operatorVal;


					if (operatorVal.Equals("AND"))
					{

						for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
						{

							string[] searchTermArray = fieldValue.Split(' ');

							switch (fieldName.Replace("➰", "").ToLower().Trim())
							{
								case "title":
									Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.titleLinkClassname).Text, searchTermArray), "Unable to find " + fieldValue + "in the records");
									break;
								case "authors":
								case "author":
									Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.authorsSpanClassName).Text, searchTermArray), "Unable to find " + fieldValue + "in the records");
									break;
								case "journal name":
									Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "Id",CommonControlsPage.journalSpanId).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
									break;
								case "page range":
									Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.pagesSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
									break;
								case "issue":
									Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.issueSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
									break;
								case "volume":
									Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.volumeSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
									break;
								case "publication year":
									Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.dateSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
									break;
								case "publicationtype":
									Assert.IsTrue(MOGAConstants.mogaFunctions.VerifySearchTermInArray(CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.articleTypeSpanClassName).Text.ToLower(), searchTermArray), "Unable to find " + fieldValue + "in the records");
									break;
								default:
									Assert.Fail("Not given proper field name.Please check!!");
									break;
							}
						}
					}
				}

			}

		}

		// This method verifies the search terms are retained after search 
		public static void VerifyFieldsForRetainedValues(Dictionary<string, string> fieldData)
		{
			ResultReport.AddTestStepDetails("Verifying fields for retained values after search");

			int rowNo = 0;
			foreach (KeyValuePair<string, string> fieldNameAndValues in fieldData)
			{
                //Capture field name
                IWebElement dropdown = UIObjects.WebElement("Name=" + fsFieldNameComboNameFirstPart + rowNo + fsFieldNameComboNameSecondPart);
				SelectElement fpselect = new SelectElement(dropdown);
				string fieldName = fpselect.SelectedOption.Text;

				//Capture search term                
				string fieldValue = UIObjects.WebElement("Name=" + fsSeacrhTermEditBoxNameFirstPart + rowNo + fsSeacrhTermEditBoxNameSecondPart).GetAttribute("Value");
                
				Assert.IsTrue(fieldName == fieldNameAndValues.Key, "Field Name selected is not retained after search");
				Assert.IsTrue(fieldValue == fieldNameAndValues.Value, "Field value selected is not retained after search");

				rowNo = rowNo + 1;
			}

		}

		/// <summary>
		/// This method verifies the title of the retracted records for which titles started with the given/retracted search term
		/// </summary>
		public static void VerifyTitleOfTheRetractedArticlesStartsWithRetract(string searchTerm)
		{
			ResultReport.AddTestStepDetails("Verifying retracted articles for the updated Title");

			string getCellText = string.Empty;

            int recordCount = CommonControlsPage.commonControlsPage.recordsCollection.Count;
           if (recordCount != 0)
			{
				for (int i = 0; i < recordCount; i++)
				{
                        IWebElement link = CommonFixtures.FindChildElementbyCriteria(CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName", CommonControlsPage.titleLinkClassname);
                        Assert.IsTrue(link.Text.StartsWith(searchTerm), "Retracted article title not started with the word Retracted");
				}
			}
			else
			{
				Assert.IsTrue(false, "No records found for the given search terms");
			}
		}

		/// <summary>
		/// This method verifies the title of the Retracted records in the search results
		/// </summary>
		public static void VerifyTitleOfTheRetractedArticles(string searchTerm)
		{
			ResultReport.AddTestStepDetails("Verifying retracted articles gets in search results with Relevant Retracted Title");

			string getCellText = string.Empty;

			if (CommonControlsPage.commonControlsPage.recordsCollection.Count != 0)
			{
				bool testRetractedArticleFlag = false;
				for (int i = 0; i < CommonControlsPage.commonControlsPage.recordsCollection.Count; i++)
				{
                    //modified for test case 'RetractedArticles_Test'. Here the code will not be able to fetch the text as her the searched element is a div
                    // and it does not conatin any text. In fact the a tag inside that dic has that text. Hence changing the code to fetch text on the a tag
                    //inside the div.
					//if (CommonControlsPage.commonControlsPage.recordsCollection[i], "ClassName",CommonControlsPage.titleLinkClassname)).Text.EndsWith("."))
                    string textFromResultRecord = CommonFixtures.FindChildElementbyCriteria( CommonControlsPage.commonControlsPage.recordsCollection[i],"XPath","//div[@class='title rowPadding']/a").Text;
                    //if (CommonControlsPage.commonControlsPage.recordsCollection[i].FindElement(By.XPath("//div[@class='title rowPadding']/a")).Text.EndsWith("."))
                    //{
                        List<string> lstSubStringOfsearchTerm = searchTerm.Split(' ').ToList();
                       
                     if (lstSubStringOfsearchTerm.Any(textFromResultRecord.Contains))
						{
							testRetractedArticleFlag = true;
							break;
						}
                    //}
                    
				}
				Assert.IsTrue(testRetractedArticleFlag, "Retracted articles  not found in the search results with Retracted title");
			}
			else
			{
				Assert.IsTrue(false, "No records found for the given search terms");
			}
		}


		// This method is used to validate the movement between pages
		public static void VerifyPageDisplayOnFieldedSearch()
		{
			ResultReport.AddTestStepDetails("Verifying how pages are displaying upon Selecting last page");
			SingleFieldSearch("Title ➰", "heart");
            IWebElement ele = CommonFixtures.FindChildElementbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage, "ClassName", "wk-active");
            //Verifying for First page is active by default
            string firstPageStatus = CommonFixtures.FindChildElementbyCriteria(CommonFixtures.FindChildElementbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage, "ClassName","wk-active"),"TagName","a").Text;
			Assert.IsTrue(firstPageStatus == "1", "First page link is not active by dafault");

            CommonFixtures.FindChildElementbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage,"LinkText","10").Click();

			//Verifying for 10th page is active after click on 10
			string tenthPageStatus = CommonFixtures.FindChildElementbyCriteria(CommonFixtures.FindChildElementbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage, "ClassName","wk-active"),"TagName","a").Text;
			Assert.IsTrue(tenthPageStatus == "10", "10th page link is not active after selecting");

			Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage,"LinkText","14").Displayed);
			Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage,"LinkText","5").Displayed);
			Assert.IsFalse(CommonFixtures.FindChildElementsbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage,"LinkText","15").Count > 0);

            CommonFixtures.FindChildElementbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage,"LinkText","9").Click();
			Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage,"LinkText","13").Displayed);
			Assert.IsTrue(CommonFixtures.FindChildElementbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage,"LinkText","4").Displayed);
			Assert.IsFalse(CommonFixtures.FindChildElementsbyCriteria(fieldedSearchPage.paginationDivFieldedSearchPage,"LinkText","14").Count > 0);

		}

		//This method reads testdata according to database sheet and returns values from three columns of test data
		public List<FSTestData> ReturnTestDataFromExcel(string fieldName, string fieldValue, string fieldValue1, string SheetName)
		{
			string query = "SELECT [" + fieldName + "],[" + fieldValue + "],[" + fieldValue1 + "] FROM [" + SheetName + "$]";

            DataTable excelDataTable = MOGAConstants.mogaFunctions.ReadExcelTable(query);
            List<FSTestData> testData = new List<FSTestData>();
			int i = 0;
			for (int x = 0; x < excelDataTable.Rows.Count; x++)
			{
				FSTestData ts = new FSTestData();
				ts.fieldName = excelDataTable.Rows[x][0].ToString();
				ts.searchTerm = excelDataTable.Rows[x][1].ToString();
				ts.operatorVal = excelDataTable.Rows[x][2].ToString();
				//ts.sheetName = excelDataTable.Rows[x][3].ToString();
				i++;
				testData.Add(ts);

			}
			return testData;
		}

		//This method verifies Auto focus of the cursor in the Fielded search page
		public static void VerifyAutoFocusOfFieldedSearchPage()
		{
			ResultReport.AddTestStepDetails("Verifying AutoFocus of the cursor in Fielded search page");

			Assert.IsTrue(fieldedSearchPage.fsTextArea.Equals(WebDriver.SwitchTo().ActiveElement()), "Auto Focus is not in Fielded search input box");
		}

		//This method tests tooltip messages of Fielded search page
		public static void FieldedSearchTabTooltipVerification()
		{
			ResultReport.AddTestStepDetails("Verifying tooltip text of Fielded Search Tab");

			Actions action = new Actions(WebDriver);
			action.ClickAndHold(fieldedSearchPage.fieldedSearchTab).Build().Perform();

			//Get the tool tip of fielded search tab
			string fieldedSearchTabToolTipText = fieldedSearchPage.toolTipOfFieldedSearchTab.Text;
			Assert.AreEqual("Precision searching with a little help.", fieldedSearchTabToolTipText);
			action.MoveToElement(fieldedSearchPage.fieldedSearchTab).Release(fieldedSearchPage.fieldedSearchTab).Perform();

			ResultReport.AddTestStepDetails("Verifying tooltip text of Fielded Search edit box");

			fieldedSearchPage.fieldedSearchTab.Click();

			WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(60));
			waitForObject.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("Input_Rows_0__SearchText")));

			//Get the tooltip of fielded search box
			action = new Actions(WebDriver);
			action.ClickAndHold(fieldedSearchPage.toolTipControlOfFieldedSearchBox).Build().Perform();

			string fieldedSearchBoxTooltipText = fieldedSearchPage.toolTipOfFieldedSearchBox.Text;
			Assert.IsTrue(fieldedSearchBoxTooltipText.Contains("Know what you’re looking for? Know where to find it? Fielded search is for you. Combine steps with Boolean operators."), "FieldedSearch tooltip not displayed as expected");
			//Assert.IsTrue(CommonControlsPage.commonControlsPage.learnMoreLink.Displayed, "Learn more link not displayed on FieldedSearch tooltip");
			action.MoveToElement(fieldedSearchPage.toolTipControlOfFieldedSearchBox).Release(fieldedSearchPage.toolTipControlOfFieldedSearchBox).Perform();

            //Get the tooltip of use synonyms check box
            action = new Actions(WebDriver);
            action.ClickAndHold(fieldedSearchPage.toolTipControlOfSynonymsCheckBox).Build().Perform();

            string useSynonymsCheckBoxTooltip = fieldedSearchPage.toolTipOfSynonymsCheckBox.Text;
            Assert.IsTrue(useSynonymsCheckBoxTooltip.Contains("Apply synonyms to Title and Abstract fields if selected"), "FieldedSearch use synonyms tooltip not displayed as expected");
            action.MoveToElement(fieldedSearchPage.toolTipControlOfSynonymsCheckBox).Release(fieldedSearchPage.toolTipControlOfSynonymsCheckBox).Perform();
        }

		

		#endregion


        public static void ClickSearchButton()
        {
            fieldedSearchPage.searchButton.Click();
        }

        public static string GetMessageForSearchWithoutSearchTerm()
        {
            return fieldedSearchPage.ErrorMessageForSearchWithoutSearchTerm.Text;
        }
    }
}
