using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF
{
    [Export]
    public class SampleOne : IControl
    {
        public int valu1 = 32;
        public int MyProperty
        {
            get
            {
                return valu1;
            }
        }
    }
}
