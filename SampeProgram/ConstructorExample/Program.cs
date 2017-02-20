using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorExample
{
    public class Sample
    {
        //Default Constructor
        public string param, param1;
        //public Sample()
        //{
        //    param = "Hello";
        //    param1 = "World";
        //}
        //Parameterized Constructor
        public Sample(string x, string y)
        {
            param = x;
            param1 = y;
            Console.WriteLine(val);
        }

        //Copy Constructor
        public Sample(Sample s1)
        {
            param = s1.param;
            param1 = s1.param1;
        }

        //Static Constructor
        static Sample()
        {
            Console.WriteLine("Static Constructor");
        }

        static int val;
        //Private Constructor
        // We cannot create an instance to a private constructor an we cannot have public and private default constructor in the same class and we cannot
        //Inherit if the class has only private constructor
        private Sample()
        {
            
            Console.WriteLine("Private Constructor");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //Sample obj1 = new Sample();
            //Console.WriteLine(obj1.param + " " + obj1.param1);

            Sample obj2 = new Sample("good", "morning");
            Console.WriteLine(obj2.param + " " + obj2.param1);

            Sample obj3 = new Sample(obj2);
            Console.WriteLine(obj3.param + " " + obj3.param1);

            //Sample obj4 = new Sample();
            Console.ReadKey();

           
        }
    }
}
