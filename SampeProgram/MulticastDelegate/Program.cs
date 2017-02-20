using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegate
{
    class Program
    {
        //Multicast delegates allows us to call multiple target methods when invoking single delegate. We can add and remove target methods using += and -= operators
        private  delegate void VoidDelegate(int a);
        private delegate int MathOperation(int a, int b);
        public readonly int x;
        static void Main(string[] args)
        {
            var sample = new VoidDelegate(WriteToConsole);
            sample(4);
            sample += WriteToConsoleWithMessage;
            sample(45);
            sample -= WriteToConsole;
            sample(46);

            var math = new MathOperation(Add);
            math(20, 30);
            math += Mul;
            //In multicast delegate if the function returns any type then it will take last delegate target method return value that was invoked(Both methods will be called)
            //Using keywords as variable names
            var @static = math(40, 60);

            Console.ReadKey();
            string[] RT = { "SF", "SFD" };
            int[] ST = { 23, 34 };
            var num = ST.Zip(RT, Compare).ToList();
 
        }

        public static string Compare(int name,string age)
        {
            return name + ": " + age;
        }
        public static void WriteToConsole(int s)
        {
            Console.WriteLine(s);
        }

        public static void WriteToConsoleWithMessage(int x)
        {
            Console.WriteLine("With Message");
            Console.WriteLine(x);
        }

        public static int Add(int x,int y)
        {
            Console.WriteLine("Add method will be called");
            return x + y;
        }

        public static int Mul(int a, int b)
        {
            Console.WriteLine("Mul method called");
            return a + b;
        }
    }
}
