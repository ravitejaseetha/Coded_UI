using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WKH.SeleniumFrameWork;

namespace WKH.MOGA
{
    public class RCPpage : UIObjects
    {

        public static RCPpage rcpPage;

        public RCPpage()
        {
            PageFactory.InitElements(WebDriver, this);
            rcpPage = this;
        }

        //creating object of this class. Call this before accessing anyother method of this class
        public static void NavigateHere()
        {
            rcpPage = new RCPpage();
            CommonControlsPage.NavigateHere();
        }

        #region Relevance Page controls

        [FindsBy(How = How.LinkText, Using = "RCP")]
        public IWebElement relevanceControlTab;

        [FindsBy(How = How.Id, Using = "QueryString")]
        public IWebElement RCPsearchQueryField;

        [FindsBy(How = How.ClassName, Using = "wk-search-submit")]
        public IWebElement rcpSubmitBtn;

        //Tool tip controls
        [FindsBy(How = How.CssSelector, Using = ".tooltip-inner")]
        public IWebElement toolTipOfRCPtab;

        [FindsBy(How = How.CssSelector, Using = ".glyphicon.glyphicon-comment")]
        public IWebElement toolTipControlOfRCPbox;

        [FindsBy(How = How.CssSelector, Using = ".col-sm-12.text-left")]
        public IWebElement toolTipOfRCPbox;

	    [FindsBy(How = How.XPath, Using = "//div[@class = 'col-sm-6 nopadding'][1]//select[@class = 'form-control input-sm wk-select-option']")]
		public   IList<IWebElement> BoostFieldNames;

	    [FindsBy(How = How.XPath, Using = "//div[@class = 'col-sm-6 nopadding'][1] //div[contains(text(),'Boost') and @class='tooltip-inner']")]
		public IList<IWebElement> BoostFieldValues;


        [FindsBy(How = How.CssSelector, Using = ".tooltip-inner")]
        public IList<IWebElement> toolTip;

        [FindsBy(How = How.XPath, Using = ".//div[@class = 'col-sm-6 nopadding'][1]//div[@class='slider-handle min-slider-handle round']")]
        public IList<IWebElement> lstSlider;

        [FindsBy(How = How.XPath, Using = ".//*[@id='system_defaults']")]
        public IWebElement DefaultHeaderValue;
        #endregion

        #region Relevance Page Methods

        //Select Fielded search Tab
        public static void SelectRCPTab()
        {
            ResultReport.AddTestStepDetails("Select RCP Tab");
            
            rcpPage.relevanceControlTab.Click();

            CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver,By.Id("QueryString"),60);
        }
        
        public bool IsHeaderVisible()
        {
          
            if(DefaultHeaderValue.Displayed)
            {
                return true;
            }
            return false;
        }

        public static void RCPTabTooltipVerification()
        {
            ResultReport.AddTestStepDetails("Verifying tooltip text of RCP Tab");

            Actions action = new Actions(WebDriver);
            action.ClickAndHold(rcpPage.relevanceControlTab).Build().Perform();

            //Get the tool tip text of RCP tab
            string rcpTabToolTipText = rcpPage.toolTipOfRCPtab.Text;
            Assert.AreEqual("Relevance Control Panel", rcpTabToolTipText);
            action.MoveToElement(rcpPage.relevanceControlTab).Release(rcpPage.relevanceControlTab).Perform();

            ResultReport.AddTestStepDetails("Verifying tooltip text of RCP edit box");

            rcpPage.relevanceControlTab.Click();

            CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver,By.Id("QueryString"),60);

            //Get the tooltip text of RCP box
            action = new Actions(WebDriver);
            action.ClickAndHold(rcpPage.toolTipControlOfRCPbox).Build().Perform();

            string rcpBoxTooltipText = rcpPage.toolTipOfRCPbox.Text;
            Assert.IsTrue(rcpBoxTooltipText.Contains("Adjust and save your personal relevance profile."), "RCP tooltip not displayed as expected");
            action.MoveToElement(rcpPage.toolTipControlOfRCPbox).Release(rcpPage.toolTipControlOfRCPbox).Perform();
        }

        public List<string> GetBoostFieldElementValues()
        {
            List<string> dropdownValue = new List<string>();
          

            IDictionary<string, string> boostFields = new Dictionary<string, string>();
            for (int value = 0; value < BoostFieldNames.Count; value++)
            {
                // boostFields.Add(BoostFieldNames[value].Text, BoostFieldValues[value].Text);
            }
            foreach (var item in BoostFieldNames)
            {
                SelectElement ele = new SelectElement(item);
                dropdownValue.Add(ele.SelectedOption.Text);
            }
            return dropdownValue;
        }

        public List<string> GetToolTipValues()

        {
            List<string> defaulToolTipValue = new List<string>();
            Actions action = new Actions(WebDriver);
            int i = 0;
            var count = rcpPage.lstSlider.Count;
            foreach (var item in rcpPage.lstSlider)
            {
                action.MoveToElement(item).Build().Perform();
                defaulToolTipValue.Add(rcpPage.BoostFieldValues[i].Text);
                action.Release();
                i++;
                
            }
            
			return defaulToolTipValue;
	    }
 
       public static string generateRandomString(int stringLength)
        {
            string allowedChars = "23456789";
            var rSeed = new Random();
            char[] newChars = new char[stringLength];

            for (int i = 0; i < stringLength; i++)
            {
                newChars[i] = allowedChars[rSeed.Next(allowedChars.Length)];
            }
            String randString = new String(newChars);
            return randString;
        }

        string randomString = generateRandomString(1);
        public List<string> DragSlider()

        {
            List<string> tooltipAfterSlide = new List<string>();
            Actions action = new Actions(WebDriver);
            int i = 0;
            foreach (var item in rcpPage.lstSlider)
            {
                action.DragAndDropToOffset(item,Convert.ToInt32(randomString),0).Build().Perform();
                tooltipAfterSlide.Add(rcpPage.BoostFieldValues[i].Text);
                action.Release();
                i++;

            }

            return tooltipAfterSlide;
        }

        public   void ClickCombo()
	    {
			BoostFieldNames[0].Click();

		}

	    public void Navigate()
	    {
		 WebDriver.Navigate().GoToUrl("");   
	    }
        #endregion


    }
}
