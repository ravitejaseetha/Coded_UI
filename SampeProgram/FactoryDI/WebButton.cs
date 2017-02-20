using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{
    public class WebButton : WebControl
    {
        public WebButton()
            :base(ControlType.Button)
        {

        }
        public IButton Button
        {
            get
            {
                return (IButton)Control;
            }
        }

    }
}
