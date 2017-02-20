using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleNunit
{
    [TestFixture]
    class Calculation
    {
        MemoryCalculator mc;

        [SetUp]
        public void CreateInstance()
        {
            Console.WriteLine("Before{0}", TestContext.CurrentContext.Test.Name);
            mc = new MemoryCalculator();
        }
        [Test]
        public void ShouldAdd()
        {
            
            mc.Add(10);
            mc.Add(5);
            mc.Add(5);
            Assert.That(mc.CurrentValue, Is.EqualTo(20));
        }

        [Test]
        public void ShouldSubstract()
        {
        
            mc.Sub(10);
            Assert.That(mc.CurrentValue, Is.EqualTo(-10));
        }
        //[TearDown]
       
        //public void AfterEachTest()
        //{
        //    Console.WriteLine("After {0}",TestContext.CurrentContext.Test.Name);
        //    mc = null;
        //}
 

    }
}
