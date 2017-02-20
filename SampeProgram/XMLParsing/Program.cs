using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSettings ts = new TestSettings(Directory.GetCurrentDirectory());
            Console.WriteLine(ts.URL);
            Console.ReadKey();
        }
    }
}
