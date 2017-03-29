using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NunitExample
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Class1
    {
        [TestFixtureSetUp]
        public void Start()
        {
            Console.WriteLine("Fixture Setup");
        }
        [Test]
        [Category("Smoke"),Order(1)]
        public void TC1_TestMethod()
        {
            IWebDriver driver = new ChromeDriver();
            Thread.Sleep(5000);
            Console.WriteLine("Test case 1");
            driver.Navigate().GoToUrl("http://www.google.com");
        }

        [Test]
        [Category("Smoke"),Order(2)]
        public void TC2_TestMethod()
        {
             IWebDriver driver = new ChromeDriver();
            Thread.Sleep(5000);
            Console.WriteLine("Test case 2");
            driver.Navigate().GoToUrl("http://www.linkedin.com");
        }

        [TestFixtureTearDown]
        public void Close()
        {
            Console.WriteLine("Fixture Tear down");
        }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Test Setup");
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("Test Teardown");
        }
    }
}
