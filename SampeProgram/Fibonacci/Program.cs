using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
           
           // Fibo(5);
            foreach (var item in   Fibonacc(5))
            {
                Console.WriteLine(item);
            }
          
           
            Console.ReadKey();
        }
        //public static void Fibo(int x)
        //{
        //    int prev = -1;
        //    int next = 1;
        //    for (int i = 0; i < x; i++)
        //    {
        //        int sum = prev + next;
        //        prev = next;
        //        next = sum;
        //        Console.WriteLine(sum);
        //    }
        //}



        public static IEnumerable<int> Fibonacc(int x)
        {
            int prev = -1;
            int sum = 0;
            int next = 1;
            for (int i = 0; i < x; i++)
            {
                sum = prev + next;
                prev = next;
                next = sum;
                Console.WriteLine(sum);
                yield return sum;

            }


        }
    }
}
