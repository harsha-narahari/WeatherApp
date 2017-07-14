using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class WeatherData
    {
        public string Temperature { get; set; }
        public string MinTemperature { get; set; }
        public string MaxTemperature { get; set; }
        public string Wind { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string UpdatedOn { get; set; }
    }
}