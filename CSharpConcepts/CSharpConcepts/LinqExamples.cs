using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using Nessos.LinqOptimizer.CSharp;


namespace CSharpConcepts
{
    class LinqExamples
    {
        public void SampleLinq()
        {
            var emp = new List<EmployeeDetails>()
            {
                new EmployeeDetails(){ Name = "Ravi", ID = 519195, Company ="EPAM" },
                new EmployeeDetails(){ Name = "Teja", ID = 519165, Company ="AGs" },
                new EmployeeDetails{ Name = "Sachin", ID = 519195, Company ="EPAM" },
            };

            var emp1 = emp.Where((c) => c.Company == "AGs").OrderBy(x => x.Name).Select(x => new { x.Name, x.ID });

            //Deffered execution-------Dont compute the code until the caller actually uses it
            emp.Add(new EmployeeDetails() { Name = "John", ID = 3434, Company = "AGs" });

            foreach (var val in emp1)
            {
                Console.WriteLine(val.Name + " " + val.ID);
            }

            string[] input = { "Ravi", "Sureshdddddddddddddddd", "Sreenivas", "BhanuPrasad" };
            //To get maximum length string name and string count
            var st = input.OrderByDescending(x => x.Length).Skip(2).FirstOrDefault();
            var output = input.OrderByDescending(x => x.Count()).Select(x => new
            {
                StringName = x,
                StringLenght = x.Count()
            }).FirstOrDefault();

            Console.WriteLine(output.StringName + "And its length " + output.StringLenght);
            
            //Add Morelinq nuget for MaxBy
            var val1 = input.MaxBy(x => x.Length);
            Console.WriteLine("Name{0}and length{1}", val1, val1.Count());

            var rr = Enumerable.Range(1, 20).Batch(2);
            foreach (var item in rr)
            {
                Console.WriteLine(item);
            }


            var strings = new List<string>() { "Hello", "Bye" };
            //Lazy evaluation.It wont print the values unless it is looped outside this line.Select returns lazly
            var upperCase = strings.Select(X =>
            {
                Console.WriteLine(X);
                return (X);
            });
                                    
            //evaluated IEnumerable sequence
            foreach (var item in upperCase)
            {
                Console.WriteLine(item.ToUpper());
            }

           // strings.Select(x => x.ToUpper()).ForEach(x => Console.WriteLine(x));//it will print

            //LinqOptimizer nuget
            var q = Enumerable.Range(1, 10000).AsQueryExpr()
                               .Select(n => n * 2)
                               .Select(n => Math.Sin((2 * Math.PI * n) / 1000))
                               .Select(n => Math.Pow(n, 2))
                               .Sum();
           var s2 =  q.Run();
           Console.WriteLine(s2);

           List<EmployeeDetails> emp12 = new List<EmployeeDetails>()
           {
               new EmployeeDetails(){ Name="Sachin", ID=3 , Company="australia"},
               new EmployeeDetails(){ Name="Rahul", ID=4, Company="India"},
           };

           //EmployeeDetails ddff = new EmployeeDetails()
           //{
           //    Company ="hi",
           //    ID=2,
           //    Name="ad",
           //};
           var dd = emp12.OrderBy(c => c.Company).ThenBy(c => c.Name);
           foreach (var item in dd)
           {
               Console.WriteLine(item.Company+item.Name);
           }

        }
    }

    class EmployeeDetails
    {
        
        public string Name { get; set; }
        public int ID { get; set; }
        public string Company { get; set; }
    }
}
