using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
//using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace WindowsFormsApp1
{
    using System;
    using System.Data;
    using System.Net.Http;
    using System.Numerics;
    using System.Security.Policy;
    using System.Text.Json;
    using System.Threading.Tasks;

    namespace WindowsFormsApp1
    {
        internal class ReactorRepository
        {
            public static async Task<HttpResponseMessage> JsonAsync(HttpClient httpClient)
            {
                string url = "https://mephi.opentoshi.net/api/v1/reactor/data?team_id=e27df733";
                return await httpClient.GetAsync(url);
            }

            public static async Task GetReactorAsync(HttpClient httpClient, Reactor popa)
            {
                string url = "https://mephi.opentoshi.net/api/v1/reactor/data?team_id=e27df733";
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var reactorResponse = JsonSerializer.Deserialize<ReactorResponse>(url, options);
                popa = reactorResponse?.data;

                DataTable table = new DataTable();
                table.Columns.Add("Параметр", typeof(string));
                table.Columns.Add("Значение", typeof(string));

                table.Rows.Add("Температура", popa.temperature.ToString("F1"));
                table.Rows.Add("Уровень воды", popa.water_level.ToString("F1"));
                table.Rows.Add("Радиация", popa.radiation.ToString());
            }
        }
    }
}