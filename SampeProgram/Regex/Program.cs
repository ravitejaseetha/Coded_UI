using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
namespace Regex
{
    class Program
    {
        private static int abc = 245;
        public static int Abc
        {
            get
            {
                return abc;
            }
            set
            {
                if (value > 100)
                {
                    abc = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        static void Main(string[] args)
        {
            string va = "abcab";
   
            char[] cd = va.ToCharArray();
            List<string> str = new List<string>();
            foreach (var item in cd) 
            {
                str.Add(item.ToString());
            }
           var fdc = str.Aggregate((x,y) => x + "," + y);
            
            for (int i = 0; i < va.Length; i++)
            {
                
            }
            Abc = -100;
            string[] input = { "Ravi", "Suresh", "Sreenivas", "BhanuPrasad" };
            string firstEle = input[0];
            foreach (var item in input)
            {
                if (item.Length > firstEle.Count()) firstEle = item;
            }
            Console.WriteLine("String : {0} and length : {1} ", firstEle, firstEle.Count());

            var output = input.OrderByDescending(x => x.Count()).Select(x => new
            {
                StringName = x,
                StringLenght = x.Count()
            }).FirstOrDefault();
            Console.WriteLine(output.StringName + "And its length " + output.StringLenght);

            var val1 = input.MaxBy(x => x.Length);
            Console.WriteLine("Name{0}and length{1}", val1, val1.Count());


            var books = new[] 
            {
                new { Author = "abc" , Title = "Clean Code", Pages = 444 },
                new { Author = "abcdefg" , Title = "worst Code", Pages = 45 },
            };

            Console.WriteLine(books.MaxBy(b => b.Pages));
            Console.ReadKey();
        }

           
          //  
        }
    }


