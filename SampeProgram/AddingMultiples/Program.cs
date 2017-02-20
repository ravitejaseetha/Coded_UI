using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddingMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = null;
            IWebElement slider = driver.FindElement(By.XPath("//div[@id='slider']/span"));
           
            Actions move = new Actions(driver);
            move.DragAndDropToOffset(slider, 30, 0).Build().Perform();
           

            Console.WriteLine("Enter the number");
            int valu = Int32.Parse( Console.ReadLine());
            Console.WriteLine("Addition of 3 and 5 multiples is : "+AddMultiples(valu));
         

                 int sum=11;
                for(int i=0; i<20; i++) {
                    if((i%3 == 0) || (i%5 == 0)){
                        sum += i;
                    }
            }
               Console.WriteLine("Bharath"+sum);
               Console.ReadKey();
        }

        public static int AddMultiples(int x)
        {
            List<int> resultThree = new List<int>();
            List<int> resultFive = new List<int>();
            for(int i = 1; i < x;i++)
            {
                var val = i % 3;
                if(val == 0)
                {
                    resultThree.Add(i);
                }
                var val1 = i % 5;
                if(val1 == 0)
                {
                  
                    resultFive.Add(i);
                }

            }
            int val2 = 0;
            List<int> finalResult = new List<int>();
            List<int> items = new List<int>();
            foreach(var result in resultThree)
            {
                foreach(var resultOne in resultFive)
                {
                    if(result.Equals(resultOne))
                    {
                         items.Add(result);
                    }

                }
            }
            foreach(var item in items)
            {
                resultThree.Remove(item);
            }

            int endResult = 0;

            foreach(var ite in resultThree)
            {
                endResult = endResult + ite;
            }

            int endResultOne = 0;

            foreach (var ite in resultFive)
            {
                endResultOne = endResultOne + ite;
            }


            int sampleResult = endResult + endResultOne;

            return sampleResult;
            
        }
    }

    public class Sample
    {
        private int ittt = 2;
        public int j ;
        public void GG()
        {
            Console.WriteLine(ittt);
        }
    }

    public class Dep : Sample
    {
        public void Sa()
        {
            GG();
         
        }
    }
}
