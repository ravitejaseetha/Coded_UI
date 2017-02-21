using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WKH.SeleniumFrameWork;

namespace WKH.MOGA
{
    public class UserRegistrationPage : UIObjects
    {
        public static UserRegistrationPage userRegistrationPage;
        
        public UserRegistrationPage()
        {
            PageFactory.InitElements(WebDriver, this);
            userRegistrationPage = this;
        }

        //creating object of this class. Call this before accessing anyother method of this class
        public static void NavigateHere()
        {
            userRegistrationPage = new UserRegistrationPage();
        }

        #region Controls

        [FindsBy(How = How.CssSelector, Using = ".col-sm-10.text-left.text-justify")]
        public IWebElement agreementTextClass;

        #endregion

        #region Methods

        /// <summary>
        /// Verifies the Agreement text on User registration page
        /// </summary>
        public static void VerifyRegistrationPageAgreementText()
        {
            ResultReport.AddTestStepDetails("Verify Agreement text on Registration page");

            CommonFixtures.WaitTillAllElementDisplayed(WebDriver, By.CssSelector(".col-sm-10.text-left.text-justify"), 100);
            Assert.IsTrue(userRegistrationPage.agreementTextClass.Text.Contains("Thank you for participating in Ovid Labs and providing us with your valuable feedback! Your comments will be used internally at Wolters Kluwer for gauging the effectiveness of our solutions as well as guiding us in making improvements to our tools."), "Expected Agreement text not found");
            Assert.IsTrue(userRegistrationPage.agreementTextClass.Text.Contains("Look for the feedback link on every page. Please remember that the product is still under development and in early testing. Our current focus is on both the visual design and key search functionality such as “citation searching”. We will continue to make frequent updates to the interface and algorithms."), "Expected Agreement text not found");
            Assert.IsTrue(userRegistrationPage.agreementTextClass.Text.Trim().Contains("As this is a private invitation, we ask that you not share the site or your feedback with others at this time. Any comments you provide will only be shared within the project team. As always, your participation is greatly appreciated."), "Expected Agreement text not found");
            Assert.IsTrue(userRegistrationPage.agreementTextClass.Text.Trim().Contains("The Ovid Labs Team"), "Expected Agreement text not found");

        }

        #endregion

    }
}
