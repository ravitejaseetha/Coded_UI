using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{
    public class SeleniumWebControl : IControl
    {
        public void SendKeys()
        {
            Console.WriteLine("");
        }

        public void Click()
        {
            Console.WriteLine("Hello Click");
        }
    }
}
