using DataAccess;
using DataAccess.Entities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BVT
{
    class Artinstitute : BVTBase,IBVTContext
    {
        public BVTEntity InvalidrIFDataEntry;
        public List<BVTEntity> StudentInfo;

        public Artinstitute(BVTEntity invalidrIFDataEntry, List<BVTEntity> studentInfo)
        {
            InvalidrIFDataEntry = invalidrIFDataEntry;
            StudentInfo = studentInfo;
        }

        public void Fixture()
        {
            Driver.Navigate().GoToUrl("https://www.linkedin.com/");
            Driver.Manage().Window.Maximize();
        }

        public void TearDown()
        {
            throw new NotImplementedException();
        }

        public void RequestInfo()
        {
            throw new NotImplementedException();
        }

        public void StraighRIFDataEntry()
        {
            throw new NotImplementedException();
        }

        public void InvalidRIFDataEntry()
        {
            Thread.Sleep(2000);
            StudentInfo.ForEach(eachData =>
                {
                    Driver.FindElement(By.XPath("//*[@id='login-email']")).SendKeys(eachData.FirstName);
                    Thread.Sleep(2000);
                    Driver.FindElement(By.XPath("//*[@id='login-email']")).Clear();
                    Thread.Sleep(2000);
                    BVTData.UpdateStudentData("update", "TestLastName17");
                });
            
        }

        public void SourceRepData()
        {
            throw new NotImplementedException();
        }

        public void ValidateData()
        {
            throw new NotImplementedException();
        }

        public void CheckBrokenLink()
        {
            throw new NotImplementedException();
        }
    }
}
