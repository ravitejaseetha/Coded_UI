using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ReportGeneration
{
    public class Class2 : TestBase
    {
        [Test]
        public void TestMethod3()
        {
            Runner.DoStep("Class2 Google", () =>
            {
               Control.NavigateToURL("http://www.google.com");
            });
            

        }

        [Test]
        public void TestMethod4()
        {
           Runner.DoStep("Class2 EPAM", () =>
           {
               Control.NavigateToURL("http://www.google.com");
           });
        }
    }
}
