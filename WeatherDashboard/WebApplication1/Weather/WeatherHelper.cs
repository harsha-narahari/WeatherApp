using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Weather
{
    public abstract class WeatherHelper
    {
        
        public abstract string GetWeatherInformation(string path, int CityID);

        public List<City> GetCities(string path)
        {
            List<City> Cities = new List<City>();
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string s = sr.ReadToEnd();
                    Cities = JsonConvert.DeserializeObject<List<City>>(s);
                }
            }

            return Cities;
        }
}
}