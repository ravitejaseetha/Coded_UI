using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleNunit
{
    [SetUpFixture]
    class BeforeEachNamespace
    {
        MemoryCalculator mc;
        [OneTimeSetUp]
        public void RunBeforeAssembly()
        {
            Console.WriteLine("Before namespace");
            MessageBox.Show("Hello");
        }


        [OneTimeTearDown]
        public void AfterAllTest()
        {
            MessageBox.Show("Bye");
        }
    }
}
