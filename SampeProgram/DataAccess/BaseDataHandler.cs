using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaseDataHandler
    {
        private static DataAccess dataAccess;
        protected static DataAccess Data
        {
            get
            {
                return dataAccess;
            }
        }

        public static void Initialize(string dataFile, DataAccess da)
        {
            dataAccess = da;
            dataAccess.ConectionString = string.Format(dataAccess.ConectionString, dataFile);
            dataAccess.DataCategory = DataCategory.MSExcel;
        }
    }
}
