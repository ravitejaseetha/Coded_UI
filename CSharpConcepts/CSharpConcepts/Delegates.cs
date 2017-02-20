using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Delegates
    {
        public void AccessDelegate()
        {
            //Action takes 0 to 16 parameters and returns void
            Action<int> myAction = new Action<int>(DoSomething);
            myAction(123);           // Prints out "123"
            // can be also called as myAction.Invoke(123);

            //Func takes 0 to 16 parameters and returns any one specified type
            Func<int, double> myFunc = new Func<int, double>(CalculateSomething);
            Console.WriteLine(myFunc(5));   // Prints out "2.5"

            //Predicate takes one parameter and returns bool
            Predicate<string> isUpper = IsUpperCase;
            Predicate<string> pre = new Predicate<string>(IsUpperCase);

            bool result = isUpper("HELLO WORLD!!");
            bool result1 = pre("hello");
            Console.WriteLine(result + " " + result1);


           
        }
        static void DoSomething(int i)
        {
            Console.WriteLine(i);
        }

        static double CalculateSomething(int i)
        {
            return (double)i / 2;
        }

        static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }
    }
}
