using WebApiTestModel.weather;
using WebApiTestUtils;

namespace WebApiTestBll.weather
{
    //天气业务
    public class WeatherBll
    {
        /// <summary>
        /// 根据城市天气ID获取天气信息
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public CityWeather GetCityWeather(string cityName)
        {

            var api = ApiKeyUtils.GetHeWeatherApi(cityName);
            var weather = HttpUtils.HttpGet(api);

            var cityWeather = JsonUtils.JsonToObj<CityWeather>(weather);
            return cityWeather;
        }
    }
}
