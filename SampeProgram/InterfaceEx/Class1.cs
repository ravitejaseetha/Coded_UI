using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEx
{
     class Class1 : IStudent,IContext
    {
        public void Name()
        {
            Console.WriteLine("Class1 class");
        }

        public void ID()
        {
            Console.WriteLine("Class1 class");
        }

        public void Address()
        {
            Console.WriteLine("Class1 class");
        }

        public void Salary()
        {
            Console.WriteLine("Class1 class");
        }

        public void Gender()
        {
            Console.WriteLine("Class1 class");
        }
    }
}
