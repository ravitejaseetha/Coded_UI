using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, sum = 0, remainder;
            Console.WriteLine("Enter a Number : ");
            num = int.Parse(Console.ReadLine());
            while (num != 0)
            {
                remainder = num % 10;
                num = num / 10;
                sum = sum + remainder;
            }
            Console.WriteLine("Sum of Digits of the Number : " + sum);
            Console.WriteLine("Enter a No. to reverse");
           
            int Number = int.Parse(Console.ReadLine());
            int Reverse = 0;
            while (Number > 0)
            {
                int rem = Number % 10;
                Reverse = (Reverse * 10) + rem;
                Number = Number / 10;
            }
            Console.WriteLine("Reverse No. is {0}", Reverse);
            
            Console.ReadLine();
        }
    }
}
