//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace WebApplication1.Weather.OpenWeather
//{
//    //{"coord":{"lon":84.63,"lat":28},"weather":[{"id":500,"main":"Rain","description":"light rain","icon":"10d"}],"base":"stations","main":{"temp":289.078,"pressure":804.05,"humidity":100,"temp_min":289.078,"temp_max":289.078,"sea_level":1016.94,"grnd_level":804.05},"wind":{"speed":0.61,"deg":12.001},"rain":{"3h":2.13},"clouds":{"all":88},"dt":1499669119,"sys":{"message":0.0129,"country":"NP","sunrise":1499643153,"sunset":1499692863},"id":1283378,"name":"Gorkhā","cod":200}
//    public class OpenWeatherData
//    {
//        public coord coord { get; set; }
//        public weather[] weather { get; set; }
//        public string baseInfo {get;set;}
//    }

//    public class coord
//    {
//        public double lon { get; set; }
//        public double lat { get; set; }
//    }

//    public class weather
//    {
//        public int id  { get; set; }
//        public string main { get; set; }
//        public string description { get; set; }
//        public string icon { get; set; }
//    }

//    public class coord
//    {
//        {
        
//        "base":"stations",
//        "main":
//            {
//                "temp":289.078,"pressure":804.05,"humidity":100,"temp_min":289.078,"temp_max":289.078,"sea_level":1016.94,"grnd_level":804.05
//            },
//        "wind":
//            {
//                "speed":0.61,"deg":12.001
//            },
//        "rain":
//            {
//                "3h":2.13
//            },
//        "clouds":
//            {
//                "all":88
//            },
//        "dt":1499669119,
//        "sys":
//            {
//                "message":0.0129,
//                "country":"NP",
//                "sunrise":1499643153,
//                "sunset":1499692863
//            },
//        "id":1283378,
//        "name":"Gorkhā","cod":200
//        }
//    }
//}