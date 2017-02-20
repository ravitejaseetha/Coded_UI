using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.Name = "apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99;
            product.Sizes = new string[] { "Small", "Medium", "Large" };
            string output = JsonConvert.SerializeObject(product);
            Console.WriteLine(output + Environment.NewLine);
            System.IO.File.WriteAllText("d:\\message.txt",output);
            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
             Console.ReadKey();

        }
    }

    class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double Price { get; set; }
        public string[] Sizes { get; set; }
    }
}
