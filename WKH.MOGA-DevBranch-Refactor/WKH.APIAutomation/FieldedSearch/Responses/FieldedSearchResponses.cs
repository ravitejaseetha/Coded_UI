using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WKH.APIAutomation.FieldedSearch.Responses
{
#region Valid Responses
   public class ValidFieldedSearchResponseWithJournalName
    {
        public int TotalFound { get; set; }
        public int QueryTime { get; set; }
        public string NextCursorMark { get; set; }
        public DebugClass Debug { get; set; }
        public List<ResultsClass> Results { get; set; }
    }

   public class DebugClass
    {
        public string InternalSearchUrl { get; set; }
    }

   public class ResultsClass
    {
        public string Id { get; set; }
        public decimal Score { get; set; }
        public List<FieldsClass> Fields { get; set; }
    }

   public class FieldsClass
    {
        public string FieldName { get; set; }
        public object FieldValue { get; set; }
        public string FieldType { get; set; }
    }
#endregion

}
