using System.Collections.Generic;
using System.Linq;
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
           
            if (cityWeather == null || cityWeather.HeWeather5.Count <= 0) return cityWeather;
            var suggestion = cityWeather.HeWeather5[0].suggestion;
            if (suggestion == null) return cityWeather;
            //格式化指数信息为list，便于微信端显示
            var stype = suggestion.GetType();
            cityWeather.HeWeather5[0].suggestions = new List<CityWeather.Index>();
            foreach (var item in stype.GetProperties())
            {
                var obj = (CityWeather.Index) SystemUtils.GetObjectPropertyValue(suggestion, item.Name);
                SystemUtils.SetTPropertyValueByName(obj, "src", item.Name);
            }
            cityWeather.HeWeather5[0].suggestions.AddRange(
                stype.GetProperties()
                    .Select(item => SystemUtils.SetTPropertyValueByName((CityWeather.Index)SystemUtils.GetObjectPropertyValue(suggestion, item.Name),"src",item.Name)));

            return cityWeather;
        }
        
    }
}
