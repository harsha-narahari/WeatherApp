using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.App_Start
{
    public class WeatherHelper
    {
        const string WEATHER_API_PATH = "http://api.openweathermap.org/data/2.5/weather?id={0}&appid=93c76bf4c1c493ffdbb459b97b24588d";

        public List<City> GetCities(string CountryCityFilePath)
        {
            List<City> Cities = new List<City>();
            using (FileStream fs = new FileStream(CountryCityFilePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string s = sr.ReadToEnd();
                    Cities = JsonConvert.DeserializeObject<List<City>>(s);
                }
            }

            return Cities;
        }

        public string GetWeatherInformation(int CityID)
        {
            string WeatherInfo = null;
            string weatherAPIPath = string.Format(WEATHER_API_PATH, CityID);
            using (WebClient client = new WebClient())
            {
                client.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)  (compatible; MSIE 6.0; Windows NT 5.1;  .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                WeatherInfo = System.Text.Encoding.Default.GetString(client.DownloadData(weatherAPIPath));
            }
            return WeatherInfo;
        }
    }
}