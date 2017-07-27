using System.Collections.Generic;

namespace WebApiTestModel.weather
{
    //城市编码
    public class CityCode
    {
        //城市区
        public string area { get; set; }
        //城市id
        public string code { get; set; }
    }

    public class Province
    {
        //省份
        public string province { get; set; }
        
        public List<CityCode> city { get; set; }
    }

    public class CnList
    {
        public List<Province> list { get; set; } 
    }
}
