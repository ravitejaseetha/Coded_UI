using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKH.SeleniumFrameWork;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace WKH.MOGA
{
    public class AutoCompleteFeature : UIObjects
    {
        public static AutoCompleteFeature autoCompleteFeature;

        public AutoCompleteFeature()
        {
            PageFactory.InitElements(WebDriver, this);
            autoCompleteFeature = this;
        }

        //creating object of this class. Call this before accessing anyother method of this class
        public static void NavigateHere()
        {
            autoCompleteFeature = new AutoCompleteFeature();
        }

        #region Find citation page controls

        [FindsBy(How = How.CssSelector, Using = ".typeahead.dropdown-menu")]
        public IWebElement acTermsWidget;
       
        public IList<IWebElement> acTermsCollection;

        #endregion


        public static void VerifyListOfAutoCompleteTerms(string searchTerm)
        {
            ResultReport.AddTestStepDetails("Verifying type ahead terms");

            //WebDriverWait waitForObject = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            //waitForObject.Until(ExpectedConditions.ElementIsVisible(By.ClassName("typeahead dropdown-menu")));

            autoCompleteFeature.acTermsCollection = CommonFixtures.FindChildElementsbyCriteria(autoCompleteFeature.acTermsWidget, "TagName","li");
            
            Assert.IsTrue(autoCompleteFeature.acTermsCollection.Count == 10, "Less than 10 terms are getting displayed");

            foreach (IWebElement acTerm in autoCompleteFeature.acTermsCollection)
            {
                IWebElement link = CommonFixtures.FindChildElementbyCriteria(acTerm, "TagName","a");
                if (link != null)
                {
                    Assert.IsTrue(CommonFixtures.CheckPropertyValue(link,"Value",searchTerm.ToLower(),"contains"), "type ahead terms does not conatin the search term we gave");

                    Assert.IsTrue(CommonFixtures.CheckPropertyValue(link, "Text", searchTerm.ToLower(), "contains"), "type ahead terms does not conatin the search term we gave");

                   // Assert.IsTrue(link.Text.ToLower().Contains(searchTerm.ToLower()), "type ahead terms does not conatin the search term we gave");
                }
                else
                    Assert.IsTrue(link!=null, "type ahead terms does not conatin the search term we gave");
            }
        }

        

    }
}
