using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SampleNunit
{

    

    //[TestFixture]
   [Parallelizable(ParallelScope.Fixtures)]
    public class Class1
    {
        //IWebDriver driver = new ChromeDriver();
        //[TestFixtureSetUp]
        //public void First()
        //{
        //    driver = new ChromeDriver();
        //}

        [Test]
       
        public void SampleZero()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.Manage().Window.Maximize();
            Thread.Sleep(15000);
            driver.Close();
        }

        [Test]
 
        public void SampleOne()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.linkedin.com");
            driver.Manage().Window.Maximize();
            Thread.Sleep(15000);
            driver.Close();

        }
        //[TearDown]
        
        //public void Close()
        //{
          
        //    driver.Close();

        //}
    }
  

    [Parallelizable(ParallelScope.Fixtures)]
    public class Class2 : Class1
    {
        [Test]
      
        public void SampleThree()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.linkedin.com");
            driver.Manage().Window.Maximize();
            Thread.Sleep(15000);
        }

    }
}
