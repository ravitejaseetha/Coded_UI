using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddnumberYield
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            foreach (var n in p.OddInts())
            {
                Console.WriteLine(n);
            }
        }

        public IEnumerable<int> OddInts()
        {
            int start = 1;
            while (start > 0)
            {
                yield return start += 2;
                Console.WriteLine(start);
            }
        }
    }
}
