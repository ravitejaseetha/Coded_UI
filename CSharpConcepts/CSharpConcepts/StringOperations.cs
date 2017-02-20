using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class StringOperations
    {
        public void Operations()
        {
            string strOriginal = "These functions will come handy";
            string strModified = String.Empty;
            //Iterate String
            foreach (char c in strOriginal)
            {
                Console.WriteLine(c.ToString());
            }

            //Split  a string
            char[] delim = { ' ' };
            string[] strArr = strOriginal.Split(delim);
            foreach (string s in strArr)
            {
                Console.WriteLine(s);
            }

            // only starting position specified
            strModified = strOriginal.Substring(25);
            Console.WriteLine(strModified);

            // starting position and length of string to be extracted specified
            strModified = strOriginal.Substring(20, 3);
            Console.WriteLine(strModified);

            // Single Dimensional String Array

            string[] strArrr = new string[3] { "string 1", "string 2", "string 3" };
            // Omit Size of Array
            string[] strArr1 = new string[] { "string 1", "string 2", "string 3" };
            // Omit new keyword
            string[] strArr2 = { "string 1", "string 2", "string 3" };

            // Multi Dimensional String Array

            string[,] strArr3 = new string[2, 2] { { "string 1", "string 2" }, { "string 3", "string 4" } };
            // Omit Size of Array
            string[,] strArr4 = new string[,] { { "string 1", "string 2" }, { "string 3", "string 4" } };
            // Omit new keyword
            string[,] strArr5 = { { "string 1", "string 2" }, { "string 3", "string 4" } };

            //Reverse a string

            var ct = strOriginal.Reverse().ToArray();
            Console.WriteLine(ct);

            //String comparision
            string one = "Hello";
            string two = "hello";
            Console.WriteLine(one == two);
            //true or false is for case sensitive
            var a =  string.Compare(one, two, true);
            //throws null reference exception if the string is empty
            //nsole.WriteLine(one.Equals(two));


            //Convert a string to char[](char array)
            char[] chArr = strOriginal.ToCharArray();

            //Char array to string
            strModified = new string(chArr);
            
            //Test if String is null or Zero Length
            bool check = String.IsNullOrEmpty(strOriginal);
                                    
           // Convert the Case of a String
           System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
           System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
           // Lower Case
           Console.WriteLine(textInfo.ToLower(strOriginal));
           // Upper Case
           Console.WriteLine(textInfo.ToUpper(strOriginal));
           // Proper Case
           Console.WriteLine(textInfo.ToTitleCase(strOriginal));

           //Count the occurrences of words in a String

           string animals = "Dog,Cat,Dog,Dog,Lion,Dog,Tiger,Cat";
           var resul = animals.Split(',')
                       //.GroupBy(x => (x != "Dog" && x != "Cat") ?  "Other" : x)
                       .GroupBy(x => x)
                       .Select(g => new { Pet = g.Key, Count = g.Count() });

           foreach (var item in resul)
           {
               Console.WriteLine(item.Pet + " " + item.Count);
           }
           
           //Insert characters inside a string
           strModified = strOriginal.Insert(26, "very ");
           

           //Replace characters in a String
           strModified = strOriginal.Replace("come handy", "be useful");
        }
    }
}
