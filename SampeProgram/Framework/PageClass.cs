using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class PageClass : PageClassBase
    {
        private List<object> utilityList;
        public PageClass(List<object> utilsList)
            : base(utilsList)
        {
            //utilityList = utilsList;
        }
        //  WebControlUtility wb = new WebControlUtility();
        public WebButton Button
        {
            get
            {
                return GetHtmlControl<WebButton>();
            }


        }
    }
}
