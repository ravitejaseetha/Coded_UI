using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{
    public class SeleniumWebCombobox : SeleniumWebControl,ICombobox
    {
        public void SelectByText(string option)
        {
            Console.WriteLine(option);
        }

        public void SelectByIndex(int index)
        {
            Console.WriteLine("");
        }
    }
}
