using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts
{
    class DatabaseConnection
    {
        public void Connection()
        {

            DirectoryInfo dir = new DirectoryInfo(@"D:\");
            var f = dir.GetFiles("*.json");
            SqlCommand comm = new SqlCommand();
            //comm.Connection = new SqlConnection(@"Data Source=HYD-RSEETHA\SQLEXPRESS;" + "Initial Catalog=Sample; Trusted_Connection=Yes"); //Windows Authentication
            comm.Connection = new SqlConnection(@"Data Source=HYD-RSEETHA\SQLEXPRESS;" + "Initial Catalog=Sample; user id=sa;pwd=alliance123$");
             string sql = @"SELECT TOP 1 * FROM ( SELECT TOP 2 * FROM sampletable ORDER BY salary DESC) AS emp ORDER BY salary ASC";

            //string sql1 = @"update sampletable set name = 'test' where Salary = 10000";
            // comm.CommandText = sql;
            comm.CommandText = sql;
            comm.Connection.Open();
            SqlDataReader cursor = comm.ExecuteReader();
            while (cursor.Read())
            {
                string user = cursor.GetValue(1).ToString();
                string name = cursor["name"].ToString();
                string salary = cursor["Salary"].ToString();
                Console.WriteLine(name + " " + salary);
            }
            Console.ReadKey();
            string tmp = null;
            var x = tmp;
            var tm2p = (string)null;
            var v = new object();
            comm.Connection.Close();
        }
         
    }
}
