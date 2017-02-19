using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.Data;
using System.Xml;
using System.Data.OleDb;

namespace SampleUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver(@"D:\Drivers");
        [TestMethod]
        public void TC1_UserName()
        {
            var va = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var val = GetEnvironmentData("Name");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http:\\www.linkedin.com");
            driver.FindElement(By.Id("login-email")).SendKeys(val);
           
            
            //driver.Navigate().Back();
            //driver.Navigate().GoToUrl("http:\\www.google.com");
        }

        [TestMethod]
        public void TC2_Password()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http:\\www.linkedin.com");
            driver.FindElement(By.Id("login-password")).SendKeys("Bye");
            Thread.Sleep(2000);
        }

        public static string GetEnvironmentData(string key)
        {
            string connString = "";
            string path =@"d:\sample.xls";

            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "; Jet OLEDB:Engine Type=5;Extended Properties=\"Excel 8.0;\"";
            string query = "SELECT [Value] FROM [Test$] where Key ='" + key + "'";

            DataTable excelDataTable = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(query, connString);
            da.Fill(excelDataTable);

            string searchTerm = excelDataTable.Rows[0][0].ToString();

            return searchTerm;
        }
    }
}
