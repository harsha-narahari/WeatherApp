using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.App_Start;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class WeatherController : Controller
    {
        const string CITY_LIST_RELATIVE_PATH = "../App_Data/cityList.json";
        
        // GET: Weather
        public ActionResult Index()
        {            
            return View();
        }

        [HttpGet]
        public ActionResult GetAllCountries()
        {
            List<string> Countries = new List<string>();
            WeatherHelper helper = new App_Start.WeatherHelper();
            Countries = helper.GetCities(Server.MapPath(CITY_LIST_RELATIVE_PATH))
                                    .Where(c=>!string.IsNullOrEmpty(c.country))
                                    .Select(c => c.country)
                                    .Distinct()
                                    .OrderBy(c => c).ToList<string>();
            return Json(Countries, JsonRequestBehavior.AllowGet);
        }        

        [HttpGet]
        public ActionResult GetCities(string Country)
        {
            WeatherHelper helper = new App_Start.WeatherHelper();
            List<City> SpecificCities = helper.GetCities(Server.MapPath(CITY_LIST_RELATIVE_PATH))
                                                    .Where(c => c.country == Country)
                                                    .Distinct()
                                                    .OrderBy(c => c.name).ToList<City>();            
            return Json(SpecificCities, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetWeather(int CityID)
        {            
            WeatherHelper helper = new App_Start.WeatherHelper();
            string WeatherInformation = helper.GetWeatherInformation(CityID);
            return Json(WeatherInformation, JsonRequestBehavior.AllowGet);
        }
    }
}