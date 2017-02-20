using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{
    public interface IControl
    {
        void SendKeys();
        void Click();
    }
}
