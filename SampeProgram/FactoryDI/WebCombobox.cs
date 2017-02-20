using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{
    public class WebCombobox : WebControl
    {
        public WebCombobox()
            :base(ControlType.Combobox)
        {

        }
        private ICombobox Combo
        {
            get
            {
                return (ICombobox)Control;
            }
        }


        public void SelectByText(string option)
        {
            Combo.SelectByText(option);
        }

        public void SelectByIndex(int index)
        {
            Combo.SelectByIndex(index);
        }
    }
}
