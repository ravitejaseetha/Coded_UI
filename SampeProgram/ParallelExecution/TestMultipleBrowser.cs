using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelExecution
{
    [TestFixture(typeof(FirefoxDriver))]
    //[TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [Parallelizable]
    [Category("Parallel New")]
    public class TestWithMultipleBrowsers<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver driver;
        IWebElement query;
        [TestFixtureSetUp]
        public void CreateDriver()
        {
            this.driver = new TWebDriver();
        }

        [Test]
        public void GoogleTest()
        {
            driver.Navigate().GoToUrl("http://www.google.com/");
            query = driver.FindElement(By.Name("q"));
            
            Thread.Sleep(10000);
            
            
        }
        [Test]
        public void Validate()
        {
            query.SendKeys("Bread" + Keys.Enter);
            Thread.Sleep(4000);
            Assert.AreEqual("Bread - Google Search", driver.Title);
        }

        [TestFixtureTearDown]
        public void Quit()
        {
            driver.Quit();
        }

    }
}
