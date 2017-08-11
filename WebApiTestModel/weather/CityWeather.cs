using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using WebApiTestUtils;

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
        /// 指数
        /// </summary>
        public class Index
        {

            //private string _src;
            /// <summary>
            /// 简介
            /// </summary>
            public string brf { get; set; }
            /// <summary>
            /// 详情
            /// </summary>
            public string txt { get; set; }
            /// <summary>
            /// 指数名称
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 图片地址
            /// </summary>
            public string src { get; set; }
        }
        
        /// <summary>
        /// 生活指数
        /// </summary>
        public class Suggestion
        {
            private Index _air;
            private Index _comf;
            private Index _cw;
            private Index _drsg;
            private Index _flu;
            private Index _sport;
            private Index _trav;
            private Index _uv;
            /// <summary>
            /// 空气指数
            /// </summary>
            public Index air
            {
                get { return _air; }
                set
                {
                    _air = value;
                    _air.name = "空气";
                }
            }

            /// <summary>
            /// 紫外线指数
            /// </summary>
            public Index uv
            {
                get { return _uv; }
                set
                {
                    _uv = value;
                    _uv.name = "紫外线";
                }
            }

            /// <summary>
            /// 感冒指数
            /// </summary>
            public Index flu
            {
                get { return _flu; }
                set
                {
                    _flu = value;
                    _flu.name = "感冒";
                }
            }

            /// <summary>
            /// 舒适度指数
            /// </summary>
            public Index comf
            {
                get { return _comf; }
                set
                {
                    _comf = value;
                    _comf.name = "舒适度";
                }
            }

            /// <summary>
            /// 穿衣指数
            /// </summary>
            public Index drsg
            {
                get { return _drsg; }
                set
                {
                    _drsg = value;
                    _drsg.name = "穿衣";
                }
            }

            /// <summary>
            /// 运动指数
            /// </summary>
            public Index sport
            {
                get { return _sport; }
                set
                {
                    _sport = value;
                    _sport.name = "运动";
                }
            }

            /// <summary>
            /// 旅行指数
            /// </summary>
            public Index trav
            {
                get { return _trav; }
                set
                {
                    _trav = value;
                    _trav.name = "旅行";
                }
            }

            /// <summary>
            /// 洗车指数
            /// </summary>
            public Index cw
            {
                get { return _cw; }
                set
                {
                    _cw = value;
                    _cw.name = "洗车";
                }
            }

            
        }

        public class HeWeather
        {

            private Suggestion _suggestion;
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
            public Suggestion suggestion
            {
                get { return _suggestion; }
                set
                {
                    _suggestion = value;
                }
            }

            /// <summary>
            /// 指数列表,便于微信端显示
            /// </summary>
            public List<Index> suggestions { get; set; } 
        }
    }
    
}
