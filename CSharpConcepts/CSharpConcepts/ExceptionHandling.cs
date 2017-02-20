using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class ExceptionHandling
    {
        public void ExceptionSample()
        {
            try
            {
                string abc = null;
                abc.Split(' ');


            }
            //Specific exceptions should always be on top
            catch (NullReferenceException ex)
            {
                try
                {
                    int i = 0;
                    Console.WriteLine(5 / i);
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e);
                }

            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1);
            }

            ////Finally can be executed irrespective of the exception occured or not.It is mainly used to dispose unmanaged resources.
            //// If you have only try and finally, To run the program in Visual Studio, type CTRL+F5. Then 
            //// click Cancel in the error dialog.
            finally
            {
                Console.WriteLine("finally");
            }
           


          
        }
    }
}
