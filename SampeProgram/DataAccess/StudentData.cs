using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StudentData : BaseDataHandler
    {
        public static List<Student> GetStudenData()
        {
            Data.QueryString = SQL.Resource.SampleQuery;
            return Data.GetData<Student>();
        }

    }
}
