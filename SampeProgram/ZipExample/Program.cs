using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ZipExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"D:\TCO",@"D:\New.zip", CompressionLevel.Optimal, true);
            ZipFile.ExtractToDirectory(@"D:\New.zip",@"D:\Sour");
        }
    }
}
