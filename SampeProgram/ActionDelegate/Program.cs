using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner.DoStep("hello", (x,y) =>
                {
                    Console.WriteLine("Hello World"+x+y);
                });
            Console.ReadKey();
        }
    }
}
