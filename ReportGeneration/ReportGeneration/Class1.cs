using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ReportGeneration
{
    public class Class1 : TestBase
    {

        private readonly Data _createProjectData;
        private string _errorMessage;
        public Class1()
        {
            _createProjectData = SerializeConfig<Data>.DeSerialize("CreateProjectInput.xml");
        }
        [Test]
        public void TestMethod()
        {
            Runner.DoStep("Navigate", () =>
            {
                Control.NavigateToURL("http://www.linkedin.com");
                Control.Maximize();
            });


            Runner.DoStep("Username", () =>
            {
               Control.SendKeys(Login.Username,_createProjectData.CreateOpportunity[0].AccountName);
            });
        }


        [Test]
        public void TestMethod2()
        {
            Runner.DoStep("Password", () =>
            {
                Control.SendKeys(Login.Password, _createProjectData.CreateOpportunity[0].CalculatorType);
            });
        }

       
    }
}
