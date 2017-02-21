using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using WKH.GlobalIdentifiers;
using System.Collections.Concurrent;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;

/// <summary>
/// Core of UI Automation Framework
/// </summary>
namespace WKH.SeleniumFrameWork
{
    /// <summary>
    /// Provides WebDriver entity and methods use it, for example context switching,
    /// test application launching, screenshots making, etc.
    /// </summary>
    public class UIObjects
    {
        /// <summary>
        /// Map of test configs with WebDrivers</summary>
        static ConcurrentDictionary<Constants.TestInstance, IWebDriver> InstanceMap =
            new ConcurrentDictionary<Constants.TestInstance, IWebDriver>();

        /// <summary>
        /// Main instance of WebDriver. All other classes use this object from here</summary>
        public static IWebDriver WebDriver = null;
        /// <summary>
        /// Empty locator for web elements searching</summary>
        public static By by;
        /// <summary>
        /// Wrapper for WebElement</summary>
        public static IWebElement PageObject;
        /// <summary>
        /// Wrapper for list of web elements</summary>
        public static ReadOnlyCollection<IWebElement> PageObjectCollection;
        /// <summary>
        /// Reference to default application window</summary>
        public static string parentWIndow = null;


        /// <summary>
        /// Change default implicity WebDriver timeout
        /// </summary>
        /// <param name="seconds">Timeout in seconds</param>
        public static void SetWebDriverImplicityTimeout(int seconds)
        {
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }


        /// <summary>
        /// Switch WebDriver to required frame with explicit waiting
        /// </summary>
        /// <param name="frameElement">WebElement represents frame</param>
        protected static void SwitchToFrameContextSafely(IWebElement frameElement)
        {
            WebDriver = Waiters.DefaultWait.Until(d => WebDriver.SwitchTo().Frame(frameElement));
        }


        /// <summary>
        /// Switch WebDriver to required frame by its name with explicit waiting
        /// </summary>
        /// <param name="frameName">Name of frame</param>
        protected static void SwitchToFrameContextSafely(string frameName)
        {
            WebDriver = Waiters.DefaultWait.Until(d => WebDriver.SwitchTo().Frame(frameName));
        }


