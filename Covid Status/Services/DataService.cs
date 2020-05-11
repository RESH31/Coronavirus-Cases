using Covid_Status.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Covid_Status.Services
{
    public class DataService
    {
        public static string path = "https://covid2019-api.herokuapp.com/v2/";

        public static async Task<Global> fetchAllCountryCoronaData()
        {
            using (var client = new HttpClient())
            {
                Global globalData = new Global();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.BaseAddress = new Uri(path);
                var responseTask = client.GetAsync("current");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string responseContent = await result.Content.ReadAsStringAsync();
                    globalData = JsonConvert.DeserializeObject<Global>(responseContent);
                    return globalData;

                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
        }

        public static async Task<Country> fetchCountryCoronaData(string country)
        {
            using (var client = new HttpClient())
            {
                Country countryData = new Country();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.BaseAddress = new Uri(path);
                var responseTask = client.GetAsync("country/"+country);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    string responseContent = await result.Content.ReadAsStringAsync();
                    countryData = JsonConvert.DeserializeObject<Country>(responseContent);
                    return countryData;

                }
                else
                {
                    throw new Exception(result.ReasonPhrase);
                }
            }
        }
    }
}