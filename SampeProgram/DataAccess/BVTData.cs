using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class BVTData : BaseTestData
    {
       public BVTData(string fileName)
           : base(fileName)
       {
           
       }

       public List<BVTEntity> GetInvalidRIFData()
       {
           DataAccess.QueryString = SQL.Resource.GetInvalidRIFData;
           return DataAccess.GetData<BVTEntity>();
       }



       public static void UpdateStudentData(string tokens, string studentid)
       {
           DataAccess.QueryString = SQL.Resource.UpdateStudentInfo;
           DataAccess.ExecuteCommand<OleDbCommand>(command =>
           {
               command.Parameters.AddWithValue("FirstName", tokens);
               command.Parameters.AddWithValue("LastName", studentid);

               //command.Parameters.AddWithValue("Tokens", tokens);
               //command.Parameters.AddWithValue("SSN", studentid);

           });
       }
    }
}
