using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace test_yelp_api
{
    class Program
    {
        static void Main(string[] args)
        {
            string urltest = string.Format("https://api.yelp.com/v3/businesses/search/phone?phone=+18067854025");
            WebRequest requestObject = WebRequest.Create(urltest);
            requestObject.PreAuthenticate = true;
            
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("Gx - v1l6hahIJLVv_eq - 3oqzH0m3Ub35LOCXI9q7rCAn8dq - B1 - ziT5GAGzatpjVWsVO7hmudTkv3fgYejI_gmmJKYuoQLWFSLYYz5rh - qjS - fggH_ - l9Uc0dK_NyXXYx"));
            requestObject.Headers.Add("Authorization","Bearer " + "Gx-v1l6hahIJLVv_eq-3oqzH0m3Ub35LOCXI9q7rCAn8dq-B1-ziT5GAGzatpjVWsVO7hmudTkv3fgYejI_gmmJKYuoQLWFSLYYz5rh-qjS-fggH_-l9Uc0dK_NyXXYx");
           
            requestObject.Method = "GET";
            HttpWebResponse responseObject = null;
            responseObject = (HttpWebResponse)requestObject.GetResponse();
            string resultTest = null;
            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader re = new StreamReader(stream);
                resultTest = re.ReadToEnd();
                re.Close();
            }
        }
    }
}
