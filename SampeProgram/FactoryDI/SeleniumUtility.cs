using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{
    public class SeleniumUtility
    {
        internal static IControl GetSeleniumControl(ControlType ctype)
        {
            if(ctype == ControlType.Button)
            {
                return new SeleniumWebButton();
            }
            if (ctype == ControlType.Combobox)
            {
                return new SeleniumWebCombobox();
            }
            else return null;
        }
    }
}
