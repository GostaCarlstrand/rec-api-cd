using System;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.Http;
using System.Text;

namespace RecruiteeASPNETCoreWebAPI.PyPrinter
{
    public static class PyPrinter
    {
        public async static void PrintToPy(string printData)
        {
            var dict = new Dictionary<string, string>()
            {
                {"data", printData}  
            };
            var jsonData = JsonSerializer.Serialize(dict);


            var URL = "http://127.0.0.1:9090/printing";
            var client = new HttpClient();
            var data = new StringContent(jsonData , System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(URL, data);

        }
    }
}

