using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Weather
{
    public class ApixuWeatherHelper : WeatherHelper
    {
        private const string WEATHER_API_PATH = "http://api.apixu.com/v1/current.json?key=474ca64aea4d4bc2a8054045171007&q={0}";
        
        public override string GetWeatherInformation(string path, int CityID)
        {
            string cityName = this.GetCities(path).Where(c => c.id == CityID).Select(c => c.name).FirstOrDefault();
            string WeatherInfo = null;
            string weatherAPIPath = string.Format(WEATHER_API_PATH, cityName);
            WeatherData oWeatherData = null;
            using (WebClient client = new WebClient())
            {
                client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)  (compatible; MSIE 6.0; Windows NT 5.1;  .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                try
                {
                    WeatherInfo = System.Text.Encoding.Default.GetString(client.DownloadData(weatherAPIPath));
                }
                catch (Exception ex)
                {
                    int i = 0;
                    throw;
                }
                dynamic odata = JsonConvert.DeserializeObject(WeatherInfo);
                oWeatherData = new WeatherData()
                {
                    Temperature = odata.current.temp_c,
                    Pressure = odata.current.pressure_in,
                    Humidity = odata.current.humidity,
                    Wind = odata.current.wind_kph,
                    UpdatedOn = DateTime.Now.ToString("dd/mmm/yyyy HH:mm:ss")                    
                };

            }
            return WeatherInfo;
        }
    }
}