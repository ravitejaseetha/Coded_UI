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
    public class MemoryCalculatorDataDrivenTests
    {
        //[TestCase(-5, -10, 15)]
        //[TestCase(-5, -5, 10)]
        //[TestCase(-5, 0, 5)]
        [TestCaseSource(typeof(ExampleTestCaseSource))]
        public void ShouldSubtractTwoNegativeNumbers(int firstNum, int secondNum, int expectedNum)
        {
            var sut = new MemoryCalculator();

            sut.Sub(firstNum);
            sut.Sub(secondNum);

            Assert.That(sut.CurrentValue, Is.EqualTo(expectedNum));
        }


    }

    public class ExampleTestCaseSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new[] { -5, -10, 15 };
            yield return new[] { -5, 0, 5 };
            yield return new[] { -5, -5, 10 };
        }

  
    }
}
