using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{

    public enum ControlType
    {
        Button,
        Combobox
    }

    public class ControlAccess
    {
        public ControlType ControlType { get; set; }
        public IControl GetControll()
        {
            return SeleniumUtility.GetSeleniumControl(ControlType);
        }
    }
}
