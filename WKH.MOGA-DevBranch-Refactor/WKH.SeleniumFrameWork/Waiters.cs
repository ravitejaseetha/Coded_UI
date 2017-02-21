using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

/// <summary>
/// Core of UI Automation Framework
/// </summary>
namespace WKH.SeleniumFrameWork
{
    /// <summary>
    /// Class contains methods for waiting any event or condition
    /// </summary>
    public static class Waiters
    {
        /// <summary>
        /// Timeout is used by DefaultWait, 50 sec by default
        /// </summary>
        public const int DefaultWaitTimeout = 50;

        /// <summary>
        /// Default timeout for wait methods, could be changed during waiter using. 30 sec by default
        /// </summary>
        private const int TIMEOUT = 30;

        /// <summary>
        /// Property is used to create new waiters
        /// </summary>
        public static WebDriverWait DefaultWait
        {
            get
            {
                var wait = new WebDriverWait(UIObjects.WebDriver, TimeSpan.FromSeconds(DefaultWaitTimeout));
                //ignoring all exceptions
                wait.IgnoreExceptionTypes(typeof(Exception));
                return wait;
            }
        }


        /// <summary>
        /// Verifies if exception should be generated 
        /// </summary>
        /// <param name="output">Output of wait.Until method</param>
        /// <param name="exceptionRequires">Should method generate exception in case of False output</param>
        /// <param name="errorMessage">Message should be displayed in case of error</param>
        /// <returns>Ouput value if exception was not generated</returns>
        private static bool CheckForException(bool output, bool exceptionRequires, string errorMessage)
        {
            if (!output && exceptionRequires)
            {
                throw new Exception(errorMessage);
            }

            return output;
        }


        /// <summary>
        /// Explicit wait for element Enabled
        /// </summary>
        /// <param name="WebDriver">Parameter required for extend Selenium WebDriver</param>
        /// <param name="elementLocator">Locator to find required web element</param>
        /// <param name="timeoutInSeconds">How much time need to wait, 30 seconds by default</param>
        /// <param name="exceptionRequires">Should method generate exception if timeout elapsed, False by default</param>
        /// <returns>True if success, False in vice versa</returns>
        public static bool WaitForElementEnabled(this IWebDriver WebDriver, By elementLocator, int timeoutInSeconds = TIMEOUT,
                                                                                                            bool exceptionRequires = false)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            bool output = wait.Until(ExpectedConditions.ElementExists(elementLocator)) != null ? true : false;

            return CheckForException(output, exceptionRequires, "ERROR: element was not enabled");
        }


        /// <summary>
        /// Explicit wait for element Displayed
        /// </summary>
        /// <param name="WebDriver">Parameter required for extend Selenium WebDriver</param>
        /// <param name="elementLocator">Locator to find required web element</param>
        /// <param name="timeoutInSeconds">How much time need to wait, 30 seconds by default</param>
        /// <param name="exceptionRequires">Should method generate exception if timeout elapsed, False by default</param>
        /// <returns>True if element disappeared and False in vice versa</returns>
        public static bool WaitForElementDisplayed(this IWebDriver WebDriver, By elementLocator, int timeoutInSeconds = TIMEOUT,
                                                                                                            bool exceptionRequires = false)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
            bool output = wait.Until(ExpectedConditions.ElementIsVisible(elementLocator)) != null ? true : false;

            return CheckForException(output, exceptionRequires, "ERROR: element was not displayed");
        }


        /// <summary>
        /// Explicit wait for element disappeared from page
        /// </summary>
        /// <param name="WebDriver">Parameter required for extend Selenium WebDriver</param>
        /// <param name="elementLocator">Locator to find required web element</param>
        /// <param name="timeout">How much time need to wait, 30 seconds by default</param>
        /// <param name="exceptionRequires">Should method generate exception if timeout elapsed, False by default</param>
        /// <returns>True if element disappeared and False in vice versa</returns>
        public static bool WaitTillElementDisappeared(this IWebDriver WebDriver, By elementLocator, int timeout = TIMEOUT,
                                                                                                        bool exceptionRequires = false)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(timeout));
            bool output = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(elementLocator));

            return CheckForException(output, exceptionRequires, "ERROR: element was not disappeared");
        }


        /// <summary>
        /// Explicit wait for switch to window with required title completed
        /// </summary>
        /// <param name="WebDriver">Parameter required for extend Selenium WebDriver</param>
        /// <param name="windowTitle">Title of window to switch WebDriver</param>
        /// <param name="exceptionRequires">Should method generate exception if timeout elapsed, False by default</param>
        /// <returns>True if success, False in vice versa</returns>
        public static bool WaitSwitchToWindowByTitle(this IWebDriver WebDriver, string windowTitle, bool exceptionRequires = false)
        {
            bool output = false;

            output = DefaultWait.Until(d =>
            {
                UIObjects.SwitchToWindowByTitle(windowTitle);
                return true;
            });

            return CheckForException(output, exceptionRequires,
                                        string.Format("ERROR: web driver was not switched to window with title [{0}]", windowTitle));
        }


        /// <summary>
        /// Explicit wait for all child windows be closed. If timeout elapsed exception generates
        /// </summary>
        /// <param name="WebDriver">Parameter required for extend Selenium WebDriver</param>
        /// <param name="timeout">How much time need to wait, 30 seconds by default</param>
        /// <param name="exceptionRequires">Should method generate exception if timeout elapsed, True by default</param>
        /// <returns>True if all child windows closed and False in vice versa</returns>
        public static bool WaitTillChildWindowClosed(this IWebDriver WebDriver, int timeout = TIMEOUT, bool exceptionRequires = true)
        {
            UIObjects.SwitchToParentWindow();

            WebDriverWait wait = new WebDriverWait(UIObjects.WebDriver, TimeSpan.FromSeconds(timeout));
            bool result = wait.Until<bool>((d) =>
            {
                var windowHandles = WebDriver.WindowHandles;
                List<string> windows = new List<string>(windowHandles);

                foreach (string window in windows)
                {
                    if (window != UIObjects.parentWIndow)
                    {
                        return false;
                    }
                }

                return true;
            });

            return CheckForException(result, exceptionRequires, "ERROR: child window was not closed");
        }
    }
}
