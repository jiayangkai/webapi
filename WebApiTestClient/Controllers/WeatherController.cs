using System.Web.Http;
using WebApiTestBll.weather;
using WebApiTestModel.weather;

namespace WebApiTestClient.Controllers
{
    /// <summary>
    /// 天气
    /// </summary>
    public class WeatherController : ApiController
    {
        private readonly WeatherBll _bll = new WeatherBll();

        /// <summary>
        /// 根据城市id返回天气信息
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public CityWeather GetWeatherByCity(string cityName)
        {
            return _bll.GetCityWeather(cityName);
        }
    }
}
