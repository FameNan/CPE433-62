using System;
using System.Net.Http;
using System.Text;

namespace DNWS
{
    //inherit from IPlugin interface
    public class PM25Plugin : IPlugin
    {
        public void PreProcessing(HTTPRequest request)
        {
            throw new NotImplementedException();
        }

        public HTTPResponse PostProcessing(HTTPResponse response)
        {
            throw new NotImplementedException();
        }

        //create HTTP clent for fetch PM2.5 data from AQICN API
        public HTTPResponse GetResponse(HTTPRequest request)
        {
            // Fetch PM2.5 data from AQICN API
            HttpClient client = new HttpClient();
            string token = "demo";
            string city = "shanghai";
            //create url for API request
            string url = $"https://api.waqi.info/feed/{city}/?token={token}";
            // Send GET request (API) and get response as string
            string result = client.GetStringAsync(url).Result;
            
            // Return JSON response to client
            HTTPResponse response = new HTTPResponse(200);
            response.body = Encoding.UTF8.GetBytes(result);
            response.type = "application/json"; 
            return response;
        }
    }
}