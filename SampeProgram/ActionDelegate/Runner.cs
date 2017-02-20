using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegate
{
    public class Runner
    {
        public static void DoStep(string message, Action<int,int> action)
        {
            try
            {
                //Tray.Message = TrayMessage(message);
                action(2,6);
            }
            finally
            {
                //Print.ScreenPrint(message);
            }
           
        }
    }
}
