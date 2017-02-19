using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.IO;
using OpenQA.Selenium.Chrome;

namespace SampleTwo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, Microsoft.VisualStudio.TestTools.UnitTesting.Description("http://www.google.com")]
   
        public void TestMethod2()
        {
            IWebDriver driver = new ChromeDriver(@"D:\Drivers");
            driver.Navigate().GoToUrl("http://www.google.com");

            var val = TestContext.TestResultsDirectory;
           // TestContext.AddResultFile(string.Format("\"{0}\"", @"d:\se.jpg"));
             Console.Write(string.Format("\"{0}\",", @"d:\se.jpg"));
            
            // Console.Write(string.Format("\"{0}\"", @"d:\screen.bmp"));
    
        }

        [TestMethod,TestCategory("smoke")]
        public void TestMethod3()
            {
            Console.WriteLine(string.Format("\"{0}\"", @"d:\images.jpg"));
            Assert.AreEqual("hello", "hello");
            
        }

        [TestMethod,TestCategory("smoke")]
        public void TestMethod4()
        {
            Assert.AreEqual("hello", "hello");
            //Console.WriteLine(string.Format("\"{0}\"", @"d:\screen.bmp"));
           
        }

        private TestContext m_testContext;

        public TestContext TestContext
        {

            get { return m_testContext; }

            set { m_testContext = value; }

        }

    }
}
