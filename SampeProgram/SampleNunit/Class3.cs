using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleNunit1
{
    [TestFixture]
   // [Category("Regression")]
    class Class3
    {
        [Test]
        //[Ignore("Hello")]
        [Category("Regression1")]
        [MaxTime(4000)]
        [Repeat(10)]
        public void Sa()
        {
            Console.WriteLine("Hello sa");
        }
    }
}
