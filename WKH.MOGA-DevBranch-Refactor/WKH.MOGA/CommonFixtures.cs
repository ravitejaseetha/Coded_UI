using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using WKH.SeleniumFrameWork;

namespace WKH.MOGA
{
    public static class  CommonFixtures
    {
        /// <summary>
        /// Explicit wait for all elements to be displayed in page
        /// </summary>
        /// <param name="WebDriver">Parameter required for extend Selenium WebDriver</param>
        /// <param name="elementLocator">Locator to find required web element</param>
        /// <param name="timeout">How much time need to wait, 30 seconds by default</param>
        /// <param name="exceptionRequires">Should method generate exception if timeout elapsed, False by default</param>
        /// <returns>True if element disappeared and False in vice versa</returns> 
        public static bool WaitTillAllElementDisplayed(this IWebDriver WebDriver, By elementLocator, int timeout = Waiters.DefaultWaitTimeout,
                                                                                                        bool exceptionRequires = false)
        {
            MOGAConstants.log.InfoFormat( "Waiting for Presence of all Elements located by {0}",elementLocator.ToString());
            var wait = Waiters.DefaultWait;
            bool output = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(elementLocator)) != null ? true : false;

            return CheckForException(output, exceptionRequires, "ERROR: elements were not displayed");
        }


        /// <summary>
        /// Explicit wait for all elements to be displayed in page
        /// </summary>
        /// <param name="WebDriver">Parameter required for extend Selenium WebDriver</param>
        /// <param name="elementLocator">Locator to find required web element</param>
        /// <param name="timeout">How much time need to wait, 30 seconds by default</param>
        /// <param name="exceptionRequires">Should method generate exception if timeout elapsed, False by default</param>
        /// <returns>True if element disappeared and False in vice versa</returns>
        public static bool WaitTillElementwithTextDisappeared(this IWebDriver WebDriver, By elementLocator,string ElementText, int timeout = Waiters.DefaultWaitTimeout,
                                                                                                        bool exceptionRequires = false)
        {
            MOGAConstants.log.InfoFormat("Waiting for Invisibility of all Elements located by {0} and text {1}", elementLocator.ToString(),ElementText);
            var wait = Waiters.DefaultWait;
            bool output = wait.Until(ExpectedConditions.InvisibilityOfElementWithText(elementLocator, ElementText));

            return CheckForException(output, exceptionRequires, "ERROR: elements were not displayed");
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
                MOGAConstants.log.InfoFormat("Exception {0}", errorMessage);

                throw new Exception(errorMessage);
            }

            return output;
        }


        /// <summary>
        /// Get Child of a Given Parent Webelement with given properties
        /// </summary>
        /// <param name="ParentObject">IWebelement to be searched under</param>
        /// <param name="props">Property Name  & value key pair separated by '='.</param>
        /// <returns></returns>
        public static IWebElement FindChildElementbyCriteria(IWebElement ParentObject, string LocatorName,string LocatorValue)
        {
            MOGAConstants.log.InfoFormat("ParentObject: {0},LocatorName:{1},LocatorValue:{2}", ParentObject.Text, LocatorName, LocatorValue);
            Type ClassName = typeof(By);
            MethodInfo MethodName = ClassName.GetMethod(LocatorName);
            By objProperty = (By)MethodName.Invoke(UIObjects.@by, new object[] { LocatorValue });
            Type objType = ParentObject.GetType();
            MethodInfo objMethod = objType.GetMethod("FindElement");
            UIObjects.PageObject = (IWebElement)objMethod.Invoke(ParentObject, new object[] { objProperty });
            return UIObjects.PageObject;
        }


        /// <summary>
        /// Get Childern of a Given Parent Webelement with given properties
        /// </summary>
        /// <param name="ParentObject">IWebelement to be searched under</param>
        /// <param name="props">Property Name  & value key pair separated by '='.</param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> FindChildElementsbyCriteria(IWebElement ParentObject, string LocatorName, string LocatorValue)
        {
            MOGAConstants.log.InfoFormat("ParentObject: {0},LocatorName:{1},LocatorValue:{2}", ParentObject.Text, LocatorName, LocatorValue);

            Type ClassName = typeof(By);
            MethodInfo MethodName = ClassName.GetMethod(LocatorName);
            By objProperty = (By)MethodName.Invoke(UIObjects.@by, new object[] { LocatorValue });

            Type objType = ParentObject.GetType();
            MethodInfo objMethod = objType.GetMethod("FindElements");
            UIObjects.PageObjectCollection =
                (ReadOnlyCollection<IWebElement>)objMethod.Invoke(ParentObject, new object[] { objProperty });
            return UIObjects.PageObjectCollection;
        }

        /// <summary>
        /// Verify whether given Webelement property value matching with expected value
        /// </summary>
        /// <param name="WebObject">IWebelement having Properties</param>
        /// <param name="PropertyName">Property Name to get.</param>
        /// <param name="ValueToCheck">Value to compare with Property Value.</param>
        /// <param name="ComparisionType">Comparision Operator.</param>
        /// <returns></returns>
        public static bool CheckPropertyValue(IWebElement WebObject, string PropertyName, string ValueToCheck, string ComparisionType = "=")
        {
            MOGAConstants.log.InfoFormat("WebElement: {0},PropertyName:{1},ValueToCheck:{2},ComparisionType{3}", WebObject.Text, PropertyName, ValueToCheck, ComparisionType);

            PropertyInfo propInfo = WebObject.GetType().GetProperty(PropertyName);
            if (propInfo != null)
            {
                object value = propInfo.GetValue(WebObject, null);               
                if (value != null)
                {
                    string propertyValue = value.ToString();
                    switch (ComparisionType.ToLower())
                    {
                        case "=":
                            if (propertyValue == ValueToCheck)
                                return true;
                            break;
                        case "contains":
                            if (propertyValue.ToLower().Contains(ValueToCheck.ToLower()))
                                return true;
                            break;
                        case ">":
                            if (int.Parse(propertyValue) > int.Parse(ValueToCheck))
                                return true;
                            break;
                        case ">=":
                            if (int.Parse(propertyValue) > int.Parse(ValueToCheck))
                                return true;
                            break;
                        case "<":
                            if (int.Parse(propertyValue) > int.Parse(ValueToCheck))
                                return true;
                            break;
                        case "=<":
                            if (int.Parse(propertyValue) > int.Parse(ValueToCheck))
                                return true;
                            break;
                    }
                }

            }

            return false;
        }

        /// <summary>
        /// Close Current Window
        /// </summary>
        /// <param name="element">WebElement to click</param>
        public static void CloseCurrentWindow(IWebDriver WebDriver)
        {
            IJavaScriptExecutor ex = (IJavaScriptExecutor)WebDriver;
            ex.ExecuteScript("window.close();");
        }
    }
}
