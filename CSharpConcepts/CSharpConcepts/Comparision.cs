using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class Comparision
    {
        public void PrimitiveType()
        {
            // Create two equal but distinct strings
            string a = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            string b = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });

            Console.WriteLine(a == b);
            Console.WriteLine(a.Equals(b));

            // Now let's see what happens with the same tests but
            // with variables of type object
            object c = a;
            object d = b;
            Comparision c1 = new Comparision();
            Comparision c2 = new Comparision();
            Console.WriteLine(c == d); //Compares values of object referrences.Use it for value types
            Console.WriteLine(c.Equals(d));//Compares values inside object . Use it for reference types
            Console.WriteLine("Comp " + c1.Equals(c2));
            //a == b will just throw an exception if there's no comparison available for those types.
            //a.Equals(b) will nearly always return some value for a and b, regardless of type (the normal way to overload is to just return false if b is an unkown type).
        }
        public const int i = 0;//It cannot be changed anywhere and cannot be static and it has to be intialized before it is used
        public  readonly int j;//A readonly field cannot be assigned to(except in a constructor or a variable initializer)

        public Comparision()
        {
            j = 18;
        }

        public void Sample()
        {
            int k ;
            k = j;
        }

        public void ConvertString()
        {
            string j = null;
            string l = j.ToString();//Will return null reference exception
            string k = Convert.ToString(j);//will return null
        }
        


    }
}
