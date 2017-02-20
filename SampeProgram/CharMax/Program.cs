using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharMax
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] val = { 'A', 'b', 'C', 'D', 'E', 'o' ,'d','G'};

            foreach (var item in val)
            {
                Console.WriteLine(Convert.ToInt32(item));
            }
            var va = val.OrderByDescending(x => x);
            var v = val.OrderByDescending(x => x).Skip(2).First();

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.w3schools.com/html/html_tables.asp");
            driver.Manage().Window.Maximize();
            var size = driver.FindElements(By.XPath(".//*[@id='customers']/tbody/tr"));
            var size1 = driver.FindElements(By.XPath(".//*[@id='customers']/tbody/tr[2]/td"));
            int count = size.Count;
            int count1 = size1.Count;
          
            string expected = "Canada";
            for (int i = 2; i <= count; i++)
            {
                for (int j = 1; j <= count1; j++)
                {
                    var final = driver.FindElement(By.XPath(".//*[@id='customers']/tbody/tr["+ i +"]/td["+ j +"]")).Text;
                    if(expected.Equals(final))
                    {
                        Console.WriteLine("Row :{0}, Column :{1}",i,j);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
