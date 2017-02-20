using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{
    class Program
    {
        public delegate void printMessage(string str);


        public void WriteText(string str)
        {
            Console.WriteLine(str);
        }

        public void WriteToFile(string str)
        {
            FileStream fs = new FileStream("D:\\message.txt",FileMode.Append,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Close();
            sw.Flush();
        }

        public static void Sample(printMessage ps)
        {
            ps("Hello World");
        }

        public static void Show(int str,int str1,int str2)
        {
            Console.WriteLine(str+str1+str2);
        }

        

        static int Sum()
        {
            return 10;
        }


        static string Display(string x, string y)
        {
            return x + y;
        }
        public delegate TResult Func<in T, out TResult>(T arg);
        static void Main(string[] args)
        {
            //Program p = new Program();
            //printMessage p1 = new printMessage(p.WriteText);
            //printMessage p2 = new printMessage(p.WriteToFile);
            //Sample(p1);
            //Sample(p2);
            //Console.ReadKey();
           
            //Action Delegate
            Action<int,int,int> d = Show;
            d(20,21,34);
           
            Action<string> d1 = s => Console.WriteLine(s);
            d1("World");
            

            //Func Delegate
             Func<int> someOperation = Sum;
            Console.WriteLine(Sum());
            
            
            Func<string,string,string> showResult = Display;
            Console.WriteLine(Display("abcd", "hello"));
            
            //Anonymous Function
            Func<int> randomNumber = delegate()
            {
                Random rnd = new Random();
                return rnd.Next(90, 100);
            };
            Console.WriteLine(randomNumber.Invoke());

            //Lambda expressions
            Func<int, int, int>  Sum1  = (x, y) => x + y;
            Console.WriteLine(Sum1(10, 20));
            Console.ReadLine();
        }
    }
}
