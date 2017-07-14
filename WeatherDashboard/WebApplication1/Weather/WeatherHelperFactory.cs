using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Weather
{
    public class WeatherHelperFactory
    {
        public static WeatherHelper GetWeatherHelper(WeatherApiName Api)
        {
            WeatherHelper helper = null;
            
            if (Api== WeatherApiName.OpenWeather)
            {
                helper = new OpenWeatherHelper();
            }
            else if (Api == WeatherApiName.Apixu)
            {
                helper = new ApixuWeatherHelper();
            }

            return helper;
        }
    }
}