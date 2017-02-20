using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelExecution
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Class1 : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "Browser")]
        [Category("ParallelExecution")]
        public void GoogleLogin(string browser)
        {
            SetupBrowser(browser);
            Thread.Sleep(10000);
        }
    }
}
