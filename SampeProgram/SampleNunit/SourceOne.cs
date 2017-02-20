using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleNunit
{
    [TestFixture]
    public class MyTests
    {
        [Test, TestCaseSource(typeof(MyDataClass), "TestCases")]
        public int DivideTest(int n, int d)
        {
            return n / d;
        }
    }

    public class MyDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(4);
                yield return new TestCaseData(12, 2).Ignore("Ignoring this test case");
                yield return new TestCaseData(12, 4).Explicit("Explicit");
                yield return new TestCaseData(12, 6).SetCategory("Regression");
            }
        }
    }
}
