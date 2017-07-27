using Newtonsoft.Json;

namespace WebApiTestUtils
{
    /// <summary>
    /// json
    /// </summary>
    public class JsonUtils
    {
        public static T JsonToObj<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string ObjToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
