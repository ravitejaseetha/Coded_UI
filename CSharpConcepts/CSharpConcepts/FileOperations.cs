using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class FileOperations
    {
        public void ReadWrite()
        {
            string file = String.Format(@"~\{0}", "CSharpConcepts.sln");
            if (File.Exists(file))
            {
                
            }
            if (File.Exists(@"d:\dd.txt"))
            {
                string content = File.ReadAllText(@"d:\dd.txt");
                Console.WriteLine("Current content of file:");
                Console.WriteLine(content);
            }
            
            //Write
            //Console.WriteLine("Please enter new content for the file:");
            //string newContent = Console.ReadLine();
            //File.WriteAllText(@"d:\dd.txt", newContent);

            //Append
            Console.WriteLine("Please enter new content for the file - type exit and press enter to finish editing:");
            string newContent1 = Console.ReadLine();
            while (newContent1 != "exit")
            {
                File.AppendAllText(@"d:\dd.txt", newContent1 + Environment.NewLine);
                newContent1 = Console.ReadLine();
            }


            //Writing using streamwriter
            //Using ensures that the file reference is closed once it goes out of scope
            Console.WriteLine("Please enter new content for the file - type exit and press enter to finish editing:");
            using (StreamWriter sw = new StreamWriter("test.txt"))
            {
                string newContent2 = Console.ReadLine();
                while (newContent2 != "exit")
                {
                    sw.Write(newContent2 + Environment.NewLine);
                    newContent2 = Console.ReadLine();
                }
            }
        }
    }
}
