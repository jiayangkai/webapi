using System;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Newtonsoft.Json;

namespace WebApiTestClient.Controllers
{
    
    /// <summary>
    /// 测试API Test Client
    /// </summary>
    public class TestChargingDataController : ApiController
    {
        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns>返回数据</returns>
        [HttpGet]
        public string GetAllChargingData()
        {

            return "all";
        }
        [HttpGet]
        public string CheckToken()
        {
            string token = "kaiqingjie0219";
            string echoString = HttpContext.Current.Request.QueryString["echoStr"];
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            if (!string.IsNullOrEmpty(echoString))
            {
                //HttpContext.Current.Response.Write(echoString);
                //HttpContext.Current.Response.End();
            }
            return echoString;
        }

        private bool CheckSignature(HttpRequest Request,string Token)
        {
            string signature = Request.QueryString["signature"].ToString();
            string timestamp = Request.QueryString["timestamp"].ToString();
            string nonce = Request.QueryString["nonce"].ToString();
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }  

        /// <summary>
        /// 得到当前Id的所有数据
        /// </summary>
        /// <param name="id">参数Id</param>
        /// <returns>返回数据</returns>
        [HttpGet]
        public string GetAllChargingData(string id)
        {
            var bll = new WebApiTestBll.TestConnection();
            var sql =
                string.Format(
                    "SELECT u.`ID`,u.`username`,u.`password` FROM bdm284884200_db.`User` AS u WHERE u.`ID`={0}", id);
            var user = bll.GetUser(sql);
            var jsonstr = JsonConvert.SerializeObject(user);
            return jsonstr;
        }

        /// <summary>
        /// Post提交
        /// </summary>
        /// <param name="oData">对象</param>
        /// <returns>提交是否成功</returns>
        [HttpPost]
        public bool Post(TB_CHARGING oData)
        {
            return true;
        }

        /// <summary>
        /// Put请求
        /// </summary>
        /// <param name="oData">对象</param>
        /// <returns>提交是否成功</returns>
        [HttpPut]
        public bool Put(TB_CHARGING oData)
        {
            return true;
        }

        /// <summary>
        /// delete操作
        /// </summary>
        /// <param name="id">对象id</param>
        /// <returns>操作是否成功</returns>
        [HttpDelete]
        public bool Delete(string id)
        {
            return true;
        }
    }

    /// <summary>
    /// 充电对象实体
    /// </summary>
    public class TB_CHARGING
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 充电设备名称
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 充电设备描述
        /// </summary>
        public string DES { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATETIME { get; set; }
    }
}
