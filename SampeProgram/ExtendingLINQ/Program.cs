using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var el = "2:54,3:48".Split(',').Select(t => TimeSpan.Parse("0:" + t)).Sum();
            var el1 = "3:01,4:10".Split(',').Select(t => TimeSpan.Parse("0:" + t)).Aggregate((t1, t2) => t1 + t2);
            Console.WriteLine(el+" \n"+el1);

            var st= string.Join("-", new[]{ "Apple" , "Banana","Grapes"});
            Console.WriteLine(st);
            Console.ReadKey();
        }
    }
    static class MyLinqExtensions
    {
        public static TimeSpan Sum(this IEnumerable<TimeSpan> times)
        {
            var total = TimeSpan.Zero;
            foreach (var time in times)
            {
                total += time;
            }
            return total;
        }
    }
}
