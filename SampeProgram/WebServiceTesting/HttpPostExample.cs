using CodeScales.Http;
using CodeScales.Http.Common;
using CodeScales.Http.Entity;
using CodeScales.Http.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTesting
{
    class HttpPostExample
    {
        public static void DoPost()
        {
            HttpClient client = new HttpClient();
            HttpPost postMethod = new HttpPost(new Uri("http://www.w3schools.com/asp/demo_simpleform.asp"));

            List<NameValuePair> nameValuePairList = new List<NameValuePair>();
            nameValuePairList.Add(new NameValuePair("fname", "brian"));

            UrlEncodedFormEntity formEntity = new UrlEncodedFormEntity(nameValuePairList, Encoding.UTF8);
            postMethod.Entity = formEntity;

            HttpResponse response = client.Execute(postMethod);

            Console.WriteLine("Response Code: " + response.ResponseCode);
            Console.WriteLine("Response Content: " + EntityUtils.ToString(response.Entity));
        }
    }
}
