using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericImplicitTyping
{
    class Program
    {
        int dd ;
        int ss ;
        static void Main()
        {
            string s = "Hello";
            int i = 45;
            //Calling generic Methods using implicit  typing
            Example(s);
            Example(i);
            Example<string>(s);

            List<object> things = new List<object>()
            {
                "Hello",
                42,
                "Hi",
                new Program(){ dd =56, ss=77}
            };

            IEnumerable<string> val = things.OfType<string>().Select(x => x.ToUpper()).Where(x => x.Length > 2);
            IEnumerable<int> val1 = things.OfType<int>().Select(x => x).Where(x => x > 42);
            IEnumerable<object> val2 = things.OfType<Program>().Select(x => new { x.dd, x.ss }).Where(x => x.dd > 51 && x.ss > 76);


            
            Console.ReadKey();
        }

        public static void Example<T>(T obj)
        {
            Console.WriteLine(obj);
        }

        public static void Example(string s)
        {
            Console.WriteLine(s); ;
        }
    }

}
