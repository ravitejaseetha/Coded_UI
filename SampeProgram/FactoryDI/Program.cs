using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            WebPage wb = new WebPage();
            wb.Button.Click();
            wb.Combo.SelectByText("Hello combo");
            Console.ReadKey();
        }
    }

    public class WebPage : WebControlUtility
    {
        public WebButton Button
        {
            get
            {
                return GetControlFromLocator<WebButton>();
            }
        }

        public WebCombobox Combo
        {
            get
            {
                return GetControlFromLocator<WebCombobox>();
            }
        }
    }
}
