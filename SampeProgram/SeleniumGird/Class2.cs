using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumGird
{
    [Parallelizable]
    [TestFixture]
    public class GridTest2
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;


        [SetUp]
        public void SetupTest()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();


            capabilities = DesiredCapabilities.Chrome();

            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            capabilities.SetCapability(CapabilityType.Version, "53.0");
            //capabilities.SetCapability("version",35);
            driver = new RemoteWebDriver(new Uri("http://172.16.107.127:5555/wd/hub"), capabilities);
            //driver = new FirefoxDriver();
            baseURL = "https://www.google.co.in/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            driver.Quit();
        }

        [Test]
        [Category("Grid")]
        public void GoogleTest1()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
         //   driver.FindElement(By.Id("sb_ifc0")).Clear();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@id='gbw']/div/div/div[1]/div[1]/a")).Click();
         //   driver.FindElement(By.Id("gbqfb")).Click();
            Thread.Sleep(10000);
        }
    }
}
