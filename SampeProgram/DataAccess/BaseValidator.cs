using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
  public  class BaseValidator
    {
        private static DataAccess da;

        public static string ConnectionString { get; set; }

        protected static DataAccess DataAccess
        {
            get
            {
                return da;
            }
        }

        public BaseValidator()
        { }

        public static void InitializeValidator(string connectionString)
        {
            ConnectionString = connectionString;

            da = new DataAccess()
            {
                ConectionString = connectionString,
                //ConectionString = "Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source = " + dataFileName + ";" + "Extended Properties = 'Excel 8.0;HDR=Yes'",
                DataCategory = DataCategory.SQLDB
            };
        }
    }
}
