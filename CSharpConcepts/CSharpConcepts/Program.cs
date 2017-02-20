using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Program 
    {
        
        static void Main(string[] args)
        {
            //DatabaseConnection dc = new DatabaseConnection();
            //    dc.Connection();

            //Delegates dl = new Delegates();
            //dl.AccessDelegate();

            // Inheritance s1 = new SampleInheritance();
            //  s1.DerivedExample();
            //  s1.BaseMethod();

            //Polymorphism p1 = new DerivedPolymorphism();
            //p1.SampleOverride(2);
            //p1.SampleHiding(3);

            //Encapsulation e1 = new Encapsulation();
            //e1.Balance = 100;

            //ConstructorExample c1 = new ConstructorExample("Hello");

            //ExceptionHandling ex1 = new ExceptionHandling();
            //ex1.ExceptionSample();

            //CollectionsExample col = new CollectionsExample();
            //col.SampleDictionary();
            //col.SampleList();
            //col.SampleArray();

            //StringOperations sop = new StringOperations();
            //sop.Operations();

            //LinqExamples linq = new LinqExamples();
            //linq.SampleLinq();

            FileOperations file = new FileOperations();
            file.ReadWrite();

            // FunctionParameters fp = new FunctionParameters();
            //fp.PassByReference();
            //fp.PassByOut();
            //fp.PassParams();
            //fp.NamedParameters(age: 25, name: "Hi");

            StaticExample.Display();
            StaticExample se1 = new StaticExample();
            StaticExample.Display();
            Console.WriteLine("ncount : "+se1.ncount);
            StaticExample se2 = new StaticExample();
            StaticExample.Display();
            Console.WriteLine("ncount :" +se2.ncount);

            //Comparision c = new Comparision();
            //c.PrimitiveType();

            InterfaceExample empExam = new EmployeeExample();
            empExam.Name();

            EnumExample enumEx = new EnumExample();
            enumEx.ValuesEnum();

 
            


            Console.ReadKey();
        }
    }
}
