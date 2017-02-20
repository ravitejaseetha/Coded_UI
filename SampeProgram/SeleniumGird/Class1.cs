using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumGrid
{
    [Parallelizable]
    [TestFixture]
    public class GridTest1
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;


        [SetUp]
        public void SetupTest()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            capabilities = DesiredCapabilities.Firefox();
            capabilities.SetCapability(CapabilityType.BrowserName, "Chrome");
          // capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
           capabilities.SetCapability("platform", "Windows 7");
            capabilities.SetCapability(CapabilityType.Version, "46.0");
            // capabilities.SetCapability("version", 35);
            capabilities.SetCapability("username", "ravitejaseetha");
            capabilities.SetCapability("accessKey", "f5f0beae-2bb3-40f5-9ace-58084188497f");
            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), capabilities);
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
        public void GoogleTestAj()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
          //  driver.FindElement(By.Id("sb_ifc0")).Clear();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("lst-ib")).SendKeys("Testing");
          //  driver.FindElement(By.Id("gbqfb")).Click();
            Thread.Sleep(10000);
        }
    }
}
