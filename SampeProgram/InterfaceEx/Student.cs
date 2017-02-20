using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEx
{
    class Student 
    {
        IStudent abc = new Class1();
        Employee abcd = new Employee();
        IStudent abcde = new Employee();

       Employee emp = new Employee();

        [Test]
        public void Sample()
        {
            abc.Address();
            abcd.NewAddress();
            abcde.Address();
            
        }
    }
}
