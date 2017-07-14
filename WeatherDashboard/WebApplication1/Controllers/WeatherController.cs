using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Weather;

namespace WebApplication1.Controllers
{
    public class WeatherController : Controller
    {
        const string CITY_LIST_RELATIVE_PATH = "../App_Data/cityList.json";
        WeatherHelper oWeatherHelper = WeatherHelperFactory.GetWeatherHelper(WeatherApiName.OpenWeather);
        // GET: Weather
        public ActionResult Index()
        {            
            return View();
        }

        [HttpGet]
        public ActionResult GetAllCountries()
        {
            List<string> Countries = new List<string>();
            Countries = oWeatherHelper.GetCities(Server.MapPath(CITY_LIST_RELATIVE_PATH))
                                    .Where(c=>!string.IsNullOrEmpty(c.country))
                                    .Select(c => c.country)
                                    .Distinct()
                                    .OrderBy(c => c).ToList<string>();
            return Json(Countries, JsonRequestBehavior.AllowGet);
        }        

        [HttpGet]
        public ActionResult GetCities(string Country)
        {
            List<City> SpecificCities = oWeatherHelper.GetCities(Server.MapPath(CITY_LIST_RELATIVE_PATH))
                                                    .Where(c => c.country == Country)
                                                    .Distinct()
                                                    .OrderBy(c => c.name).ToList<City>();            
            return Json(SpecificCities, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetWeather(int CityID)
        {            
            return Json(oWeatherHelper.GetWeatherInformation(Server.MapPath(CITY_LIST_RELATIVE_PATH), CityID), JsonRequestBehavior.AllowGet);
        }
    }
}