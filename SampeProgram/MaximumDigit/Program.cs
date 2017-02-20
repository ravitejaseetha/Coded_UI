using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            var val = Enumerable.Range(1, 5).Aggregate((a, b) => a * b);
            Console.WriteLine("Enter number");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFact(num));
            Console.ReadKey();
        }

        public static int GetFact(int number)
        {
            int fact = 1;
            if(number == 0)
            {
                return 1;
            }
            else
            {
                for(int j = number;j>=1;j--)
                {
                    fact = fact * j;
                }
            }
            return fact;
        }
    }
}
