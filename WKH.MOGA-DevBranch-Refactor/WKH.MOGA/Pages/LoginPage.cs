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
    public class LoginPage : UIObjects
    {
        public static LoginPage loginPage;

        public LoginPage()
        {
            PageFactory.InitElements(WebDriver, this);
            loginPage = this;
        }

        #region Login page controls
        
        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement userNameInput;

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement passwordInput = null;

        [FindsBy(How = How.CssSelector, Using = ".wk-button-primary.wk-button-full")]        
        public IWebElement loginButton = null;

        [FindsBy(How = How.ClassName, Using = "error-new")]
        public IWebElement loginErrorDiv = null;

        [FindsBy(How = How.LinkText, Using = "Log out")]
        public IWebElement logoutLink;

        [FindsBy(How = How.LinkText, Using = "Afmelden")]
        public IWebElement logoutDutchLink;

        [FindsBy(How = How.LinkText, Using = "Log out")]
        public IList<IWebElement> logoutLinkColl;

        [FindsBy(How = How.ClassName, Using = "field-validation-error")]
        public IList<IWebElement> fieldValidationErrors;

        [FindsBy(How = How.LinkText, Using = "Forgot password?")]
        public IWebElement forgotPasswordLink;

        [FindsBy(How = How.Name, Using = "EmailId")]
        public IWebElement eMailEditBox;

        [FindsBy(How = How.ClassName, Using = "wk-button-success")]
        public IWebElement resetPasswordButton;
                
        [FindsBy(How = How.ClassName, Using = "forgotpass")]
        public IList<IWebElement> forgotPwdTextElementsList;

        [FindsBy(How = How.ClassName, Using = "field-validation-error")]
        public IList<IWebElement> fieldValidnErrMsgEleList;

        [FindsBy(How = How.TagName, Using = "P")]
        public IList<IWebElement> elementsWithTagNameP;

        #endregion

        #region Login page Methods

        //Login to Application by passing parameters "user name" and "Password"
        public static void LoginToMOGA(string username, string pwd)
        {
            loginPage = new LoginPage();
            ResultReport.AddTestStepDetails("Login to MOGA");

            if (loginPage.logoutLinkColl.Count > 0)
            {
                loginPage.logoutLink.Click();
            }
            loginPage.userNameInput.SendKeys(username);
            loginPage.passwordInput.SendKeys(pwd);
            loginPage.loginButton.Click();
        }

        //Login page validation for UnAthorized / InValid users
        public static void LoginToMOGAWithInvalidUserCredentials(string username, string pwd)
        {
            loginPage = new LoginPage();
            ResultReport.AddTestStepDetails("Login to MOGA with InValid user credentials");
            
            loginPage.userNameInput.SendKeys(username);
            loginPage.passwordInput.SendKeys(pwd);
            loginPage.loginButton.Click();

            Assert.IsFalse(UIObjects.WebElements("LinkText=Log out").Count > 1, "InValid/UnAuthorized user is able to login to MOGA");

        }

        //Login page validation for UnAthorized / InValid users
        public static void WarningMessagesVerificationForInvalidUsers(string username, string pwd)
        {
            loginPage = new LoginPage();
            ResultReport.AddTestStepDetails("Login to MOGA with InValid user credentials");

            loginPage.userNameInput.SendKeys(username);
            loginPage.passwordInput.SendKeys(pwd);
            loginPage.loginButton.Click();
            Assert.IsTrue(UIObjects.WebElement("ClassName=field-validation-error").Text.Contains("The username / password you entered is invalid. Please try again"), "Warning message not displayed for InValid/Un Authorized user");

            loginPage.userNameInput.Clear();
            loginPage.userNameInput.SendKeys("");
            loginPage.passwordInput.Clear();
            loginPage.passwordInput.SendKeys(pwd);
            loginPage.loginButton.Click();
            Assert.IsTrue(UIObjects.WebElement("ClassName=field-validation-error").Text.Contains("Username is required and should be an email."), "Warning message not displayed for empty user name");

            loginPage.userNameInput.Clear();
            loginPage.userNameInput.SendKeys(username);
            loginPage.passwordInput.Clear();
            loginPage.passwordInput.SendKeys("");
            loginPage.loginButton.Click();
            bool flagError = false;
            if (loginPage.fieldValidationErrors.Count > 0)
            {
                foreach ( IWebElement ele in loginPage.fieldValidationErrors)
                {
                    if (ele.Text.ToLower().Contains("password cannot be blank")) flagError =true;
                }
            }
            Assert.IsTrue(flagError, "Warning message not displayed for empty password");

            loginPage.userNameInput.Clear();
            loginPage.userNameInput.SendKeys("");
            loginPage.passwordInput.Clear();
            loginPage.passwordInput.SendKeys("");
            loginPage.loginButton.Click();

            flagError = false;
            if (loginPage.fieldValidationErrors.Count > 0)
            {
                foreach (IWebElement ele in loginPage.fieldValidationErrors)
                {
                    if (ele.Text.ToLower().Contains("username is required and should be an email"))
                    {
                        flagError = true;
                        break;
                    }
                }
            }
            Assert.IsTrue(flagError, "Warning message not displayed for empty username/password"); 
        }

        //Logout from MOGA
        public static void LogoutFromMOGA()
        {
            loginPage = new LoginPage();
            ResultReport.AddTestStepDetails("Logout from MOGA");
            
            loginPage.logoutLink.Click();
            CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver,By.LinkText("Log out"));

        }

        //Logout from MOGA Dutch application
        public static void LogoutFromMOGADutch()
        {
            loginPage = new LoginPage();
            ResultReport.AddTestStepDetails("Logout from MOGA");

            loginPage.logoutDutchLink.Click();
        }

        //Reset Password
        public static void ResetPasswordOfUser()
        {
            loginPage = new LoginPage();

            ResultReport.AddTestStepDetails("Reset password");

            loginPage.forgotPasswordLink.Click();
            CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver,By.ClassName("wk-button-success"));

            //Verifying Text on Forgot password page
            Assert.IsTrue(CommonMethods.FindElementInList(loginPage.forgotPwdTextElementsList, "To receive your password, please enter the email address you have registered with Ovid Labs. We will email you a link to a page where you can create a new password. If you do not receive an email, please check your spam mail folder or contact Customer Support.").Displayed, "Expected text not displayed on reset password Page");

            Assert.IsTrue(CommonMethods.FindElementInList(loginPage.forgotPwdTextElementsList, "Email Address").Displayed,"Expected 'Email address' label not displayed");

            loginPage.eMailEditBox.SendKeys("ovidqa.automation@wolterskluwer.com");

            loginPage.resetPasswordButton.Click();

            Assert.IsTrue(CommonMethods.FindElementInList(loginPage.elementsWithTagNameP, "Reset Password is successful. An email with reset password link is sent to you").Displayed, "Reset password failed,please check");
            
        }

        //Reset Password
        public static void ResetPasswordErrorMessagesValidation()
        {
            loginPage = new LoginPage();

            ResultReport.AddTestStepDetails("Forgot password validation messages verification");
            loginPage.forgotPasswordLink.Click();
            CommonFixtures.WaitTillAllElementDisplayed(UIObjects.WebDriver,By.ClassName("wk-button-success"));

            //Verifying for Empty field
            loginPage.resetPasswordButton.Click();
            Assert.IsTrue(CommonMethods.FindElementInList(loginPage.fieldValidnErrMsgEleList, "Email address is required").Displayed, "Expected validation message not displayed");
            
            //Verifying for Invalid Email
            loginPage.eMailEditBox.SendKeys("wolterskluwer.com");
            loginPage.resetPasswordButton.Click();
            Assert.IsTrue(CommonMethods.FindElementInList(loginPage.fieldValidnErrMsgEleList, "Invalid Email Address").Displayed, "Expected validation message not displayed");
            
        }

        #endregion

    }
}
