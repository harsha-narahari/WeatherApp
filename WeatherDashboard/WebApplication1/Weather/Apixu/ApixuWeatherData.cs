//namespace WebApplication1.Weather.Apixu
//{
//    //{"location":{"name":"Sydney","region":"New South Wales","country":"Australia","lat":-33.88,"lon":151.22,"tz_id":"Australia/Sydney","localtime_epoch":1499665277,"localtime":"2017-07-10 15:41"},"current":{"last_updated_epoch":1499664606,"last_updated":"2017-07-10 15:30","temp_c":17.0,"temp_f":62.6,"is_day":1,"condition":{"text":"Sunny","icon":"//cdn.apixu.com/weather/64x64/day/113.png","code":1000},"wind_mph":11.9,"wind_kph":19.1,"wind_degree":300,"wind_dir":"WNW","pressure_mb":1024.0,"pressure_in":30.7,"precip_mm":0.0,"precip_in":0.0,"humidity":39,"cloud":0,"feelslike_c":17.0,"feelslike_f":62.6,"vis_km":10.0,"vis_miles":6.0}}

//    public class ApixuWeatherData
//    {        
//        public location location { get; set; }
//        public current current { get; set; }
//    }

//    public class current
//    {
//        public string last_updated_epoch { get; set; }
//        public string last_updated { get; set; }
//        public string temp_c { get; set; }
//        public string temp_f { get; set; }
//        public string is_day { get; set; }
//        public condition condition { get; set; }
//        public string wind_mph { get; set; }
//        public string wind_kph { get; set; }
//        public string wind_degree { get; set; }
//        public string wind_dir { get; set; }
//        public string pressure_mb { get; set; }
//        public string pressure_in { get; set; }
//        public string precip_mm { get; set; }
//        public string precip_in { get; set; }
//        public string humidity { get; set; }
//        public string cloud { get; set; }
//        public string feelslike_c { get; set; }
//        public string feelslike_f { get; set; }
//        public string vis_km { get; set; }
//        public string vis_miles { get; set; }
//    }

//    public class condition
//    {
//        public string text { get; set; }
//        public string icon { get; set; }
//        public string code { get; set; }
//    }

//    public class location
//    {
//        public string name { get; set; }
//        public string region { get; set; }
//        public string country { get; set; }
//        public string lat { get; set; }
//        public string lon { get; set; }
//        public string tz_id { get; set; }
//        public string localtime_epoch { get; set; }
//        public string localtime { get; set; }
//    }
//}