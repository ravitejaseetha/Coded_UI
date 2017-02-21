using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
using Microsoft.Office.Interop.Word;
using System.Configuration;

/// <summary>
/// Core of UI Automation Framework
/// </summary>
namespace WKH.SeleniumFrameWork
{
    /// <summary>
    /// Provides most usefull methods for interacting with WebElements
    /// </summary>
    public class CommonMethods : UIObjects
    {
        /// <summary>
        /// Writes markup characters and text to an ASP.NET server control output stream</summary>
        public static HtmlTextWriter writer;

        /// <summary>
        /// Implements a TextWriter for writing information to a string</summary>
        public static StringWriter stringWriter = new StringWriter();


        /// <summary>
        /// This method is used to capture the Path of Selenium drivers from the framework Project
        /// </summary>
        /// <returns>Path to driver from config</returns>
        public static string PathToDrivers()
        {
            string driverPath = Environment.CurrentDirectory;
            driverPath = ConfigurationManager.AppSettings["DriverPath"].ToString();

            return driverPath;
        }


        /// <summary>
        /// This method is used to capture the Path of framework Project
        /// </summary>
        /// <returns>Path to framework</returns>
        public static string PathToFrameworkProject()
        {
            string frameworkPath = Environment.CurrentDirectory;
            if (frameworkPath.Contains("QTAgent"))
            {
                frameworkPath = "C:\\SeleniumReport\\";
            }
            else
            {
                string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;
                FileInfo info = new FileInfo(projectPath);
                DirectoryInfo ParentDir = info.Directory;
                frameworkPath = ParentDir.Parent.FullName + "\\WKH.SeleniumFrameWork\\WKH.SeleniumFrameWork\\";
              
                //Added by vijay for R&D on May9th,2016
                if (frameworkPath.Contains("\\bin"))
                {
                    frameworkPath = "C:\\SeleniumReport\\";
                }

            }
            return frameworkPath;            
        }


        /// <summary>
        /// This method is returns the Path of current Test Project
        /// </summary>
        /// <param name="product">Folder name of required product</param>
        /// <returns>Path to report</returns>
        public static string PathForReport(String product)
        {
            string prjPath = "C:\\SeleniumReport\\" + product + "\\";

            if (!(Directory.Exists(prjPath)))
                Directory.CreateDirectory(prjPath);
          
            return prjPath;
        }


        /// <summary>
        /// Getting Test data path
        /// </summary>
        /// <returns>Path to test data</returns>
        public static string PathToTestData()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\TestData\\";
        }


        /// <summary>
        /// Find web element and covers it to SelectElement wrapper
        /// </summary>
        /// <param name="driver">WebDriver which should be used to locate element</param>
        /// <param name="elementLocator">Locator to element which should be covered</param>
        /// <returns>Covered to SelectElement web element</returns>
        private static SelectElement GetDropdownList(IWebDriver driver, By elementLocator)
        {
            IWebElement dropdown = driver.FindElement(elementLocator);
            return new SelectElement(dropdown);
        }


        /// <summary>
        /// Selecting dropdown using item index
        /// </summary>
        /// <param name="driver">WebDriver which should be used to locate element</param>
        /// <param name="elementLocator">Locator to dropdown element</param>
        /// <param name="itemNumber">Number of item to select</param>
        public static void SelectDropdownListByItemNo(IWebDriver driver, By elementLocator, int itemNumber)
        {
            GetDropdownList(WebDriver, elementLocator).SelectByIndex(itemNumber);
        }


        /// <summary>
        /// Selecting dropdown using text
        /// </summary>
        /// <param name="driver">WebDriver which should be used to locate element</param>
        /// <param name="elementLocator">Locator to dropdown element</param>
        /// <param name="itemText">Text to select from dropdown element</param>
        public static void SelectDropdownListByText(IWebDriver driver, By elementLocator, string itemText)
        {
            GetDropdownList(driver, elementLocator).SelectByText(itemText);
        }


        /// <summary>
        /// Selecting dropdown using value
        /// </summary>
        /// <param name="driver">WebDriver which should be used to locate element</param>
        /// <param name="elementLocator">Locator to dropdown element</param>
        /// <param name="itemValue">Value to select from dropdown element</param>
        public static void SelectDropdownListByValue(IWebDriver driver, By elementLocator, string itemValue)
        {
            GetDropdownList(driver, elementLocator).SelectByText(itemValue);
        }


        /// <summary>
        /// To check the checkbox using strings "yes" and "no"
        /// </summary>
        /// <param name="driver">WebDriver which should be used to locate element</param>
        /// <param name="elementLocator">Locator to checkbox element</param>
        /// <param name="YesNo">Required state, "yes" for checked and "no" for unchecked checkbox</param>
        public static void SetCheckBoxState(IWebDriver driver, By elementLocator, string YesNo)
        {
            IWebElement chkbox = driver.FindElement(elementLocator);

            if (YesNo.ToLower().Equals("yes"))
            {
                if (!chkbox.Selected)
                {
                    chkbox.Click();
                }
            }
            else if (YesNo.ToLower().Equals("no"))
            {
                if (chkbox.Selected)
                {
                    chkbox.Click();
                }
            }
            else
            {
                throw new Exception(string.Format("ERROR: wrong parameter [{0}]", YesNo));
            }
        }


        /// <summary>
        /// To check the checkbox using boolean values
        /// </summary>
        /// <param name="driver">WebDriver which should be used to locate element</param>
        /// <param name="elementLocator">Locator to checkbox element</param>
        /// <param name="expectedState">Required state, True for checked and False for unchecked checkbox</param>
        public static void SetCheckBoxState(IWebDriver driver, By elementLocator, bool expectedState)
        {
            IWebElement checkBox = driver.FindElement(elementLocator);

            if (checkBox.Selected != expectedState)
            {
                checkBox.Click();
            }
        }


