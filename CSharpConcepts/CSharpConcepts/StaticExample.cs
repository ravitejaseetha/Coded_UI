using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class StaticExample
    {
        public static int  count = 0;//Static fields shared across multiple objects
        public int ncount = 0;       //Vice versa
        public static void Display()
        {
            Console.WriteLine("Count is " + count);
        }

        public StaticExample()
        {
            count = count + 1;
            ncount = ncount + 1;
        }


    }
}
