using apiB.Contants;
using apiB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace apiB.Service
{
    public class WeatherService
    {
        HttpClient _client;
        public WeatherService()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherPOJO> GetWeather(string inCity)
        {
            WeatherPOJO weatherData = null;
            try
            {
                var response = await _client.GetAsync(GetUriCity(inCity));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherPOJO>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return weatherData;
        }

        private string GetUriCity(string inCity)
        {
            string requestUri = ConnectionApiOpenWeather.OpenWeatherMapEndpoint;
            requestUri += $"?q={inCity}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={ConnectionApiOpenWeather.OpenWeatherMapAPIKey}";

            return requestUri;
        }
    }
}