        /// <summary>
        /// Verify if Element presents
        /// </summary>
        /// <param name="driver">WebDriver which should be used to locate element</param>
        /// <param name="by">Locator to find element</param>
        /// <returns>True if element present and False in vice versa</returns>
        public static bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // 
        /// <summary>
        /// verify element is visible for use in PageFactory
        /// </summary>
        /// <param name="webElement">webElement to check Displayed attribute</param>

        public static bool isElementVisible(IWebElement webElement)
        {
            try
            {
                var myElement = webElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Move mouse pointer to required element
        /// </summary>
        /// <param name="webElement">WebElement which should be highlighted</param>
        public static void MouseHover(IWebElement webElement)
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(webElement).Perform();
        }


        /// <summary>
        /// Kill process with required name
        /// </summary>
        /// <param name="processName">Name of process</param>
        public static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }


        /// <summary>
        /// Click WebElement which is not visible on screen
        /// </summary>
        /// <param name="element">WebElement to click</param>
        public static void ClickElementUsingJavaScript(IWebElement element)
        {
            IJavaScriptExecutor ex = (IJavaScriptExecutor)WebDriver;
            ex.ExecuteScript("arguments[0].click();", element);
        }


        /// <summary>
        /// To get Text from the Text file
        /// </summary>
        /// <param name="strfilename">Full path to file</param>
        /// <returns>Text from file</returns>
        public static string GetTextFromTextFile(string strfilename)
        {
            return File.ReadAllText(strfilename);
        }


        /// <summary>
        /// To get Text from the MS Word file
        /// </summary>
        /// <param name="path">Full path to file</param>
        /// <returns>List of text lines from file</returns>
        public static List<string> GetTextFromMSWord(string path)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
            Document doc = new Document();

            object fileName = path;
            // Define an object to pass to the API for missing parameters
            object missing = System.Type.Missing;
            doc = word.Documents.Open(ref fileName, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

            String read = string.Empty;
            List<string> data = new List<string>();
            foreach (Microsoft.Office.Interop.Word.Range tmpRange in doc.StoryRanges)
            {
                data.Add(tmpRange.Text);
            }
            ((_Document)doc).Close();
            ((Microsoft.Office.Interop.Word._Application)word).Quit();

            return data;
        }


        /// <summary>
        /// Helper Method. Find an Element within an list and click it
        /// </summary>
        /// <param name="elementList">List of WebElements to find</param>
        /// <param name="text">Text of WebElement to click</param>
        /// <returns>True if success and False in vice versa</returns>
        public static bool FindElementAndClick(IList<IWebElement> elementList, string text)
        {
            IWebElement element = FindElementInList(elementList, text);
            if (null != element)
            {
                element.Click();
                return true;
            }
            return false;
        }


        /// <summary>
        /// Helper Method. Find an Element within an IList and return the IWebElement
        /// </summary>
        /// <param name="elementList">List of WebElements to find</param>
        /// <param name="text">Text of WebElement to return</param>
        /// <returns>Found WebElement from the list</returns>
        public static IWebElement FindElementInList(IList<IWebElement> elementList, string text)
        {
            IWebElement foundElement = null;
            foreach (var item in elementList)
            {
                if (item.Text.Contains(text))
                {
                    foundElement = item;
                    break;
                }
            }
            return foundElement;
        }


        /// <summary>
        /// Generate random alphabetical string
        /// </summary>
        /// <param name="length">Length of random string</param>
        /// <returns>Random string</returns>
        public static string GenerateRandomAlphaString(int length)
        {
            string characterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();

            string randomCode = new string(
            Enumerable.Repeat(characterSet, length)
                    .Select(set => set[random.Next(set.Length)])
                    .ToArray());
            return randomCode;
        }


        /// <summary>
        /// Returns URL which is currently opened in browser
        /// </summary>
        /// <returns>URL address</returns>
        public static Uri GetCurrentURL()
        {
            return new Uri(WebDriver.Url);
        }


        /// <summary>
        /// Navigate driver to required URL
        /// </summary>
        /// <param name="URL">New URL to navigate</param>
        public static void OpenURL(Uri URL)
        {
            WebDriver.Navigate().GoToUrl(URL);
        }


        /// <summary>
        /// Open previous page in browser
        /// </summary>
        /// <param name="count">How many pages should be reverted</param>
        public static void Back(int count = 1)
        {
            for (int index = 0; index < count; index++)
            {
                WebDriver.Navigate().Back();
            }
        }        

        [Obsolete("use WaitForElementDisplayed from Waiters class instead")]
        public static void WaitForElementPresent(IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(120));
                wait.Until(driver => element.Displayed);
                Console.WriteLine("Wait Passed");                
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Wait Failed");                
            }
        }

        [Obsolete("use WaitForElementEnabled from Waiters class instead")]
        public static void WaitForElementEnabled(IWebElement webElement)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(120));
                wait.Until(driver => webElement.Enabled);
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("Wait Failed due to: " + e.Message);
            }
        }

        [Obsolete("use SelectDropdownListByText instead")]
        public static void SelectDropdownlistByText(string dropdownID, string itemText)
        {
            IWebElement dropdown = WebDriver.FindElement(By.Id(dropdownID));
            SelectElement fpselect = new SelectElement(dropdown);
            fpselect.SelectByText(itemText);
        }

        [Obsolete("use SelectDropdownListByText instead")]
        public static void SelectDropdownlistByValue(string dropdownName, string itemValue)
        {
            IWebElement dropdown = WebDriver.FindElement(By.Name(dropdownName));
            SelectElement fpselect = new SelectElement(dropdown);
            fpselect.SelectByText(itemValue);
        }
    }
}
