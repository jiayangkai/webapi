using System;
using System.Collections.Generic;

namespace WebApiTestModel.weather
{
    /// <summary>
    /// 城市天气
    /// </summary>
    public class CityWeather
    {

        public List<HeWeather> HeWeather5 { get; set; }
        //城市
        public class City
        {
            /// <summary>
            /// 空气质量指数
            /// </summary>
            public string aqi { get; set; }
            /// <summary>
            /// 一氧化碳
            /// </summary>
            public string co { get; set; }
            /// <summary>
            /// 二氧化氮
            /// </summary>
            public string no2 { get; set; }
            /// <summary>
            /// 臭氧
            /// </summary>
            public string o3 { get; set; }
            /// <summary>
            /// 66
            /// </summary>
            public string pm10 { get; set; }
            /// <summary>
            /// 45
            /// </summary>
            public string pm25 { get; set; }
            /// <summary>
            /// 空气质量
            /// </summary>
            public string qlty { get; set; }
            /// <summary>
            /// 二氧化硫
            /// </summary>
            public string so2 { get; set; }
        }
        /// <summary>
        /// 空气质量指数
        /// </summary>
        public class Aqi
        {
            /// <summary>
            /// City
            /// </summary>
            public City city { get; set; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public class Update
        {
            /// <summary>
            /// 本地时间-2017-07-26 09:48
            /// </summary>
            public DateTime loc { get; set; }
            /// <summary>
            /// utc时间-2017-07-26 01:48
            /// </summary>
            public DateTime utc { get; set; }
        }
        /// <summary>
        /// 城市基本信息
        /// </summary>
        public class Basic
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string city { get; set; }
            /// <summary>
            /// 国家
            /// </summary>
            public string cnty { get; set; }
            /// <summary>
            /// 城市id
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 纬度
            /// </summary>
            public string lat { get; set; }
            /// <summary>
            /// 经度
            /// </summary>
            public string lon { get; set; }
            /// <summary>
            /// 更新时间
            /// </summary>
            public Update update { get; set; }
        }
        /// <summary>
        /// 天文指数
        /// </summary>
        public class Astro
        {
            /// <summary>
            /// 月升时间
            /// </summary>
            public string mr { get; set; }
            /// <summary>
            /// 月落时间
            /// </summary>
            public string ms { get; set; }
            /// <summary>
            /// 日出时间
            /// </summary>
            public string sr { get; set; }
            /// <summary>
            /// 日落时间
            /// </summary>
            public string ss { get; set; }
        }

        
        /// <summary>
        /// 温度
        /// </summary>
        public class Tmp
        {
            /// <summary>
            /// 最高温
            /// </summary>
            public string max { get; set; }
            /// <summary>
            /// 最低温
            /// </summary>
            public string min { get; set; }
        }

        /// <summary>
        /// 预报信息
        /// </summary>
        public class forecast
        {
            /// <summary>
            /// 相对湿度
            /// </summary>
            public string hum { get; set; }
            /// <summary>
            /// 降水量
            /// </summary>
            public string pcpn { get; set; }
            /// <summary>
            /// 降水概率
            /// </summary>
            public string pop { get; set; }
            /// <summary>
            /// 气压
            /// </summary>
            public string pres { get; set; }
            
            /// <summary>
            /// 紫外线指数
            /// </summary>
            public string uv { get; set; }
            /// <summary>
            /// 能见度
            /// </summary>
            public string vis { get; set; }
            /// <summary>
            /// 风力
            /// </summary>
            public Wind wind { get; set; }

            /// <summary>
            /// 日期
            /// </summary>
            public DateTime date { get; set; }

            /// <summary>
            /// 体感温度
            /// </summary>
            public string fl { get; set; }
        }

        /// <summary>
        /// 天气日报
        /// </summary>
        public class Dailyforecast : forecast
        {
            /// <summary>
            /// Astro
            /// </summary>
            public Astro astro { get; set; }
            /// <summary>
            /// Cond
            /// </summary>
            public CondInfo cond { get; set; }

            /// <summary>
            /// 温度
            /// </summary>
            public Tmp tmp { get; set; }
            
        }

        /// <summary>
        /// 天气状况
        /// </summary>
        public class CondInfo
        {
            /// <summary>
            /// 白天
            /// </summary>
            public string code_d { get; set; }
            /// <summary>
            /// 夜间
            /// </summary>
            public string code_n { get; set; }
            /// <summary>
            /// 白天描述
            /// </summary>
            public string txt_d { get; set; }
            /// <summary>
            /// 夜间描述
            /// </summary>
            public string txt_n { get; set; }
            /// <summary>
            /// 图片地址，为空则由客户端生成
            /// </summary>
            public string src { get; set; }
        }

        /// <summary>
        /// 小时天气
        /// </summary>
        public class Hourlyforecast : forecast
        {
            /// <summary>
            /// Cond
            /// </summary>
            public Cond cond { get; set; }
            /// <summary>
            /// 温度
            /// </summary>
            public string tmp { get; set; }
            
        }
        /// <summary>
        /// 天气状况
        /// </summary>
        public class Cond
        {
            /// <summary>
            /// 天气状况代码
            /// </summary>
            public string code { get; set; }
            /// <summary>
            /// 数据详情
            /// </summary>
            public string txt { get; set; }
            
        }
        /// <summary>
        /// 风力
        /// </summary>
        public class Wind
        {
            /// <summary>
            /// 风向（360度）
            /// </summary>
            public string deg { get; set; }
            /// <summary>
            /// 风向
            /// </summary>
            public string dir { get; set; }
            /// <summary>
            /// 风力等级
            /// </summary>
            public string sc { get; set; }
            /// <summary>
            /// 风速
            /// </summary>
            public string spd { get; set; }
        }

