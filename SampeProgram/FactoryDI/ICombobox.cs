using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDI
{
    public interface ICombobox : IControl
    {
        void SelectByText(string option);
        void SelectByIndex(int index);
    }
}
