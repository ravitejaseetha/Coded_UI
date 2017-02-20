using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionarExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(23, "abc");
            dict.Add(24, "xyz");

            foreach(KeyValuePair<int,string> val in dict)
            {
                Console.WriteLine("{0},{1}", val.Key, val.Value);
                
            }
            

            string[] ab = new string[3];
            ab[0] = "array1";
            ab[1] = "array2";
            ab[2] = "array3";

            Dictionary<string, string> ar = ab.ToDictionary(key => key, value => value);

            foreach(var x in ar)
            {
                Console.WriteLine("{0},{1}", x.Key, x.Value);
            }

            var hashset = new HashSet<string>(ab);

            foreach(var y in hashset)
            {
                Console.WriteLine(y);
            }
            


            Customer c1 = new Customer()
            {
                ID = 23,
                Name = "Ravi",
                Salary = 2000
            };


            Customer c2 = new Customer()
            {
                ID = 24,
                Name = "Teja",
                Salary = 4000
            };


            Dictionary<int, Customer> cust = new Dictionary<int, Customer>();
            cust.Add(c1.ID,c1);
            cust.Add(c2.ID,c2);

            cust.Select(x => new { x.Key, x.Value }).ToList().ForEach(x => Console.WriteLine(x.Key +"\t"+ x.Value.ID + x.Value.Name + x.Value.Salary));
            


            var names = from i in cust
                        where i.Value.Salary > 2000
                        select i.Value.ID;

            foreach(var xy in names)
            {
                Console.WriteLine("Keys"+xy);
            }


             cust.Where(x => x.Value.Salary > 1000).Select(x => new { x.Value.ID }).ToList().ForEach(x => Console.WriteLine("Single line"+x.ID));
             cust.Select(x => new {x.Value.ID}).ToList().ForEach(x => Console.WriteLine(x.ID));
            //foreach(var z in names1)
            //{
            //    Console.WriteLine("Lambda expression"+z);
            //}

             Dictionary<int, string> dictionary = new Dictionary<int, string>();

             dictionary.Add(100, "abc"); dictionary.Add(200, "xyz");

            // new is used to select multiple values i.e, key and value in select clause
             var linq = from ik in dictionary
                        where ik.Key > 10
                        select new {ik.Value, ik.Key} ;

            foreach(var sa in linq)
            {
                Console.WriteLine("Key {0} and value {1} using linq",sa.Key , sa.Value);
            }

            // Select single value(eihter key or value) this returns IEnumerable<string> which is nothing but read only suitable to iterate through collection
            // and cannot modify

             IEnumerable<string> linq1 = from ik in dictionary
                        where ik.Key > 100
                        select  ik.Value;

            foreach(var xyz in linq1)
            {
                Console.WriteLine("Only value using linq " + xyz);
            }
           
            //Now Convert dictionary to list using lambda expressions with select multiple values and foreach
            dictionary.Where(x => x.Key > 10).Select(x => new {x.Key, x.Value}).ToList().ForEach(x => Console.WriteLine("With select and selecting multiple values {0} {1}",x.Key,x.Value));

            //Without select and for each
            dictionary.ToList().ForEach(x => Console.WriteLine("Without select"+x.Value));

            //With where and for each
            dictionary.Where(x => x.Key > 10).ToList().ForEach(x => Console.WriteLine("with where " + x.Value));      


            //With select and for each you need to use new {} in select clause in order loop the dictionary keys or values
            dictionary.Select(x => new { x.Key }).ToList().ForEach(x => Console.WriteLine("with Select " + x.Key));

            Console.ReadKey();
        }
       
    }

    public class Customer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Salary { get; set; }
    }
}
