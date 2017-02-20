using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogExample
{
    public class Class1
    {
       // IWebDriver driver = new FirefoxDriver();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Test]
        public void TC1Sample()
        {
            var stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(0);
            MethodBase methodBase = stackFrame.GetMethod();

           // var sa = log.GetType();
            log.Error(this.GetType().FullName);
            log.Debug(methodBase.Name);
            log.Error("asd" );
        }
    }
}
