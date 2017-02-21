using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WKH.MOGA.UIAutomation.Browser;

namespace WKH.MOGA.UITests.Tests.LogInTests
{
    [TestClass]
    public class LogIn
    {
        [TestInitialize]
        public void SetUp()
        {
            Browser.InvokeBrowser();
            Browser.NavigateToUrl();
            Browser.MaximizeWindow();

        }
        [TestMethod]
        public void SimpleLogIn()
        {
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.Quit();
        }
    }
}
