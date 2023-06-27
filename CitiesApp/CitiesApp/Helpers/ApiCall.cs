using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CitiesApp.Helpers
{
    public class ApiCall
    {
        //Countries API Call
        public static async Task<T> GetAsync<T>(string url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            T responseGet = JsonSerializer.Deserialize<T>(result);
            return responseGet;
        }
    }
}