        public class Now : forecast
        {
            /// <summary>
            /// Cond
            /// </summary>
            public Cond cond { get; set; }
            
        }
        /// <summary>
        /// 空气指数
        /// </summary>
        public class Air
        {
            /// <summary>
            /// 简介
            /// </summary>
            public string brf { get; set; }
            /// <summary>
            /// 详情--气象条件对空气污染物稀释、扩散和清除无明显影响，易感人群应适当减少室外活动时间。
            /// </summary>
            public string txt { get; set; }
        }
        /// <summary>
        /// 舒适度指数
        /// </summary>
        public class Comf
        {
            /// <summary>
            /// 简介--很不舒适
            /// </summary>
            public string brf { get; set; }
            /// <summary>
            /// 详情--白天天气晴好，但烈日炎炎您会感到很热，很不舒适。
            /// </summary>
            public string txt { get; set; }
        }
        /// <summary>
        /// 洗车指数
        /// </summary>
        public class Cw
        {
            /// <summary>
            /// 较适宜
            /// </summary>
            public string brf { get; set; }
            /// <summary>
            /// 较适宜洗车，未来一天无雨，风力较小，擦洗一新的汽车至少能保持一天。
            /// </summary>
            public string txt { get; set; }
        }
        /// <summary>
        /// 穿衣指数
        /// </summary>
        public class Drsg
        {
            /// <summary>
            /// 炎热
            /// </summary>
            public string brf { get; set; }
            /// <summary>
            /// 天气炎热，建议着短衫、短裙、短裤、薄型T恤衫等清凉夏季服装。
            /// </summary>
            public string txt { get; set; }
        }
        /// <summary>
        /// 感冒指数
        /// </summary>
        public class Flu
        {
            /// <summary>
            /// 少发
            /// </summary>
            public string brf { get; set; }
            /// <summary>
            /// 各项气象条件适宜，发生感冒机率较低。但请避免长期处于空调房间中，以防感冒。
            /// </summary>
            public string txt { get; set; }
        }
        /// <summary>
        /// 运动指数
        /// </summary>
        public class Sport
        {
            /// <summary>
            /// 较不宜
            /// </summary>
            public string brf { get; set; }
            /// <summary>
            /// 天气较好，无雨水困扰，但考虑气温很高，请注意适当减少运动时间并降低运动强度，运动后及时补充水分。
            /// </summary>
            public string txt { get; set; }
        }
        /// <summary>
        /// 旅行指数
        /// </summary>
        public class Trav
        {
            /// <summary>
            /// 较不宜
            /// </summary>
            public string brf { get; set; }
            /// <summary>
            /// 天气较好，微风，但温度高，天气很热，请注意防暑降温，并注意防晒，若外出可选择水上娱乐等清凉项目。
            /// </summary>
            public string txt { get; set; }
        }
        /// <summary>
        /// 紫外线指数
        /// </summary>
        public class Uv
        {
            /// <summary>
            /// 中等
            /// </summary>
            public string brf { get; set; }
            /// <summary>
            /// 属中等强度紫外线辐射天气，外出时建议涂擦SPF高于15、PA+的防晒护肤品，戴帽子、太阳镜。
            /// </summary>
            public string txt { get; set; }
        }
        /// <summary>
        /// 生活指数
        /// </summary>
        public class Suggestion
        {
            /// <summary>
            /// Air
            /// </summary>
            public Air air { get; set; }
            /// <summary>
            /// Comf
            /// </summary>
            public Comf comf { get; set; }
            /// <summary>
            /// Cw
            /// </summary>
            public Cw cw { get; set; }
            /// <summary>
            /// Drsg
            /// </summary>
            public Drsg drsg { get; set; }
            /// <summary>
            /// Flu
            /// </summary>
            public Flu flu { get; set; }
            /// <summary>
            /// Sport
            /// </summary>
            public Sport sport { get; set; }
            /// <summary>
            /// Trav
            /// </summary>
            public Trav trav { get; set; }
            /// <summary>
            /// Uv
            /// </summary>
            public Uv uv { get; set; }
        }

        public class HeWeather
        {
            /// <summary>
            /// Aqi
            /// </summary>
            public Aqi aqi { get; set; }
            /// <summary>
            /// Basic
            /// </summary>
            public Basic basic { get; set; }
            /// <summary>
            /// Daily_forecast
            /// </summary>
            public List<Dailyforecast> daily_forecast { get; set; }
            /// <summary>
            /// Hourly_forecast
            /// </summary>
            public List<Hourlyforecast> hourly_forecast { get; set; }
            /// <summary>
            /// Now
            /// </summary>
            public Now now { get; set; }
            /// <summary>
            /// ok
            /// </summary>
            public string status { get; set; }
            /// <summary>
            /// Suggestion
            /// </summary>
            public Suggestion suggestion { get; set; }
        }
    }
    
}
