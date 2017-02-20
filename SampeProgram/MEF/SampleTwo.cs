using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF
{
    [Export]
    public class SampleTwo : IControl
    {
        public string Valu;
        public SampleTwo(string ConstructorValue)
        {
            Valu = ConstructorValue;
        }
        
        public string StringProp
        {
            get
            {
                return Valu;
            }
            set
            {
                Valu = value;
            }
        }
    }
}
