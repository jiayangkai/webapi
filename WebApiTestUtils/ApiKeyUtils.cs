namespace WebApiTestUtils
{
    public static class ApiKeyUtils
    {
        #region news
        public static readonly string NewsKey = "1a83984c905cb78b16bdebe15f196bba"; 
        #endregion

        #region express
        //电商ID
        public static string EBusinessID = "1294811";

        //电商加密私钥，快递鸟提供，注意保管，不要泄漏
        public static string AppKey = "7cd2c8aa-1833-429c-9f86-96859f89757f";
        //测试环境
        //private string ReqURL = "http://testapi.kdniao.cc:8081/Ebusiness/EbusinessOrderHandle.aspx";
        //请求url
        public static string ReqURL = "http://api.kdniao.cc/Ebusiness/EbusinessOrderHandle.aspx"; 
        #endregion


        #region weather

        /// <summary>
        /// 和风天气key
        /// </summary>
        private static readonly string hekey = "417df3eed210404c93ca3d3b23bb1d02";
        
        /// <summary>
        /// 返回对应城市天气api
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns>--http://www.apifree.net/weather/101191201(城市天气id).xml--</returns>
        public static string GetWeatherApi(string cityID)
        {
            return string.Format("http://www.apifree.net/weather/" + cityID + ".xml");
        }
        /// <summary>
        /// 和风天气
        /// </summary>
        /// <param name="CityName"></param>
        /// <returns></returns>
        public static string GetHeWeatherApi(string CityName)
        {
            var api = string.Format("https://free-api.heweather.com/v5/weather?" + "city={0}&key={1}", CityName, hekey);
            return api;
        }
        #endregion

    }
}
