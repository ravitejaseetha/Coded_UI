using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaseTestData
    {
        private static DataAccess da;

        protected static DataAccess DataAccess
        {
            get
            {
                return da;
            }
        }


        public BaseTestData(string dataFileName)
        {
            da = new DataAccess()
            {

                //ConectionString = "Provider = Microsoft.Jet.
                //.4.0;" + "Data Source = " + dataFileName + ";" + "Extended Properties = 'Excel 8.0;HDR=Yes'",
                ////ConectionString = "Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = " + dataFileName + ";" + "Extended Properties = 'Excel 8.0;HDR=Yes'",
                //DataCategory = DataCategory.MSExcel,

            };

  
        }
    }
}
