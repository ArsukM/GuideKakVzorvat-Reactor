using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Data;


namespace WindowsFormsApp1
{
    internal class ReactorRepository
    {
        public static async Task GetAsync(HttpClient httpClient)
        {
            string httpApiLink = "https://mephi.opentoshi.net/api/v1/reactor/data?team_id=e27df733";
            using (HttpResponseMessage response = await httpClient.GetAsync(httpApiLink))
            {
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"{jsonResponse}\n");
            };
        }
        //public DataTable JsonToDGV(HttpResponseMessage jsonResponse)
        //{
        //    var abc = new JsonSerializer();
        //    var abc2 = jsonResponse.js
        //}
    }
}
