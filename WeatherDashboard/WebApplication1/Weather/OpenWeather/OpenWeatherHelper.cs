using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.Weather
{
    public class OpenWeatherHelper: WeatherHelper
    {
        const string WEATHER_API_PATH = "http://api.openweathermap.org/data/2.5/weather?id={0}&appid=93c76bf4c1c493ffdbb459b97b24588d";
        
        public override string GetWeatherInformation(string path, int CityID)
        {
            string WeatherInfo = null;
            string weatherAPIPath = string.Format(WEATHER_API_PATH, CityID);
            WeatherData oWeatherData = null;
            using (WebClient client = new WebClient())
            {
                client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)  (compatible; MSIE 6.0; Windows NT 5.1;  .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                WeatherInfo = System.Text.Encoding.Default.GetString(client.DownloadData(weatherAPIPath));
                JsonSerializer ser = new JsonSerializer();                
                //dynamic odata = JsonConvert.DeserializeObject(WeatherInfo);
                //oWeatherData = new WeatherData()
                //{
                //    Temperature = odata.main.temp,
                //    Humidity = odata.main.humidity,
                //    Wind = odata.wind.speed,
                //    UpdatedOn = DateTime.Now.ToString("dd/mmm/yyyy HH:mm:ss"),
                //    MinTemperature = odata.main.temp_min,
                //    MaxTemperature = odata.main.temp_max,
                //    Pressure = odata.main.pressure
                //};
            }
            return WeatherInfo;
        }
    }
}