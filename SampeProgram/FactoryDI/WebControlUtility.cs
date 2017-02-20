using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{
    public class WebControlUtility
    {
        public T GetControlFromLocator<T>() where T : WebControl
        {
            WebControl aWebCustomControl = null;

            if (typeof(T) == typeof(WebButton))
            {
                aWebCustomControl = new WebButton();
            }

            if (typeof(T) == typeof(WebCombobox))
            {
                aWebCustomControl = new WebCombobox();
            }
            
            aWebCustomControl.GetControl();

            return (T)aWebCustomControl;
        }
    }
}
