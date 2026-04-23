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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp1
{
    using System;
    using System.Data;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Numerics;
    using System.Security.Policy;
    using System.Text.Json;
    using System.Threading.Tasks;

    namespace WindowsFormsApp1
    {
        internal class ReactorRepository
        {
            //public static async Task<HttpResponseMessage> JsonAsync(HttpClient httpClient)
            //{




            //    DataTable table = new DataTable();
            //    table.Columns.Add("Параметр", typeof(string));
            //    table.Columns.Add("Значение", typeof(string));

            //    table.Rows.Add("Температура", popa.temperature.ToString("F1"));
            //    table.Rows.Add("Уровень воды", popa.water_level.ToString("F1"));
            //    table.Rows.Add("Радиация", popa.radiation.ToString());


            //}

            public static async Task GetReactorAsync(HttpClient httpClient, Reactor popa)
            {
                string url = "https://mephi.opentoshi.net/api/v1/reactor/data?team_id=e27df733";
            }
        }
    }
}