        /// <summary>
        /// Switch WebDriver context to window with required title
        /// </summary>
        /// <param name="windowTitle">Title of window to switching</param>
        public static void SwitchToWindowByTitle(string windowTitle)
        {
            var windowHandles = WebDriver.WindowHandles;
            foreach (var handle in windowHandles)
            {
                WebDriver = WebDriver.SwitchTo().Window(handle);
                if (WebDriver.Title.Trim().Equals(windowTitle.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }
            throw new NoSuchWindowException(windowTitle);
        }


        /// <summary>
        /// Switch WebDriver to default context
        /// </summary>
        public static void LeaveContext()
        {
            WebDriver.SwitchTo().DefaultContent();
        }


        /// <summary>
        /// Returns instance of WebDriver depends on test config
        /// </summary>
        /// <param name="instance">Test config should be used</param>
        /// <returns>WebDriver according to config</returns>
        public static IWebDriver GetDriver(Constants.TestInstance instance)
        {
            return InstanceMap[instance];
        }


        /// <summary>
        /// Initiate WebBrowser with required browser and navigate it to url
        /// </summary>
        /// <param name="brwBrowser">Name of browser to start, for example Firefox</param>
        /// <param name="url">URL to navigate browser right after start</param>
        public static void LaunchApplication(string brwBrowser, string url)
        {
            WebDriver = null;
            string driversPath = CommonMethods.PathToDrivers();

            switch (brwBrowser)
            {
                case "FireFox":

                    WebDriver = new FirefoxDriver();
                    WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    WebDriver.Navigate().GoToUrl(url);
                    break;

                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("no-sandbox"); //Added for Jenkins testing
                    options.AddArguments("--start-maximized");
                    WebDriver = new ChromeDriver(driversPath, options);
                    WebDriver.Navigate().GoToUrl(url);
                    break;

                case "IExplore":
                case "IE":
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    ieOptions.IgnoreZoomLevel = true;
                    ieOptions.EnsureCleanSession = true;
                    ieOptions.EnableNativeEvents = false;
                    WebDriver = new InternetExplorerDriver(driversPath, ieOptions);
                    WebDriver.Navigate().GoToUrl(url);
                    break;

                default:
                    Console.WriteLine("Wrong Browser name, please verify");
                    break;
            }
        }


        /// <summary>
        /// Initiate WebBrowser with required browser and test config. Navigate it to url after start
        /// </summary>
        /// <param name="brwBrowser">Name of browser to start, for example Firefox</param>
        /// <param name="url">URL to navigate browser right after start</param>
        /// <param name="instance">Test config should be used, for example Gamma</param>
        public static void LaunchApplication(string brwBrowser, string url, Constants.TestInstance instance)
        {
            IWebDriver _WebDriver = null;
            string driversPath = CommonMethods.PathToDrivers();

            switch (brwBrowser)
            {
                case "FireFox":
                    _WebDriver = new FirefoxDriver();
                    _WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    _WebDriver.Navigate().GoToUrl(url);
                    break;

                case "Chrome":

                    _WebDriver = new ChromeDriver(driversPath);
                    _WebDriver.Navigate().GoToUrl(url);
                    break;

                case "IExplore":
                case "IE":
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    ieOptions.IgnoreZoomLevel = true;
                    ieOptions.EnableNativeEvents = false;
                    _WebDriver = new InternetExplorerDriver(driversPath, ieOptions);
                    _WebDriver.Navigate().GoToUrl(url);
                    _WebDriver.Manage().Window.Maximize();
                    break;

                default:
                    Console.WriteLine("Wrong Browser name, please verify");
                    break;
            }
            InstanceMap.AddOrUpdate(instance, _WebDriver, (key, oldValue) => _WebDriver);
        }


        /// <summary>
        /// Initiate WebBrowser on remote server with required OS. Navigate it to url after start
        /// </summary>
        /// <param name="remoteService">Name of remote server should be used</param>
        /// <param name="url">URL to navigate browser right after start</param>
        /// <param name="entity">Remote server OS type</param>
        public static void LaunchApplication(string remoteService, string url, RemoteEnvConfigEntity entity)
        {
            string driversPath = CommonMethods.PathToDrivers();
            DesiredCapabilities capability = new DesiredCapabilities();

            switch (remoteService)
            {
                case "SauceLabs":
                    capability.SetCapability("browser", entity.Browser);
                    capability.SetCapability("platform", entity.OS);
                    capability.SetCapability("username", entity.User);
                    capability.SetCapability("accessKey", entity.Key);
                    capability.SetCapability("jobId", entity.TestId);

                    WebDriver = new RemoteWebDriver(
                        new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capability
                    );

                    WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    WebDriver.Navigate().GoToUrl(url);
                    WebDriver.Manage().Window.Maximize();
                    break;

                case "Browserstack":
                    capability.SetCapability("browser", entity.Browser);
                    capability.SetCapability("os", entity.OS);
                    capability.SetCapability("os_version", entity.OSVersion);
                    capability.SetCapability("browserstack.user", entity.User);
                    capability.SetCapability("browserstack.key", entity.Key);
                    capability.SetCapability("name", entity.TestId);


                    WebDriver = new RemoteWebDriver(
                        new Uri("http://hub.browserstack.com/wd/hub/"), capability
                    );

                    WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    WebDriver.Navigate().GoToUrl(url);
                    WebDriver.Manage().Window.Maximize();
                    break;

                default:
                    Console.WriteLine("Invalid Remote virtual service");
                    break;
            }
        }


        /// <summary>
        /// Initiate WebBrowser on remote server with required OS and test config. Navigate it to url after start
        /// </summary>
        /// <param name="remoteService">Name of remote server should be used</param>
        /// <param name="url">URL to navigate browser right after start</param>
        /// <param name="entity">Remote server OS type</param>
        /// <param name="instance">Test config should be used, for example Gamma</param>
        public static void LaunchApplication(string remoteService, string url, RemoteEnvConfigEntity entity,
            WKH.GlobalIdentifiers.Constants.TestInstance instance)
        {
            IWebDriver _WebDriver = null;
            string driversPath = CommonMethods.PathToDrivers();
            DesiredCapabilities capability = new DesiredCapabilities();

            switch (remoteService)
            {
                case "SauceLabs":
                    capability = DesiredCapabilities.Firefox();
                    capability.SetCapability("platform", "Windows 7");
                    capability.SetCapability("username", "WK-DavidS");
                    capability.SetCapability("accessKey", "054c1638-ce0a-4464-bbc8-a6dd0e7a44a2");

                    _WebDriver = new RemoteWebDriver(
                        new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capability
                    );

                    _WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    _WebDriver.Navigate().GoToUrl(url);
                    _WebDriver.Manage().Window.Maximize();
                    break;

                case "Browserstack":
                    capability.SetCapability("browser", entity.Browser);
                    capability.SetCapability("os", entity.OS);
                    capability.SetCapability("os_version", entity.OSVersion);
                    capability.SetCapability("browserstack.user", entity.User);
                    capability.SetCapability("browserstack.key", entity.Key);
                    capability.SetCapability("browserstack.video", "false");

                    _WebDriver = new RemoteWebDriver(
                        new Uri("http://hub.browserstack.com/wd/hub/"), capability
                    );
                    _WebDriver.Navigate().GoToUrl(url);
                    _WebDriver.Manage().Window.Maximize();
                    break;

                default:
                    Console.WriteLine("Invalid Remote virtual service");
                    break;
            }
            InstanceMap.AddOrUpdate(instance, _WebDriver, (key, oldValue) => _WebDriver);
        }


        /// <summary>
        /// Search WebElement by its properties 
        /// </summary>
        /// <param name="props">Properties to find element</param>
        /// <returns>Founded element</returns>
        public static IWebElement WebElement(string props)
        {
            string[] objProp = props.Split(new[] { "=" }, 2, StringSplitOptions.None);

            Type ClassName = typeof(By);
            MethodInfo MethodName = ClassName.GetMethod(objProp[0]);
            By objProperty = (By)MethodName.Invoke(@by, new object[] { objProp[1] });

            Type objType = WebDriver.GetType();
            MethodInfo objMethod = objType.GetMethod("FindElement");
            PageObject = (IWebElement)objMethod.Invoke(WebDriver, new object[] { objProperty });
            return PageObject;
        }


        /// <summary>
        /// This method is used to Take collection of webelements
        /// We need to pass the parameters of the element, we will be using to take collection of elements
        /// </summary>
        /// <param name="props">Properties to find element</param>
        /// <returns>Collection of WebElements</returns>
        public static ReadOnlyCollection<IWebElement> WebElements(string props)
        {
            string[] objProp = props.Split(new[] { "=" }, 2, StringSplitOptions.None);

            Type ClassName = typeof(By);
            MethodInfo MethodName = ClassName.GetMethod(objProp[0]);
            By objProperty = (By)MethodName.Invoke(@by, new object[] { objProp[1] });

            Type objType = WebDriver.GetType();
            MethodInfo objMethod = objType.GetMethod("FindElements");
            PageObjectCollection =
                (ReadOnlyCollection<IWebElement>)objMethod.Invoke(WebDriver, new object[] { objProperty });
            return PageObjectCollection;
        }


        /// <summary>
        /// Close browser and destruct WebDriver
        /// </summary>
        public static void CloseApp()
        {
            WebDriver.Quit();
        }


        /// <summary>
        /// Switch WebDriver context to any child window
        /// </summary>
        public static void SwitchToChildWindow()
        {
            try
            {
                parentWIndow = WebDriver.CurrentWindowHandle;
                string childWindow = null;
                var windowHandles = WebDriver.WindowHandles;
                List<string> windows = new List<string>(windowHandles);
                Console.WriteLine("window count: " + windows.Count);
                foreach (string window in windows)
                {
                    if (window != parentWIndow)
                    {
                        childWindow = window;
                    }
                }
                WebDriver.SwitchTo().Window(childWindow);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Switch the window after clicking on button
        /// </summary>
        /// <param name="driver">WebDriver which should be switched</param>
        /// <param name="urlstring">URL of window to switch</param>
        /// <param name="btnId">Id of button element for click</param>
        public static void SwitchWindow(IWebDriver driver, string urlstring, string btnId)
        {
            string basewindow = driver.CurrentWindowHandle;
            driver.FindElement(By.Id(btnId)).Click();
            ReadOnlyCollection<string> newwindow = driver.WindowHandles;

            foreach (string handle in newwindow)
            {
                if (handle != basewindow)
                {
                    driver.SwitchTo().Window(handle).Url.Contains(urlstring);
                }
            }
        }


        /// <summary>
        /// Switch the WebDriver context to window with required URL
        /// </summary>
        /// <param name="driver">WebDriver which should be switched</param>
        /// <param name="urlstring">URL of window to switch</param>
        public static void SwitchWindow(IWebDriver driver, string urlstring)
        {
            string basewindow = driver.CurrentWindowHandle;
            ReadOnlyCollection<string> newwindow = driver.WindowHandles;

            foreach (string handle in newwindow)
            {
                if (handle != basewindow)
                {
                    driver.SwitchTo().Window(handle).Url.Contains(urlstring);
                }
            }
        }


        /// <summary>
        /// Switch context to original/previous window
        /// </summary>
        /// <param name="driver">WebDriver which should be switched</param>
        /// <param name="prevWindowHandle">Handle of window to switch</param>
        public static void SwitchToPreviousWindow(IWebDriver driver, string prevWindowHandle)
        {
            string basewindow = prevWindowHandle;
            driver.SwitchTo().Window(basewindow);
        }


        /// <summary>
        /// Switch context to main window
        /// </summary>
        public static void SwitchToParentWindow()
        {
            try
            {
                WebDriver.SwitchTo().Window(parentWIndow);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Check if any alert existing
        /// </summary>
        /// <returns>True if existing, and False in vice versa</returns>
        public static bool GetAlertPresence()
        {
            IAlert alert = ExpectedConditions.AlertIsPresent().Invoke(WebDriver);
            return (alert != null);
        }


        /// <summary>
        /// Return message from existing alert
        /// </summary>
        /// <returns>Message from alert</returns>
        public static string GetAlertText()
        {
            IAlert alert = WebDriver.SwitchTo().Alert();
            return alert.Text;
        }


        /// <summary>
        /// Take a Screen shot when needed
        /// </summary>
        /// <param name="driver">WebDriver instance</param>
        /// <param name="saveLocation">Full path to save image</param>
        public void TakeScreenshot(IWebDriver driver, string saveLocation)
        {
            try
            {
                ITakesScreenshot ssdriver = driver as ITakesScreenshot;
                driver.Manage().Window.Maximize();
                Screenshot screenshot = ssdriver.GetScreenshot();
                screenshot.SaveAsFile(saveLocation, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
