using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WKH.APIAutomation.FieldedSearch.Requests
{
  
        #region Valid Requests
   public class FieldedSearchValidRequest
    {
       public FieldedSearchValidRequest()
       {
           SynonymsRequired = false;
       }
        public  string QueryString { get; set; }
        public  List<string> Products { get; set; }
        public  List<string> FilterQueries { get; set; }
        public  ResultSpecClass ResultSpec { get; set; }
        public bool SynonymsRequired { get; set; } 
    }


   public class ResultSpecClass
    {
        public  int Rows { get; set; }
        public  List<string> ReturnFields { get; set; }
    }
        #endregion
   
}
